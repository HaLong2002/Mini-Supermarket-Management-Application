using iText.Commons.Actions.Data;
using iText.IO.Util;
using SieuThiMini.DAO;
using SieuThiMini.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieuThiMini.BUS
{
    public class SupplierProductsBUS
    {
        private SupplierProductsDAO supplierProductsDAO;
        public SupplierProductsBUS()
        {
            supplierProductsDAO = new SupplierProductsDAO();
        }

        public List<SupplierProductsDTO> GetSupplierProductList()
        {
            return supplierProductsDAO.GetSupplierProductList();
        }
        public List<SupplierProductsDTO> GetSupplierProductListBySupplier(int supplierID)
        {
            return supplierProductsDAO.GetSupplierProductListBySupplier(supplierID);
        }

        public List<SupplierProductsDTO> GetAllSupplierProduct()
        {
            return supplierProductsDAO.GetAllSupplierProduct();
        }
        public List<SupplierProductsDTO> GetAllSupplierProductListBySupplier(int supplierID)
        {
            return supplierProductsDAO.GetAllSupplierProductListBySupplier(supplierID);
        }

        public void CreateSupplierProduct(SupplierProductsDTO product)
        {
            supplierProductsDAO.CreateSupplierProduct(product);
        }
        public void EditSupplierProduct(SupplierProductsDTO product)
        {
            supplierProductsDAO.EditSupplierProduct(product);
        }
        public void DeleteSupplierProductBySupplier(int supplierID)
        {
            supplierProductsDAO.DeleteSupplierProductBySupplier(supplierID);
        }
        public void DeleteSupplierProduct(int productID)
        {
            supplierProductsDAO.DeleteSupplierProduct(productID);
        }
        public SupplierProductsDTO GetProductById(int productId)
        {
            return supplierProductsDAO.GetProductFromSupplier(productId);
        }
    }
}
