using Microsoft.Identity.Client;
using OfficeOpenXml;
using SieuThiMini.BUS;
using SieuThiMini.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace SieuThiMini.Panel
{
    public partial class PromotionPanel : Form
    {
        private int id;
        private string employeeName;
        private PromotionBUS promotionBUS = new PromotionBUS();
        private ProductBUS productBUS = new ProductBUS();
        private EmployeeBUS employeeBUS = new EmployeeBUS();
        private int selectedPromotionID, selectedProductId;
        public PromotionPanel(int id)
        {
            InitializeComponent();
            LoadPromotions();
            txtPromotionId.Text = GenerateRandomPromotionId();
            LoadProduct();
            ViewProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ViewPromotion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.id = id;
            string role = employeeBUS.GetRoleById(id);

            if(role == "Nhân viên bán hàng")
            {
                btnAdd.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnUnLock.Visible = false;
                btnLock.Visible = false;
            }    

            // Retrieve employee name by ID and display in textbox
            employeeName = promotionBUS.GetEmployeeNameById(id);
            if (!string.IsNullOrEmpty(employeeName))
            {
                lblEmployeeName.Text = employeeName;
            }
            else
            {
                MessageBox.Show("Employee not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPromotions()
        {
            promotionBUS.UpdateExpiredPromotions();
            List<PromotionDTO> promotions = promotionBUS.GetAllPromotions();
            ViewPromotion.DataSource = promotions;
            // Ẩn cột IsActive nếu tồn tại
            if (ViewPromotion.Columns["IsActive"] != null)
            {
                ViewPromotion.Columns["IsActive"].Visible = false;
            }
        }

        public void LoadProduct()
        {
            List<ProductDTO> products = productBUS.GetProductsForSale();
            ViewProduct.DataSource = products;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidatePromotionInput())
                return; // Dừng lại nếu kiểm tra không hợp lệ

            // Kiểm tra xem PromotionID có dữ liệu trong textbox chưa
            string promotionId = txtPromotionId.Text.Trim();
            if (string.IsNullOrEmpty(promotionId))
            {
                // Randomize PromotionID
                promotionId = GenerateRandomPromotionId();
                // Kiểm tra xem mã giảm giá đã tồn tại chưa
                while (promotionBUS.IsPromotionIdExists(promotionId))
                {
                    promotionId = GenerateRandomPromotionId();
                }
            }

            // Ensure that PromotionID is set before creating PromotionDTO
            if (string.IsNullOrEmpty(promotionId))
            {
                MessageBox.Show("Promotion ID cannot be null or empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Ensure that we don't attempt to add a promotion with a null ID
            }

            PromotionDTO promotion = new PromotionDTO
            {
                PromotionID = int.Parse(promotionId),
                PromotionName = txtPromotionName.Text,
                Point = int.TryParse(txtPoint.Text, out int point) ? point : 0,
                DiscountPercent = decimal.TryParse(txtDiscountPercent.Text, out decimal discount) ? discount : 0,
                StartDate = dateStartDate.Value,
                EndDate = dateEndDate.Value,
                ProductID = int.TryParse(txtProductID.Text, out int productId) ? (int?)productId : null // Use nullable for ProductID
            };

            bool result = promotionBUS.AddPromotion(promotion);

            if (result)
            {
                MessageBox.Show("Thêm mã giảm giá thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetPromotionFields();
                LoadPromotions(); // Tải lại danh sách khuyến mãi
            }
            else
            {
                MessageBox.Show("Thêm mã giảm giá thất bại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Method to generate a random PromotionID
        private string GenerateRandomPromotionId()
        {
            Random random = new Random();
            return random.Next(100, 999).ToString(); // Example format
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedPromotionID == 0)
            {
                MessageBox.Show("Vui lòng chọn mã giảm giá cần cập nhật.");
                return;
            }

            if (!ValidatePromotionInput())
                return; // Stop if validation fails
            if (string.IsNullOrEmpty(txtProductID.Text))
            {
                MessageBox.Show("Bạn đang nhập mã giành cho sản phẩm");
            }

            PromotionDTO promotion = new PromotionDTO
            {
                PromotionID = selectedPromotionID,
                PromotionName = txtPromotionName.Text,
                Point = int.TryParse(txtPoint.Text, out int point) ? point : 0,
                DiscountPercent = decimal.TryParse(txtDiscountPercent.Text, out decimal discount) ? discount : 0,
                StartDate = dateStartDate.Value,
                EndDate = dateEndDate.Value,
                ProductID = int.TryParse(txtProductID.Text, out int productId) ? (int?)productId : null // Use nullable for ProductID
            };

            bool result = promotionBUS.UpdatePromotion(promotion);

            if (result)
            {
                MessageBox.Show("Cập nhật mã giảm giá thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetPromotionFields();
                LoadPromotions(); // Tải lại danh sách khuyến mãi
            }
            else
            {
                MessageBox.Show("Cập nhật mã giảm giá thất bại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedPromotionID == 0)
            {
                MessageBox.Show("Vui lòng chọn khuyến mái cần xóa.");
                return;
            }

            var confirmResult = MessageBox.Show("Bạn chắc muốn xóa khuyến mãi không?",
                                                 "Xóa khuyễn mãi", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                promotionBUS.DeletePromotion(selectedPromotionID);
                MessageBox.Show("Xóa khuyến mãi thành công.");
                LoadPromotions();
                ResetPromotionFields();
            }
        }

        private void ResetPromotionFields()
        {
            txtPromotionId.Text = GenerateRandomPromotionId();
            txtPromotionName.Clear();
            txtPoint.Clear();
            txtDiscountPercent.Clear();
            txtProductID.Clear();
            dateStartDate.Value = DateTime.Now;
            dateEndDate.Value = DateTime.Now;
            selectedPromotionID = 0; // Reset selected promotion
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial; // or LicenseContext.NonCommercial

            List<PromotionDTO> promotions = promotionBUS.GetAllPromotions();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Promotions");
                    worksheet.Cells[1, 1].Value = "ID";
                    worksheet.Cells[1, 2].Value = "ID";
                    worksheet.Cells[1, 3].Value = "Tên Khuyến Mãi";
                    worksheet.Cells[1, 4].Value = "Phần Trăm Giảm Giá";
                    worksheet.Cells[1, 5].Value = "Point";
                    worksheet.Cells[1, 6].Value = "Ngày Bắt Đầu";
                    worksheet.Cells[1, 7].Value = "Ngày Kết Thúc";
                    worksheet.Cells[1, 8].Value = "Trạng Thái";

                    int row = 2;
                    foreach (var promotion in promotions)
                    {
                        worksheet.Cells[row, 1].Value = promotion.PromotionID;
                        worksheet.Cells[row, 2].Value = promotion.ProductID;
                        worksheet.Cells[row, 3].Value = promotion.PromotionName;
                        worksheet.Cells[row, 4].Value = promotion.DiscountPercent;
                        worksheet.Cells[row, 5].Value = promotion.Point;
                        worksheet.Cells[row, 6].Value = promotion.StartDate.ToString("yyyy-MM-dd");
                        worksheet.Cells[row, 7].Value = promotion.EndDate.ToString("yyyy-MM-dd");
                        worksheet.Cells[row, 8].Value = promotion.IsActive ? "Đang hoạt động" : "Không hoạt động";

                        row++;
                    }

                    package.SaveAs(new FileInfo(saveFileDialog.FileName));
                }

                MessageBox.Show("Xuất khuyến mãi thành công.");
            }
        }

        private bool ValidatePromotionInput()
        {
            // Kiểm tra xem tên khuyến mãi có trống không
            if (string.IsNullOrEmpty(txtPromotionName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khuyến mãi.");
                return false;
            }

            // Kiểm tra phần trăm giảm giá
            if (string.IsNullOrEmpty(txtDiscountPercent.Text))
            {
                MessageBox.Show("Vui lòng nhập phần trăm giảm giá.");
                return false;
            }

            // Kiểm tra số điểm
            if (string.IsNullOrEmpty(txtPoint.Text))
            {
                MessageBox.Show("Vui lòng nhập số điểm.");
                return false;
            }

            // Kiểm tra số điểm có phải là số nguyên không và không âm
            if (!int.TryParse(txtPoint.Text, out int point) || point < 0)
            {
                MessageBox.Show("Vui lòng nhập số điểm hợp lệ (số nguyên không âm).");
                return false;
            }

            // Kiểm tra phần trăm giảm giá có phải là số không và trong khoảng từ 0 đến 100
            if (!decimal.TryParse(txtDiscountPercent.Text, out decimal discount) || discount < 0 || discount > 100)
            {
                MessageBox.Show("Vui lòng nhập phần trăm giảm giá hợp lệ (0-100).");
                return false;
            }

            // Kiểm tra ngày kết thúc có phải sau ngày bắt đầu không
            if (dateEndDate.Value <= dateStartDate.Value)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu.");
                return false;
            }

            return true;
        }


        private void btnLock_Click(object sender, EventArgs e)
        {
            try
            {
                int promotionID = selectedPromotionID;
                if (promotionID <= 0)
                {
                    MessageBox.Show("Vui lòng chọn khuyến mãi cần khóa.");
                    return;
                }

                bool success = promotionBUS.LockPromotion(promotionID);
                if (success)
                {
                    MessageBox.Show("Khuyến mãi đã được khóa.");
                    LoadPromotions();
                    ResetPromotionFields();
                }
                else
                {
                    MessageBox.Show("Khóa khuyến mãi thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnUnLock_Click(object sender, EventArgs e)
        {
            try
            {
                int promotionID = selectedPromotionID;
                if (promotionID <= 0)
                {
                    MessageBox.Show("Vui lòng chọn khuyến mãi cần mở.");
                    return;
                }

                bool success = promotionBUS.UnlockPromotion(promotionID);
                if (success)
                {
                    MessageBox.Show("Khuyến mãi đã được mở.");
                    LoadPromotions();
                    ResetPromotionFields();
                }
                else
                {
                    MessageBox.Show("Mở khuyến mãi thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void ViewPromotion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = ViewPromotion.Rows[e.RowIndex];
                txtPromotionId.Text = row.Cells["PromotionId"].Value.ToString();
                txtPromotionName.Text = row.Cells["PromotionName"].Value.ToString();
                txtDiscountPercent.Text = row.Cells["DiscountPercent"].Value.ToString();
                txtPoint.Text = row.Cells["Point"].Value.ToString();
                dateStartDate.Value = (DateTime)row.Cells["StartDate"].Value;
                dateEndDate.Value = (DateTime)row.Cells["EndDate"].Value;
                selectedPromotionID = Convert.ToInt32(row.Cells["PromotionId"].Value);
                MessageBox.Show("" + selectedPromotionID);
                // Kiểm tra trạng thái hoạt động
                object isActiveValue = row.Cells["IsActive"].Value;

                // Kiểm tra kiểu dữ liệu trước khi chuyển đổi
                bool isActive = false;
                if (isActiveValue is bool)
                {
                    isActive = (bool)isActiveValue;
                }
                else if (isActiveValue is string)
                {
                    // Chuyển đổi từ string sang bool
                    isActive = bool.TryParse((string)isActiveValue, out bool temp) && temp;
                }

                btnLock.Enabled = isActive; // Kích hoạt nút khóa 
                btnUnLock.Enabled = !isActive; // Kích hoạt nút mở khóa
            }
        }

        private void ViewProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = ViewProduct.Rows[e.RowIndex];
                if (row.Cells["ProductID"].Value != null)
                {
                    selectedProductId = int.Parse(row.Cells["ProductID"].Value.ToString());
                    txtProductID.Text = selectedProductId.ToString();
                }
            }
        }

        private void txtSearchPromotion_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchPromotion.Text;
            List<PromotionDTO> filteredPromotions = promotionBUS.GetPromotions(searchText);
            ViewPromotion.DataSource = filteredPromotions;
            ViewPromotion.Refresh();
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchProduct.Text;
            List<ProductDTO> filteredPromotions = promotionBUS.GetProducts(searchText);
            ViewProduct.DataSource = filteredPromotions;
            ViewProduct.Refresh();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            TestCustomerPromotionPanel testCustomerPromotionPanel = new TestCustomerPromotionPanel();
            testCustomerPromotionPanel.Show();
        }
    }
}
