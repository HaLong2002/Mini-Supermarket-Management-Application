using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using OfficeOpenXml;
using SieuThiMini.BUS;
using SieuThiMini.DAO;
using SieuThiMini.DTO;
using System.Drawing; // Chỉ dùng cho System.Drawing.Image
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Image;
using iText.Layout.Properties;
using iText.Layout.Borders;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using System.Threading.Tasks;
using System.Net;
namespace SieuThiMini.Panel
{
    public partial class ProductPanel : Form
    {
        private int id;

        private ProductBUS productBUS = new ProductBUS();
        private ProductTypeBUS producttypeBUS = new ProductTypeBUS();
        private List<ProductDTO> products;


        private string selectedImageName;
        private ErrorProvider errorProvider = new ErrorProvider();


        public ProductPanel(int id)
        {
            InitializeComponent();
            this.dataGridViewProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProducts_CellClick);
            //this.SearchProductPanel.SearchCompleted += UpdateProductGrid;

            LoadProductTypes();
            // Thiết lập số lượng mặc định khi thêm
            txtStockQuantity.Text = "0";
            txtStockQuantity.Enabled = false; // Không cho phép chỉnh sửa

            LoadProducts(); // Tải danh sách sản phẩm khi khởi động
            this.id = id;
        }



        // Tải danh sách sản phẩm
        private void LoadProducts()
        {
            products = productBUS.GetProducts();

            foreach (var product in products)
            {
                // Kiểm tra hạn sử dụng
                if (product.ExpirationDate < DateTime.Today)
                {
                    // Cập nhật trạng thái thành "Hết hạn sử dụng"
                    product.Status = "Hết hạn sử dụng";
                    productBUS.UpdateProductStatus(product.ProductId, "Hết hạn sử dụng"); // Giả sử bạn có phương thức để cập nhật trạng thái
                }
                else if (product.ExpirationDate < DateTime.Today.AddMonths(1))
                {
                    // Cập nhật trạng thái thành "Gần hết hạn"
                    product.Status = "Gần hết hạn";
                    productBUS.UpdateProductStatus(product.ProductId, "Gần hết hạn"); // Giả sử bạn có phương thức để cập nhật trạng thái
                }
            }

            // Tải lại danh sách sản phẩm
            products = productBUS.GetProducts();
            dataGridViewProducts.DataSource = products; // Hiển thị danh sách sản phẩm trong DataGridView
        }

        // Phương thức để tải danh sách ProductTypes
        private void LoadProductTypes()
        {
            var productTypes = producttypeBUS.GetAllProductTypes();
            comboBoxProductType.Items.Clear(); // Xóa các item cũ trong ComboBox

            foreach (var productType in productTypes)
            {
                comboBoxProductType.Items.Add(productType); // Thêm đối tượng ProductTypeDTO vào ComboBox
            }

            if (comboBoxProductType.Items.Count > 0)
            {
                comboBoxProductType.SelectedIndex = 0; // Chọn giá trị mặc định nếu có
            }
        }


        // Thêm sản phẩm
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInputs()) // Kiểm tra dữ liệu trước khi thêm
            {

                ProductDTO product = new ProductDTO
                {
                    ProductName = txtProductName.Text,
                    // Lấy ProductTypeID từ đối tượng ProductTypeDTO đã chọn
                    ProductTypeID = ((ProductTypeDTO)comboBoxProductType.SelectedItem).ProductTypeID,
                    Brand = txtBrand.Text,
                    CountryOfOrigin = txtCountryOfOrigin.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    StockQuantity = 0, // Mặc định số lượng là 0
                    Unit = txtUnit.Text,
                    Description = txtDescription.Text,
                    Ingredients = txtIngredients.Text,
                    Benefits = txtBenefits.Text,
                    Weight = decimal.Parse(txtWeight.Text),
                    Flavor = txtFlavor.Text,
                    ManufactureDate = dateTimePickerManufactureDate.Value,
                    ExpirationDate = dateTimePickerExpirationDate.Value,
                    ImageUrl = selectedImageName,
                    Status = comboBoxStatus.SelectedItem.ToString()

                };

                productBUS.AddProduct(product);
                LoadProducts(); // Tải lại danh sách sản phẩm
                ClearInputs(); // Xóa các trường nhập liệu
            }
        }

        // Cập nhật sản phẩm
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.CurrentRow != null && ValidateInputs())
            {
                int productId = (int)dataGridViewProducts.CurrentRow.Cells["ProductId"].Value;

                ProductDTO product = new ProductDTO
                {
                    ProductId = productId,
                    ProductName = txtProductName.Text,
                    // Lấy ProductTypeID từ đối tượng ProductTypeDTO đã chọn
                    ProductTypeID = ((ProductTypeDTO)comboBoxProductType.SelectedItem).ProductTypeID,
                    Brand = txtBrand.Text,
                    CountryOfOrigin = txtCountryOfOrigin.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    StockQuantity = int.Parse(dataGridViewProducts.CurrentRow.Cells["StockQuantity"].Value.ToString()), // Không thay đổi số lượng
                    Unit = txtUnit.Text,
                    Description = txtDescription.Text,
                    Ingredients = txtIngredients.Text,
                    Benefits = txtBenefits.Text,
                    Weight = decimal.Parse(txtWeight.Text),
                    Flavor = txtFlavor.Text,
                    ManufactureDate = dateTimePickerManufactureDate.Value,
                    ExpirationDate = dateTimePickerExpirationDate.Value,
                    ImageUrl = selectedImageName,
                    Status = comboBoxStatus.SelectedItem.ToString()
                };

                productBUS.UpdateProduct(product);
                LoadProducts(); // Tải lại danh sách sản phẩm
                ClearInputs(); // Xóa các trường nhập liệu
            }
        }

        // Xóa sản phẩm
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.CurrentRow != null)
            {
                int productId = (int)dataGridViewProducts.CurrentRow.Cells["ProductId"].Value;
                productBUS.DeleteProduct(productId);
                LoadProducts(); // Tải lại danh sách sản phẩm
            }
        }

        // Tìm kiếm sản phẩm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string productName = txtSearch.Text; // Giả sử bạn có một TextBox tên là txtSearch
            var result = productBUS.SearchProducts(productName);
            dataGridViewProducts.DataSource = result; // Hiển thị kết quả tìm kiếm
        }

        // Xóa các trường nhập liệu
        private void ClearInputs()
        {
            txtProductName.Clear();
            comboBoxProductType.SelectedIndex = 0; // Đặt lại giá trị mặc định
            txtBrand.Clear();
            txtCountryOfOrigin.Clear();
            txtPrice.Clear();
            txtUnit.Clear();
            txtDescription.Clear();
            txtIngredients.Clear();
            txtBenefits.Clear();
            txtWeight.Clear();
            txtFlavor.Clear();
            selectedImageName = "";
            comboBoxStatus.SelectedIndex = 0;
            // Đặt lại PictureBox về ảnh mặc định
            pictureBoxProductImage.Image = Properties.Resources.product_default; // Thay "DefaultImage" bằng tên hình ảnh mặc định của bạn

            // Đặt lại các DateTimePicker
            dateTimePickerManufactureDate.Value = DateTime.Today; // Ngày sản xuất là hôm nay
            dateTimePickerExpirationDate.Value = DateTime.Today.AddYears(1); // Ngày hết hạn là một năm sau
        }

        // Kiểm tra dữ liệu nhập vào
        private bool ValidateInputs()
        {
            bool isValid = true; // Biến kiểm tra tổng hợp
            string errorMessage = "Vui lòng nhập đầy đủ và đúng định dạng các trường bắt buộc:";

            // Kiểm tra ProductName
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                txtProductName.BackColor = Color.LightCoral;
                errorMessage += "\n- Tên sản phẩm";
                isValid = false;
            }
            else
            {
                txtProductName.BackColor = Color.White;
            }

            // Kiểm tra Price
            if (string.IsNullOrWhiteSpace(txtPrice.Text) || !decimal.TryParse(txtPrice.Text, out _))
            {
                txtPrice.BackColor = Color.LightCoral;
                errorMessage += "\n- Giá sản phẩm (phải là số)";
                isValid = false;
            }
            else
            {
                txtPrice.BackColor = Color.White;
            }

            // Kiểm tra Brand
            if (string.IsNullOrWhiteSpace(txtBrand.Text))
            {
                txtBrand.BackColor = Color.LightCoral;
                errorMessage += "\n- Nhãn hiệu";
                isValid = false;
            }
            else
            {
                txtBrand.BackColor = Color.White;
            }

            // Kiểm tra CountryOfOrigin
            if (string.IsNullOrWhiteSpace(txtCountryOfOrigin.Text))
            {
                txtCountryOfOrigin.BackColor = Color.LightCoral;
                errorMessage += "\n- Xuất xứ";
                isValid = false;
            }
            else
            {
                txtCountryOfOrigin.BackColor = Color.White;
            }

            // Kiểm tra Unit
            if (string.IsNullOrWhiteSpace(txtUnit.Text))
            {
                txtUnit.BackColor = Color.LightCoral;
                errorMessage += "\n- Đơn vị";
                isValid = false;
            }
            else
            {
                txtUnit.BackColor = Color.White;
            }

            // Kiểm tra Description
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                txtDescription.BackColor = Color.LightCoral;
                errorMessage += "\n- Mô tả";
                isValid = false;
            }
            else
            {
                txtDescription.BackColor = Color.White;
            }

            // Kiểm tra Ingredients
            if (string.IsNullOrWhiteSpace(txtIngredients.Text))
            {
                txtIngredients.BackColor = Color.LightCoral;
                errorMessage += "\n- Thành phần";
                isValid = false;
            }
            else
            {
                txtIngredients.BackColor = Color.White;
            }

            // Kiểm tra Benefits
            if (string.IsNullOrWhiteSpace(txtBenefits.Text))
            {
                txtBenefits.BackColor = Color.LightCoral;
                errorMessage += "\n- Lợi ích";
                isValid = false;
            }
            else
            {
                txtBenefits.BackColor = Color.White;
            }

            // Kiểm tra Weight
            if (string.IsNullOrWhiteSpace(txtWeight.Text) || !decimal.TryParse(txtWeight.Text, out _))
            {
                txtWeight.BackColor = Color.LightCoral;
                errorMessage += "\n- Trọng lượng (phải là số)";
                isValid = false;
            }
            else
            {
                txtWeight.BackColor = Color.White;
            }

            // Kiểm tra Flavor
            if (string.IsNullOrWhiteSpace(txtFlavor.Text))
            {
                txtFlavor.BackColor = Color.LightCoral;
                errorMessage += "\n- Hương vị";
                isValid = false;
            }
            else
            {
                txtFlavor.BackColor = Color.White;
            }

            // Kiểm tra Hình ảnh
            if (string.IsNullOrEmpty(selectedImageName))
            {
                btnEditImage.BackColor = Color.LightCoral;
                errorMessage += "\n- Hình ảnh sản phẩm";
                isValid = false;
            }
            else
            {
                btnEditImage.BackColor = SystemColors.Control; // Màu mặc định của nút
            }

            // Nếu có trường nào không hợp lệ, hiển thị thông báo
            if (!isValid)
            {
                MessageBox.Show(errorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }




        // Sự kiện khi người dùng chọn hàng trong DataGridView để điền thông tin vào các trường nhập liệu
        private void dataGridViewProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewProducts.CurrentRow != null)
            {
                txtProductName.Text = dataGridViewProducts.CurrentRow.Cells["ProductName"].Value.ToString();
                // Cập nhật giá trị cho ComboBox dựa trên ProductTypeID
                int productTypeId = (int)dataGridViewProducts.CurrentRow.Cells["ProductTypeID"].Value;
                comboBoxProductType.SelectedItem = comboBoxProductType.Items.Cast<ProductTypeDTO>()
                    .FirstOrDefault(pt => pt.ProductTypeID == productTypeId);
                txtBrand.Text = dataGridViewProducts.CurrentRow.Cells["Brand"].Value.ToString();
                txtCountryOfOrigin.Text = dataGridViewProducts.CurrentRow.Cells["CountryOfOrigin"].Value.ToString();
                txtPrice.Text = dataGridViewProducts.CurrentRow.Cells["Price"].Value.ToString();
                txtStockQuantity.Text = dataGridViewProducts.CurrentRow.Cells["StockQuantity"].Value.ToString();
                txtUnit.Text = dataGridViewProducts.CurrentRow.Cells["Unit"].Value.ToString();
                txtDescription.Text = dataGridViewProducts.CurrentRow.Cells["Description"].Value.ToString();
                txtIngredients.Text = dataGridViewProducts.CurrentRow.Cells["Ingredients"].Value.ToString();
                txtBenefits.Text = dataGridViewProducts.CurrentRow.Cells["Benefits"].Value.ToString();
                txtWeight.Text = dataGridViewProducts.CurrentRow.Cells["Weight"].Value.ToString();
                txtFlavor.Text = dataGridViewProducts.CurrentRow.Cells["Flavor"].Value.ToString();
                dateTimePickerManufactureDate.Value = (DateTime)dataGridViewProducts.CurrentRow.Cells["ManufactureDate"].Value;
                dateTimePickerExpirationDate.Value = (DateTime)dataGridViewProducts.CurrentRow.Cells["ExpirationDate"].Value;

                // Cập nhật hình ảnh trong PictureBox
                string imageName = dataGridViewProducts.CurrentRow.Cells["ImageUrl"].Value.ToString();
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string imagePath = Path.Combine(basePath, "Images", "product", imageName);
                selectedImageName = imageName;
                // Hiển thị hình ảnh trong PictureBox
                if (System.IO.File.Exists(imagePath))
                {
                    pictureBoxProductImage.Image = System.Drawing.Image.FromFile(imagePath);

                }
                else
                {
                    pictureBoxProductImage.Image = Properties.Resources.product_default;
                    //pictureBoxProductImage.Image = null; // Nếu hình ảnh không tồn tại, đặt hình ảnh về null
                    //MessageBox.Show($"Hình ảnh không tồn tại tại: {imagePath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Gán giá trị cho ComboBox dựa vào Status trong DataGridView
                string statusValue = dataGridViewProducts.CurrentRow.Cells["Status"].Value.ToString();

                if (statusValue == "Còn hạn lâu dài")
                {
                    comboBoxStatus.SelectedIndex = 0;
                }
                else if (statusValue == "Gần hết hạn")
                {
                    comboBoxStatus.SelectedIndex = 1;
                }
                else if (statusValue == "Hết hạn sử dụng")
                {
                    comboBoxStatus.SelectedIndex = 2;
                }
                else if (statusValue == "Hư hỏng")
                {
                    comboBoxStatus.SelectedIndex = 3;
                }
            }
        }


        private void dataGridViewProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dataGridViewProducts.Rows[e.RowIndex];

                // Cập nhật các TextBox
                txtProductId.Text = selectedRow.Cells["ProductId"].Value.ToString();
                txtProductName.Text = selectedRow.Cells["ProductName"].Value.ToString();
                txtBrand.Text = selectedRow.Cells["Brand"].Value.ToString();
                txtCountryOfOrigin.Text = selectedRow.Cells["CountryOfOrigin"].Value.ToString();
                txtPrice.Text = selectedRow.Cells["Price"].Value.ToString();
                txtStockQuantity.Text = selectedRow.Cells["StockQuantity"].Value.ToString();
                txtUnit.Text = selectedRow.Cells["Unit"].Value.ToString();
                txtDescription.Text = selectedRow.Cells["Description"].Value.ToString();
                txtIngredients.Text = selectedRow.Cells["Ingredients"].Value.ToString();
                txtBenefits.Text = selectedRow.Cells["Benefits"].Value.ToString();
                txtWeight.Text = selectedRow.Cells["Weight"].Value.ToString();
                txtFlavor.Text = selectedRow.Cells["Flavor"].Value.ToString();

                // Cập nhật DateTimePicker cho ngày sản xuất
                if (DateTime.TryParse(selectedRow.Cells["ManufactureDate"].Value?.ToString(), out DateTime manufactureDate))
                {
                    dateTimePickerManufactureDate.Value = manufactureDate;
                }

                // Cập nhật DateTimePicker cho ngày hết hạn
                if (DateTime.TryParse(selectedRow.Cells["ExpirationDate"].Value?.ToString(), out DateTime expirationDate))
                {
                    dateTimePickerExpirationDate.Value = expirationDate;
                }

                // Cập nhật đường dẫn hình ảnh
                string imageName = selectedRow.Cells["ImageUrl"].Value.ToString();
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string imagePath = Path.Combine(basePath, "Images", "product", imageName);
                selectedImageName = imageName;

                // Hiển thị hình ảnh trong PictureBox
                if (System.IO.File.Exists(imagePath))
                {
                    pictureBoxProductImage.Image = System.Drawing.Image.FromFile(imagePath);
                }
                else
                {
                    
                    pictureBoxProductImage.Image = Properties.Resources.product_default;
                    //MessageBox.Show($"Hình ảnh không tồn tại tại: {imagePath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Cập nhật giá trị cho ComboBox
                int productTypeId = (int)selectedRow.Cells["ProductTypeID"].Value;
                var productType = comboBoxProductType.Items.Cast<ProductTypeDTO>()
                    .FirstOrDefault(pt => pt.ProductTypeID == productTypeId);

                comboBoxProductType.SelectedItem = productType;

                // Gán giá trị cho ComboBox dựa vào Status trong DataGridView
                string statusValue = selectedRow.Cells["Status"].Value.ToString();

                if (statusValue == "Còn hạn lâu dài")
                {
                    comboBoxStatus.SelectedIndex = 0;
                }
                else if (statusValue == "Gần hết hạn")
                {
                    comboBoxStatus.SelectedIndex = 1;
                }
                else if (statusValue == "Hết hạn sử dụng")
                {
                    comboBoxStatus.SelectedIndex = 2;
                }
                else if (statusValue == "Hư hỏng")
                {
                    comboBoxStatus.SelectedIndex = 3;
                }
            }
        }



        private void btnEditImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImageName = System.IO.Path.GetFileName(openFileDialog.FileName); // Lấy tên ảnh
                    pictureBoxProductImage.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var package = new ExcelPackage(new FileInfo(openFileDialog.FileName)))
                    {
                        var worksheet = package.Workbook.Worksheets[0];
                        int rowCount = worksheet.Dimension.Rows;

                        for (int row = 2; row <= rowCount; row++) // Bắt đầu từ hàng 2 vì hàng 1 là tiêu đề
                        {
                            int productId = int.Parse(worksheet.Cells[row, 1].Value.ToString());

                            // Kiểm tra nếu sản phẩm đã tồn tại
                            if (!productBUS.IsProductIdExists(productId))
                            {
                                ProductDTO product = new ProductDTO
                                {
                                    ProductId = productId,
                                    ProductName = worksheet.Cells[row, 2].Value.ToString(),
                                    ProductTypeID = int.Parse(worksheet.Cells[row, 3].Value.ToString()),
                                    Brand = worksheet.Cells[row, 4].Value.ToString(),
                                    CountryOfOrigin = worksheet.Cells[row, 5].Value.ToString(),
                                    Price = decimal.Parse(worksheet.Cells[row, 6].Value.ToString()),
                                    StockQuantity = 0, // Mặc định số lượng là 0
                                    Unit = worksheet.Cells[row, 8].Value.ToString(),
                                    Description = worksheet.Cells[row, 9].Value.ToString(),
                                    Ingredients = worksheet.Cells[row, 10].Value.ToString(),
                                    Benefits = worksheet.Cells[row, 11].Value.ToString(),
                                    Weight = decimal.Parse(worksheet.Cells[row, 12].Value.ToString()),
                                    Flavor = worksheet.Cells[row, 13].Value.ToString(),
                                    ManufactureDate = DateTime.Parse(worksheet.Cells[row, 14].Value.ToString()),
                                    ExpirationDate = DateTime.Parse(worksheet.Cells[row, 15].Value.ToString()),
                                    ImageUrl = worksheet.Cells[row, 16].Value.ToString(),
                                    Status = worksheet.Cells[row, 17].Value.ToString()
                                };

                                productBUS.AddProduct(product); // Thêm sản phẩm vào database
                            }
                        }
                    }

                    LoadProducts(); // Tải lại danh sách sản phẩm
                    MessageBox.Show("Nhập file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Lưu file Excel";
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string exportPath = Path.Combine(basePath, "Export");

                saveFileDialog.InitialDirectory = exportPath;

                saveFileDialog.FileName = "Products.xlsx"; // Tên file mặc định

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Kiểm tra nếu file đã tồn tại
                    if (System.IO.File.Exists(saveFileDialog.FileName))
                    {
                        MessageBox.Show("File đã tồn tại. Vui lòng chọn tên khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Ngừng hàm nếu file đã tồn tại
                    }

                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        // Tạo một worksheet mới
                        var worksheet = excelPackage.Workbook.Worksheets.Add("Products");

                        // Đặt tiêu đề cho các cột
                        worksheet.Cells[1, 1].Value = "ProductId";
                        worksheet.Cells[1, 2].Value = "ProductName";
                        worksheet.Cells[1, 3].Value = "ProductTypeID";
                        worksheet.Cells[1, 4].Value = "Brand";
                        worksheet.Cells[1, 5].Value = "CountryOfOrigin";
                        worksheet.Cells[1, 6].Value = "Price";
                        worksheet.Cells[1, 7].Value = "StockQuantity";
                        worksheet.Cells[1, 8].Value = "Unit";
                        worksheet.Cells[1, 9].Value = "Description";
                        worksheet.Cells[1, 10].Value = "Ingredients";
                        worksheet.Cells[1, 11].Value = "Benefits";
                        worksheet.Cells[1, 12].Value = "Weight";
                        worksheet.Cells[1, 13].Value = "Flavor";
                        worksheet.Cells[1, 14].Value = "ManufactureDate";
                        worksheet.Cells[1, 15].Value = "ExpirationDate";
                        worksheet.Cells[1, 16].Value = "ImageUrl";
                        worksheet.Cells[1, 17].Value = "Status";

                        // Xuất dữ liệu sản phẩm vào các ô
                        for (int i = 0; i < products.Count; i++)
                        {
                            var product = products[i];
                            worksheet.Cells[i + 2, 1].Value = product.ProductId;
                            worksheet.Cells[i + 2, 2].Value = product.ProductName;
                            worksheet.Cells[i + 2, 3].Value = product.ProductTypeID;
                            worksheet.Cells[i + 2, 4].Value = product.Brand;
                            worksheet.Cells[i + 2, 5].Value = product.CountryOfOrigin;
                            worksheet.Cells[i + 2, 6].Value = product.Price;
                            worksheet.Cells[i + 2, 7].Value = product.StockQuantity;
                            worksheet.Cells[i + 2, 8].Value = product.Unit;
                            worksheet.Cells[i + 2, 9].Value = product.Description;
                            worksheet.Cells[i + 2, 10].Value = product.Ingredients;
                            worksheet.Cells[i + 2, 11].Value = product.Benefits;
                            worksheet.Cells[i + 2, 12].Value = product.Weight;
                            worksheet.Cells[i + 2, 13].Value = product.Flavor;
                            worksheet.Cells[i + 2, 14].Value = product.ManufactureDate.ToString("yyyy-MM-dd");
                            worksheet.Cells[i + 2, 15].Value = product.ExpirationDate.ToString("yyyy-MM-dd");
                            worksheet.Cells[i + 2, 16].Value = product.ImageUrl;
                            worksheet.Cells[i + 2, 17].Value = product.Status;
                        }

                        // Lưu file vào đường dẫn đã chỉ định
                        System.IO.FileInfo fileInfo = new System.IO.FileInfo(saveFileDialog.FileName);
                        excelPackage.SaveAs(fileInfo);

                        // Thông báo cho người dùng
                        MessageBox.Show("Dữ liệu đã được xuất thành công vào file: " + saveFileDialog.FileName, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }


        private void btnFilter_Click(object sender, EventArgs e)
        {
            // Khởi tạo SearchProductPanel nếu chưa được khởi tạo
            if (this.SearchProductPanel == null)
            {
                this.SearchProductPanel = new SearchProductPanel();

                // Đăng ký sự kiện SearchCompleted
                this.SearchProductPanel.SearchCompleted += UpdateProductGrid;

                // Thêm SearchProductPanel vào ProductPanel
                this.Controls.Add(this.SearchProductPanel);
            }

            // Đặt vị trí cho SearchProductPanel ở giữa ProductPanel
            this.SearchProductPanel.Location = new Point(
                (this.Width - this.SearchProductPanel.Width) / 2,
                (this.Height - this.SearchProductPanel.Height) / 2
            );

            // Hiển thị SearchProductPanel
            this.SearchProductPanel.Visible = true; // Đảm bảo nó hiển thị
            this.SearchProductPanel.BringToFront(); // Đảm bảo nó nằm trên cùng
        }

        // Hàm xử lý sự kiện 
        public void UpdateProductGrid(List<ProductDTO> products)
        {
            // Xóa dữ liệu hiện tại trong DataGridView
            dataGridViewProducts.DataSource = null; // Đặt lại DataSource

            // Cập nhật DataGridView với danh sách sản phẩm mới
            dataGridViewProducts.DataSource = products;

            //// Tùy chọn: Đặt lại định dạng cho DataGridView nếu cần
            //dataGridViewProducts.Columns["ProductId"].Visible = false; // Ẩn cột nếu không cần thiết
        }



        public void CreatePdfCatalog(List<ProductDTO> products)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    saveFileDialog.Title = "Lưu Catalog Sản Phẩm";
                    saveFileDialog.FileName = "ProductCatalog.pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        // Hiển thị ảnh loading
                        pictureBoxLoading.Visible = true;
                        pictureBoxLoading.BringToFront();

                        // Chạy task để export PDF mà không làm treo giao diện người dùng
                        Task.Run(() =>
                        {
                            try
                            {
                                using (var writer = new PdfWriter(filePath))
                                {
                                    using (var pdf = new PdfDocument(writer))
                                    {
                                        // Sử dụng font hỗ trợ Unicode tiếng Việt
                                        string fontPath = @"c:\Windows\Fonts\arial.ttf"; // Đường dẫn tới file font Arial
                                        var font = PdfFontFactory.CreateFont(fontPath, "Identity-H");
                                        Document document = new Document(pdf);
                                        document.SetFont(font);

                                        // Thêm tiêu đề
                                        document.Add(new Paragraph("Catalog Sản Phẩm")
                                            .SetFontSize(20)
                                            .SetBold()
                                            .SetTextAlignment(TextAlignment.CENTER));

                                        // Tạo bảng với 2 cột
                                        Table table = new Table(UnitValue.CreatePercentArray(new float[] { 50, 50 }));
                                        table.SetWidth(UnitValue.CreatePercentValue(100)); // Đặt chiều rộng bảng là 100%

                                        int cellCount = 0; // Biến đếm số ô đã thêm

                                        foreach (var product in products)
                                        {
                                            // Tạo một cell cho thông tin sản phẩm với khung viền
                                            Cell cell = new Cell()
                                                .SetBorder(new SolidBorder(1)) // Thêm viền cho ô
                                                .SetPadding(10) // Thêm khoảng cách bên trong ô
                                                .SetHeight(250); // Đặt chiều cao cố định cho ô

                                            // Thêm thông tin sản phẩm
                                            cell.Add(new Paragraph($"Tên sản phẩm: {product.ProductName}"));
                                            cell.Add(new Paragraph($"Thương hiệu: {product.Brand}"));
                                            cell.Add(new Paragraph($"Xuất xứ: {product.CountryOfOrigin}"));
                                            cell.Add(new Paragraph($"Giá: {product.Price}"));
                                            cell.Add(new Paragraph($"Mô tả: {product.Description}"));

                                            // Lấy đường dẫn hình ảnh
                                            string imageName = product.ImageUrl;
                                            string basePath = AppDomain.CurrentDomain.BaseDirectory;
                                            string imagePath = Path.Combine(basePath, "Images", "product", imageName);
                                            string defaultImagePath = Path.Combine(basePath, "Images", "product", "product_default.jpg");


                                            // Kiểm tra nếu hình ảnh tồn tại, nếu không thì sử dụng ảnh mặc định
                                            string finalImagePath = File.Exists(imagePath) ? imagePath : defaultImagePath;

                                            // Thêm hình ảnh vào cell
                                            if (File.Exists(finalImagePath))
                                            {
                                                var image = new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(finalImagePath));
                                                image.SetWidth(100); // Thiết lập chiều rộng hình ảnh
                                                image.SetHeight(100); // Thiết lập chiều cao hình ảnh
                                                cell.Add(image);
                                            }
                                            else
                                            {
                                                //MessageBox.Show(imagePath+defaultImagePath);
                                                cell.Add(new Paragraph("Hình ảnh không tìm thấy."));
                                            }

                                            // Thêm cell vào bảng
                                            table.AddCell(cell);
                                            cellCount++;
                                        }

                                        // Nếu còn sản phẩm chưa đủ 2 sản phẩm trên 1 hàng, thêm ô trống để giữ cho các hàng thẳng hàng
                                        if (cellCount % 2 != 0)
                                        {
                                            // Thêm ô trống có viền để giữ thẳng hàng
                                            table.AddCell(new Cell().SetBorder(new SolidBorder(1)).SetHeight(250));
                                        }

                                        // Thêm bảng vào tài liệu
                                        document.Add(table);

                                        document.Close();
                                    }
                                }

                                // Sau khi hoàn tất, thông báo thành công và ẩn ảnh loading
                                this.Invoke(new Action(() =>
                                {
                                    pictureBoxLoading.Visible = false;
                                    MessageBox.Show("Catalog đã được tạo thành công.");
                                }));
                            }
                            catch (Exception ex)
                            {
                                // Xử lý lỗi và ẩn ảnh loading
                                this.Invoke(new Action(() =>
                                {
                                    pictureBoxLoading.Visible = false;
                                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
                                }));
                            }
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }




        public List<ProductDTO> GetProductsFromDataGridView(DataGridView dataGridView)
        {
            var products = new List<ProductDTO>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Bỏ qua dòng trống
                if (row.IsNewRow) continue;

                // Khởi tạo trọng lượng mặc định
                decimal weight = 0;

                // Lấy trọng lượng và xử lý giá trị
                if (row.Cells["Weight"].Value != null)
                {
                    decimal.TryParse(row.Cells["Weight"].Value.ToString(), out weight);
                }

                var product = new ProductDTO
                {
                    ProductId = row.Cells["ProductId"].Value != null ? (int)row.Cells["ProductId"].Value : 0,
                    ProductName = row.Cells["ProductName"].Value?.ToString() ?? string.Empty,
                    ProductTypeID = row.Cells["ProductTypeID"].Value != null ? (int)row.Cells["ProductTypeID"].Value : 0,
                    Brand = row.Cells["Brand"].Value?.ToString() ?? string.Empty,
                    CountryOfOrigin = row.Cells["CountryOfOrigin"].Value?.ToString() ?? string.Empty,
                    Price = row.Cells["Price"].Value != null ? decimal.Parse(row.Cells["Price"].Value.ToString()) : 0,
                    StockQuantity = row.Cells["StockQuantity"].Value != null ? (int)row.Cells["StockQuantity"].Value : 0,
                    Unit = row.Cells["Unit"].Value?.ToString() ?? string.Empty,
                    Description = row.Cells["Description"].Value?.ToString() ?? string.Empty,
                    Ingredients = row.Cells["Ingredients"].Value?.ToString() ?? string.Empty,
                    Benefits = row.Cells["Benefits"].Value?.ToString() ?? string.Empty,
                    Weight = weight, // Gán trọng lượng đã xử lý
                    Flavor = row.Cells["Flavor"].Value?.ToString() ?? string.Empty,
                    ManufactureDate = row.Cells["ManufactureDate"].Value != null ? DateTime.Parse(row.Cells["ManufactureDate"].Value.ToString()) : DateTime.MinValue,
                    ExpirationDate = row.Cells["ExpirationDate"].Value != null ? DateTime.Parse(row.Cells["ExpirationDate"].Value.ToString()) : DateTime.MinValue,
                    ImageUrl = row.Cells["ImageUrl"].Value?.ToString() ?? string.Empty,
                    Status = row.Cells["Status"].Value?.ToString() ?? string.Empty,
                };

                products.Add(product);
            }

            return products;
        }


        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            List<ProductDTO> products = GetProductsFromDataGridView(dataGridViewProducts);
            CreatePdfCatalog(products);
        }
    }
}
