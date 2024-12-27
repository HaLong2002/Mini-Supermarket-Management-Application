using Microsoft.Data.SqlClient;
using SieuThiMini.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieuThiMini.DAO
{
    public class InvoiceDetailDAO
    {
        private static string connectionString = ClassKetnoi.ConnectionString;

        public DataTable GetInvoiceDetailsByInvoiceID(int invoiceId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT d.InvoiceID, d.ProductID, d.PromotionID, d.quantity, d.price,
                                (d.quantity * d.price) AS TotalPrice
                         FROM InvoiceDetails d
                         WHERE d.InvoiceID = @InvoiceID";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dtInvoiceDetails = new DataTable();
                adapter.Fill(dtInvoiceDetails);
                return dtInvoiceDetails;
            }
        }

        public DataTable GetInvoiceDetailsForNameByInvoiceID(int invoiceId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Truy vấn SQL để lấy tên sản phẩm và tên mã giảm giá
                string query = @"
            SELECT 
                d.InvoiceID,
                p.ProductName,                -- Lấy tên sản phẩm
                prm.PromotionName,            -- Lấy tên khuyến mãi
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
                d.quantity,                         -- Giá trong chi tiết hóa đơn
                (d.Quantity * d.quantity) AS TotalPrice -- Tổng tiền (Số lượng * Giá)
            FROM 
                InvoiceDetails d
            LEFT JOIN 
                Products p ON d.ProductID = p.ProductId
            LEFT JOIN 
                Promotions prm ON d.PromotionID = prm.PromotionID
            WHERE 
                d.InvoiceID = @InvoiceID";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dtInvoiceDetails = new DataTable();
                adapter.Fill(dtInvoiceDetails);

                // Trả về bảng chứa các cột chính xác
                return dtInvoiceDetails;
            }
        }


        public void AddInvoiceDetail(InvoiceDetailDTO detail)
        {
            string query = @"
            INSERT INTO InvoiceDetails (InvoiceID, ProductID, PromotionID, quantity, price)
            VALUES (@InvoiceID, @ProductID, @PromotionID, @Quantity, @Price)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@InvoiceID", detail.InvoiceID);
                cmd.Parameters.AddWithValue("@ProductID", detail.ProductID);
                cmd.Parameters.AddWithValue("@PromotionID", (object)detail.PromotionID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Quantity", detail.Quantity);
                cmd.Parameters.AddWithValue("@Price", detail.Price);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static bool CheckProductInInvoiceDetail(int invoiceId, int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM InvoiceDetails WHERE InvoiceID = @InvoiceID AND ProductID = @ProductID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@InvoiceID", invoiceId);
                    command.Parameters.AddWithValue("@ProductID", productId);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    return count > 0; // Trả về true nếu có sản phẩm, false nếu không
                }
            }
        }

        /// C?p nhật số lượng cho sản phẩm
        public bool UpdateProductStock(int productId, int quantitySold)
        {
            string query = "UPDATE Products SET StockQuantity = StockQuantity - @quantitySold WHERE ProductId = @productId AND StockQuantity >= @quantitySold";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@quantitySold", quantitySold);
                cmd.Parameters.AddWithValue("@productId", productId);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Hàm lấy top 5 sản phẩm bán chạy nhất trong một năm
        public List<TopProductDTO> GetTopSellingProductsByYear(int year)
        {
            // Chuẩn bị câu lệnh SQL để lấy top sản phẩm bán chạy theo năm
            string query = @"
         SELECT TOP 5 p.ProductID,p.ProductName, SUM(id.Quantity) AS TotalQuantity
        FROM InvoiceDetails id
        INNER JOIN Invoices i ON id.InvoiceID = i.InvoiceID
        INNER JOIN Products p ON id.ProductID = p.ProductID
        WHERE YEAR(i.InvoiceDate) = @Year
        GROUP BY p.ProductID, p.ProductName
        ORDER BY TotalQuantity DESC"; // Giới hạn 5 sản phẩm bán chạy nhất

            // Tạo danh sách để lưu trữ kết quả
            List<TopProductDTO> topSellingProducts = new List<TopProductDTO>();

            // Kết nối với cơ sở dữ liệu và thực thi câu lệnh
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Year", year);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TopProductDTO product = new TopProductDTO
                    {
                        ProductID = Convert.ToInt32(reader["ProductID"]), // Đọc ID sản phẩm
                        ProductName = reader["ProductName"].ToString(),
                        TotalQuantity = Convert.ToInt32(reader["TotalQuantity"])
                    };
                    topSellingProducts.Add(product);
                }
            }

            return topSellingProducts;
        }




    }

}
