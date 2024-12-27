using System;
using SieuThiMini.DAO;

namespace SieuThiMini.BUS
{
    public class CustomerPromotionBUS
    {
        private CustomerPromotionDAO promotionDAO = new CustomerPromotionDAO();

        // 1. Áp dụng mã giảm giá cho hóa đơn
        public decimal ApplyDiscount(int customerID, int promotionID, decimal totalBill)
        {
            // Kiểm tra mã giảm giá đã được sử dụng chưa
            if (promotionDAO.IsPromotionUsed(customerID, promotionID))
            {
                throw new Exception("Mã giảm giá này đã được sử dụng.");
            }

            // Lấy phần trăm giảm giá
            decimal discountPercent = promotionDAO.GetDiscountPercent(promotionID);

            // Tính tổng tiền sau khi áp dụng giảm giá
            decimal discountAmount = (totalBill * discountPercent) / 100;
            decimal finalAmount = totalBill - discountAmount;

            // Cập nhật trạng thái mã giảm giá sau khi sử dụng
            promotionDAO.UpdatePromotionStatus(customerID, promotionID);

            return finalAmount;
        }

        // 2. Xử lý đổi mã giảm giá bằng điểm thưởng
        public bool RedeemPromotion(String customerID, int promotionID)
        {
            return promotionDAO.RedeemPromotion(customerID, promotionID);
        }

        // 3. Kiểm tra mã giảm giá đã sử dụng chưa
        public bool IsPromotionUsed(int customerID, int promotionID)
        {
            return promotionDAO.IsPromotionUsed(customerID, promotionID);
        }

        // 4. Lấy phần trăm giảm giá của mã khuyến mãi
        public decimal GetDiscountPercent(int promotionID)
        {
            return promotionDAO.GetDiscountPercent(promotionID);
        }

        // 5. Cập nhật trạng thái mã giảm giá đã được sử dụng
        public void UpdatePromotionStatus(int customerID, int promotionID)
        {
            promotionDAO.UpdatePromotionStatus(customerID, promotionID);
        }

        public void DeleteCustomerPromotions()
        {
            try
            {
                // Xóa các bản ghi có IsUsed = 1
                promotionDAO.DeleteUsedPromotions();

                Console.WriteLine("Successfully updated and deleted customer promotions.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Business Logic: " + ex.Message);
            }
        }

    }
}
