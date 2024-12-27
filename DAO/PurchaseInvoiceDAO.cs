using Microsoft.Data.SqlClient;
using SieuThiMini.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace SieuThiMini.DAO
{
    public class PurchaseInvoiceDAO
    {
        static string connectionString = ClassKetnoi.ConnectionString;
        private static SqlConnection connection = new SqlConnection(connectionString);

        // Hàm tìm kiếm ký tự trong bảng PurchaseInvoice
        public DataTable SearchPurchaseInvoices(string keyword)
        {
            DataTable dataTable = new DataTable();
            string query = @"SELECT * 
                         FROM PurchaseInvoices
                         WHERE PurchaseInvoiceID LIKE @Keyword 
                            OR SupplierID LIKE @Keyword
                            OR EmployeeID LIKE @Keyword
                            OR PurchaseDate LIKE @Keyword
                            OR TotalAmount LIKE @Keyword";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    connection.Open();
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public DataTable GetAllInvoices()
        {
            // Khởi tạo kết nối SQL
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Truy vấn SQL để lấy tất cả thông tin hóa đơn
                string query = @"SELECT i.PurchaseInvoiceID, i.SupplierID, i.EmployeeID, i.PurchaseDate, i.TotalAmount
                         FROM PurchaseInvoices i";

                // Sử dụng SqlDataAdapter để điền dữ liệu vào DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                // Khởi tạo DataTable để chứa dữ liệu
                DataTable dtInvoices = new DataTable();

                // Điền dữ liệu vào DataTable
                adapter.Fill(dtInvoices);

                // Trả về DataTable chứa các hóa đơn
                return dtInvoices;
            }
        }


        public DataTable GetPurchaseInvoiceDetailsByInvoiceID(int purchaseInvoiceID)
        {
            // Khởi tạo kết nối SQL
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Truy vấn SQL để lấy thông tin chi tiết hóa đơn nhập theo PurchaseInvoiceID
                string query = @"SELECT p.PurchaseInvoiceID, p.ProductID, p.Quantity, p.UnitPrice
                         FROM PurchaseInvoiceDetails p
                         WHERE p.PurchaseInvoiceID = @PurchaseInvoiceID";

                // Khởi tạo SqlCommand và thêm tham số vào truy vấn
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PurchaseInvoiceID", purchaseInvoiceID);

                // Sử dụng SqlDataAdapter để điền dữ liệu vào DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                // Khởi tạo DataTable để chứa dữ liệu
                DataTable dtInvoiceDetails = new DataTable();

                // Điền dữ liệu vào DataTable
                adapter.Fill(dtInvoiceDetails);

                // Trả về DataTable chứa các chi tiết hóa đơn nhập
                return dtInvoiceDetails;
            }
        }

        public DataTable GetPurchaseInvoiceById(int purchaseInvoiceId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT p.PurchaseInvoiceID, p.SupplierID, p.EmployeeID, p.PurchaseDate, p.TotalAmount
                         FROM PurchaseInvoices p
                         WHERE p.PurchaseInvoiceID = @PurchaseInvoiceID";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@PurchaseInvoiceID", purchaseInvoiceId);
                DataTable dtInvoice = new DataTable();
                adapter.Fill(dtInvoice);
                return dtInvoice;
            }
        }

        public DataTable GetPurchaseInvoiceDetailsForNameByInvoiceID(int invoiceId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Truy vấn SQL để lấy thông tin chi tiết hóa đơn nhập và các thuộc tính của sản phẩm từ SupplierProducts
                string query = @"
            SELECT 
                d.PurchaseInvoiceID, 
                p.ProductId,                     -- Mã sản phẩm
                p.ProductName,                   -- Tên sản phẩm
                p.ProductTypeID,                 -- Mã loại sản phẩm
                p.Brand,                         -- Nhãn hiệu
                p.CountryOfOrigin,              -- Quốc gia sản xuất
                p.Price,                         -- Giá
                d.Quantity,                     -- Số lượng trong chi tiết hóa đơn
                p.Unit,                          -- Đơn vị tính
                p.Description,                   -- Mô tả
                p.Ingredients,                   -- Thành phần
                p.Benefits,                      -- Lợi ích
                p.Weight,                        -- Cân nặng
                p.Flavor,                        -- Hương vị
                p.ManufactureDate,               -- Ngày sản xuất
                p.ExpirationDate,                -- Ngày hết hạn
                p.Status,                        -- Trạng thái
                d.UnitPrice,                         -- Giá trong chi tiết hóa đơn
                (d.Quantity * d.UnitPrice) AS TotalPrice -- Tổng tiền (Số lượng * Giá)
            FROM 
                PurchaseInvoiceDetails d
            LEFT JOIN 
                SupplierProducts p ON d.ProductID = p.ProductId
            WHERE 
                d.PurchaseInvoiceID = @PurchaseInvoiceID";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@PurchaseInvoiceID", invoiceId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dtInvoiceDetails = new DataTable();
                adapter.Fill(dtInvoiceDetails);

                // Trả về bảng chứa tất cả các cột cần thiết
                return dtInvoiceDetails;
            }
        }



        // Thêm hóa đơn nhập mới
        public static int CreatePurchaseInvoice(PurchaseInvoiceDTO invoice)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO PurchaseInvoices (SupplierID, EmployeeID, TotalAmount) OUTPUT INSERTED.PurchaseInvoiceID VALUES (@SupplierID, @EmployeeID, @TotalAmount)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierID", invoice.SupplierID);
                        command.Parameters.AddWithValue("@EmployeeID", invoice.EmployeeID);
                        command.Parameters.AddWithValue("@TotalAmount", invoice.TotalAmount);

                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                        else
                        {
                            throw new Exception("Không thể tạo hóa đơn nhập. Không có ID nào được trả về.");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Lỗi cơ sở dữ liệu: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi: {ex.Message}");
            }
        }

        // Cập nhật tổng số tiền của hóa đơn
        public static bool UpdateTotalAmount(int invoiceID, decimal totalAmount)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE PurchaseInvoices SET TotalAmount = @TotalAmount WHERE PurchaseInvoiceID = @PurchaseInvoiceID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PurchaseInvoiceID", invoiceID);
                command.Parameters.AddWithValue("@TotalAmount", totalAmount);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Thêm chi tiết hóa đơn nhập kho
        public static bool AddPurchaseInvoiceDetail(PurchaseInvoiceDetailDTO detail)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO PurchaseInvoiceDetails (PurchaseInvoiceID, ProductID, Quantity, UnitPrice) VALUES (@PurchaseInvoiceID, @ProductID, @Quantity, @UnitPrice)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PurchaseInvoiceID", detail.PurchaseInvoiceID);
                command.Parameters.AddWithValue("@ProductID", detail.ProductID);
                command.Parameters.AddWithValue("@Quantity", detail.Quantity);
                command.Parameters.AddWithValue("@UnitPrice", detail.UnitPrice);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public static bool ReduceStock(int productID, int quantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE SupplierProducts SET StockQuantity = StockQuantity - @Quantity WHERE ProductID = @ProductID AND StockQuantity >= @Quantity";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", productID);
                command.Parameters.AddWithValue("@Quantity", quantity);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }


        //Product
        // Hàm kiểm tra sự tồn tại của sản phẩm
        public bool CheckProductExists(string productName)
        {
            // Mở kết nối trước khi thực thi câu lệnh
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            string query = "SELECT COUNT(*) FROM Products WHERE ProductName = @ProductName";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ProductName", productName);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        // Hàm cập nhật số lượng sản phẩm trong bảng Products
        public void UpdateProductStock(string productName, int quantity)
        {
            // Mở kết nối nếu nó chưa mở
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            string query = "UPDATE Products SET StockQuantity = StockQuantity + @Quantity WHERE ProductName = @ProductName";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ProductName", productName);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.ExecuteNonQuery();
            }
        }

        // Hàm thêm sản phẩm mới vào bảng Products
        public void AddNewProduct(ProductDTO product)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            string query = "INSERT INTO Products (ProductName, ProductTypeID, Brand, CountryOfOrigin, Price, StockQuantity, Unit, Description, Ingredients, Benefits, Weight, Flavor, ManufactureDate, ExpirationDate, ImageUrl, Status) " +
                           "VALUES (@ProductName, @ProductTypeID, @Brand, @CountryOfOrigin, @Price, @StockQuantity, @Unit, @Description, @Ingredients, @Benefits, @Weight, @Flavor, @ManufactureDate, @ExpirationDate, @ImageUrl, @Status)";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ProductTypeID", product.ProductTypeID);
                cmd.Parameters.AddWithValue("@Brand", product.Brand ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CountryOfOrigin", product.CountryOfOrigin ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
                cmd.Parameters.AddWithValue("@Unit", product.Unit ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", product.Description ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Ingredients", product.Ingredients ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Benefits", product.Benefits ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Weight", product.Weight == default(decimal) ? (object)DBNull.Value : product.Weight);
                cmd.Parameters.AddWithValue("@Flavor", product.Flavor ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ManufactureDate", product.ManufactureDate);
                cmd.Parameters.AddWithValue("@ExpirationDate", product.ExpirationDate);
                cmd.Parameters.AddWithValue("@ImageUrl", product.ImageUrl ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", product.Status ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }


        // Đảm bảo đóng kết nối sau khi sử dụng
        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }


    }
}
