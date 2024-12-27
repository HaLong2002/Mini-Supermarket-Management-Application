using iText.Commons.Actions.Data;
using SieuThiMini.DAO;
using SieuThiMini.DTO;
using System;
using System.Collections.Generic;

namespace SieuThiMini.BUS
{
    public class PromotionBUS
    {
        private readonly PromotionDAO promotionDAO = new PromotionDAO();
        private readonly ProductBUS productBUS = new ProductBUS();

        public bool IsPromotionIdExists(string promotionId)
        {
            return promotionDAO.IsPromotionIdExists(int.Parse(promotionId));
        }
        // Lấy danh sách khuyến mãi còn hiệu lực
        public List<PromotionDTO> GetValidPromotions()
        {
            return promotionDAO.GetValidPromotions();
        }

        // Lấy chi tiết khuyến mãi theo ID
        public PromotionDTO GetPromotionByID(int promotionID)
        {
            return promotionDAO.GetPromotionByID(promotionID);
        }

        public List<PromotionDTO> GetAllPromotions()
        {
            var promotions = promotionDAO.GetAllPromotions();

            // Chuyển đổi từ Promotion sang PromotionViewModel để hiển thị trạng thái
            var promotionViewModels = promotions.Select(p => new PromotionDTO
            {
                PromotionID = p.PromotionID,
                ProductID = p.ProductID,
                PromotionName = p.PromotionName,
                Point = p.Point,
                DiscountPercent = p.DiscountPercent,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                Status = p.IsActive ? "Còn hoạt động" : "Không hoạt động",
                IsActive = p.IsActive
            }).ToList();

            return promotionViewModels;
        }

        public bool CheckPromotionExists(int promotionID)
        {
            return GetAllPromotions().Any(p => p.PromotionID == promotionID);
        }

        // Cập nhật trạng thái các khuyến mãi hết hạn
        public void UpdateExpiredPromotions()
        {
            promotionDAO.UpdateExpiredPromotions();
        }

        // Lấy chương trình khuyến mãi hiện tại cho sản phẩm
        public PromotionDTO GetCurrentPromotion(int productId)
        {
            return promotionDAO.GetCurrentPromotion(productId);
        }

        // Thêm mới một khuyến mãi và kiểm tra
        public bool AddPromotion(PromotionDTO promotion)
        {
            if (promotion.ProductID.HasValue) // Check if ProductID is present
            {
                return promotionDAO.AddPromotionWithoutProductId(promotion);
            }
            else
            {
                return promotionDAO.AddPromotion(promotion);
            }
        }

        public bool UpdatePromotion(PromotionDTO promotion)
        {
            if (promotion.ProductID.HasValue) // Check if ProductID is present
            {
                return promotionDAO.UpdatePromotion(promotion);
            }
            else
            {
                return promotionDAO.UpdatePromotionNoProductId(promotion);
            }
        }

        public List<PromotionDTO> GetPromotions(string searchText)
        {
            List<PromotionDTO> promotions = GetAllPromotions();
            return promotions.Where(p => p.GetType().GetProperties().Any(pi =>
            {
                return pi.GetValue(p)?.ToString().ToLower().Contains(searchText.ToLower()) ?? false;
            })).ToList();
        }

        public List<ProductDTO> GetProducts(string searchText)
        {
            List<ProductDTO> products = productBUS.GetProducts();
            return products.Where(p => p.GetType().GetProperties().Any(pi =>
            {
                return pi.GetValue(p)?.ToString().ToLower().Contains(searchText.ToLower()) ?? false;
            })).ToList();
        }

        public bool DeletePromotion(int promotionId)
        {
            return promotionDAO.DeletePromotion(promotionId);
        }

        // Khóa một khuyến mãi
        public bool LockPromotion(int promotionId)
        {
            return promotionDAO.LockPromotion(promotionId);
        }

        // Mở khóa một khuyến mãi
        public bool UnlockPromotion(int promotionId)
        {
            return promotionDAO.UnlockPromotion(promotionId);
        }

        // Lấy danh sách khuyến mãi của khách hàng
        public List<PromotionDTO> GetPromotionsWithDetailsByCustomerId(string customerId)
        {
            return promotionDAO.GetPromotionsWithDetailsByCustomerId(customerId);
        }

        public List<PromotionDTO> GetPromotionsDetailsByCustomerId(string customerId)
        {
            var promotions = promotionDAO.GetPromotionsDetailsByCustomerId(customerId);

            // Chuyển đổi từ Promotion sang PromotionViewModel để hiển thị trạng thái
            var promotionViewModels = promotions.Select(p => new PromotionDTO
            {
                PromotionID = p.PromotionID,
                ProductID = p.ProductID,
                PromotionName = p.PromotionName,
                Point = p.Point,
                DiscountPercent = p.DiscountPercent,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                Status = p.IsActive ? "Còn hoạt động" : "Không hoạt động",
                IsActive = p.IsActive
            }).ToList();

            return promotionViewModels;
        }

        // Lấy tất cả các ProductID có trong khuyến mãi đang hoạt động
        public List<int> GetAllActivePromotionProductIds()
        {
            return promotionDAO.GetAllActivePromotionProductIds();
        }

        // Kiểm tra mã khuyến mãi có tồn tại không
        public bool CheckPromotionCodeExist(int promotionId)
        {
            return promotionDAO.CheckPromotionCodeExist(promotionId);
        }

        public decimal CalculateDiscountedPrice(int productId, int promotionID, decimal originalPrice)
        {
            // Get discount percentage from DAO using the promotionID
            decimal discountPercent = promotionDAO.GetDiscountPercentByPromotionID(promotionID);

            // Calculate the discounted price
            decimal discountedPrice;
            if (discountPercent > 0)
            {
                discountedPrice = originalPrice * (1 - (discountPercent / 100));
            }
            else
            {
                discountedPrice = originalPrice; // No discount
            }

            return discountedPrice;
        }

        // In EmployeeBUS class
        public string GetEmployeeNameById(int employeeId)
        {
            return promotionDAO.GetEmployeeNameById(employeeId);
        }

        public List<PromotionDTO> SearchPromotions(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                // Nếu không có từ khóa tìm kiếm, trả về toàn bộ danh sách khuyến mãi
                return GetAllPromotions();
            }
            return promotionDAO.SearchPromotions(keyword);
        }

        // Phương thức để lấy giá gốc của sản phẩm từ DAO
        public decimal GetOriginalPrice(int productId)
        {
            return promotionDAO.GetOriginalPrice(productId);
        }

    }
}
