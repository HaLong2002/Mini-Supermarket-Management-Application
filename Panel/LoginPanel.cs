using SieuThiMini.BUS;
using SieuThiMini.DAO;
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
    public partial class LoginPanel : Form
    {
        EmployeeBUS employeeBUS = new EmployeeBUS();

        public int id { get; private set; }

        public LoginPanel()
        {
            InitializeComponent();

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            errorEmail.Clear();
            errorPass.Clear();
            string email = txtEmail.Text;
            string pass = txtMatKhau.Text;
            int? employeeId = employeeBUS.Login(email, pass);
            if (string.IsNullOrEmpty(email))
            {
                errorEmail.SetError(txtEmail, "Vui lòng nhập thông tin đăng nhập");
            }
            if (string.IsNullOrEmpty(pass))
            {
                errorPass.SetError(txtMatKhau, "Vui lòng nhập thông tin đăng nhập");
            }
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(pass))

                if (!employeeBUS.CheckEmailExists(email))
                {
                    errorEmail.SetError(txtEmail, "Không tìm thấy tài khoản");
                }
                else
                {
                    if (employeeId.HasValue)
                    {
                        HomePage home = new HomePage(employeeId.Value);
                        home.Show();
                        this.Hide();
                    }
                    else
                    {
                        errorPass.SetError(txtMatKhau, "Mật khẩu không đúng.");
                    }
                }
        }

        private void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            SignUpPanel signhup = new SignUpPanel();
            signhup.Show();
            this.Close();
        }

        private void btnQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FogotPasswordPanel forgotpassword = new FogotPasswordPanel();
            forgotpassword.Show();
            this.Hide();
        }

        private void LoginPanel_Load(object sender, EventArgs e)
        {

            this.CenterToScreen();
            this.KeyPreview = true;
            this.AcceptButton = btnDangNhap;

        }

        private void btnDangNhap_MouseEnter(object sender, EventArgs e)
        {
            btnDangNhap.BackColor = Color.FromArgb(255, 127, 14);


        }

        private void btnDangNhap_MouseLeave(object sender, EventArgs e)
        {
            btnDangNhap.BackColor = Color.FromArgb(24, 119, 242);
        }


        private void btnQuenMatKhau_MouseEnter(object sender, EventArgs e)
        {
            btnQuenMatKhau.LinkColor = Color.FromArgb(255, 127, 14);

        }

        private void btnQuenMatKhau_MouseLeave(object sender, EventArgs e)
        {
            btnQuenMatKhau.LinkColor = Color.FromArgb(24, 119, 242);

        }

    }
}
