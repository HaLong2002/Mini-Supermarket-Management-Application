using SieuThiMini.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieuThiMini.BUS
{
    public class SuppliersBUS
    {
        private SuppliersDAO suppliersDAO;
        public SuppliersBUS()
        {
            suppliersDAO = new SuppliersDAO();
        }
        public List<SupplierDTO> GetSuppliersList()
        {
            return suppliersDAO.GetSuppliersList();
        }
        public void CreateSuppilers(SupplierDTO supplier)
        {
            suppliersDAO.CreateSuppilers(supplier);
        }
        public void EditSuppliers(SupplierDTO supplier)
        {
            suppliersDAO.EditSuppliers(supplier);
        }
        public void Delete(int supplierId)
        {
            suppliersDAO.Delete(supplierId);
        }

        public List<SupplierDTO> GetSuppliers(string searchText)
        {
            List<SupplierDTO> suppliers = GetSuppliersList();
            return suppliers.Where(p => p.GetType().GetProperties().Any(pi =>
            {
                return pi.GetValue(p)?.ToString().ToLower().Contains(searchText.ToLower()) ?? false;
            })).ToList();
        }
    }
}
