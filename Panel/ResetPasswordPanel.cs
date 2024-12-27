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
    public partial class ResetPasswordPanel : Form
    {
        private string email;
        EmployeeBUS employeeBUS = new EmployeeBUS();
        private List<EmployeeDTO> employees;

        public ResetPasswordPanel(string email)
        {
            this.email = email;
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string newPass = txtMatKhauMoi.Text;
            string confirmPass = txtNhapLaiMatKhauMoi.Text;
            lblSuccess.Visible = false;
            errorPass.Clear();
            errorConfirmPass.Clear();
            if (string.IsNullOrEmpty(newPass))
            {
                errorPass.SetError(txtMatKhauMoi, "Vui lòng nhập đầy đủ thông tin");
            }
            else if (newPass.Length < 7)
            {
                errorPass.SetError(txtMatKhauMoi, "Mật khẩu phải có hơn 6 ký tự");
            }
            else if (!newPass.Any(char.IsDigit)) // Kiểm tra có số hay không
            {
                errorPass.SetError(txtMatKhauMoi, "Mật khẩu phải chứa ít nhất một số");
            }
            else if (!newPass.Any(char.IsLetter))
            {
                errorPass.SetError(txtMatKhauMoi, "Mật khẩu phải chứa ít nhất một chữ cái");
            }
            if (string.IsNullOrEmpty(confirmPass))
            {
                errorConfirmPass.SetError(txtNhapLaiMatKhauMoi, "Vui lòng nhập đầy đủ thông tin");
            }
            else if (confirmPass != newPass)
            {
                errorConfirmPass.SetError(txtNhapLaiMatKhauMoi, "Mật khẩu xác nhận không khớp");
            }
            if (newPass.Length >= 7 && newPass.Any(char.IsDigit) && newPass.Any(char.IsLetter) && confirmPass == newPass)
            {
                //  MessageBox.Show("Mật khẩu đã được thay đổi thành công!");
                employees = employeeBUS.GetAllEmployees();
                foreach (EmployeeDTO employee in employees)
                {
                    if (employee.Email.Equals(email))
                    {
                        employeeBUS.ChangePassword(employee.EmployeeID, newPass);
                        lblSuccess.Visible = true;
                        lblSuccess.Text = "Mật khẩu được đổi thành công.Bây giờ bạn sẽ được chuyển đến trang đăng nhập";
                        timerHideMessage.Interval = 3000; // 3 giây
                        timerHideMessage.Start();
                    }
                }
            }

        }

        private void btnDangNhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginPanel loginPanel = new LoginPanel();
            loginPanel.Show();
            this.Hide();
        }

        private void btnXacNhan_MouseEnter(object sender, EventArgs e)
        {
            btnXacNhan.BackColor = Color.FromArgb(255, 127, 14);
        }

        private void btnXacNhan_MouseLeave(object sender, EventArgs e)
        {
            btnXacNhan.BackColor = Color.FromArgb(24, 119, 242);
        }

        private void btnDangNhap_MouseEnter(object sender, EventArgs e)
        {
            btnDangNhap.LinkColor = Color.FromArgb(255, 127, 14);
        }

        private void btnDangNhap_MouseLeave(object sender, EventArgs e)
        {
            btnDangNhap.LinkColor = Color.FromArgb(24, 119, 242);
        }

        private void ResetPasswordPanel_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.KeyPreview = true;
            this.AcceptButton = btnXacNhan;
        }

        private void timerHideMessage_Tick(object sender, EventArgs e)
        {
            errorConfirmPass.Clear();
            errorPass.Clear();
            LoginPanel login = new LoginPanel();
            login.Show();
            this.Hide();
            timerHideMessage.Stop();
        }

       
    }
}
