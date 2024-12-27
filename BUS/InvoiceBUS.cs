using iText.Commons.Actions.Data;
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
    public class InvoiceBUS
    {
        
        private InvoiceDAO invoiceDAO = new InvoiceDAO();

        public DataTable GetAllInvoices()
        {
            return invoiceDAO.GetAllInvoices();
        }
        public DataTable GetInvoice(int invoiceID)
        {
            return invoiceDAO.GetInvoice(invoiceID);
        }
        public DataTable SearchInvoices(string keyword)
        {
            return invoiceDAO.SearchInvoices(keyword);
        }

        public int CreateInvoice(InvoiceDTO invoice)
        {
            return invoiceDAO.CreateInvoice(invoice);
        }
        public static void UpdateInvoiceTotalAndPoints(int invoiceId, decimal totalAmount, int pointsEarned)
        {
            // Gọi đến hàm trong lớp DAO để thực hiện cập nhật
            InvoiceDAO.UpdateInvoiceTotalAndPoints(invoiceId, totalAmount, pointsEarned);
        }
        //Cập nhật điểm tích lũy cho khách hàng
        public bool UpdateCustomerRewardPoints(int customerId, int pointsEarned)
        {
            return invoiceDAO.UpdateCustomerRewardPoints(customerId, pointsEarned);
        }

        // Lấy doanh thu theo tháng cho một năm
        public List<RevenueByMonthDTO> GetRevenueByMonth(int year)
        {
            return invoiceDAO.GetRevenueByMonth(year);
        }

        // Lấy Top 5 khách hàng đã chi nhiều tiền nhất
        public List<TopLoyalCustomers> GetTop5LoyalCustomers()
        {
            return invoiceDAO.GetTop5LoyalCustomers();
        }

        public ProductDTO GetProductDetailsByInvoiceID(int productId)
        {
            return invoiceDAO.GetProductDetailsById(productId);
        }

    }

}
