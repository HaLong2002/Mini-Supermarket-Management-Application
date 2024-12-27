using System.Collections.Generic;
using SieuThiMini.DAO;
using SieuThiMini.DTO;

namespace SieuThiMini.BUS
{
    internal class ProductBUS
    {
        string connectionString = ClassKetnoi.ConnectionString;
        private ProductDAO productDAO = new ProductDAO();

        public List<ProductDTO> GetProducts()
        {
            return productDAO.GetAllProducts();
        }
        public List<ProductDTO> GetProductsForSale()
        {
            return productDAO.GetAllProductsForSale();
        }
        public void UpdateProductStatus(int productId, string status)
        {
            productDAO.UpdateProductStatus(productId, status);
        }

        public void AddProduct(ProductDTO product)
        {
            productDAO.AddProduct(product);
        }

        public void UpdateProduct(ProductDTO product)
        {
            productDAO.UpdateProduct(product);
        }

        public void DeleteProduct(int productId)
        {
            productDAO.DeleteProduct(productId);
        }

        public List<ProductDTO> SearchProducts(string productName)
        {
            return productDAO.SearchProducts(productName);
        }
        public ProductDTO GetProductById(int productId)
        {
            return productDAO.GetProductById(productId);
        }
        public List<string> GetUniqueCountries()
        {
            return productDAO.GetUniqueCountries();
        }

        public List<string> GetUniqueBrands()
        {
            return productDAO.GetUniqueBrands();
        }

        public List<ProductTypeDTO> GetUniqueProductTypes()
        {
            return productDAO.GetUniqueProductTypes();
        }
        public List<ProductDTO> AdvancedSearch(List<string> conditions)
        {
            return productDAO.AdvancedSearch(conditions);
        }
        public bool IsProductIdExists(int productId)
        {
            return productDAO.CheckProductExists(productId);
        }

        public List<ProductDTO> GetProductsNearExpiration()
        {
            return productDAO.GetProductsNearExpiration();
        }
    }
}
