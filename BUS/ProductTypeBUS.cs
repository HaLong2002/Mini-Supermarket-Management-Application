using SieuThiMini.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieuThiMini.BUS
{
    public class ProductTypeBUS
    {
        private ProductTypeDAO productTypeDAO;
        private string connectionString = ClassKetnoi.ConnectionString;

        public ProductTypeBUS()
        {
            productTypeDAO = new ProductTypeDAO(connectionString);
        }

        // Method to get all product types
        public List<ProductTypeDTO> GetAllProductTypes()
        {
            return productTypeDAO.GetAllProductTypes();
        }

        public List<ProductTypeDTO> GetProductTypesByCategoryId(int idCategory)
        {
            return productTypeDAO.GetProductTypesByCategoryId(idCategory);
        }

        // Method to add a new product type
        public void AddProductType(string productTypeName, int categoryId)
        {
            ProductTypeDTO type = new ProductTypeDTO { ProductTypeName = productTypeName, CategoryID = categoryId };
            productTypeDAO.AddProductType(type);
        }

        // Method to edit a product type
        public bool UpdateProductType(int typeId, string typeName, int categoryId)
        {
            return productTypeDAO.UpdateProductType(typeId, typeName, categoryId);
        }

        // Method to delete a product type
        public bool DeleteProductType(int typeId)
        {
            return productTypeDAO.DeleteProductType(typeId);
        }
    }
}
