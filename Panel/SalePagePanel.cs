using iTextSharp.text;
using iTextSharp.text.pdf;
using SieuThiMini.BUS;
using SieuThiMini.DTO;
using Font = System.Drawing.Font;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace SieuThiMini.Panel
{
    public partial class SalePagePanel : Form
    {
        private ProductBUS productBUS = new ProductBUS();
        private PromotionBUS promotionBUS = new PromotionBUS();
        private CustomerBUS customerBUS = new CustomerBUS();
        private InvoiceBUS invoiceBUS = new InvoiceBUS();
        private InvoiceDetailBUS InvoiceDetailBUS = new InvoiceDetailBUS();
        private CustomerPromotionBUS CustomerPromotionBUS = new CustomerPromotionBUS();
        private List<ProductDTO> products = new List<ProductDTO>(); // Danh sách sản phẩm
        private List<CartItemDTO> cartItems = new List<CartItemDTO>(); // List to store cart items

        private int _employeeID;
        private bool isPromotionApplied = false;

        private String selectedCustomerId, selectedPromotionId, selectedProductId, selectedInvoiceId;
        private const int productsPerPage = 6;  // Số sản phẩm mỗi trang (1 hàng x 3 sản phẩm)
        private const int panelWidth = 250;     // Chiều rộng panel sản phẩm
        private const int panelHeight = 300;    // Chiều cao panel sản phẩm
        private const int spaceBetween = 20;    // Khoảng cách giữa các panel
        private int currentPage = 0;            // Trang hiện tại
        private Button btnLeft;
        private Button btnRight;
        private bool hasNavigated = false; // Đánh dấu đã chuyển trang ít nhất 1 lần

        private decimal totalAmount = 0;
        public SalePagePanel(int _employeeID)
        {
            InitializeComponent();
            InitializePaginationButtons();
            LoadProductsIntoPanel();
            LoadCustomers();
            LoadInvoices();
            // Đăng ký sự kiện cho TabControl
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            ViewCartItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ViewCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ViewPromotions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ViewCTHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ViewHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            this._employeeID = _employeeID;

            txtEmployeeID.Text = _employeeID.ToString();
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage2"])
            {
                LoadCartIntoPanel(); // Tải lại giỏ hàng khi chuyển sang tabPage2
            }
        }

        // Phương thức tải sản phẩm theo trang
        private void LoadProductsIntoPanel()
        {
            ClearProductPanels(); // Clear old product panels

            // Get product data from the BUS layer
            products = productBUS.GetProductsForSale();

            // Base path for image files
            string basePath = @"D:\Workspace\C#\MiniStore_C_Sharp"; // Adjust this path as necessary

            // Calculate the start and end index for the current page
            int startIndex = currentPage * productsPerPage;
            int endIndex = Math.Min(startIndex + productsPerPage, products.Count);

            int xStart = 55; // Initial X position
            int yPosition = 0; // Initial Y position

            // Display products on the current page
            for (int i = startIndex; i < endIndex; i++)
            {
                var product = products[i];

                // Check for a current promotion
                var promotion = promotionBUS.GetCurrentPromotion(product.ProductId);
                decimal finalPrice = product.Price;

                // Apply discount if there is a promotion
                if (promotion != null)
                {
                    decimal discountAmount = product.Price * promotion.DiscountPercent / 100;
                    finalPrice -= discountAmount;
                    product.Price = finalPrice; // Save the discounted price back to the product's Price property
                }

                // Create a panel for each product
                System.Windows.Forms.Panel productPanel = new System.Windows.Forms.Panel
                {
                    Size = new Size(panelWidth, panelHeight),
                    Location = new Point(xStart, yPosition),
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Get the image path from local directory
                string imagePath = Path.Combine(basePath, "Images", "product", product.ImageUrl);

                // Add product image
                PictureBox pictureBox = new PictureBox
                {
                    Size = new Size(100, 100),
                    Location = new Point((panelWidth - 100) / 2, 10),
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                // Check if the image file exists
                if (File.Exists(imagePath))
                {
                    pictureBox.Image = System.Drawing.Image.FromFile(imagePath); // Load image from file
                }
                else
                {
                    pictureBox.Image = Properties.Resources.product_default; // Placeholder image for missing files
                }

                productPanel.Controls.Add(pictureBox);

                // Product name
                productPanel.Controls.Add(new Label
                {
                    Text = product.ProductName,
                    Location = new Point(10, 120),
                    AutoSize = true,
                    Font = new Font("Arial", 10, FontStyle.Bold)
                });

                // Product price (display discounted price if there is a promotion)
                productPanel.Controls.Add(new Label
                {
                    Text = promotion != null ? $"Giá Đã Giảm: {finalPrice:C2}" : $"Giá: {finalPrice:C2}",
                    Location = new Point(10, 180),
                    AutoSize = true,
                    ForeColor = Color.Green
                });

                // "Add to Cart" button
                Button btnAddToCart = new Button
                {
                    Text = "Thêm Vào Giỏ",
                    Location = new Point(10, 240),
                    Size = new Size(100, 30)
                };
                btnAddToCart.Click += (sender, e) => AddToCart(product.ProductId);
                productPanel.Controls.Add(btnAddToCart);

                // Add product panel to tabPage1
                tabControl1.TabPages["tabPage1"].Controls.Add(productPanel);

                // Update X position for the next panel
                xStart += panelWidth + spaceBetween;

                // Move to the next row after every 3 products
                if ((i - startIndex + 1) % 3 == 0)
                {
                    xStart = 55; // Reset X position for the next row
                    yPosition += panelHeight + spaceBetween; // Increase Y position for the next row
                }
            }

            // Update pagination button visibility
            btnLeft.Visible = currentPage > 0; // Hide Left button if on the first page
            btnRight.Visible = (currentPage + 1) * productsPerPage < products.Count; // Hide Right button if all products are shown
        }

        // Phương thức xóa các panel sản phẩm cũ
        private void ClearProductPanels()
        {
            var panelsToRemove = tabControl1.TabPages["tabPage1"].Controls.OfType<System.Windows.Forms.Panel>().ToList();
            foreach (var panel in panelsToRemove)
            {
                tabControl1.TabPages["tabPage1"].Controls.Remove(panel);
            }
        }

        // Phương thức thêm sản phẩm vào giỏ hàng
        private void AddToCart(int productId)
        {
            // Check if the product is already in the cart
            var existingItem = cartItems.FirstOrDefault(item => item.ProductId == productId);

            if (existingItem != null)
            {
                // Update quantity
                existingItem.Quantity += 1;
            }
            else
            {
                // Retrieve product information
                var product = products.FirstOrDefault(p => p.ProductId == productId);
                if (product != null)
                {
                    // Add new item to cart
                    cartItems.Add(new CartItemDTO
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        Price = product.Price,
                        Quantity = 1
                    });
                }
            }

            MessageBox.Show($"Product {productId} added to cart!");
            LoadCartIntoPanel(); // Tải lại giỏ hàng sau khi thêm sản phẩm
            LoadCartIntoDataGridView();
        }

        // Nút trái: Quay về trang trước
        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
                hasNavigated = true; // Đánh dấu đã chuyển trang
                LoadProductsIntoPanel();
            }
        }

        // Nút phải: Chuyển sang trang tiếp theo
        private void btnRight_Click(object sender, EventArgs e)
        {
            if ((currentPage + 1) * productsPerPage < products.Count)
            {
                currentPage++;
                hasNavigated = true; // Đánh dấu đã chuyển trang
                LoadProductsIntoPanel();
            }
        }

        // Phương thức khởi tạo nút phân trang
        private void InitializePaginationButtons()
        {
            // Nút trái
            btnLeft = new Button
            {
                Text = "<",
                Size = new Size(40, 40),
                Location = new Point(10, 290), // Vị trí bên trái
                Visible = false // Ẩn ban đầu
            };
            btnLeft.Click += btnLeft_Click;
            tabControl1.TabPages["tabPage1"].Controls.Add(btnLeft);

            // Nút phải
            btnRight = new Button
            {
                Text = ">",
                Size = new Size(40, 40),
                Location = new Point(tabControl1.TabPages["tabPage1"].Width - 45, 290), // Vị trí bên phải
                Visible = false // Ẩn ban đầu
            };
            btnRight.Click += btnRight_Click;
            tabControl1.TabPages["tabPage1"].Controls.Add(btnRight);
        }


        // Method to load cart items into tabPage2
        private void LoadCartIntoPanel()
        {
            // Clear existing controls in tabPage2
            tabControl1.TabPages["tabPage2"].Controls.Clear();
            tabControl1.TabPages["tabPage2"].Controls.Add(btnXN);


            // Create a scrollable panel to hold cart items
            System.Windows.Forms.Panel scrollablePanel = new System.Windows.Forms.Panel
            {
                AutoScroll = true,
                Size = new Size(tabControl1.TabPages["tabPage2"].Width - 20, tabControl1.TabPages["tabPage2"].Height - 300),
                Location = new Point(10, 10)
            };

            int yPosition = 10; // Initial Y position for each product

            foreach (var item in cartItems)
            {
                // Create a panel for each item
                System.Windows.Forms.Panel itemPanel = new System.Windows.Forms.Panel
                {
                    Size = new Size(scrollablePanel.Width - 25, 90),
                    Location = new Point(10, yPosition),
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Product name
                itemPanel.Controls.Add(new Label
                {
                    Text = item.ProductName,
                    Location = new Point(10, 10),
                    AutoSize = true
                });

                // Show Discounted Price if available, otherwise Original Price
                decimal displayedPrice = item.DiscountedPrice > 0 ? item.DiscountedPrice : item.Price;
                itemPanel.Controls.Add(new Label
                {
                    Text = $"Price: {displayedPrice:C2}",
                    Location = new Point(10, 30),
                    AutoSize = true
                });

                // Quantity label
                itemPanel.Controls.Add(new Label
                {
                    Text = "Quantity:",
                    Location = new Point(180, 10),
                    AutoSize = true
                });

                // Quantity control (NumericUpDown)
                NumericUpDown quantityControl = new NumericUpDown
                {
                    Value = item.Quantity,
                    Minimum = 1,
                    Location = new Point(250, 10),
                    Width = 50
                };
                quantityControl.ValueChanged += (sender, e) => UpdateCartQuantity(item.ProductId, (int)quantityControl.Value);
                itemPanel.Controls.Add(quantityControl);

                // Total price per item (based on quantity and discounted price)
                Label totalPriceLabel = new Label
                {
                    Text = $"Total: {(displayedPrice * item.Quantity):C2}",
                    Location = new Point(10, 50),
                    AutoSize = true
                };
                itemPanel.Controls.Add(totalPriceLabel);

                if (!string.IsNullOrEmpty(selectedPromotionId))
                {
                    // Tạo nút Select chỉ khi có mã giảm giá được chọn
                    Button selectButton = new Button
                    {
                        Text = "Chọn",
                        Location = new Point(320, 10),
                        Width = 60,
                        Height = 30
                    };

                    // Xử lý sự kiện Click của nút Select
                    selectButton.Click += (sender, e) =>
                    {
                        selectedProductId = item.ProductId.ToString();

                        // Kiểm tra nếu đã chọn mã giảm giá
                        if (!string.IsNullOrEmpty(selectedPromotionId))
                        {
                            // Hiển thị hộp thoại xác nhận trước khi áp dụng mã giảm giá
                            DialogResult result = MessageBox.Show(
                                $"Bạn có muốn áp dụng mã giảm giá {selectedPromotionId} cho sản phẩm {item.ProductName}?",
                                "Xác nhận",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            );

                            if (result == DialogResult.Yes)
                            {
                                // Tìm sản phẩm đã có mã giảm giá cũ
                                var previousCartItem = cartItems.FirstOrDefault(ci => ci.PromotionId == int.Parse(selectedPromotionId));
                                if (previousCartItem != null)
                                {
                                    // Gỡ bỏ mã giảm giá khỏi sản phẩm cũ và khôi phục giá gốc
                                    previousCartItem.PromotionId = 0;  // Hủy mã giảm giá cũ
                                    previousCartItem.Price = promotionBUS.GetOriginalPrice(previousCartItem.ProductId); // Lấy lại giá gốc

                                    // Kiểm tra xem sản phẩm cũ có áp dụng mã giảm giá khác không
                                    var newPromotion = promotionBUS.GetCurrentPromotion(previousCartItem.ProductId); // Kiểm tra mã giảm giá mới của sản phẩm
                                    if (newPromotion != null)
                                    {
                                        // Nếu có mã giảm giá mới, tính lại giá sau giảm
                                        decimal discountAmount = previousCartItem.Price * newPromotion.DiscountPercent / 100;
                                        previousCartItem.Price -= discountAmount;  // Cập nhật giá giảm
                                    }
                                }

                                // Tìm sản phẩm mới và áp dụng mã giảm giá cho sản phẩm đó
                                var cartItem = cartItems.FirstOrDefault(ci => ci.ProductId == item.ProductId);
                                if (cartItem != null)
                                {
                                    // Áp dụng mã giảm giá cho sản phẩm mới
                                    cartItem.PromotionId = int.Parse(selectedPromotionId);

                                    // Tính giá sau khi áp dụng mã giảm giá
                                    decimal discountedPrice = promotionBUS.CalculateDiscountedPrice(cartItem.ProductId, cartItem.PromotionId, cartItem.Price);

                                    // Cập nhật lại giá của sản phẩm mới sau giảm giá
                                    cartItem.Price = discountedPrice;

                                    // Cập nhật trạng thái mã giảm giá trong cơ sở dữ liệu
                                    int customerId = int.Parse(txtCustomerID.Text);
                                    CustomerPromotionBUS.UpdatePromotionStatus(customerId, cartItem.PromotionId);

                                    // Hiển thị thông báo thành công
                                    MessageBox.Show($"Mã giảm giá {selectedPromotionId} đã được áp dụng cho {cartItem.ProductName}. Giá sau khuyến mãi: {discountedPrice:C}");

                                    // Cập nhật lại giỏ hàng
                                    LoadCartIntoDataGridView();
                                    LoadCartIntoPanel();

                                    // Chuyển sang tabPage4
                                    tabControl1.TabPages["tabPage4"].Enabled = true;
                                }
                            }
                            else
                            {
                                // Nếu người dùng chọn No, không áp dụng mã giảm giá
                                MessageBox.Show("Bạn đã hủy áp dụng mã giảm giá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            // Nếu không chọn mã giảm giá, thông báo người dùng
                            MessageBox.Show("Vui lòng chọn lại mã giảm giá.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    };

                    // Thêm nút vào giao diện (ví dụ, panel hoặc container)
                    itemPanel.Controls.Add(selectButton);
                }





                // Delete button to remove item from cart
                Button deleteButton = new Button
                {
                    Text = "Xóa",
                    Location = new Point(400, 10),
                    Width = 60,
                    Height = 30
                };
                deleteButton.Click += (sender, e) =>
                {
                    RemoveFromCart(item.ProductId); // Call the remove method
                    LoadCartIntoPanel(); // Refresh the panel after deletion
                    LoadCartIntoDataGridView();
                };
                itemPanel.Controls.Add(deleteButton);

                // Add the item panel to the scrollable panel
                scrollablePanel.Controls.Add(itemPanel);

                // Update Y position for the next product panel
                yPosition += 100;
            }

            // Add the scrollable panel to tabPage2
            tabControl1.TabPages["tabPage2"].Controls.Add(scrollablePanel);

            // Display total cart amount
            Label totalAmountLabel = new Label
            {
                Text = $"Total Amount: {CalculateTotalCartAmount():C2}",
                Location = new Point(10, scrollablePanel.Bottom + 10),
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            tabControl1.TabPages["tabPage2"].Controls.Add(totalAmountLabel);

            // Add txtSearchPromotions and ViewPromotions
            tabControl1.TabPages["tabPage2"].Controls.Add(txtSearchPromotions);
            tabControl1.TabPages["tabPage2"].Controls.Add(ViewPromotions);
        }

        // Method to remove item from cart
        private void RemoveFromCart(int productId)
        {
            var itemToRemove = cartItems.FirstOrDefault(item => item.ProductId == productId);
            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
            }
        }


        // Helper method to calculate total amount in cart, including discounts
        private decimal CalculateTotalCartAmount()
        {
            decimal totalAmount = 0;
            foreach (var item in cartItems)
            {
                decimal itemPrice = item.DiscountedPrice > 0 ? item.DiscountedPrice : item.Price;
                totalAmount += itemPrice * item.Quantity;
            }
            return totalAmount;
        }


        // Method to update quantity in the cart
        private void UpdateCartQuantity(int productId, int newQuantity)
        {
            var item = cartItems.FirstOrDefault(cartItem => cartItem.ProductId == productId);
            if (item != null)
            {
                item.Quantity = newQuantity;
            }

            // Reload cart to reflect updated quantities
            LoadCartIntoPanel();
            LoadCartIntoDataGridView();
        }

        private void LoadPromotionsForCustomer(String customerId)
        {
            List<PromotionDTO> promotions = promotionBUS.GetPromotionsDetailsByCustomerId(customerId); // Giả sử bạn có phương thức này
                                                                                                       // Kiểm tra xem có mã giảm giá nào không
            if (promotions == null || promotions.Count == 0)
            {
                // Hiển thị thông báo nếu không có mã giảm giá
                MessageBox.Show("Khách hàng chưa có mã giảm giá nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ViewPromotions.DataSource = null; // Đặt DataSource về null nếu không có dữ liệu
                return; // Kết thúc hàm nếu không có dữ liệu
            }

            // Tải dữ liệu vào DataGridView ở tabPage2
            ViewPromotions.DataSource = promotions;
            // Ẩn cột IsActive nếu tồn tại
            if (ViewPromotions.Columns["IsActive"] != null)
            {
                ViewPromotions.Columns["IsActive"].Visible = false;
                ViewPromotions.Columns["Point"].Visible = false;
                ViewPromotions.Columns["ProductID"].Visible = false;
            }
        }

        private void ViewPromotions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = ViewPromotions.Rows[e.RowIndex];
                if (row.Cells["PromotionID"].Value != null)
                {
                    selectedPromotionId = row.Cells["PromotionID"].Value.ToString();

                    // Kiểm tra nếu mã giảm giá đã được áp dụng cho sản phẩm khác trong giỏ hàng
                    if (cartItems.Any(ci => ci.PromotionId.ToString() == selectedPromotionId))
                    {
                        MessageBox.Show("Mã giảm giá này đã được áp dụng cho sản phẩm khác. Vui lòng chọn mã giảm giá khác.");
                        return; // Dừng không cho phép chọn mã giảm giá này
                    }
                    LoadCartIntoPanel();

                    MessageBox.Show("Mã Giảm Giá đã chọn :" + selectedPromotionId);
                    // Set flag and disable tabPage4
                    isPromotionApplied = true;
                    tabControl1.TabPages["tabPage4"].Enabled = false;
                }
            }
        }

        private void txtSearchPromotions_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearchPromotions.Text;
            List<PromotionDTO> searchResults = promotionBUS.SearchPromotions(keyword);
            ViewPromotions.DataSource = searchResults;
        }

        private void btnXN_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn mã giảm giá chưa
            if (!string.IsNullOrEmpty(selectedPromotionId))
            {
                // Hiển thị hộp thoại hỏi xác nhận
                DialogResult result = MessageBox.Show(
                    $"Bạn có muốn áp dụng mã giảm giá ?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    // Kiểm tra nếu sản phẩm chưa được chọn
                    if (string.IsNullOrEmpty(selectedProductId))
                    {
                        MessageBox.Show("Bạn chưa chọn sản phẩm. Vui lòng chọn sản phẩm trước khi áp dụng mã giảm giá.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Dừng xử lý nếu chưa chọn sản phẩm
                    }
                    // Nếu chọn Yes: giữ mã giảm giá và chuyển sang tabPage4
                    MessageBox.Show($"Mã giảm giá sẽ được áp dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    // Nếu chọn No: xóa mã giảm giá và tiếp tục
                    selectedPromotionId = null;
                    MessageBox.Show("Mã giảm giá đã bị hủy. Tiếp tục mà không áp dụng khuyến mãi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Nếu chưa chọn mã giảm giá: chỉ chuyển sang tabPage4
                MessageBox.Show("Không có mã giảm giá được chọn. Tiếp tục mà không áp dụng khuyến mãi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Luôn chuyển sang tabPage4
            tabControl1.SelectedTab = tabControl1.TabPages["tabPage4"];
        }

        //tabPage3
        private void LoadCustomers()
        {
            List<CustomerDTO> customers = customerBUS.GetAllCustomers();
            ViewCustomer.DataSource = customers;
        }

        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearchCustomer.Text.Trim();
            List<CustomerDTO> searchResults = customerBUS.SearchCustomers(keyword);

            // Cập nhật DataGridView với kết quả tìm kiếm
            ViewCustomer.DataSource = searchResults;
        }

        private void ViewCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = ViewCustomer.Rows[e.RowIndex];
                if (row.Cells["CustomerID"].Value != null)
                {
                    selectedCustomerId = row.Cells["CustomerID"].Value.ToString();
                    txtCustomerID.Text = selectedCustomerId;
                    // Lưu ID khách hàng đã chọn (có thể lưu vào biến toàn cục hoặc truyền đến phương thức)
                    LoadPromotionsForCustomer(selectedCustomerId);
                    tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"]; // Chuyển sang tabPage2
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string gender = "";
            bool check = true;
            DateTime dateofbirth = cbbDayOfBirth.Value;
            if (rdbNu.Checked)
            {
                gender = "Nữ";
            }
            else if (rdnNam.Checked)
            {
                gender = "Nam";
            }
            else if (rdbKhac.Checked)
            {
                gender = "Khác";
            }
            int year = cbbDayOfBirth.Value.Year;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show(txtName, "Không bỏ trống dữ liệu");
                check = false;
            }
            if (string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show(txtPhoneNumber, "Không bỏ trống dữ liệu");
                check = false;
            }
            else if (phoneNumber.Length != 10)
            {
                MessageBox.Show(txtPhoneNumber, "Số điện thoại phải bao gồm 10 chữ số");
                check = false;
            }
            else if (customerBUS.IsPhoneExists(phoneNumber))
            {
                MessageBox.Show(txtPhoneNumber, "Số điện thoại đã tồn tại!");
                check = false;
            }
            if (string.IsNullOrEmpty(gender))
            {
                MessageBox.Show(groupGioiTinh, "Không bỏ trống dữ liệu");
                check = false;
            }
            if (year > 2012 || year < 1924)
            {
                MessageBox.Show(cbbDayOfBirth, "Năm sinh không hợp lệ !");
                check = false;
            }
            if (check)
            {
                CustomerDTO customer = new CustomerDTO();

                customer.Name = name;
                customer.Phone = phoneNumber;
                customer.Gender = gender;
                customer.DayOfBirth = dateofbirth;
                customerBUS.AddCustomer(customer);
                LoadCustomers();
            }
        }

        private void btnCreateInvoice_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin khách hàng và nhân viên
            string customerID = txtCustomerID.Text;
            string employeeID = txtEmployeeID.Text;
            bool check = true;

            // Kiểm tra các trường dữ liệu đầu vào
            if (string.IsNullOrEmpty(customerID))
            {
                MessageBox.Show("Vui lòng chọn khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedTab = tabControl1.TabPages["tabPage3"];
                check = false;
                return;
            }

            if (string.IsNullOrEmpty(employeeID))
            {
                MessageBox.Show("Vui lòng cập nhật nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                check = false;
                return;
            }

            // Kiểm tra giỏ hàng có sản phẩm hay không
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống. Vui lòng thêm sản phẩm vào giỏ hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedTab = tabControl1.TabPages["tabPage1"];
                check = false;
                return;
            }

            // Nếu thông tin không đủ, không tạo hóa đơn
            if (!check)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi tạo hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra đủ số lượng hàng tồn kho cho từng sản phẩm trong giỏ
            foreach (var item in cartItems)
            {
                bool stockAvailable = InvoiceDetailBUS.ReduceStock(item.ProductId, item.Quantity);
                if (!stockAvailable)
                {
                    MessageBox.Show($"Không đủ số lượng sản phẩm cho {item.ProductName}. Vui lòng điều chỉnh số lượng hoặc xóa sản phẩm.", "Lỗi tồn kho", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
                    return;
                }
            }

            // Tạo hóa đơn
            InvoiceDTO newInvoice = new InvoiceDTO
            {
                EmployeeID = int.Parse(employeeID),
                CustomerID = int.Parse(customerID),
                InvoiceDate = DateTime.Now,
                PointEarned = 0,
                TotalAmount = 0 // To be updated after adding items
            };

            // Tạo hóa đơn và lấy ID
            selectedInvoiceId = invoiceBUS.CreateInvoice(newInvoice).ToString();
            MessageBox.Show("Hóa đơn được tạo với ID: " + selectedInvoiceId);

            // Kiểm tra nếu hóa đơn đã được tạo thành công
            if (string.IsNullOrEmpty(selectedInvoiceId))
            {
                MessageBox.Show("Không thể tạo hóa đơn. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Khởi tạo tổng tiền hóa đơn
            totalAmount = 0;

            // Lấy danh sách sản phẩm trong giỏ hàng và thêm vào chi tiết hóa đơn
            foreach (var item in cartItems)
            {
                // Lấy mã giảm giá của từng sản phẩm
                int? promotionID = item.PromotionId;

                // Tính giá sau khi áp dụng giảm giá (nếu có)
                decimal discountedPrice = item.Price;

                // Tạo đối tượng chi tiết hóa đơn cho từng sản phẩm trong giỏ
                InvoiceDetailDTO detail = new InvoiceDetailDTO
                {
                    InvoiceID = int.Parse(selectedInvoiceId),
                    ProductID = item.ProductId,
                    Quantity = item.Quantity,
                    Price = discountedPrice,
                    PromotionID = string.IsNullOrEmpty(selectedPromotionId) ? (int?)null : (int?)int.Parse(selectedPromotionId)
                };

                // Thêm chi tiết hóa đơn
                InvoiceDetailBUS.AddInvoiceDetail(detail);

                // Cập nhật tổng số tiền của hóa đơn
                totalAmount += discountedPrice * item.Quantity;
            }

            // Tính điểm tích lũy dựa trên tổng tiền
            int pointsEarned = CalculatePoints(totalAmount);

            // Cập nhật tổng tiền và điểm tích lũy vào hóa đơn
            InvoiceBUS.UpdateInvoiceTotalAndPoints(int.Parse(selectedInvoiceId), totalAmount, pointsEarned);

            // Cập nhật điểm thưởng của khách hàng
            bool rewardUpdated = invoiceBUS.UpdateCustomerRewardPoints(int.Parse(customerID), pointsEarned);

            if (rewardUpdated)
            {
                MessageBox.Show("Điểm thưởng của khách hàng đã được cập nhật thành công.");
            }
            else
            {
                MessageBox.Show("Lỗi khi cập nhật điểm thưởng của khách hàng.");
            }

            ResetAfterInvoiceCreation();
            LoadCustomers();
            LoadInvoices();
        }

        private void ResetAfterInvoiceCreation()
        {
            // Clear cart items
            cartItems.Clear();

            // Clear selected promotion and product IDs
            selectedPromotionId = null;
            selectedProductId = null;
            selectedInvoiceId = null;

            // Clear customer and employee ID fields
            txtCustomerID.Text = string.Empty;

            // Clear displayed cart items on UI
            tabControl1.TabPages["tabPage2"].Controls.Clear();

            // Optionally reset promotion-related UI elements (e.g., txtSearchPromotions)
            txtSearchPromotions.Text = string.Empty;

            // Clear total amount label and reset it to zero if displayed on UI
            totalAmount = 0;
            UpdateTotalAmountLabel();
            LoadCartIntoDataGridView();

            // Show a message confirming reset
            MessageBox.Show("Giỏ hàng và các lựa chọn đã được đặt lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Optional helper method to update total amount label
        private void UpdateTotalAmountLabel()
        {
            Label totalAmountLabel = new Label
            {
                Text = $"Total Amount: {totalAmount:C2}",
                Location = new Point(10, 20), // Update based on layout
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            tabControl1.TabPages["tabPage2"].Controls.Add(totalAmountLabel);
        }


        private void ViewCartItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadCartIntoDataGridView()
        {
            // Xóa dữ liệu cũ
            ViewCartItem.Rows.Clear();

            // Thêm các cột vào DataGridView nếu chưa có
            if (ViewCartItem.Columns.Count == 0)
            {
                ViewCartItem.Columns.Add("ProductName", "Product Name");
                ViewCartItem.Columns.Add("Price", "Price");
                ViewCartItem.Columns.Add("Quantity", "Quantity");
                ViewCartItem.Columns.Add("Total", "Total");
            }

            // Thêm sản phẩm vào DataGridView
            foreach (var item in cartItems)
            {
                decimal total = item.Price * item.Quantity;
                ViewCartItem.Rows.Add(item.ProductName, item.Price.ToString("C2"), item.Quantity, total.ToString("C2"));
            }

            // Cập nhật tổng tiền
            decimal totalAmount = CalculateTotalCartAmount();
            lblThanhTien.Text = $"Total Amount: {totalAmount:C2}";

        }

        // Hàm tính toán điểm tích lũy, giả sử quy tắc 1 điểm cho mỗi 1000 đơn vị tiền
        private int CalculatePoints(decimal totalAmount)
        {
            return (int)(totalAmount / 10000);
        }

        //tabpage5
        private void LoadInvoices()
        {
            DataTable dtInvoices = invoiceBUS.GetAllInvoices();
            ViewHD.DataSource = dtInvoices;
        }
        private void LoadInvoiceDetails(int invoiceID)
        {
            DataTable dtDetails = InvoiceDetailBUS.GetInvoiceDetailsForNameByInvoiceID(invoiceID);
            ViewCTHD.DataSource = dtDetails;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadInvoices();
            }
            else
            {
                DataTable searchResult = invoiceBUS.SearchInvoices(keyword);
                ViewHD.DataSource = searchResult;
            }
        }

        private void VỉewHD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = ViewHD.Rows[e.RowIndex];
                if (row.Cells["InvoiceID"].Value != null)
                {
                    selectedInvoiceId = row.Cells["InvoiceID"].Value.ToString();
                    int invoiceID = int.Parse(selectedInvoiceId);
                    LoadInvoiceDetails(invoiceID);
                }
            }
        }

        private void ViewCTHD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = ViewHD.Rows[e.RowIndex];
                if (row.Cells["InvoiceID"].Value != null)
                {
                    selectedInvoiceId = row.Cells["InvoiceID"].Value.ToString();
                }
            }
        }

        // Phương thức xuất hóa đơn PDF dựa trên InvoiceID đã chọn
        private void ExportInvoiceToPDF(int invoiceId)
        {
            DataTable invoice = invoiceBUS.GetInvoice(invoiceId);

            if (invoice.Rows.Count == 0)
            {
                MessageBox.Show("Invoice not found!");
                return;
            }

            // Tạo SaveFileDialog để lưu file PDF
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.FileName = $"Invoice_{invoiceId}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        Document doc = new Document(PageSize.A4);
                        PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                        doc.Open();

                        // Thông tin hóa đơn
                        var invoiceRow = invoice.Rows[0];
                        doc.Add(new Paragraph($"Invoice ID: {invoiceRow["InvoiceID"]}"));
                        doc.Add(new Paragraph($"Employee ID: {invoiceRow["EmployeeID"]}"));
                        doc.Add(new Paragraph($"Customer ID: {invoiceRow["CustomerID"]}"));
                        doc.Add(new Paragraph($"Date: {Convert.ToDateTime(invoiceRow["InvoiceDate"]).ToString("dd/MM/yyyy")}"));
                        doc.Add(new Paragraph($"Total Amount: {invoiceRow["TotalAmount"]}"));
                        doc.Add(new Paragraph($"Points Earned: {invoiceRow["PointEarned"]}"));
                        doc.Add(new Paragraph("\n"));

                        // Chi tiết sản phẩm
                        PdfPTable table = new PdfPTable(7); // 7 cột
                        table.AddCell("Product Name");
                        table.AddCell("Brand");
                        table.AddCell("Price");
                        table.AddCell("Quantity");
                        table.AddCell("Manufacture Date");
                        table.AddCell("Expiration Date");
                        table.AddCell("Status");

                        // Duyệt qua các chi tiết hóa đơn và thêm sản phẩm vào bảng
                        var invoiceDetails = InvoiceDetailBUS.GetInvoiceDetailsByInvoiceID(invoiceId); // Lấy chi tiết hóa đơn

                        foreach (DataRow detailRow in invoiceDetails.Rows)
                        {
                            int productId = (int)detailRow["ProductID"];
                            ProductDTO product = invoiceBUS.GetProductDetailsByInvoiceID(productId); // Lấy thông tin sản phẩm từ ProductID

                            if (product != null)
                            {
                                // Kiểm tra null và thay thế bằng chuỗi trống hoặc giá trị mặc định
                                table.AddCell(product.ProductName ?? "N/A"); // Nếu null, thêm "N/A"
                                table.AddCell(product.Brand ?? "N/A");
                                table.AddCell(product.Price != 0.0m ? product.Price.ToString("F2") : "0.00");
                                table.AddCell(detailRow["quantity"] != DBNull.Value ? detailRow["quantity"].ToString() : "0"); // Kiểm tra số lượng
                                table.AddCell(product.ManufactureDate != null ? ((DateTime)product.ManufactureDate).ToString("dd/MM/yyyy") : "N/A");
                                table.AddCell(product.ExpirationDate != null ? ((DateTime)product.ExpirationDate).ToString("dd/MM/yyyy") : "N/A");
                                table.AddCell(product.Status ?? "Unknown");

                            }
                        }

                        doc.Add(table);
                        doc.Close();
                        writer.Close();
                    }

                    MessageBox.Show("Xuất hóa đơn thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while exporting the invoice: {ex.Message}");
                }
            }
        }






        private void btnExport_Click(object sender, EventArgs e)
        {
            int invoiceId;
            if (int.TryParse(selectedInvoiceId, out invoiceId))
            {
                ExportInvoiceToPDF(invoiceId);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xuất ra.");
            }
        }


    }
}
