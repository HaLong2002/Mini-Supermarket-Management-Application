using SieuThiMini.DAO;
using SieuThiMini.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieuThiMini.BUS
{
    public class InvoiceDetailBUS
    {
        private InvoiceDetailDAO invoiceDetailDAO = new InvoiceDetailDAO();

        public DataTable GetInvoiceDetailsByInvoiceID(int invoiceId)
        {
            return invoiceDetailDAO.GetInvoiceDetailsByInvoiceID(invoiceId);
        }

        public DataTable GetInvoiceDetailsForNameByInvoiceID(int invoiceId)
        {
            return invoiceDetailDAO.GetInvoiceDetailsForNameByInvoiceID(invoiceId);
        }

        public void AddInvoiceDetail(InvoiceDetailDTO detail)
        {
            invoiceDetailDAO.AddInvoiceDetail(detail);
        }

        public static bool CheckProductInInvoiceDetail(int invoiceId, int productId)
        {
            return InvoiceDetailDAO.CheckProductInInvoiceDetail(invoiceId, productId);
        }

        public bool ReduceStock(int productId, int quantitySold)
        {
            return invoiceDetailDAO.UpdateProductStock(productId, quantitySold);
        }
        // Lấy top 5 sản phẩm bán chạy nhất cho một năm
        public List<TopProductDTO> GetTopSellingProductsByYear(int year)
        {
            var topProducts = invoiceDetailDAO.GetTopSellingProductsByYear(year);

            // Trả về danh sách sản phẩm bán chạy nhất
            return topProducts;
        }


    }

}
