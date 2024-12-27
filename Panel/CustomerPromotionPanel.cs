using SieuThiMini.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SieuThiMini.Panel
{
    public partial class CustomerPromotionPanel : Form
    {
        private PromotionBUS promotionBUS = new PromotionBUS();
        private CustomerPromotionBUS customerPromotion = new CustomerPromotionBUS();
        public string customerID { get; set; }
        private string _customerID;

        public CustomerPromotionPanel(string customerId)
        {
            InitializeComponent();
            _customerID = customerId;
            customerPromotion.DeleteCustomerPromotions();
            LoadPromotionsIntoPanel();
            LoadInfoPromotion();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadInfoPromotion()
        {
            if (!string.IsNullOrEmpty(_customerID))
            {
                List<PromotionDTO> pro = promotionBUS.GetPromotionsWithDetailsByCustomerId(_customerID);
                if (pro != null && pro.Count > 0)
                {
                    dataGridView1.DataSource = pro;
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.Visible = false; // Ẩn tất cả các cột trước
                    }
                    // Chỉ hiển thị các cột liên quan
                    ShowColumnIfExists("PromotionID", "ID");
                    ShowColumnIfExists("PromotionName", "Tên Khuyến Mãi");
                    ShowColumnIfExists("DiscountPercent", "Giảm Giá (%)");
                    ShowColumnIfExists("StartDate", "Ngày Bắt Đầu");
                    ShowColumnIfExists("EndDate", "Ngày Kết Thúc");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã giảm giá cho khách hàng này."+ _customerID);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng");
            }
        }

        // Hàm hỗ trợ kiểm tra và hiển thị cột theo tên
        private void ShowColumnIfExists(string columnName, string headerText)
        {
            if (dataGridView1.Columns[columnName] != null)
            {
                dataGridView1.Columns[columnName].Visible = true;
                dataGridView1.Columns[columnName].HeaderText = headerText;
            }
        }

        private Button buttonLeft;
        private Button buttonRight;
        private int currentPage = 0; // Trang hiện tại
        private const int PromotionsPerPage = 10; // Số mã khuyến mãi trên mỗi trang
        private List<PromotionDTO> promotions = new List<PromotionDTO>(); // Danh sách khuyến mãi

        private const int panelWidth = 140;   // Chiều rộng của panel khuyến mãi
        private const int panelHeight = 140;  // Chiều cao của panel khuyến mãi
        private const int spaceBetween = 15;  // Khoảng cách giữa các panel

        // Phương thức tải các mã khuyến mãi vào panel
        private void LoadPromotionsIntoPanel()
        {
            // Khởi tạo các nút nếu chưa có
            InitializeNavigationButtons();

            // Xóa các panel cũ nếu có
            ClearPromotionPanels();

            // Lấy các mã khuyến mãi có thể hiển thị
            promotions = promotionBUS.GetValidPromotions();
            int start = currentPage * PromotionsPerPage;
            int end = Math.Min(start + PromotionsPerPage, promotions.Count);

            // Tạo và hiển thị các panel cho các mã khuyến mãi trong trang hiện tại
            int xStart = 20;
            int yPosition = 10;
            int xPosition = xStart;

            for (int i = start; i < end; i++)
            {
                var promo = promotions[i];

                // Tạo panel cho từng mã khuyến mãi
                System.Windows.Forms.Panel promoPanel = new System.Windows.Forms.Panel
                {
                    Size = new Size(panelWidth, panelHeight),
                    Location = new Point(xPosition, yPosition),
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Thêm các control vào panel
                promoPanel.Controls.Add(new Label
                {
                    Text = promo.PromotionName,
                    Location = new Point(10, 10),
                    AutoSize = true
                });
                promoPanel.Controls.Add(new Label
                {
                    Text = $"Giảm {promo.DiscountPercent}%",
                    Location = new Point(10, 40),
                    AutoSize = true
                });
                promoPanel.Controls.Add(new Label
                {
                    Text = $"{promo.Point} Điểm",
                    Location = new Point(10, 70),
                    AutoSize = true
                });

                Button btnRedeem = new Button
                {
                    Text = "Đổi Mã",
                    Location = new Point(10, 100),
                    Size = new Size(80, 30)
                };
                btnRedeem.Click += (sender, e) => RedeemPromotion(promo.PromotionID);
                promoPanel.Controls.Add(btnRedeem);

                // Thêm panel vào form
                this.Controls.Add(promoPanel);

                // Cập nhật vị trí cho panel tiếp theo
                xPosition += panelWidth + spaceBetween;
                if ((i - start + 1) % 5 == 0) // Mỗi hàng 5 mã khuyến mãi
                {
                    xPosition = xStart;
                    yPosition += panelHeight + spaceBetween;
                }
            }

            // Cập nhật trạng thái và vị trí của các nút điều hướng
            UpdateNavigationButtons(yPosition);
        }

        // Phương thức khởi tạo các nút điều hướng
        private void InitializeNavigationButtons()
        {
            if (buttonLeft == null)
            {
                buttonLeft = new Button
                {
                    Text = "<",
                    Size = new Size(40, 40),
                    Visible = false // Ẩn ban đầu
                };
                buttonLeft.Click += (sender, e) => ShowPreviousPromotions();
                this.Controls.Add(buttonLeft);
            }

            if (buttonRight == null)
            {
                buttonRight = new Button
                {
                    Text = ">",
                    Size = new Size(40, 40),
                    Visible = false // Ẩn nếu không cần phân trang
                };
                buttonRight.Click += (sender, e) => ShowNextPromotions();
                this.Controls.Add(buttonRight);
            }
        }

        // Phương thức xóa các panel khuyến mãi cũ
        private void ClearPromotionPanels()
        {
            var panelsToRemove = this.Controls.OfType<System.Windows.Forms.Panel>().ToList();
            foreach (var panel in panelsToRemove)
            {
                this.Controls.Remove(panel);
            }
        }

        // Phương thức cập nhật vị trí và trạng thái của các nút điều hướng
        private void UpdateNavigationButtons(int lastYPosition)
        {
            // Tính vị trí Y giữa các hàng khuyến mãi
            int centerY = (lastYPosition + panelHeight) / 2 - buttonLeft.Height / 2;

            // Đặt vị trí nút trái và phải
            buttonLeft.Location = new Point(10, centerY);
            buttonRight.Location = new Point(this.Width - 50, centerY);

            // Cập nhật trạng thái hiển thị của các nút
            buttonLeft.Visible = currentPage > 0;
            buttonRight.Visible = (currentPage + 1) * PromotionsPerPage < promotions.Count;
        }

        // Phương thức hiển thị các mã khuyến mãi ở trang trước
        private void ShowPreviousPromotions()
        {
            if (currentPage > 0)
            {
                currentPage--;
                LoadPromotionsIntoPanel();
            }
        }

        // Phương thức hiển thị các mã khuyến mãi ở trang sau
        private void ShowNextPromotions()
        {
            if ((currentPage + 1) * PromotionsPerPage < promotions.Count)
            {
                currentPage++;
                LoadPromotionsIntoPanel();
            }
        }


        // Hàm xử lý sự kiện "Đổi Mã"
        private void RedeemPromotion(int promotionId)
        {
            MessageBox.Show($"Bạn đã đổi mã giảm giá với ID: {promotionId}");
            MessageBox.Show($"Mã khách hàng: {customerID}");
            bool result = customerPromotion.RedeemPromotion(customerID, promotionId);
            if (result)
            {
                MessageBox.Show("Đổi mã giảm giá thành công!");
                LoadInfoPromotion();
            }
            else
            {
                MessageBox.Show("Đổi mã giảm giá thất bại.");
            }
        }




    }
}
