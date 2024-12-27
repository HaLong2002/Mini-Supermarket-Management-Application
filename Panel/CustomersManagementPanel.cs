using SieuThiMini.BUS;
using SieuThiMini.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SieuThiMini.Panel
{
    public partial class CustomersManagementPanel : Form
    {
        private int id;
        CustomerBUS customerBUS = new CustomerBUS();
        ProductBUS productBUS = new ProductBUS();
        EmployeeBUS employeeBUS = new EmployeeBUS();
        private List<CustomerDTO> customers;

        public CustomersManagementPanel(int id)
        {
            InitializeComponent();
            LoadCustomers();
            panelSearchDate.Visible = false;
            panelSearchPoint.Visible = false;
            cbbDayS.Format = DateTimePickerFormat.Custom;
            cbbDayS.CustomFormat = "dd/MM/yyyy";
            cbbDayE.Format = DateTimePickerFormat.Custom;
            cbbDayE.CustomFormat = "dd/MM/yyyy";
            btnLoc.Visible = false;
            this.id = id;
           

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

        private void btnReLoad_MouseEnter(object sender, EventArgs e)
        {
            btnReLoad.BackColor = Color.FromArgb(255, 127, 14);
        }

        private void btnReLoad_MouseLeave(object sender, EventArgs e)
        {
            btnReLoad.BackColor = Color.FromArgb(24, 119, 242);
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            errorID.Clear();
            errorName.Clear();
            errorPhoneNumber.Clear();
            errorGender.Clear();
            errorDateOfBirth.Clear();
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
            else if (customerBUS.IsPhoneExists(phoneNumber))
            {
                errorPhoneNumber.SetError(txtPhoneNumber, "Số điện thoại đã tồn tại!");
                check = false;
            }
            if (string.IsNullOrEmpty(gender))
            {
                errorGender.SetError(groupGioiTinh, "Không bỏ trống dữ liệu");
                check = false;
            }
            if (year > 2012 || year < 1924)
            {
                errorDateOfBirth.SetError(cbbDayOfBirth, "Năm sinh không hợp lệ !");
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
                customers.Add(customer);
                LoadCustomers();
                lblSuccess.Visible = true;
                lblSuccess.Text = "Thêm khách hàng thành công !";
                timerHideMessage.Interval = 3000; // 3 giây
                timerHideMessage.Start();
            }

        }

        private void CustomersManagementPanel_Load(object sender, EventArgs e)
        {
            cbbDayOfBirth.Format = DateTimePickerFormat.Custom;
            cbbDayOfBirth.CustomFormat = "dd/MM/yyyy";
            lblSuccess.Visible = false;
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
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            if (string.IsNullOrEmpty(id))
            {
                errorID.SetError(txtID, "Không tìm thấy người dùng");
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    CustomerDTO cus = customerBUS.GetCustomerById(int.Parse(id));
                    customerBUS.DeleteCustomer(int.Parse(id));
                    customers.Remove(cus);
                    LoadCustomers();
                    lblSuccess.Visible = true;
                    lblSuccess.Text = "Xóa khách hàng thành công !";
                    timerHideMessage.Interval = 3000; // 3 giây
                    timerHideMessage.Start();
                }
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            errorID.Clear();
            errorName.Clear();
            errorPhoneNumber.Clear();
            errorGender.Clear();
            errorDateOfBirth.Clear();
            string name = txtName.Text;
            string id = txtID.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string point = txtPoint.Text;
            string gender = "";
            DateTime dateofbirth = cbbDayOfBirth.Value;
            bool check = true;
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
            if (string.IsNullOrEmpty(id))
            {
                errorID.SetError(txtID, "Không tìm thấy người dùng");
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
            if (year > 2012 || year < 1924)
            {
                errorDateOfBirth.SetError(cbbDayOfBirth, "Năm sinh không hợp lệ !");
                check = false;
            }
            if (check)
            {
                CustomerDTO customer = new CustomerDTO();
                customer.CustomerID = int.Parse(id);
                customer.Name = name;
                customer.Gender = gender;
                customer.DayOfBirth = dateofbirth;
                customer.Phone = phoneNumber;
                customer.RewardPoint = int.Parse(point);
                customerBUS.UpdateCustomer(customer);
                LoadCustomers();
                lblSuccess.Visible = true;
                lblSuccess.Text = "Sửa thông tin khách hàng thành công !";
                timerHideMessage.Interval = 3000; // 3 giây
                timerHideMessage.Start();
            }
        }
        private void Reload()
        {
            lblSuccess.Visible = false;
            txtID.Text = "";
            txtName.Text = "";
            txtPhoneNumber.Text = "";
            txtPoint.Text = "";
            txtID.Text = "";
            txtPoint.Text = "";
            txtPhoneNumber.Enabled = true;
            errorDateOfBirth.Clear();
            errorGender.Clear();
            errorName.Clear();
            errorPhoneNumber.Clear();
            errorID.Clear();
            ClearRadioButtons(groupGioiTinh);
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
            LoadCustomers();
        }
        private void LoadCustomers()
        {
            customers = customerBUS.GetAllCustomers();
            list_dskh.Items.Clear();
            if (customers == null || customers.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng.");
                return;
            }
            int stt = 1;

            foreach (var customer in customers)
            {
                ListViewItem item = new ListViewItem(stt.ToString());
                item.SubItems.Add(customer.CustomerID.ToString());
                item.SubItems.Add(customer.Name);
                item.SubItems.Add(customer.Phone);
                item.SubItems.Add(customer.Gender);
                item.SubItems.Add(customer.DayOfBirth.ToString("dd/MM/yyyy"));
                item.SubItems.Add(customer.RewardPoint.ToString());

                list_dskh.Items.Add(item);

                stt++;
            }
        }
        private void LoadInvoices(int idCus)
        {
            int customerID = idCus;
            List<InvoiceDTO> invoices = customerBUS.GetInvoicesByCustomerID(customerID);

            list_dshd.Items.Clear();
            int stt = 1;
            foreach (var i in invoices)
            {
                ListViewItem item = new ListViewItem(stt.ToString());
                item.SubItems.Add(i.InvoiceID.ToString());
                item.SubItems.Add(i.InvoiceDate.ToString("dd/MM/yyyy"));
                item.SubItems.Add(i.TotalAmount.ToString());
                list_dshd.Items.Add(item);
                stt++;
            }

        }
        private void LoadDetailInvoices(int id_in)
        {

            List<InvoiceDetailDTO> details = customerBUS.GetInvoiceDetailsByInvoiceID(id_in);
            list_cthd.ShowItemToolTips = true;
            list_cthd.Items.Clear();
            int stt = 1;

            foreach (var i in details)
            {
                string nameProduct = setNameProduct(i.ProductID);
                string namePromotion = setNamePromotion(i.PromotionID ?? 0);
                ListViewItem item = new ListViewItem(stt.ToString());
                item.SubItems.Add(i.PromotionID.ToString());
                item.SubItems.Add(namePromotion);
                item.SubItems.Add(i.ProductID.ToString());
                item.SubItems.Add(nameProduct);
                item.SubItems.Add(i.Quantity.ToString());
                item.SubItems.Add(i.Price.ToString());

                item.ToolTipText = $"ID Khuyến mãi: {i.PromotionID}\n" +
                                 $"Khuyến mãi: {namePromotion}\n" +
                                 $"ID Sản phẩm: {i.ProductID}\n" +
                                 $"Sản phẩm: {nameProduct}\n" +
                                 $"Số lượng: {i.Quantity}\n" +
                                 $"Giá tiền: {i.Price}";

                list_cthd.Items.Add(item);
                stt++;

               
            }
           
        }
        private void list_dskh_MouseClick(object sender, MouseEventArgs e)
        {
            errorDateOfBirth.Clear();
            errorGender.Clear();
            errorName.Clear();
            errorPhoneNumber.Clear();
            errorID.Clear();
            txtPhoneNumber.Enabled = false;
            if (list_dskh.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = list_dskh.SelectedItems[0];
                int id = int.Parse(selectedItem.SubItems[1].Text);
                string name = selectedItem.SubItems[2].Text;
                string phone = selectedItem.SubItems[3].Text;
                string gender = selectedItem.SubItems[4].Text;
                string birthDate = selectedItem.SubItems[5].Text;
                string point = selectedItem.SubItems[6].Text;
                txtID.Text = id.ToString();
                txtName.Text = name;
                txtPhoneNumber.Text = phone;
                txtPoint.Text = point;
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
                cbbDayOfBirth.Value = DateTime.ParseExact(birthDate, "dd/MM/yyyy", null);
                LoadInvoices(id);
                list_cthd.Items.Clear();


            }
        }
        private void UpdateCustomerList(List<CustomerDTO> customers)
        {
            list_dskh.Items.Clear();
            int stt = 1;

            foreach (var customer in customers)
            {
                ListViewItem item = new ListViewItem(stt.ToString());
                item.SubItems.Add(customer.CustomerID.ToString());
                item.SubItems.Add(customer.Name);
                item.SubItems.Add(customer.Phone);
                item.SubItems.Add(customer.Gender);
                item.SubItems.Add(customer.DayOfBirth.ToString("dd/MM/yyyy"));
                item.SubItems.Add(customer.RewardPoint.ToString());
                list_dskh.Items.Add(item);
                stt++;
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            List<CustomerDTO> result = customerBUS.SearchCustomers(keyword);
            UpdateCustomerList(result);
            btnLoc.Visible = false;
            panelSearchPoint.Visible = false;
            panelSearchDate.Visible = false;
            cbbSearch.SelectedIndex = 0;
            list_dshd.Items.Clear();
            list_cthd.Items.Clear();
        }

        private void list_dshd_MouseClick(object sender, MouseEventArgs e)
        {

            if (list_dshd.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = list_dshd.SelectedItems[0];
                int id_in = int.Parse(selectedItem.SubItems[1].Text);
                LoadDetailInvoices(id_in);
            }
        }
        private string setNameProduct(int id)
        {
            {
                string name = "";
                List<ProductDTO> products = productBUS.GetProducts();
                foreach (var i in products)
                {
                    if (i.ProductId == id)
                    {
                        name = i.ProductName;
                        break;
                    }
                }
                return name;

            }
        }
        private string setNamePromotion(int id)
        {
            {
                string name = "";
                List<PromotionDTO> promotions = customerBUS.GetAllPromotions();
                foreach (var i in promotions)
                {
                    if (i.PromotionID == id)
                    {
                        name = i.PromotionName;
                        break;
                    }
                }
                return name;

            }
        }

        private void list_dskh_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = list_dskh.Columns[e.ColumnIndex].Width;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cbbSearch.SelectedItem.ToString();
            txtSearch.Text = "";
            btnLoc.Visible = false;
            panelSearchPoint.Visible = false;
            panelSearchDate.Visible = false;

            if (selectedValue == "Điểm thưởng")
            {
                panelSearchPoint.Visible = true;
                btnLoc.Visible = true;
            }
            else if (selectedValue == "Ngày mua hàng")
            {
                panelSearchDate.Visible = true;
                btnLoc.Visible = true;
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            string opt = "";

            string selectedValue = cbbSearch.SelectedItem?.ToString();

            if (selectedValue == "Điểm thưởng")
            {
                if (rdbAll.Checked)
                {
                    opt = "Tất cả";
                    List<CustomerDTO> result = customerBUS.GetAllCustomers();
                    UpdateCustomerList(result);
                }
                else if (rdbMax.Checked)
                {
                    opt = "Từ lớn đến bé";
                    List<CustomerDTO> result = customerBUS.GetCustomersMaxPoint();
                    UpdateCustomerList(result);
                }
                else if (rdbMin.Checked)
                {
                    opt = "Từ bé đến lớn";
                    List<CustomerDTO> result = customerBUS.GetCustomersMinPoint();
                    UpdateCustomerList(result);
                }
            }


            else if (selectedValue == "Ngày mua hàng")

            {
                DateTime DateStart = cbbDayS.Value;
                DateTime DateEnd = cbbDayE.Value;
                List<CustomerDTO> result = new List<CustomerDTO>();
                List<InvoiceDTO> invoices = customerBUS.GetInvoicesByDateRange(DateStart, DateEnd);
                List<int> addedCustomerIDs = new List<int>();

                foreach (InvoiceDTO invoice in invoices)
                {
                    foreach (CustomerDTO i in customers)
                    {
                        if (invoice.CustomerID == i.CustomerID && !addedCustomerIDs.Contains(i.CustomerID))
                        {
                            result.Add(i);
                            addedCustomerIDs.Add(i.CustomerID);
                        }
                    }
                }
                UpdateCustomerList(result);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadCustomers();
        }
        private void checkRole()
        {
            string role = employeeBUS.GetRoleById(id);
            if (role.Equals("Nhân viên bán hàng"))
            {
                btnAdd.Visible = false;

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
