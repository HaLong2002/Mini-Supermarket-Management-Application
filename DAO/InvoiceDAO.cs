using Microsoft.Data.SqlClient;
using SieuThiMini.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SieuThiMini.DAO
{
    public class InvoiceDAO
    {
        private static string connectionString = ClassKetnoi.ConnectionString;

        public DataTable GetAllInvoices()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT i.InvoiceID, i.EmployeeID, i.CustomerID, i.InvoiceDate, i.TotalAmount, i.PointEarned
                         FROM Invoices i";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dtInvoices = new DataTable();
                adapter.Fill(dtInvoices);
                return dtInvoices;
            }
        }

        public DataTable GetInvoice(int invoiceID)
        {
            DataTable dtInvoice = new DataTable();
            string query = @"
            SELECT 
                InvoiceID,
                EmployeeID,
                CustomerID,
                InvoiceDate,
                TotalAmount,
                PointEarned
            FROM Invoices
            WHERE InvoiceID = @InvoiceID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dtInvoice);
                    }
                }
            }

            return dtInvoice;
        }

        public DataTable SearchInvoices(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT InvoiceID, EmployeeID, CustomerID, InvoiceDate, TotalAmount, PointEarned
                         FROM Invoices
                         WHERE CAST(InvoiceID AS NVARCHAR) LIKE @keyword
                         OR CAST(CustomerID AS NVARCHAR) LIKE @keyword
                         OR CAST(EmployeeID AS NVARCHAR) LIKE @keyword";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dtInvoices = new DataTable();
                adapter.Fill(dtInvoices);
                return dtInvoices;
            }
        }


        public int CreateInvoice(InvoiceDTO invoice)
        {
            int newInvoiceId = 0;
            string query = @"
            INSERT INTO Invoices (EmployeeID, CustomerID, InvoiceDate, TotalAmount, PointEarned)
            OUTPUT INSERTED.InvoiceID
            VALUES (@EmployeeID, @CustomerID, @InvoiceDate, @TotalAmount, @PointEarned)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EmployeeID", invoice.EmployeeID);
                cmd.Parameters.AddWithValue("@CustomerID", invoice.CustomerID);
                cmd.Parameters.AddWithValue("@InvoiceDate", invoice.InvoiceDate);
                cmd.Parameters.AddWithValue("@TotalAmount", invoice.TotalAmount);
                cmd.Parameters.AddWithValue("@PointEarned", invoice.PointEarned);

                conn.Open();
                newInvoiceId = (int)cmd.ExecuteScalar();
            }
            return newInvoiceId;
        }

        public static void UpdateInvoiceTotalAndPoints(int invoiceId, decimal totalAmount, int pointsEarned)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Invoices SET TotalAmount = @TotalAmount, PointEarned = @PointsEarned WHERE InvoiceID = @InvoiceID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@InvoiceID", invoiceId);
                    command.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    command.Parameters.AddWithValue("@PointsEarned", pointsEarned);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        // Cập nhật điểm thưởng khách hàng
        public bool UpdateCustomerRewardPoints(int customerId, int pointsEarned)
        {
            string query = "UPDATE Customers SET RewardPoint = RewardPoint + @pointsEarned WHERE CustomerID = @customerId";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pointsEarned", pointsEarned);
                cmd.Parameters.AddWithValue("@customerId", customerId);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Hàm thống kê doanh thu theo tháng
        public List<RevenueByMonthDTO> GetRevenueByMonth(int year)
        {
            List<RevenueByMonthDTO> revenueList = new List<RevenueByMonthDTO>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT MONTH(InvoiceDate) AS Month,
                   SUM(TotalAmount) AS TotalRevenue
            FROM Invoices
            WHERE YEAR(InvoiceDate) = @Year
            GROUP BY MONTH(InvoiceDate)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Year", year);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    RevenueByMonthDTO revenue = new RevenueByMonthDTO
                    {
                        Month = reader.GetInt32(0),
                        TotalRevenue = reader.GetDecimal(1)
                    };
                    revenueList.Add(revenue);
                }
            }

            return revenueList;
        }

        // Lấy Top 5 khách hàng đã chi nhiều tiền nhất
        public List<TopLoyalCustomers> GetTop5LoyalCustomers()
        {
            List<TopLoyalCustomers> loyalCustomers = new List<TopLoyalCustomers>();

            string query = @"
                SELECT TOP 5 c.CustomerID, c.Name, SUM(i.TotalAmount) AS TotalSpent
                FROM Customers c
                JOIN Invoices i ON c.CustomerID = i.CustomerID
                GROUP BY c.CustomerID, c.Name
                ORDER BY TotalSpent DESC;
            ";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create the SqlCommand to execute the query
                using (var command = new SqlCommand(query, connection))
                {
                    // Execute the query and get a SqlDataReader
                    using (var reader = command.ExecuteReader())
                    {
                        // Read the results row by row
                        while (reader.Read())
                        {
                            var customer = new TopLoyalCustomers
                            {
                                CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                TotalSpent = reader.GetDecimal(reader.GetOrdinal("TotalSpent"))
                            };

                            loyalCustomers.Add(customer);
                        }
                    }
                }
            }

            return loyalCustomers;
        }


        public ProductDTO GetProductDetailsById(int productId)
        {
            ProductDTO product = new ProductDTO();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Mở kết nối
                    conn.Open();

                    // SQL Query lấy thông tin sản phẩm từ bảng Products
                    string query = @"
                    SELECT 
                        ProductName, 
                        Brand, 
                        Price, 
                        ManufactureDate, 
                        ExpirationDate, 
                        Status
                    FROM 
                        Products
                    WHERE 
                        ProductId = @ProductId";

                    // Tạo SqlCommand với tham số
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductId", productId);

                        // Thực thi và lấy dữ liệu
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Gán giá trị vào đối tượng ProductDTO
                                product.ProductName = reader["ProductName"] as string;
                                product.Brand = reader["Brand"] as string;
                                product.Price = reader["Price"] != DBNull.Value ? Convert.ToDecimal(reader["Price"]) : 0.0m;
                                product.ManufactureDate = reader["ManufactureDate"] != DBNull.Value ? (DateTime)reader["ManufactureDate"] : DateTime.MinValue;
                                product.ExpirationDate = reader["ExpirationDate"] != DBNull.Value ? (DateTime)reader["ExpirationDate"] : DateTime.MinValue;
                                product.Status = reader["Status"] as string;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return product;
        }


    }

}
