using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieuThiMini.DAO
{
    public class CustomerPromotionDAO
    {
        string connectionString = ClassKetnoi.ConnectionString;

        public bool RedeemPromotion(String customerId, int promotionId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Lấy điểm của mã giảm giá
                    string queryPromotion = "SELECT Point FROM Promotions WHERE PromotionID = @PromotionID";
                    SqlCommand cmdPromotion = new SqlCommand(queryPromotion, conn, transaction);
                    cmdPromotion.Parameters.AddWithValue("@PromotionID", promotionId);

                    int promotionPoints = (int)cmdPromotion.ExecuteScalar();

                    // Lấy điểm thưởng của khách hàng
                    string queryCustomer = "SELECT RewardPoint FROM Customers WHERE CustomerID = @CustomerID";
                    SqlCommand cmdCustomer = new SqlCommand(queryCustomer, conn, transaction);
                    cmdCustomer.Parameters.AddWithValue("@CustomerID", customerId);

                    int customerPoints = (int)cmdCustomer.ExecuteScalar();

                    // Kiểm tra xem khách hàng có đủ điểm không
                    if (customerPoints < promotionPoints)
                    {
                        throw new Exception("Không đủ điểm để đổi mã giảm giá.");
                    }

                    // Trừ điểm của khách hàng
                    string updateCustomerPoints = @"
                        UPDATE Customers 
                        SET RewardPoint = RewardPoint - @Points 
                        WHERE CustomerID = @CustomerID";
                    SqlCommand cmdUpdateCustomer = new SqlCommand(updateCustomerPoints, conn, transaction);
                    cmdUpdateCustomer.Parameters.AddWithValue("@Points", promotionPoints);
                    cmdUpdateCustomer.Parameters.AddWithValue("@CustomerID", customerId);
                    cmdUpdateCustomer.ExecuteNonQuery();

                    // Thêm vào bảng CustomerPromotions
                    string insertCustomerPromotion = @"
                        INSERT INTO CustomerPromotions (CustomerID, PromotionID) 
                        VALUES (@CustomerID, @PromotionID)";
                    SqlCommand cmdInsertPromotion = new SqlCommand(insertCustomerPromotion, conn, transaction);
                    cmdInsertPromotion.Parameters.AddWithValue("@CustomerID", customerId);
                    cmdInsertPromotion.Parameters.AddWithValue("@PromotionID", promotionId);
                    cmdInsertPromotion.ExecuteNonQuery();

                    // Commit transaction nếu không có lỗi
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // Rollback nếu có lỗi
                    transaction.Rollback();
                    Console.WriteLine("Lỗi: " + ex.Message);
                    return false;
                }
            }
        }


        public bool IsPromotionUsed(int customerID, int promotionID)
        {
            string query = @"
            SELECT IsUsed 
            FROM CustomerPromotions 
            WHERE CustomerID = @CustomerID AND PromotionID = @PromotionID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CustomerID", customerID);
                cmd.Parameters.AddWithValue("@PromotionID", promotionID);

                conn.Open();
                return (bool)cmd.ExecuteScalar(); // Trả về true nếu mã đã được sử dụng
            }
        }

        public decimal GetDiscountPercent(int promotionID)
        {
            string query = @"
            SELECT DiscountPercent 
            FROM Promotions 
            WHERE PromotionID = @PromotionID AND IsActive = 1";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@PromotionID", promotionID);
                conn.Open();
                return (decimal)cmd.ExecuteScalar();
            }
        }

        public void UpdatePromotionStatus(int customerID, int promotionID)
        {
            string query = @"
            UPDATE CustomerPromotions 
            SET IsUsed = 1 
            WHERE CustomerID = @CustomerID AND PromotionID = @PromotionID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CustomerID", customerID);
                cmd.Parameters.AddWithValue("@PromotionID", promotionID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteUsedPromotions()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Xóa các bản ghi có IsUsed = 1
                    string deleteQuery = @"
                        DELETE FROM CustomerPromotions
                        WHERE IsUsed = 1";

                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection);
                    deleteCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deleting used promotions: " + ex.Message);
                }
            }
        }


    }
}
