using Microsoft.VisualBasic.Devices;
using SieuThiMini.BUS;
using SieuThiMini.DAO;
using SieuThiMini.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SieuThiMini.Panel
{
    public partial class EmployeesManagementPanel : Form
    {
        EmployeeBUS employeeBUS = new EmployeeBUS();
        private List<EmployeeDTO> employees;



        public EmployeesManagementPanel()
        {
            InitializeComponent();
            cbbDayOfBirth.Format = DateTimePickerFormat.Custom;
            cbbDayOfBirth.CustomFormat = "dd/MM/yyyy";
            LoadEmployees();
            LoadStatusSearch(cbbStatusSearch);


        }

        private void btnEditImage_MouseEnter(object sender, EventArgs e)
        {
            btnEditImage.BackColor = Color.FromArgb(255, 127, 14);
        }

        private void btnEditImage_MouseLeave(object sender, EventArgs e)
        {
            btnEditImage.BackColor = Color.FromArgb(24, 119, 242);

        }

        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.FromArgb(255, 127, 14);
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.FromArgb(0, 192, 0);

        }

        private void btnEdit_MouseEnter(object sender, EventArgs e)
        {
            btnEdit.BackColor = Color.FromArgb(255, 127, 14);
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            btnEdit.BackColor = Color.FromArgb(24, 119, 242);

        }

        private void btnDelete_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.FromArgb(255, 127, 14);
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.Red;

        }

      
        private void btnAdd_Click(object sender, EventArgs e)
        {
            errorName.Clear();
            errorGender.Clear();
            errorPhoneNumber.Clear();
            errorDateOfBirth.Clear();
            errorEmail.Clear();
            errorConfirmPass.Clear();
            errorPass.Clear();
            string name = txtName.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string gender = "";
            string email = txtEmail.Text;
            int year = cbbDayOfBirth.Value.Year;
            string newPass = txtPassword.Text;
            string confirmPass = txtConfirmPass.Text;
            //string role = cbbRole.SelectedItem.ToString();
            //string status = cbbStatus.SelectedItem.ToString();
            string role = cbbRole.SelectedItem?.ToString();
            string status = cbbStatus.SelectedItem?.ToString();
            bool check = true;
            txtCreateAt.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
            if (string.IsNullOrEmpty(name))
            {
                errorName.SetError(txtName, "Không bỏ trống dữ liệu");
                check = false;
            }
            if (string.IsNullOrEmpty(phoneNumber))
            {
                errorPhoneNumber.SetError(txtPhoneNumber, "Không bỏ trống dữ liệu");
                check = false;
            }
            else if (phoneNumber.Length != 10)
            {
                errorPhoneNumber.SetError(txtPhoneNumber, "Số điện thoại phải bao gồm 10 chữ số");
                check = false;
            }
            if (string.IsNullOrEmpty(gender))
            {
                errorGender.SetError(groupGioiTinh, "Không bỏ trống dữ liệu");
                check = false;
            }
            if (year > 2006 || year < 1964)
            {
                errorDateOfBirth.SetError(cbbDayOfBirth, "Năm sinh không hợp lệ !");
                check = false;
            }
            if (!email.EndsWith("@gmail.com"))
            {
                errorEmail.SetError(txtEmail, "Email không hợp lệ");
                check = false;
                btnDoiMatKhau.Enabled = false;
            }
            else if (string.IsNullOrEmpty(email))
            {
                errorEmail.SetError(txtEmail, "Không bỏ trống dữ liệu");
                check = false;
            }
            if (string.IsNullOrEmpty(newPass))
            {
                errorPass.SetError(txtPassword, "Vui lòng nhập đầy đủ thông tin");
                check = false;
            }
            else if (newPass.Length < 7)
            {
                errorPass.SetError(txtPassword, "Mật khẩu phải có hơn 6 ký tự");
                check = false;
            }
            else if (!newPass.Any(char.IsDigit)) // Kiểm tra có số hay không
            {
                errorPass.SetError(txtPassword, "Mật khẩu phải chứa ít nhất một số");
                check = false;
            }
            else if (!newPass.Any(char.IsLetter))
            {
                errorPass.SetError(txtPassword, "Mật khẩu phải chứa ít nhất một chữ cái");
                check = false;
            }
            if (string.IsNullOrEmpty(confirmPass))
            {
                errorConfirmPass.SetError(txtConfirmPass, "Vui lòng nhập đầy đủ thông tin");
                check = false;
            }
            else if (confirmPass != newPass)
            {
                errorConfirmPass.SetError(txtConfirmPass, "Mật khẩu xác nhận không khớp");
                check = false;
            }
            if (employeeBUS.CheckEmailExists(email))
            {
                errorEmail.SetError(txtEmail, "Email đã tồn tại,hãy chọn 1 email khác!");
                check = false;
            }
            else if (string.IsNullOrEmpty(email))
            {
                errorEmail.SetError(txtEmail, "Không bỏ trống dữ liệu!");
                check = false;
            }
            if (check)
            {
                EmployeeDTO employeee = new EmployeeDTO();
                employeee.Email = email;
                employeee.Password = newPass;
                employeee.Role = role;
                employeee.Status = status;
                employeee.Img = lbltenanh.Text;
                employeee.Name = name;
                employeee.Phone = phoneNumber;
                employeee.Gender = gender;
                employeee.DayOfBirth = dateofbirth;
                employeeBUS.AddEmployee(employeee);
                employees.Add(employeee);
                LoadEmployees();
                lblSuccess.Visible = true;
                lblSuccess.Text = "Thêm nhân viên thành công !";
                timerHideMessage.Interval = 3000; // 3 giây
                timerHideMessage.Start();
                btnDoiMatKhau.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            errorID.Clear();
            if (string.IsNullOrEmpty(id))
            {
                errorID.SetError(txtID, "Không tìm thấy người dùng");
            }
            else
            {
                // Hiển thị hộp thoại xác nhận trước khi xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    EmployeeDTO em = employeeBUS.GetEmployeeById(int.Parse(id));
                    employeeBUS.DeleteEmployee(int.Parse(id));
                    employees.Remove(em);
                    LoadEmployees();
                    lblSuccess.Visible = true;
                    lblSuccess.Text = "Xóa nhân viên thành công!";
                    timerHideMessage.Interval = 3000; // 3 giây
                    timerHideMessage.Start();
                }
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
        private void btnDoiMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorID.Clear();

            if (string.IsNullOrEmpty(txtID.Text))
            {
                btnDoiMatKhau.Enabled = false;
                errorID.SetError(txtID, "Không tìm thấy người dùng");

            }
            else
            {
                panelChangePass.Visible = true;
                txtPassword.Enabled = true;
                btnConfirm.Visible = true;
                txtPassword.Enabled= true;
            }


        }

        private void EmployeesManagementPanel_Load(object sender, EventArgs e)
        {
            // panelChangePass.Visible = false;
            cbbDayOfBirth.Format = DateTimePickerFormat.Custom;
            cbbDayOfBirth.CustomFormat = "dd/MM/yyyy";
            lblSuccess.Visible = false;
            panelChangePass.Visible = true;
            txtPassword.Enabled = true;
            btnDoiMatKhau.Enabled = false;
            btnConfirm.Visible = false;
            btnAdd.Visible = true;

            //  txtID.Text = "NV001";

        }

        private void btnConfirm_MouseEnter(object sender, EventArgs e)
        {
            btnConfirm.BackColor = Color.FromArgb(255, 127, 14);
        }

        private void btnConfirm_MouseLeave(object sender, EventArgs e)
        {
            btnConfirm.BackColor = Color.FromArgb(24, 119, 242);
        }

        private void btnDoiMatKhau_MouseEnter(object sender, EventArgs e)
        {
            btnDoiMatKhau.LinkColor = Color.FromArgb(255, 127, 14);
        }

        private void btnDoiMatKhau_MouseLeave(object sender, EventArgs e)
        {
            btnDoiMatKhau.LinkColor = Color.FromArgb(24, 119, 242);
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void timerHideMessage_Tick(object sender, EventArgs e)
        {
            Reload();
            txtConfirmPass.Text = "";
        }
        private void Reload()
        {
            lblSuccess.Visible = false;
            txtID.Text = "";
            txtName.Text = "";
            txtPhoneNumber.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtEmail.Enabled = true;
            cbbDayOfBirth.Value = DateTime.Now;
            panelChangePass.Visible = false;
            errorDateOfBirth.Clear();
            errorGender.Clear();
            errorName.Clear();
            errorPhoneNumber.Clear();
            errorEmail.Clear();
            errorConfirmPass.Clear();
            errorPass.Clear();
            errorID.Clear();
            ClearRadioButtons(groupGioiTinh);
            btnEdit.Enabled = true;
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            panelChangePass.Visible = true;
            txtPassword.Enabled = true;
            btnDoiMatKhau.Enabled = true;
            string img_u = "user.png";
            // avatar.ImageLocation = "D:\\MiniStore_C_Sharp\\Images\\icons\\" + img_u;
            avatar.ImageLocation = "C:\\Users\\MyLy\\Documents\\GitHub\\MiniStore_C_Sharp\\Images\\user\\" + img_u;
            lbltenanh.Text = img_u;
            timerHideMessage.Stop();
        }
        private void ClearRadioButtons(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is RadioButton)
                {
                    ((RadioButton)control).Checked = false;
                }
            }
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            Reload();
            panelChangePass.Visible = true;
            txtPassword.Enabled = true;
            btnDoiMatKhau.Enabled = false;
            btnConfirm.Visible = false;
            btnAdd.Visible = true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            lblSuccess.Visible = false;
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
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }
            else if (newPass.Length < 7)
            {
                errorPass.SetError(txtPassword, "Mật khẩu phải có hơn 6 ký tự");
                btnEdit.Enabled = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }
            else if (!newPass.Any(char.IsDigit)) // Kiểm tra có số hay không
            {
                errorPass.SetError(txtPassword, "Mật khẩu phải chứa ít nhất một số");
                btnEdit.Enabled = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }
            else if (!newPass.Any(char.IsLetter))
            {
                errorPass.SetError(txtPassword, "Mật khẩu phải chứa ít nhất một chữ cái");
                btnEdit.Enabled = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }
            if (string.IsNullOrEmpty(confirmPass))
            {
                errorConfirmPass.SetError(txtConfirmPass, "Vui lòng nhập đầy đủ thông tin");
                btnEdit.Enabled = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }
            else if (confirmPass != newPass)
            {
                errorConfirmPass.SetError(txtConfirmPass, "Mật khẩu xác nhận không khớp");
                btnEdit.Enabled = false;
            }
            if (newPass.Length >= 7 && newPass.Any(char.IsDigit) && newPass.Any(char.IsLetter) && confirmPass == newPass)
            {
                employeeBUS.ChangePassword(int.Parse(txtID.Text), newPass);
                lblSuccess.Visible = true;
                txtPassword.Text = "";
                lblSuccess.Text = "Mật khẩu đã được thay đổi thành công!";
                timerHideMessage.Interval = 3000; // 3 giây
                timerHideMessage.Start();
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            errorID.Clear();
            errorName.Clear();
            errorGender.Clear();
            errorPhoneNumber.Clear();
            errorDateOfBirth.Clear();
            errorEmail.Clear();
            errorConfirmPass.Clear();
            errorPass.Clear();
            string name = txtName.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string gender = "";
            string email = txtEmail.Text;
            int year = cbbDayOfBirth.Value.Year;
            string Pass = txtPassword.Text;
            // string confirmPass = txtConfirmPass.Text;
            //string role = cbbRole.SelectedItem.ToString();
            // string status = cbbStatus.SelectedItem.ToString();
            string role = cbbRole.SelectedItem?.ToString();
            string status = cbbStatus.SelectedItem?.ToString();
            bool check = true;
            //  txtCreateAt.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
            if (string.IsNullOrEmpty(id))
            {
                errorID.SetError(txtID, "Không tìm thấy người dùng");
                check = false;
            }
            if (string.IsNullOrEmpty(name))
            {
                errorName.SetError(txtName, "Không bỏ trống dữ liệu");
                check = false;
            }
            if (string.IsNullOrEmpty(phoneNumber))
            {
                errorPhoneNumber.SetError(txtPhoneNumber, "Không bỏ trống dữ liệu");
                check = false;
            }
            else if (phoneNumber.Length != 10)
            {
                errorPhoneNumber.SetError(txtPhoneNumber, "Số điện thoại phải bao gồm 10 chữ số");
                check = false;
            }
            if (year > 2006 || year < 1964)
            {
                errorDateOfBirth.SetError(cbbDayOfBirth, "Năm sinh không hợp lệ !");
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
                LoadEmployees();
                lblSuccess.Visible = true;
                lblSuccess.Text = "Sửa thông tin thành công !";
                timerHideMessage.Interval = 3000; // 3 giây
                timerHideMessage.Start();
                // btnDoiMatKhau.Enabled = true;

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

        private void LoadEmployees()
        {
            employees = employeeBUS.GetAllEmployees();
            LoadStatusSearch(cbbStatusSearch);
            list_dsnv.Items.Clear();
            if (employees == null || employees.Count == 0)
            {
                MessageBox.Show("No employees found.");
                return;
            }

            int stt = 1;

            foreach (var employee in employees)
            {
                ListViewItem item = new ListViewItem(stt.ToString());
                item.SubItems.Add(employee.EmployeeID.ToString());
                item.SubItems.Add(employee.Email);
                item.SubItems.Add(employee.Name);
                item.SubItems.Add(employee.Gender);
                item.SubItems.Add(employee.Phone);
                item.SubItems.Add(employee.DayOfBirth.HasValue ? employee.DayOfBirth.Value.ToShortDateString() : ""); // Nếu không có giá trị thì thêm chuỗi rỗng
                item.SubItems.Add(employee.Role);
                item.SubItems.Add(employee.Status);
                list_dsnv.Items.Add(item);

                stt++;
            }
        }
        private void list_dsnv_MouseClick(object sender, MouseEventArgs e)
        {
            errorConfirmPass.Clear();
            errorEmail.Clear();
            errorID.Clear();
            errorName.Clear();
            errorPass.Clear();
            errorPhoneNumber.Clear();
            errorConfirmPass.Clear();
            errorGender.Clear();
            btnAdd.Enabled = false;
            txtEmail.Enabled = false;
            panelChangePass.Visible = false;
            txtPassword.Enabled = false;
            btnDoiMatKhau.Enabled = true;
            if (list_dsnv.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = list_dsnv.SelectedItems[0];

                int id = int.Parse(selectedItem.SubItems[1].Text); // Lấy ID từ cột ID
                string email = selectedItem.SubItems[2].Text;
                string name = selectedItem.SubItems[3].Text;
                string gender = selectedItem.SubItems[4].Text;
                string phone = selectedItem.SubItems[5].Text;
                string birthDate = selectedItem.SubItems[6].Text;
                string role = selectedItem.SubItems[7].Text;
                string status = selectedItem.SubItems[8].Text;

                txtID.Text = id.ToString();
                txtEmail.Text = email;
                txtName.Text = name;
                if (gender == "Nam")
                {
                    rdnNam.Checked = true;
                }
                else if (gender == "Nữ")
                {
                    rdbNu.Checked = true;
                }
                else
                {
                    rdbKhac.Checked = true;
                }


                txtPhoneNumber.Text = phone;
                cbbDayOfBirth.Value = DateTime.Parse(birthDate);
                cbbRole.SelectedItem = role;
                cbbStatus.SelectedItem = status;
                EmployeeDTO employee = employeeBUS.GetEmployeeById(id);
                string img_u = employee.Img;
                avatar.ImageLocation = "C:\\Users\\MyLy\\Documents\\GitHub\\MiniStore_C_Sharp\\Images\\user\\" + img_u;
                lbltenanh.Text = img_u;
                txtCreateAt.Text = employee.CreatedAt.ToString("dd/MM/yyyy");
                txtPassword.Text = employee.Password;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            List<EmployeeDTO> result = employeeBUS.SearchEmployees(keyword);
            UpdateEmployeeList(result);

        }
        private void UpdateEmployeeList(List<EmployeeDTO> employees)
        {
            list_dsnv.Items.Clear();
            int stt = 1;

            foreach (var employee in employees)
            {
                ListViewItem item = new ListViewItem(stt.ToString());
                item.SubItems.Add(employee.EmployeeID.ToString());
                item.SubItems.Add(employee.Email);
                item.SubItems.Add(employee.Name);
                item.SubItems.Add(employee.Gender);
                item.SubItems.Add(employee.Phone);
                item.SubItems.Add(employee.DayOfBirth.HasValue ? employee.DayOfBirth.Value.ToShortDateString() : ""); // Nếu không có giá trị thì thêm chuỗi rỗng
                item.SubItems.Add(employee.Role);
                item.SubItems.Add(employee.Status);
                list_dsnv.Items.Add(item);
                stt++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadEmployees();
            ClearRadioButtons(groupGenderSearch);
            txtFrom.Text = "";
            txtTo.Text = "";
            errorAgeSearch.Clear();
            Reload();
            panelChangePass.Visible = true;
            txtPassword.Enabled = true;
            btnDoiMatKhau.Enabled = false;
            btnConfirm.Visible = false;
            btnAdd.Visible = true;

        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            errorAgeSearch.Clear();
            string gender = "";
            txtSearch.Text = "";
            int from;
            int to;
            bool fromParsed = int.TryParse(txtFrom.Text, out from);
            bool toParsed = int.TryParse(txtTo.Text, out to);
         //   string selectedValue = cbbStatusSearch.SelectedItem.ToString();

            if (rdbNuS.Checked)
            {
                gender = "Nữ";
            }
            else if (rdbNamS.Checked)
            {
                gender = "Nam";
            }
            else if (rdbKhacS.Checked)
            {
                gender = "Khác";
            }
            if (string.IsNullOrEmpty(gender) && cbbStatusSearch.SelectedItem == null)
            {
                //errorAgeSearch.Clear();
                if (!fromParsed || !toParsed || from < 0 || to < 0 || from > to)
                {
                    errorAgeSearch.SetError(txtTo, "Thông tin không hợp lệ. Vui lòng nhập lại tuổi.");
                }
                else
                {
                    List<EmployeeDTO> result1 = employeeBUS.GetEmployeesByAgeRange(from, to);
                    UpdateEmployeeList(result1);
                }
            }
            else if (string.IsNullOrEmpty(txtFrom.Text) && cbbStatusSearch.SelectedItem == null)
            {
                List<EmployeeDTO> result = employeeBUS.GetEmployeesByGender(gender);
                UpdateEmployeeList(result);
            }
            else if (string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(txtFrom.Text))
            {
                string selectedValue = cbbStatusSearch.SelectedItem.ToString();
                List<EmployeeDTO> result = employeeBUS.GetEmployeesByStatus(selectedValue);
                UpdateEmployeeList(result);
            }
            else if (!string.IsNullOrEmpty(txtFrom.Text) && !gender.Equals("") && cbbStatusSearch.SelectedItem == null)
            {
                List<EmployeeDTO> resultG = employeeBUS.GetEmployeesByGender(gender);
                List<EmployeeDTO> resultA = employeeBUS.GetEmployeesByAgeRange(from, to);
                List<EmployeeDTO> listSearch1 = new List<EmployeeDTO>();
                foreach (EmployeeDTO i in resultG)
                {
                    foreach (EmployeeDTO j in resultA)
                    {

                        if (i.EmployeeID == j.EmployeeID)
                        {
                            listSearch1.Add(j);
                        }

                    }
                }
                UpdateEmployeeList(listSearch1);
            }
            else if (!string.IsNullOrEmpty(txtFrom.Text) && gender.Equals("") && cbbStatusSearch.SelectedItem != null)
            {
                string selectedValue = cbbStatusSearch.SelectedItem.ToString();
                List<EmployeeDTO> resultA = employeeBUS.GetEmployeesByAgeRange(from, to);
                List<EmployeeDTO> resultS = employeeBUS.GetEmployeesByStatus(selectedValue);
                List<EmployeeDTO> listSearch2 = new List<EmployeeDTO>();

                foreach (EmployeeDTO j in resultA)
                {
                    foreach (EmployeeDTO k in resultS)
                    {
                        if (j.EmployeeID == k.EmployeeID)
                        {
                            listSearch2.Add(j);
                        }
                    }

                }
                UpdateEmployeeList(listSearch2);
            }
            else if (string.IsNullOrEmpty(txtFrom.Text) && !gender.Equals("") && cbbStatusSearch.SelectedItem != null)
            {
                string selectedValue = cbbStatusSearch.SelectedItem.ToString();
                List<EmployeeDTO> resultG = employeeBUS.GetEmployeesByGender(gender);
                List<EmployeeDTO> resultS = employeeBUS.GetEmployeesByStatus(selectedValue);
                List<EmployeeDTO> listSearch2 = new List<EmployeeDTO>();

                foreach (EmployeeDTO j in resultG)
                {
                    foreach (EmployeeDTO k in resultS)
                    {
                        if (j.EmployeeID == k.EmployeeID)
                        {
                            listSearch2.Add(j);
                        }
                    }

                }
                UpdateEmployeeList(listSearch2);
            }

            else if (!string.IsNullOrEmpty(txtFrom.Text) && !gender.Equals("") && cbbStatusSearch.SelectedItem != null)
            {
                string selectedValue = cbbStatusSearch.SelectedItem.ToString();
                List<EmployeeDTO> resultG = employeeBUS.GetEmployeesByGender(gender);
                List<EmployeeDTO> resultA = employeeBUS.GetEmployeesByAgeRange(from, to);
                List<EmployeeDTO> resultS = employeeBUS.GetEmployeesByStatus(selectedValue);
                List<EmployeeDTO> listSearch = new List<EmployeeDTO>();
                foreach (EmployeeDTO i in resultG)
                {
                    foreach (EmployeeDTO j in resultA)
                    {
                        foreach (EmployeeDTO k in resultS)
                        {
                            if (i.EmployeeID == j.EmployeeID && i.EmployeeID == k.EmployeeID)
                            {
                                listSearch.Add(k);
                            }
                        }

                    }
                }
                UpdateEmployeeList(listSearch);
            }
           
        }
        private void LoadStatusSearch(System.Windows.Forms.ComboBox comboBox)
        {
            List<EmployeeDTO> employees = employeeBUS.GetAllEmployees();
            ArrayList addedStatuses = new ArrayList();
            comboBox.Items.Clear();

            foreach (var employee in employees)
            {
                if (!addedStatuses.Contains(employee.Status))
                {
                    comboBox.Items.Add(employee.Status);
                    addedStatuses.Add(employee.Status);
                }
            }
            comboBox.SelectedIndex = -1;
        }

        private void txtFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnLoc_MouseEnter(object sender, EventArgs e)
        {
            btnLoc.BackColor = Color.FromArgb(255, 127, 14);
        }

        private void btnLoc_MouseLeave(object sender, EventArgs e)
        {
            btnLoc.BackColor = Color.FromArgb(24, 119, 242);
        }
    }

}
