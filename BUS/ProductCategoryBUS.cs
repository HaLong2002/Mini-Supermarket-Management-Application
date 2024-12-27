using SieuThiMini.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieuThiMini.BUS
{
    public class ProductCategoryBUS
    {
        private ProductCategoryDAO categoryDAO;
        private string connectionString = ClassKetnoi.ConnectionString;

        public ProductCategoryBUS()
        {
            categoryDAO = new ProductCategoryDAO(connectionString);
        }

        public List<ProductCategoryDTO> GetCategories()
        {
            return categoryDAO.GetAllCategories();
        }

        public void AddCategory(string categoryName)
        {
            ProductCategoryDTO category = new ProductCategoryDTO { CategoryName = categoryName };
            categoryDAO.AddCategory(category);
        }

        public bool UpdateProductCategory(int categoryId, string categoryName)
        {
            return categoryDAO.UpdateCategory(categoryId, categoryName);
        }

        public bool DeleteProductCategory(int categoryId)
        {
            return categoryDAO.DeleteCategory(categoryId);
        }
    }
}
