using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = System.Drawing.Font;
using SieuThiMini.BUS;
using SieuThiMini.DTO;
using WinFormsButton = System.Windows.Forms.Button;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SieuThiMini.Panel
{
    public partial class ProductEntryPage : Form
    {
        // Biến toàn cục để kiểm tra xem hóa đơn đã được tạo chưa
        private bool isInvoiceCreated = false;
        private String selecedidNCC, selectedInvoiceId;
        private int __employeeID;
        private int currentPage = 0; // Trang hiện tại
        private int productsPerPage = 4; // Số sản phẩm hiển thị mỗi trang (4x2)
        private List<SupplierProductsDTO> products; // Danh sách sản phẩm
        private SupplierProductsBUS supplierProductsBUS = new SupplierProductsBUS();
        private SuppliersBUS suppliersBUS = new SuppliersBUS();
        private List<CartItemDTO> cartItems = new List<CartItemDTO>(); // Giỏ hàng
        private PurchaseInvoiceBUS PurchaseInvoiceBUS = new PurchaseInvoiceBUS();

        private WinFormsButton btnLeft; // Nút lùi trang
        private WinFormsButton btnRight; // Nút tiến trang
        private bool hasNavigated = false; // Đánh dấu đã chuyển trang ít nhất 1 lần
        private const int panelWidth = 200;     // Chiều rộng panel sản phẩm
        private const int panelHeight = 300;    // Chiều cao panel sản phẩm
        private const int spaceBetween = 50;    // Khoảng cách giữa các panel
        private decimal totalAmount = 0;

        public ProductEntryPage(int employeeID)
        {
            InitializeComponent();
            LoadNCC();
            LoadInvoices();
            // Lấy danh sách sản phẩm từ BUS
            products = supplierProductsBUS.GetAllSupplierProduct();

            // Khởi tạo nút phân trang
            InitializePaginationButtons();

            // Hiển thị sản phẩm ban đầu
            ViewHDN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ViewNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ViewCartItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            __employeeID = employeeID;
            lblEmployeeID.Text = employeeID.ToString();
        }

        public void LoadNCC()
        {
            List<SupplierDTO> ncc = suppliersBUS.GetSuppliersList();
            ViewNCC.DataSource = ncc;
        }
        private void ViewNCC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Kiểm tra nếu đã tạo hóa đơn thành công, cho phép chọn lại nhà cung cấp
                if (isInvoiceCreated)
                {
                    MessageBox.Show("Bạn có thể chọn nhà cung cấp khác sau khi đã tạo hóa đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataGridViewRow row = ViewNCC.Rows[e.RowIndex];
                if (row.Cells["SupplierID"].Value != null)
                {
                    // Nếu chưa tạo hóa đơn, cho phép chọn nhà cung cấp
                    if (string.IsNullOrEmpty(selecedidNCC))
                    {
                        selecedidNCC = row.Cells["SupplierID"].Value.ToString();
                        LoadProductsIntoPanel();
                    }
                    else
                    {
                        MessageBox.Show("Chỉ được chọn 1 nhà cung cấp cho 1 lần nhập hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void LoadProductsIntoPanel()
        {
            // Xóa tất cả các sản phẩm đã hiển thị trước đó
            ClearProductPanels();
            // Lấy dữ liệu sản phẩm từ BUS layer
            products = supplierProductsBUS.GetAllSupplierProductListBySupplier(int.Parse(selecedidNCC));
            string basePath = @"D:\Workspace\C#\MiniStore_C_Sharp"; // Adjust this path as necessary

            // Tính chỉ số bắt đầu và kết thúc của trang hiện tại
            int startIndex = currentPage * 4;  // Mỗi trang chứa tối đa 4 sản phẩm
            int endIndex = Math.Min(startIndex + 4, products.Count);

            int xStart = 60;  // Vị trí X ban đầu
            int yPosition = 300; // Vị trí Y ban đầu

            // Hiển thị sản phẩm trong trang hiện tại
            for (int i = startIndex; i < endIndex; i++)
            {
                var product = products[i];

                // Tạo panel cho mỗi sản phẩm
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

                // Tên sản phẩm
                productPanel.Controls.Add(new Label
                {
                    Text = product.ProductName,
                    Location = new Point(10, 120),
                    AutoSize = true,
                    Font = new Font("Arial", 10, FontStyle.Bold)
                });

                // Giá sản phẩm
                productPanel.Controls.Add(new Label
                {
                    Text = $"Price: {product.Price:C2}",
                    Location = new Point(10, 180),
                    AutoSize = true,
                    ForeColor = Color.Green
                });
                productPanel.Controls.Add(new Label
                {
                    Text = $"Origin: {product.CountryOfOrigin}",
                    Location = new Point(10, 200),
                    AutoSize = true
                });

                // Nút "Add to Cart"
                System.Windows.Forms.Button btnAddToCart = new System.Windows.Forms.Button
                {
                    Text = "Add to Cart",
                    Location = new Point(10, 240),
                    Size = new Size(100, 30)
                };
                btnAddToCart.Click += (sender, e) => AddToCart(product);
                productPanel.Controls.Add(btnAddToCart);

                // Thêm panel sản phẩm vào tabPage1
                tabControl1.TabPages["tabPage1"].Controls.Add(productPanel);

                // Cập nhật vị trí X cho panel tiếp theo
                xStart += panelWidth + spaceBetween;

                // Sau mỗi 4 sản phẩm, di chuyển sang hàng mới
                if ((i - startIndex + 1) % 4 == 0)
                {
                    xStart = 55;  // Reset lại vị trí X để bắt đầu hàng mới
                    yPosition += panelHeight + spaceBetween; // Tăng vị trí Y để tạo hàng mới
                }
            }

            // Cập nhật hiển thị các nút phân trang
            btnLeft.Visible = currentPage > 0; // Ẩn nút trái nếu đang ở trang đầu tiên
            btnRight.Visible = (currentPage + 1) * 4 < products.Count; // Ẩn nút phải nếu không còn sản phẩm trên trang tiếp theo
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

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
                LoadProductsIntoPanel();  // Load sản phẩm của trang trước
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if ((currentPage + 1) * 4 < products.Count)
            {
                currentPage++;
                LoadProductsIntoPanel();  // Load sản phẩm của trang sau
            }
        }

        // Phương thức khởi tạo các nút phân trang
        private void InitializePaginationButtons()
        {
            // Nút trái
            btnLeft = new System.Windows.Forms.Button
            {
                Text = "<",
                Size = new Size(40, 40),
                Location = new Point(10, 455), // Vị trí bên trái
                Visible = false // Ẩn ban đầu
            };
            btnLeft.Click += btnLeft_Click;
            tabControl1.TabPages["tabPage1"].Controls.Add(btnLeft);

            // Nút phải
            btnRight = new System.Windows.Forms.Button
            {
                Text = ">",
                Size = new Size(40, 40),
                Location = new Point(tabControl1.TabPages["tabPage1"].Width - 45, 455), // Vị trí bên phải
                Visible = false // Ẩn ban đầu
            };
            btnRight.Click += btnRight_Click;
            tabControl1.TabPages["tabPage1"].Controls.Add(btnRight);
        }

        private void AddToCart(SupplierProductsDTO product)
        {
            // Check if product is already in the cart
            var existingItem = cartItems.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingItem != null)
            {
                // Update the quantity if the product already exists in the cart
                existingItem.Quantity++;
                MessageBox.Show("Product quantity updated in cart.");
            }
            else
            {
                // Add product to the cart
                CartItemDTO newCartItem = new CartItemDTO
                {
                    ProductId = product.ProductId,
                    ProductTypeID = product.ProductTypeID,
                    Benefits = product.Benefits,
                    Brand = product.Brand,
                    Description = product.Description,
                    Unit = product.Unit,
                    Weight = product.Weight,
                    Ingredients = product.Ingredients,
                    Flavor = product.Flavor,
                    Status = product.Status,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    CountryOfOrigin = product.CountryOfOrigin,
                    ExpirationDate = product.ExpirationDate,
                    ManufactureDate = product.ManufactureDate,
                    Quantity = 1,
                    DiscountedPrice = product.Price,
                    PromotionId = 0, // No promotion initially
                    ImgUrl = product.ImageUrl
                };
                cartItems.Add(newCartItem);
                MessageBox.Show("Product added to cart.");
                LoadCartIntoDataGridView();
            }
        }
        private void btnDelNCC_MouseClick(object sender, MouseEventArgs e)
        {
            ResetAfterInvoiceCreation();
        }
        //tabpage2
        private void DisplayCart()
        {
            // Clear existing controls in tabPage2
            tabControl1.TabPages["tabPage2"].Controls.Clear();

            // Create a scrollable panel to hold cart items
            System.Windows.Forms.Panel scrollablePanel = new System.Windows.Forms.Panel
            {
                AutoScroll = true,
                Size = new Size(tabControl1.TabPages["tabPage2"].Width - 20, tabControl1.TabPages["tabPage2"].Height - 300), // Adjust height for scrollable area
                Location = new Point(10, 10)
            };

            int yPosition = 10; // Initial Y position for each product

            // If the cart is empty
            if (cartItems.Count == 0)
            {
                Label emptyLabel = new Label
                {
                    Text = "Your cart is empty.",
                    AutoSize = true,
                    Location = new Point(10, 10),
                    Font = new Font("Arial", 14, FontStyle.Bold)
                };
                scrollablePanel.Controls.Add(emptyLabel);
                // Set totalAmount to 0 and update lblTotal
                totalAmount = 0;
                lblTotal.Text = totalAmount.ToString("C2");
            }
            else
            {
                foreach (var item in cartItems)
                {
                    // Create a panel for each item
                    System.Windows.Forms.Panel itemPanel = new System.Windows.Forms.Panel
                    {
                        Size = new Size(scrollablePanel.Width - 20, 125),
                        Location = new Point(10, yPosition),
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    // Product image
                    PictureBox productImage = new PictureBox
                    {
                        Size = new Size(100, 100),
                        Location = new Point(10, 10),
                        ImageLocation = item.ImgUrl,
                        SizeMode = PictureBoxSizeMode.Zoom
                    };
                    itemPanel.Controls.Add(productImage);

                    // Product name
                    itemPanel.Controls.Add(new Label
                    {
                        Text = item.ProductName,
                        Location = new Point(120, 10),
                        AutoSize = true,
                        Font = new Font("Arial", 10, FontStyle.Bold)
                    });

                    // Price label (display discounted price if available)
                    decimal displayedPrice = item.Price;
                    itemPanel.Controls.Add(new Label
                    {
                        Text = $"Price: {displayedPrice:C2}",
                        Location = new Point(120, 40),
                        AutoSize = true,
                        ForeColor = Color.Green
                    });

                    // Quantity control (NumericUpDown)
                    NumericUpDown quantityControl = new NumericUpDown
                    {
                        Value = item.Quantity,
                        Minimum = 1,
                        Location = new Point(250, 40),
                        Width = 50
                    };
                    quantityControl.ValueChanged += (sender, e) => UpdateCartQuantity(item.ProductId, (int)quantityControl.Value);
                    itemPanel.Controls.Add(quantityControl);

                    // Delete button to remove item from cart
                    System.Windows.Forms.Button deleteButton = new System.Windows.Forms.Button
                    {
                        Text = "Remove",
                        Location = new Point(430, 10),
                        Width = 60,
                        Height = 30
                    };
                    deleteButton.Click += (sender, e) =>
                    {
                        RemoveFromCart(item.ProductId); // Call the remove method
                        DisplayCart(); // Refresh the panel after deletion
                    };
                    itemPanel.Controls.Add(deleteButton);

                    // Add the item panel to the scrollable panel
                    scrollablePanel.Controls.Add(itemPanel);

                    // Update Y position for the next product panel
                    yPosition += 130; // Adjust height for each product panel
                }

                // Display total amount
                CalculateTotalCartAmount();
                txtTotal.Text = totalAmount.ToString("C2");
            }

            // Add the scrollable panel to tabPage2
            tabControl1.TabPages["tabPage2"].Controls.Add(label1);
            tabControl1.TabPages["tabPage2"].Controls.Add(txtTotal);
            tabControl1.TabPages["tabPage2"].Controls.Add(label2);
            tabControl1.TabPages["tabPage2"].Controls.Add(lblEmployeeID);
            tabControl1.TabPages["tabPage2"].Controls.Add(btnCreate);
            tabControl1.TabPages["tabPage2"].Controls.Add(ViewCartItem);
            tabControl1.TabPages["tabPage2"].Controls.Add(scrollablePanel);
        }

        // Method to update quantity in the cart
        private void UpdateCartQuantity(int productId, int newQuantity)
        {
            var item = cartItems.FirstOrDefault(cartItem => cartItem.ProductId == productId);
            if (item != null)
            {
                item.Quantity = newQuantity;
            }
            CalculateTotalCartAmount();

            // Refresh the cart display
            DisplayCart();
            LoadCartIntoDataGridView();
        }

        // Method to remove item from cart
        private void RemoveFromCart(int productId)
        {
            var itemToRemove = cartItems.FirstOrDefault(item => item.ProductId == productId);
            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
                CalculateTotalCartAmount();
                LoadCartIntoDataGridView();
                txtTotal.Text = totalAmount.ToString("C2");
            }
        }

        // Helper method to calculate total amount in cart, including discounts
        private decimal CalculateTotalCartAmount()
        {
            totalAmount = 0;
            // Kiểm tra nếu danh sách cartItems là null hoặc rỗng
            if (cartItems == null || cartItems.Count == 0)
            {
                return 0; // Không có sản phẩm trong giỏ hàng, trả về tổng tiền là 0
            }

            // Duyệt qua từng sản phẩm trong giỏ hàng để tính tổng tiền
            foreach (var item in cartItems)
            {
                totalAmount += item.Price * item.Quantity; // Cộng vào tổng tiền
            }

            return totalAmount; // Trả về tổng tiền
        }




        // Chuyển đến tab giỏ hàng
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1) // tabPage2
            {
                DisplayCart();
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage2"])
            {
                LoadCartIntoDataGridView();
            }
        }

        private void LoadCartIntoDataGridView()
        {
            // Xóa dữ liệu cũ
            ViewCartItem.Rows.Clear();

            // Thiết lập cột nếu chưa có
            if (ViewCartItem.Columns.Count == 0)
            {
                ViewCartItem.Columns.Add("ProductID", "Product ID");
                ViewCartItem.Columns.Add("ProductName", "Product Name");
                ViewCartItem.Columns.Add("Quantity", "Quantity");
                ViewCartItem.Columns.Add("UnitPrice", "Unit Price");
                ViewCartItem.Columns.Add("TotalPrice", "Total Price");
            }

            // Duyệt qua từng mục trong giỏ hàng và thêm vào DataGridView
            foreach (var item in cartItems)
            {
                decimal totalPrice = item.Price * item.Quantity; // Tổng giá của sản phẩm
                ViewCartItem.Rows.Add(
                    item.ProductId,
                    item.ProductName,
                    item.Quantity,
                    item.Price.ToString("C2"), // Giá đơn vị (định dạng tiền tệ)
                    totalPrice.ToString("C2")  // Tổng giá (định dạng tiền tệ)
                );
            }
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin nhà cung cấp và nhân viên
            string supplierID = selecedidNCC; // ID nhà cung cấp
            string employeeID = __employeeID.ToString(); // ID nhân viên
            bool check = true;

            // Kiểm tra các trường dữ liệu đầu vào
            if (string.IsNullOrEmpty(supplierID))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (ViewCartItem.Rows.Count == 0)
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
            foreach (DataGridViewRow row in ViewCartItem.Rows)
            {
                if (row.Cells["ProductID"].Value != null && row.Cells["Quantity"].Value != null)
                {
                    int productID = int.Parse(row.Cells["ProductID"].Value.ToString());
                    int quantity = int.Parse(row.Cells["Quantity"].Value.ToString());
                    bool stockAvailable = PurchaseInvoiceBUS.ReduceStock(productID, quantity); // Giảm số lượng tồn kho
                    if (!stockAvailable)
                    {
                        MessageBox.Show($"Không đủ số lượng sản phẩm cho {row.Cells["ProductName"].Value}. Vui lòng điều chỉnh số lượng hoặc xóa sản phẩm.", "Lỗi tồn kho", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tabControl1.SelectedTab = tabControl1.TabPages["tabPage1"];
                        return;
                    }
                }
            }

            // Tạo hóa đơn nhập
            PurchaseInvoiceDTO newInvoice = new PurchaseInvoiceDTO
            {
                SupplierID = int.Parse(supplierID),
                EmployeeID = int.Parse(employeeID),
                TotalAmount = 0 // Tổng tiền sẽ được tính sau khi thêm chi tiết hóa đơn
            };

            // Tạo hóa đơn và lấy ID
            string selectedInvoiceId = PurchaseInvoiceBUS.CreatePurchaseInvoice(newInvoice).ToString();
            MessageBox.Show("Hóa đơn nhập được tạo với ID: " + selectedInvoiceId);

            // Kiểm tra nếu hóa đơn đã được tạo thành công
            if (string.IsNullOrEmpty(selectedInvoiceId))
            {
                MessageBox.Show("Không thể tạo hóa đơn nhập. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Khởi tạo tổng tiền hóa đơn
            totalAmount = 0;
            // Lấy danh sách sản phẩm trong giỏ hàng và thêm vào chi tiết hóa đơn
            foreach (var item in cartItems)
            {
                // Tính giá sau khi áp dụng giảm giá (nếu có)
                decimal discountedPrice = item.Price;

                // Tạo đối tượng chi tiết hóa đơn cho từng sản phẩm trong giỏ
                PurchaseInvoiceDetailDTO detail = new PurchaseInvoiceDetailDTO
                {
                    PurchaseInvoiceID = int.Parse(selectedInvoiceId),
                    ProductID = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = discountedPrice,
                };

                // Thêm chi tiết hóa đơn
                PurchaseInvoiceBUS.AddPurchaseInvoiceDetail(detail);

                // Cập nhật tổng số tiền của hóa đơn
                totalAmount += discountedPrice * item.Quantity;
                txtTotal.Text = totalAmount.ToString("C2");

                ProductDTO product = new ProductDTO
                {
                    ProductName = item.ProductName,
                    ProductTypeID = item.ProductTypeID,
                    Brand = item.Brand,
                    CountryOfOrigin = item.CountryOfOrigin,
                    Price = item.Price,
                    StockQuantity = item.Quantity,
                    Unit = item.Unit,
                    Description = item.Description,
                    Ingredients = item.Ingredients,
                    Benefits = item.Benefits,
                    Weight = item.Weight,
                    Flavor = item.Flavor,
                    ImageUrl = item.ImageUrl,
                    Status = item.Status,
                    ManufactureDate = item.ManufactureDate,
                    ExpirationDate = item.ExpirationDate
                };

                // Gọi BUS để thêm hoặc cập nhật sản phẩm vào cơ sở dữ liệu
                PurchaseInvoiceBUS.AddOrUpdateProductInCart(item.ProductName, item.Quantity, product);
            }

            // Cập nhật tổng tiền vào hóa đơn
            bool updateSuccess = PurchaseInvoiceBUS.UpdateTotalAmount(int.Parse(selectedInvoiceId), totalAmount);

            if (updateSuccess)
            {
                isInvoiceCreated = true;
                MessageBox.Show("Hóa đơn nhập đã được tạo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetAfterInvoiceCreation();
                LoadInvoices();
            }
            else
            {
                MessageBox.Show("Có lỗi khi cập nhật tổng tiền hóa đơn. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ResetAfterInvoiceCreation()
        {
            cartItems.Clear();
            txtTotal.Text = String.Empty;
            selecedidNCC = null; // Reset lại nhà cung cấp đã chọn
            isInvoiceCreated = false; // Reset trạng thái đã tạo hóa đơn
            LoadCartIntoDataGridView();
            DisplayCart();
            ClearProductPanels();
        }

        private void txtSearchNCC_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchNCC.Text;
            List<SupplierDTO> filteredPromotions = suppliersBUS.GetSuppliers(searchText);
            ViewNCC.DataSource = filteredPromotions;
            ViewNCC.Refresh();
        }

        //tabpage3
        private void LoadInvoices()
        {
            DataTable dtInvoices = PurchaseInvoiceBUS.GetAllPurchaseInvoices();
            ViewHDN.DataSource = dtInvoices;
        }
        private void LoadPurchaseInvoices(int id)
        {
            DataTable dtInvoices = PurchaseInvoiceBUS.GetPurchaseInvoiceDetailsForNameByInvoiceID(id);
            ViewCTHD.DataSource = dtInvoices;
        }


        private void ViewHDN_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = ViewHDN.Rows[e.RowIndex];
                if (row.Cells["PurchaseInvoiceID"].Value != null)
                {
                    selectedInvoiceId = row.Cells["PurchaseInvoiceID"].Value.ToString();
                    int invoiceID = int.Parse(selectedInvoiceId);
                    LoadPurchaseInvoices(invoiceID);
                }
            }
        }

        private void ViewCTHD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = ViewCTHD.Rows[e.RowIndex];
                if (row.Cells["PurchaseInvoiceID"].Value != null)
                {
                    selectedInvoiceId = row.Cells["PurchaseInvoiceID"].Value.ToString();
                }
            }
        }

        //Chưa làm
        private void txtHDN_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtHDN.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadInvoices();
            }
            else
            {
                DataTable searchResult = PurchaseInvoiceBUS.SearchPurchaseInvoices(keyword);
                ViewHDN.DataSource = searchResult;
            }
        }

        private void ExportPurchaseInvoiceToPDF(int purchaseInvoiceId)
        {
            // Lấy thông tin hóa đơn từ PurchaseInvoices
            DataTable purchaseInvoice = PurchaseInvoiceBUS.GetPurchaseInvoiceById(purchaseInvoiceId);

            if (purchaseInvoice.Rows.Count == 0)
            {
                MessageBox.Show("Purchase Invoice not found!");
                return;
            }

            // Tạo SaveFileDialog để lưu file PDF
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.FileName = $"PurchaseInvoice_{purchaseInvoiceId}.pdf";

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

                        // Thông tin hóa đơn nhập
                        var invoiceRow = purchaseInvoice.Rows[0];
                        doc.Add(new Paragraph($"Purchase Invoice ID: {invoiceRow["PurchaseInvoiceID"]}"));
                        doc.Add(new Paragraph($"Supplier ID: {invoiceRow["SupplierID"]}"));
                        doc.Add(new Paragraph($"Employee ID: {invoiceRow["EmployeeID"]}"));
                        doc.Add(new Paragraph($"Purchase Date: {Convert.ToDateTime(invoiceRow["PurchaseDate"]).ToString("dd/MM/yyyy")}"));
                        doc.Add(new Paragraph($"Total Amount: {invoiceRow["TotalAmount"]}"));
                        doc.Add(new Paragraph("\n"));

                        // Chi tiết sản phẩm
                        PdfPTable table = new PdfPTable(7); 
                        table.AddCell("Product Name");
                        table.AddCell("Brand");
                        table.AddCell("Price");
                        table.AddCell("Quantity");
                        table.AddCell("Manufacture Date");
                        table.AddCell("Expiration Date");
                        table.AddCell("Status");

                        // Lấy chi tiết hóa đơn nhập từ bảng PurchaseInvoiceDetails
                        var purchaseInvoiceDetails = PurchaseInvoiceBUS.GetAllPurchaseInvoicesDetails(purchaseInvoiceId);

                        foreach (DataRow detailRow in purchaseInvoiceDetails.Rows)
                        {
                            int productId = (int)detailRow["ProductID"];
                            SupplierProductsDTO product = supplierProductsBUS.GetProductById(productId); // Lấy thông tin sản phẩm từ ProductBUS

                            if (product != null)
                            {
                                table.AddCell(product.ProductName);
                                table.AddCell(product.Brand);
                                table.AddCell(product.Price.ToString("F2"));
                                table.AddCell(detailRow["quantity"].ToString()); // Số lượng từ chi tiết hóa đơn
                                table.AddCell(product.ManufactureDate.ToString("dd/MM/yyyy"));
                                table.AddCell(product.ExpirationDate.ToString("dd/MM/yyyy"));
                                table.AddCell(product.Status.ToString());
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
                    MessageBox.Show($"An error occurred while exporting the purchase invoice: {ex.Message}");
                }
            }
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            int invoiceId;
            if (int.TryParse(selectedInvoiceId, out invoiceId))
            {
                ExportPurchaseInvoiceToPDF(invoiceId);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xuất ra.");
            }
        }
    }
}
