using AxWMPLib;
using SieuThiMini.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SieuThiMini.Panel
{
    public partial class HomePage : Form
    {
        EmployeeBUS employeeBUS = new EmployeeBUS();
        private Button lastClickedButton = null;
        private int id;

        public HomePage(int id)
        {
            InitializeComponent();
            this.id = id;
            ConfigureTableLayoutPanel();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.WindowState = FormWindowState.Maximized;

            // Assuming your video is in the Images folder of your project
            string videoPath = Path.Combine(Application.StartupPath, "Images", "VideoIntroduction.mp4");

            VideoIntroduction.URL = videoPath;
            VideoIntroduction.Ctlcontrols.play();
        }

        private void ConfigureTableLayoutPanel()
        {
            string role = employeeBUS.GetRoleById(id);
            EmployeeDTO emp = employeeBUS.GetEmployeeById(id);
            string name_account = emp.Name;
            string img_u = emp.Img;
            btnTaiKhoan.Text = name_account;
            //btnTaiKhoan.Image = Image.FromFile("C:\\Users\\MyLy\\Documents\\GitHub\\MiniStore_C_Sharp\\Images\\user\\" + img_u);
            //btnTaiKhoan.ImageAlign = ContentAlignment.MiddleLeft;
            //btnTaiKhoan.BackgroundImageLayout = ImageLayout.Zoom;
            if (role == "Nhân viên bán hàng")
            {
                tableLayoutPanel_ChucNang.RowStyles[1] = new RowStyle(SizeType.Absolute, 0F);
                tableLayoutPanel_ChucNang.RowStyles[8] = new RowStyle(SizeType.Absolute, 0F);
                tableLayoutPanel_ChucNang.RowStyles[7] = new RowStyle(SizeType.Absolute, 0F);
            }
            else if (role == "Nhân viên nhập hàng")
            {
                tableLayoutPanel_ChucNang.RowStyles[3] = new RowStyle(SizeType.Absolute, 0F);
                tableLayoutPanel_ChucNang.RowStyles[4] = new RowStyle(SizeType.Absolute, 0F);
                tableLayoutPanel_ChucNang.RowStyles[5] = new RowStyle(SizeType.Absolute, 0F);
                tableLayoutPanel_ChucNang.RowStyles[6] = new RowStyle(SizeType.Absolute, 0F);
                tableLayoutPanel_ChucNang.RowStyles[7] = new RowStyle(SizeType.Absolute, 0F);
            }

        }
        private void Button_MouseClick(object sender, MouseEventArgs e)
        {
            var btn = (Button)sender;

            // Chỉnh lại màu button đã nhấn trước đó
            if (lastClickedButton != null && lastClickedButton != btn)
            {
                lastClickedButton.BackColor = Color.FromArgb(123, 196, 77);
            }

            btn.BackColor = Color.FromArgb(255, 127, 14);
            lastClickedButton = btn;

            // Mở childForm trong panel
            switch (btn.Name)
            {
                case "btnTaiKhoan":
                    ProfilePanel profilePanel = new ProfilePanel(id);
                    OpenFormInPanel(profilePanel);
                    break;

                case "btnNhaCungCap":
                    SuppliersPanel supplierForm = new SuppliersPanel(id);
                    OpenFormInPanel(supplierForm);
                    break;

                case "btnSanPham":
                    ProductPanel productPanel = new ProductPanel(id);
                    OpenFormInPanel(productPanel);
                    //CategoryPanel categoryPanel = new CategoryPanel(id);
                    //OpenFormInPanel(categoryPanel);
                    break;

                case "btnHoaDon":
                    ProductEntryPage page = new ProductEntryPage(id);
                    OpenFormInPanel(page);
                    break;

                case "btnKhachHang":
                    CustomersManagementPanel customersManagementPanel = new CustomersManagementPanel(id);
                    OpenFormInPanel(customersManagementPanel);
                    break;

                case "btnBanHang":
                    SalePagePanel salePagePanel = new SalePagePanel(id);
                    OpenFormInPanel(salePagePanel);
                    break;

                case "btnKhuyenMai":
                    PromotionPanel promotionPanel = new PromotionPanel(id);
                    OpenFormInPanel(promotionPanel);
                    break;

                case "btnNhanVien":
                    EmployeesManagementPanel employeesManagementPanel = new EmployeesManagementPanel();
                    OpenFormInPanel(employeesManagementPanel);
                    break;

                case "btnThongKe":
                    StatisticsPanel statisticsPanel = new StatisticsPanel();
                    OpenFormInPanel(statisticsPanel);
                    break;

                case "btnDangXuat":
                    LoginPanel login = new LoginPanel();
                    login.Show();
                    this.Hide();
                    break;

            }

        }

        // Method to open the child form inside the panel
        private void OpenFormInPanel(Form childForm)
        {
            // Close any existing form in the panel
            panelContainer.Controls.Clear();

            // Set the child form's properties to embed it inside the panel
            childForm.TopLevel = false;  // Make it a non-top-level form
            childForm.FormBorderStyle = FormBorderStyle.None;  // Remove border
            childForm.Dock = DockStyle.Fill;  // Fill the panel completely

            // Add the child form to the panel's controls
            panelContainer.Controls.Add(childForm);

            childForm.Show();
        }

        private void VideoIntroduce_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 8) // WMPPlayState.wmppsMediaEnded
            {
                // Pause the video at the last frame
                VideoIntroduction.Ctlcontrols.pause();

                // Optionally: Restart the video after a short delay
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                //timer.Interval = 500; // 1 second delay
                timer.Tick += (s, args) =>
                {
                    timer.Stop();
                    // Set the video position to the beginning
                    VideoIntroduction.Ctlcontrols.currentPosition = 0;
                    VideoIntroduction.Ctlcontrols.play(); // Start playing again
                };
                timer.Start(); // Start the timer
            }
        }

        private void pictureBox_LogoStore_Click(object sender, EventArgs e)
        {

        }
    }
}
