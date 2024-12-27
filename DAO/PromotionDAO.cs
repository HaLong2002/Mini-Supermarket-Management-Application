using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using OfficeOpenXml;


namespace SieuThiMini.DAO
{
    public class PromotionDAO
    {
        string connectionString = ClassKetnoi.ConnectionString;
        public bool IsPromotionIdExists(int promotionId)
        {
            bool exists = false;

            try
            {
                using (Microsoft.Data.SqlClient.SqlConnection connection = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Promotions WHERE PromotionID = @PromotionID";

                    using (Microsoft.Data.SqlClient.SqlCommand command = new Microsoft.Data.SqlClient.SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PromotionID", promotionId);
                        exists = (int)command.ExecuteScalar() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi kiểm tra PromotionID trong DAO: " + ex.Message);
            }

            return exists;
        }

        public List<PromotionDTO> GetValidPromotions()
        {
            List<PromotionDTO> promotions = new List<PromotionDTO>();
            string query = @"SELECT * FROM Promotions 
                            WHERE EndDate >= CAST(GETDATE() AS DATE) 
                            AND IsActive = 1 
                            AND (ProductID IS NULL OR ProductID = '')"; // Chỉ lấy mã còn hiệu lực và đang kích hoạt

            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            {
                Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn);
                conn.Open();
                Microsoft.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    promotions.Add(new PromotionDTO
                    {
                        PromotionID = reader.GetInt32(0),
                        ProductID = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                        PromotionName = reader.GetString(2),
                        Point = reader.GetInt32(3),
                        DiscountPercent = reader.GetDecimal(4),
                        StartDate = reader.GetDateTime(5),
                        EndDate = reader.GetDateTime(6),
                        IsActive = reader.GetBoolean(7)
                    });
                }
            }
            return promotions;
        }

        public PromotionDTO GetPromotionByID(int promotionID)
        {
            string query = "SELECT * FROM Promotions WHERE PromotionID = @PromotionID AND IsActive = 1";

            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            using (Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@PromotionID", promotionID);
                conn.Open();

                using (Microsoft.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new PromotionDTO
                        {
                            PromotionID = reader.GetInt32(0),
                            ProductID = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                            PromotionName = reader.GetString(2),
                            Point = reader.GetInt32(3),
                            DiscountPercent = reader.GetDecimal(4),
                            StartDate = reader.GetDateTime(5),
                            EndDate = reader.GetDateTime(6),
                            IsActive = reader.GetBoolean(7)
                        };
                    }
                }
            }
            return null;
        }

        public List<PromotionDTO> GetAllPromotions()
        {
            List<PromotionDTO> promotionList = new List<PromotionDTO>();

            try
            {
                using (Microsoft.Data.SqlClient.SqlConnection connection = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Promotions";

                    using (Microsoft.Data.SqlClient.SqlCommand command = new Microsoft.Data.SqlClient.SqlCommand(query, connection))
                    {
                        using (Microsoft.Data.SqlClient.SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PromotionDTO promotion = new PromotionDTO
                                {
                                    PromotionID = reader.GetInt32(0),
                                    ProductID = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                                    PromotionName = reader.GetString(2),
                                    Point = reader.GetInt32(3),
                                    DiscountPercent = reader.GetDecimal(4),
                                    StartDate = reader.GetDateTime(5),
                                    EndDate = reader.GetDateTime(6),
                                    IsActive = reader.GetBoolean(7)
                                };
                                promotionList.Add(promotion);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
            }

            return promotionList;
        }

        // Hàm tự động cập nhật trạng thái của các chương trình khuyến mãi hết hạn
        public void UpdateExpiredPromotions()
        {
            const string query = "UPDATE Promotions SET IsActive = 0 WHERE EndDate < GETDATE() AND IsActive = 1";
            Microsoft.Data.SqlClient.SqlConnection connection = new Microsoft.Data.SqlClient.SqlConnection(connectionString);
            using var command = new Microsoft.Data.SqlClient.SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
        }

        // Lấy chương trình khuyến mãi có hiệu lực cho một sản phẩm
        public PromotionDTO GetCurrentPromotion(int productId)
        {
            string query = "SELECT * FROM Promotions WHERE ProductID = @ProductId AND IsActive = 1";

            using (Microsoft.Data.SqlClient.SqlConnection connection = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            {
                Microsoft.Data.SqlClient.SqlCommand command = new Microsoft.Data.SqlClient.SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductId", productId);
                connection.Open();

                using (Microsoft.Data.SqlClient.SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        PromotionDTO promotion = new PromotionDTO
                        {
                            PromotionID = reader.GetInt32(0),
                            ProductID = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                            PromotionName = reader.GetString(2),
                            Point = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                            DiscountPercent = reader.GetDecimal(4),
                            StartDate = reader.GetDateTime(5),
                            EndDate = reader.GetDateTime(6),
                            IsActive = reader.GetBoolean(7)
                        };
                        return promotion;
                    }
                }
            }

            return null; // Không có chương trình khuyến mãi nào có hiệu lực
        }

        public bool AddPromotionWithoutProductId(PromotionDTO promotion)
        {
            string query = @"INSERT INTO Promotions 
                         (PromotionID, ProductID, PromotionName, DiscountPercent, StartDate, EndDate) 
                         VALUES (@PromotionID, @ProductID, @PromotionName, @DiscountPercent, @StartDate, @EndDate)";

            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            {
                Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PromotionID", promotion.PromotionID);
                cmd.Parameters.AddWithValue("@ProductID", promotion.ProductID);
                cmd.Parameters.AddWithValue("@PromotionName", promotion.PromotionName);
                cmd.Parameters.AddWithValue("@DiscountPercent", promotion.DiscountPercent);
                cmd.Parameters.AddWithValue("@StartDate", promotion.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", promotion.EndDate);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool AddPromotion(PromotionDTO promotion)
        {
            using (Microsoft.Data.SqlClient.SqlConnection connection = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            {
                connection.Open();
                using (Microsoft.Data.SqlClient.SqlCommand command = new Microsoft.Data.SqlClient.SqlCommand(
                    "INSERT INTO Promotions (PromotionID, PromotionName, Point, DiscountPercent, StartDate, EndDate) " +
                    "VALUES (@PromotionID, @PromotionName, @Point, @DiscountPercent, @StartDate, @EndDate)", connection))
                {
                    command.Parameters.AddWithValue("@PromotionID", promotion.PromotionID);
                    command.Parameters.AddWithValue("@PromotionName", promotion.PromotionName);
                    command.Parameters.AddWithValue("@Point", promotion.Point);
                    command.Parameters.AddWithValue("@DiscountPercent", promotion.DiscountPercent);
                    command.Parameters.AddWithValue("@StartDate", promotion.StartDate);
                    command.Parameters.AddWithValue("@EndDate", promotion.EndDate);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdatePromotion(PromotionDTO promotion)
        {
            string query = @"UPDATE Promotions 
                         SET ProductID = @ProductID, PromotionName = @PromotionName, Point = @Point, 
                             DiscountPercent = @DiscountPercent, StartDate = @StartDate, 
                             EndDate = @EndDate
                         WHERE PromotionID = @PromotionID";

            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            {
                Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PromotionID", promotion.PromotionID);
                cmd.Parameters.AddWithValue("@ProductID", promotion.ProductID);
                cmd.Parameters.AddWithValue("@PromotionName", promotion.PromotionName);
                cmd.Parameters.AddWithValue("@Point", promotion.Point);
                cmd.Parameters.AddWithValue("@DiscountPercent", promotion.DiscountPercent);
                cmd.Parameters.AddWithValue("@StartDate", promotion.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", promotion.EndDate);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdatePromotionNoProductId(PromotionDTO promotion)
        {
            string query = @"UPDATE Promotions 
                         SET PromotionName = @PromotionName, Point = @Point, 
                             DiscountPercent = @DiscountPercent, StartDate = @StartDate, 
                             EndDate = @EndDate
                         WHERE PromotionID = @PromotionID";

            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            {
                Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PromotionID", promotion.PromotionID);
                cmd.Parameters.AddWithValue("@PromotionName", promotion.PromotionName);
                cmd.Parameters.AddWithValue("@Point", promotion.Point);
                cmd.Parameters.AddWithValue("@DiscountPercent", promotion.DiscountPercent);
                cmd.Parameters.AddWithValue("@StartDate", promotion.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", promotion.EndDate);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa khuyến mãi theo ID
        public bool DeletePromotion(int promotionId)
        {
            string query = "DELETE FROM Promotions WHERE PromotionID = @PromotionID";

            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            {
                Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PromotionID", promotionId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool LockPromotion(int promotionId)
        {
            return UpdatePromotionStatus(promotionId, false);
        }

        public bool UnlockPromotion(int promotionId)
        {
            return UpdatePromotionStatus(promotionId, true);
        }

        private bool UpdatePromotionStatus(int promotionId, bool isActive)
        {
            string query = "UPDATE Promotions SET IsActive = @IsActive WHERE PromotionID = @PromotionID";
            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            {
                Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IsActive", isActive);
                cmd.Parameters.AddWithValue("@PromotionID", promotionId);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0; // Trả về true nếu cập nhật thành công
            }
        }

        // Lấy danh sách mã giảm giá của khách hàng kèm thông tin chi tiết từ bảng Promotions
        public List<PromotionDTO> GetPromotionsWithDetailsByCustomerId(String customerId)
        {
            List<PromotionDTO> promotions = new List<PromotionDTO>();

            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            {
                string query = @"
                SELECT p.PromotionID, p.PromotionName, p.DiscountPercent, 
                       p.StartDate, p.EndDate
                FROM CustomerPromotions cp
                INNER JOIN Promotions p ON cp.PromotionID = p.PromotionID
                WHERE cp.CustomerID = @CustomerID";

                Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);

                conn.Open();
                using (Microsoft.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PromotionDTO promotion = new PromotionDTO
                        {
                            PromotionID = reader.GetInt32(0),
                            PromotionName = reader.GetString(1),
                            DiscountPercent = reader.GetDecimal(2),
                            StartDate = reader.GetDateTime(3),
                            EndDate = reader.GetDateTime(4)
                        };
                        promotions.Add(promotion);
                    }
                }
            }
            return promotions;
        }

        public List<PromotionDTO> GetPromotionsDetailsByCustomerId(String customerId)
        {
            List<PromotionDTO> promotions = new List<PromotionDTO>();

            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            {
                string query = @"
                SELECT p.*
                FROM CustomerPromotions cp
                INNER JOIN Promotions p ON cp.PromotionID = p.PromotionID
                WHERE cp.CustomerID = @CustomerID AND p.IsActive = 1 AND cp.IsUsed = 0";

                Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);

                conn.Open();
                using (Microsoft.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PromotionDTO promotion = new PromotionDTO
                        {
                            PromotionID = reader.GetInt32(0),
                            ProductID = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                            PromotionName = reader.GetString(2),
                            Point = reader.GetInt32(3),
                            DiscountPercent = reader.GetDecimal(4),
                            StartDate = reader.GetDateTime(5),
                            EndDate = reader.GetDateTime(6),
                            IsActive = reader.GetBoolean(7)
                        };
                        promotions.Add(promotion);
                    }
                }
            }
            return promotions;
        }

        //lấy các mã sản phẩm có trong bảng giảm giá
        public List<int> GetAllActivePromotionProductIds()
        {
            var productIds = new List<int>();

            string query = @"
            SELECT ProductID 
            FROM [dbo].[Promotions]
            WHERE IsActive = 1 ";

            using (var connection = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new Microsoft.Data.SqlClient.SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            productIds.Add(reader.GetInt32(0));
                        }
                    }
                }
            }

            return productIds;
        }

        public bool CheckPromotionCodeExist(int PromotionID)
        {
            using (Microsoft.Data.SqlClient.SqlConnection connection = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            {
                connection.Open();
                using (Microsoft.Data.SqlClient.SqlCommand command = new Microsoft.Data.SqlClient.SqlCommand("SELECT COUNT(*) FROM Promotions WHERE PromotionID = @PromotionID", connection))
                {
                    command.Parameters.AddWithValue("@PromotionID", PromotionID);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public decimal GetDiscountPercentByPromotionID(int promotionId)
        {
            decimal discountPercent = 0;
            string query = @"
            SELECT DiscountPercent
            FROM Promotions
            WHERE PromotionID = @PromotionID 
              AND IsActive = 1 
              AND GETDATE() BETWEEN StartDate AND EndDate";

            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            {
                Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PromotionID", promotionId);

                conn.Open();
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    discountPercent = Convert.ToDecimal(result);
                }
            }

            return discountPercent;
        }

        public List<PromotionDTO> SearchPromotions(string keyword)
        {
            List<PromotionDTO> promotionsList = new List<PromotionDTO>();

            try
            {
                using (Microsoft.Data.SqlClient.SqlConnection connection = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
                {
                    connection.Open();

                    // Câu truy vấn tìm kiếm theo PromotionName hoặc ProductID
                    string query = @"SELECT * FROM Promotions 
                             WHERE (PromotionName LIKE @keyword OR CAST(ProductID AS NVARCHAR) LIKE @keyword) 
                             AND IsActive = 1";

                    using (Microsoft.Data.SqlClient.SqlCommand command = new Microsoft.Data.SqlClient.SqlCommand(query, connection))
                    {
                        // Thêm tham số keyword với ký tự `%` để tìm kiếm theo từ khóa nhập vào
                        command.Parameters.AddWithValue("@keyword", $"%{keyword}%");

                        using (Microsoft.Data.SqlClient.SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PromotionDTO promotion = new PromotionDTO
                                {
                                    PromotionID = reader.GetInt32(0),
                                    ProductID = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                                    PromotionName = reader.GetString(2),
                                    Point = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                                    DiscountPercent = reader.GetDecimal(4),
                                    StartDate = reader.GetDateTime(5),
                                    EndDate = reader.GetDateTime(6),
                                    IsActive = reader.GetBoolean(7)
                                };
                                promotionsList.Add(promotion);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
            }

            return promotionsList;
        }


        // In EmployeeDAO class
        public string GetEmployeeNameById(int employeeId)
        {
            string employeeName = null;
            string query = "SELECT Name FROM Employees WHERE EmployeeID = @EmployeeID"; // Adjust EmployeeID to match the correct primary key in your table if necessary

            using (Microsoft.Data.SqlClient.SqlConnection connection = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            using (Microsoft.Data.SqlClient.SqlCommand command = new Microsoft.Data.SqlClient.SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@EmployeeID", employeeId);

                connection.Open();
                var result = command.ExecuteScalar();
                if (result != null)
                {
                    employeeName = result.ToString();
                }
            }

            return employeeName;
        }

        // Phương thức để lấy giá gốc của sản phẩm theo ProductId
        public decimal GetOriginalPrice(int productId)
        {
            decimal originalPrice = 0;

            string query = "SELECT Price FROM Products WHERE ProductId = @ProductId";

            // Declare and initialize the connection variable
            using (Microsoft.Data.SqlClient.SqlConnection connection = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            {
                using (Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ProductId", productId);

                    // Mở kết nối và thực thi truy vấn
                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    connection.Close();

                    // Nếu có kết quả, trả về giá gốc
                    if (result != DBNull.Value)
                    {
                        originalPrice = Convert.ToDecimal(result);
                    }
                }
            }

            return originalPrice;
        }


    }
}