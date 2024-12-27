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
    public partial class FogotPasswordPanel : Form
    {
        EmployeeBUS employeeBUS = new EmployeeBUS();
        public string email { get; private set; }
        public FogotPasswordPanel()
        {
            InitializeComponent();
        }

        private void btnDangNhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginPanel login = new LoginPanel();
            login.Show();
            this.Hide();
        }

        private void FogotPasswordPanel_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.KeyPreview = true;
            this.AcceptButton = btnXacNhan;
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

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            errorEmail.Clear();
            string email_ = txttEmail.Text;
            if (string.IsNullOrEmpty(email_))
            {
                errorEmail.SetError(txttEmail, "Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                if (!employeeBUS.CheckEmailExists(email_))
                {
                    errorEmail.SetError(txttEmail, "Không tìm thấy tài khoản trong hệ thống.");
                }
                else
                {
                    ResetPasswordPanel resetPasswordPanel = new ResetPasswordPanel(email_);
                    resetPasswordPanel.Show();
                    this.Hide();
                }
            }
        }

        private void btnDangNhap_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginPanel loginPanel = new LoginPanel();
            loginPanel.Show();
            this.Hide();
        }

       
    }
}
