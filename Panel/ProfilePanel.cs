using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using SieuThiMini.BUS;
using Microsoft.VisualBasic.ApplicationServices;
using System.Net.NetworkInformation;


namespace SieuThiMini.Panel
{
    public partial class ProfilePanel : Form
    {
        private int id;
        EmployeeBUS employeeBUS = new EmployeeBUS();
        public ProfilePanel(int id)
        {
            InitializeComponent();
            this.id = id;
            LoadProfile();
            cbbDayOfBirth.Format = DateTimePickerFormat.Custom;
            cbbDayOfBirth.CustomFormat = "dd/MM/yyyy";
            lbltenanh.Visible = false;
        }
        private void btnEdit_MouseEnter(object sender, EventArgs e)
        {
            btnEdit.BackColor = Color.FromArgb(255, 127, 14);
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            btnEdit.BackColor = Color.FromArgb(24, 119, 242);
        }

        private void btnEditImage_MouseEnter(object sender, EventArgs e)
        {
            btnEditImage.BackColor = Color.FromArgb(255, 127, 14);
        }

        private void btnEditImage_MouseLeave(object sender, EventArgs e)
        {
            btnEditImage.BackColor = Color.FromArgb(24, 119, 242);
        }

        private void btnDoiMatKhau_MouseEnter(object sender, EventArgs e)
        {
            btnDoiMatKhau.LinkColor = Color.FromArgb(255, 127, 14);
        }

        private void btnDoiMatKhau_MouseLeave(object sender, EventArgs e)
        {
            btnDoiMatKhau.LinkColor = Color.FromArgb(24, 119, 242);
        }

        private void ProfilePanel_Load(object sender, EventArgs e)
        {
            panelChangePass.Visible = false;
            lblSucsess.Visible = false;
            cbbDayOfBirth.Format = DateTimePickerFormat.Custom;
            cbbDayOfBirth.CustomFormat = "dd/MM/yyyy";

        }

        private void btnDoiMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelChangePass.Visible = true;
            txtPassword.Enabled = true;
            lblSucsess.Visible = false;

        }

        private void btnConfirm_MouseEnter(object sender, EventArgs e)
        {
            btnConfirm.BackColor = Color.FromArgb(255, 127, 14);

        }

        private void btnConfirm_MouseLeave(object sender, EventArgs e)
        {
            btnConfirm.BackColor = Color.FromArgb(24, 119, 242);

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            lblSucsess.Visible = false;
            panelChangePass.Visible = true;
            txtPassword.Enabled = true;
            btnEdit.Enabled = true;
            errorPass.Clear();
            errorConfirmPass.Clear();
            string newPass = txtPassword.Text;
            string confirmPass = txtConfirmPass.Text;
            if (string.IsNullOrEmpty(newPass))
            {
                errorPass.SetError(txtPassword, "Vui lòng nhập đầy đủ thông tin");
                btnEdit.Enabled = false;
            }
            else if (newPass.Length < 7)
            {
                errorPass.SetError(txtPassword, "Mật khẩu phải có hơn 6 ký tự");
                btnEdit.Enabled = false;
            }
            else if (!newPass.Any(char.IsDigit)) // Kiểm tra có số hay không
            {
                errorPass.SetError(txtPassword, "Mật khẩu phải chứa ít nhất một số");
                btnEdit.Enabled = false;
            }
            else if (!newPass.Any(char.IsLetter))
            {
                errorPass.SetError(txtPassword, "Mật khẩu phải chứa ít nhất một chữ cái");
                btnEdit.Enabled = false;
            }
            if (string.IsNullOrEmpty(confirmPass))
            {
                errorConfirmPass.SetError(txtConfirmPass, "Vui lòng nhập đầy đủ thông tin");
                btnEdit.Enabled = false;
            }
            else if (confirmPass != newPass)
            {
                errorConfirmPass.SetError(txtConfirmPass, "Mật khẩu xác nhận không khớp");
                btnEdit.Enabled = false;
            }
            if (newPass.Length >= 7 && newPass.Any(char.IsDigit) && newPass.Any(char.IsLetter) && confirmPass == newPass)
            {
                employeeBUS.ChangePassword(id, confirmPass);
                lblSucsess.Visible = true;
                lblSucsess.Text = "Mật khẩu đã được thay đổi thành công!";
                btnEdit.Enabled = true;
                panelChangePass.Visible = false;
                txtPassword.Enabled = false;
                timerHideMessage.Interval = 3000; // 3 giây
                timerHideMessage.Start();
            }
        }

        private void btnEditImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh đại diện";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"; // Chỉ cho phép chọn file ảnh
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                avatar.ImageLocation = imagePath; // Hoặc có thể dùng: avatar.Image = Image.FromFile(imagePath);
                string fileName = System.IO.Path.GetFileName(imagePath);
                lbltenanh.Text = fileName;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            errorName.Clear();
            errorPhoneNumber.Clear();
            lblSucsess.Visible = false;
            string id = txtID.Text;
            string ten = txtName.Text;
            string sdt = txtPhoneNumber.Text;
            string name = txtName.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string gender = "";
            string email = txtEmail.Text;
            int year = cbbDayOfBirth.Value.Year;
            string Pass = txtPassword.Text;
            string role = txtRole.Text;
            string status = cbbStatus.SelectedItem.ToString();
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
            if (string.IsNullOrEmpty(ten))
            {
                errorName.SetError(txtName, "Không bỏ trống dữ liệu!");
                btnDoiMatKhau.Visible = false;
                panelChangePass.Visible = false;
                check = false;
            }
            if (string.IsNullOrEmpty(sdt))
            {
                errorPhoneNumber.SetError(txtPhoneNumber, "Không bỏ trống dữ liệu!");
                btnDoiMatKhau.Visible = false;
                panelChangePass.Visible = false;
                check = false;
            }
            else if (phoneNumber.Length != 10)
            {
                errorPhoneNumber.SetError(txtPhoneNumber, "Số điện thoại phải bao gồm 10 chữ số");
                check = false;
            }
            if (check)
            {
                EmployeeDTO employee = new EmployeeDTO();
                employee.EmployeeID = int.Parse(id);
                employee.Email = email;
                employee.Password = Pass;
                employee.Role = role;
                employee.Status = status;
                EmployeeDTO em = employeeBUS.GetEmployeeById(employee.EmployeeID);
                employee.CreatedAt = em.CreatedAt;
                employee.Img = lbltenanh.Text;
                employee.Name = name;
                employee.Phone = phoneNumber;
                employee.Gender = gender;
                employee.DayOfBirth = dateofbirth;
                employeeBUS.UpdateEmployee(employee);
                lblSucsess.Visible = true;
                lblSucsess.Text = "Cập nhật thông tin thành công";
                btnDoiMatKhau.Visible = true;
                timerHideMessage.Interval = 3000; // 3 giây
                timerHideMessage.Start();
            }
        }
        private void btnReLoad_MouseEnter(object sender, EventArgs e)
        {
            btnReLoad.BackColor = Color.FromArgb(255, 127, 14);
        }

        private void btnReLoad_MouseLeave(object sender, EventArgs e)
        {
            btnReLoad.BackColor = Color.FromArgb(24, 119, 242);

        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            ReLoad();
        }

        private void timerHideMessage_Tick(object sender, EventArgs e)
        {
            lblSucsess.Visible = false;
            txtPassword.Enabled = true;
            //  btnEdit.Enabled = true;
            //    panelChangePass.Visible=false;
            ReLoad();
            timerHideMessage.Stop();
        }
        private void ReLoad()
        {
            EmployeeDTO emp = new EmployeeDTO();
            emp = employeeBUS.FindEmployeeById(id);
            errorName.Clear();
            errorConfirmPass.Clear();
            errorPhoneNumber.Clear();
            errorPass.Clear();
            btnEdit.Enabled = true;
            panelChangePass.Visible = false;
            txtPassword.Enabled = false;
            lblSucsess.Visible = false;
            btnDoiMatKhau.Visible = true;
            string img_u = emp.Img;
            // avatar.ImageLocation = "D:\\MiniStore_C_Sharp\\Images\\icons\\" + img_u;
            avatar.ImageLocation = "C:\\Users\\MyLy\\Documents\\GitHub\\MiniStore_C_Sharp\\Images\\user\\" + img_u;
            lbltenanh.Text = img_u;
            LoadProfile();
        }
        private void LoadProfile()
        {
            EmployeeDTO emp = new EmployeeDTO();
            emp = employeeBUS.FindEmployeeById(id);
            txtID.Text = emp.EmployeeID.ToString();
            txtEmail.Text = emp.Email;
            txtName.Text = emp.Name;
            string gender = emp.Gender;
            if (gender == "Nam")
            {
                rdnNam.Checked = true;
            }
            else if (gender == "Nữ")
            {
                rdbNu.Checked = true;
            }
            else if (gender == "Khác")
            {
                rdbKhac.Checked = true;
            }
            txtPhoneNumber.Text = emp.Phone;
            txtRole.Text = emp.Role;
            txtPassword.Text = emp.Password;
            cbbStatus.Text = emp.Status;
            string img_u = emp.Img;
            cbbDayOfBirth.Value = emp.DayOfBirth.Value;
            lbltenanh.Text = img_u;
            avatar.ImageLocation = "C:\\Users\\MyLy\\Documents\\GitHub\\MiniStore_C_Sharp\\Images\\user\\" + img_u;
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
