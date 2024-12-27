using SieuThiMini.DAO;
using SieuThiMini.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SieuThiMini.BUS
{
    public class PurchaseInvoiceBUS
    {
        private PurchaseInvoiceDAO PurchaseDAO = new PurchaseInvoiceDAO();

        // Hàm tìm kiếm trong BUS
        public DataTable SearchPurchaseInvoices(string keyword)
        {
            return PurchaseDAO.SearchPurchaseInvoices(keyword);
        }
        // Hàm lấy tất cả các hóa đơn mua hàng
        public DataTable GetAllPurchaseInvoices()
        {
            return PurchaseDAO.GetAllInvoices();
        }

        // Hàm lấy tất cả chi tiết của các hóa đơn
        public DataTable GetAllPurchaseInvoicesDetails(int id)
        {
            return PurchaseDAO.GetPurchaseInvoiceDetailsByInvoiceID(id);
        }

        public DataTable GetPurchaseInvoiceById(int id)
        {
            return PurchaseDAO.GetPurchaseInvoiceById(id);
        }

        public DataTable GetPurchaseInvoiceDetailsForNameByInvoiceID(int id)
        {
            return PurchaseDAO.GetPurchaseInvoiceDetailsForNameByInvoiceID(id);
        }

        public static int CreatePurchaseInvoice(PurchaseInvoiceDTO invoice)
        {
            try
            {
                // Gọi DAO để thực hiện thêm hóa đơn vào cơ sở dữ liệu
                return PurchaseInvoiceDAO.CreatePurchaseInvoice(invoice);
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần thiết
                MessageBox.Show("Lỗi khi tạo hóa đơn nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public static bool AddPurchaseInvoiceDetail(PurchaseInvoiceDetailDTO detail)
        {
            try
            {
                // Gọi DAO để thực hiện thêm chi tiết hóa đơn vào cơ sở dữ liệu
                return PurchaseInvoiceDAO.AddPurchaseInvoiceDetail(detail);
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần thiết
                MessageBox.Show("Lỗi khi thêm chi tiết hóa đơn nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Giảm số lượng tồn kho sau khi thêm chi tiết hóa đơn
        public static bool ReduceStock(int productID, int quantity)
        {
            try
            {
                // Gọi DAO để giảm số lượng tồn kho cho sản phẩm
                return PurchaseInvoiceDAO.ReduceStock(productID, quantity);
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần thiết
                MessageBox.Show("Lỗi khi giảm tồn kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Cập nhật tổng số tiền vào hóa đơn
        public static bool UpdateTotalAmount(int invoiceID, decimal totalAmount)
        {
            try
            {
                // Gọi DAO để cập nhật tổng tiền vào hóa đơn
                return PurchaseInvoiceDAO.UpdateTotalAmount(invoiceID, totalAmount);
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần thiết
                MessageBox.Show("Lỗi khi cập nhật tổng tiền hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public decimal CalculateTotalAmount(List<PurchaseInvoiceDetailDTO> invoiceDetails)
        {
            decimal totalAmount = 0;
            foreach (var detail in invoiceDetails)
            {
                totalAmount += detail.Quantity * detail.UnitPrice;
            }
            return totalAmount;
        }

        //Product
        // Hàm xử lý thêm hoặc cập nhật sản phẩm trong cơ sở dữ liệu từ giỏ hàng
        public void AddOrUpdateProductInCart(string productName, int quantity, ProductDTO productDetails)
        {
            // Kiểm tra xem sản phẩm đã tồn tại trong cơ sở dữ liệu chưa
            if (PurchaseDAO.CheckProductExists(productName))
            {
                // Nếu sản phẩm đã tồn tại, cập nhật số lượng
                PurchaseDAO.UpdateProductStock(productName, quantity);
            }
            else
            {
                // Nếu sản phẩm chưa tồn tại, thêm mới vào bảng
                productDetails.StockQuantity = quantity;
                PurchaseDAO.AddNewProduct(productDetails);
            }
        }



    }

}
