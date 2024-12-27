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
using System.Xml.Linq;

namespace SieuThiMini.Panel
{
    public partial class TestCustomerPromotionPanel : Form
    {
        private CustomerBUS customerBUS = new CustomerBUS();
        private TextBox txtCustomerID;
        private TextBox txtName;
        private TextBox txtPhone;
        private TextBox txtGender;
        private TextBox txtRewardPoint;
        private DateTimePicker dateDayOfBirth;
        public TestCustomerPromotionPanel()
        {
            InitializeComponent();
            InitializeCustomerInputPanel();
            LoadCustomer();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void LoadCustomer()
        {
            List<CustomerDTO> customers = customerBUS.GetAllCustomers();
            dataGridView1.DataSource = customers;
        }

        private void InitializeCustomerInputPanel()
        {
            // Tạo Panel chứa thông tin khách hàng
            System.Windows.Forms.Panel inputPanel = new System.Windows.Forms.Panel
            {
                Size = new System.Drawing.Size(800, 200), // Tăng kích thước panel nếu cần
                Location = new System.Drawing.Point(10, 10),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Tạo các Label và TextBox cho thông tin khách hàng
            Label lblCustomerID = new Label { Text = "Mã khách hàng:", Location = new System.Drawing.Point(10, 10), AutoSize = true };
            txtCustomerID = new TextBox { Location = new System.Drawing.Point(120, 10), Size = new System.Drawing.Size(200, 30), ReadOnly = true };

            Label lblName = new Label { Text = "Tên khách hàng:", Location = new System.Drawing.Point(10, 50), AutoSize = true };
            txtName = new TextBox { Location = new System.Drawing.Point(120, 50), Size = new System.Drawing.Size(200, 30), ReadOnly = true };

            Label lblPhone = new Label { Text = "Số điện thoại:", Location = new System.Drawing.Point(10, 90), AutoSize = true };
            txtPhone = new TextBox { Location = new System.Drawing.Point(120, 90), Size = new System.Drawing.Size(200, 30), ReadOnly = true   };

            // Di chuyển Label và TextBox Giới tính sang bên phải ngang hàng với CustomerID
            Label lblGender = new Label { Text = "Giới tính:", Location = new System.Drawing.Point(330, 10), AutoSize = true }; // Đặt ở bên phải CustomerID
            txtGender = new TextBox { Location = new System.Drawing.Point(400, 10), Size = new System.Drawing.Size(100, 30), ReadOnly = true }; // Tương tự, đặt bên phải

            // Di chuyển Label và TextBox Điểm thưởng sang bên phải ngang hàng với CustomerID
            Label lblRewardPoint = new Label { Text = "Điểm thưởng:", Location = new System.Drawing.Point(330, 50), AutoSize = true }; // Đặt ở bên phải
            txtRewardPoint = new TextBox { Location = new System.Drawing.Point(400, 50), Size = new System.Drawing.Size(100, 30), ReadOnly = true }; // Tương tự, đặt bên phải

            // Di chuyển Label và DateTimePicker Ngày sinh sang bên phải ngang hàng với CustomerID
            Label lblDayOfBirth = new Label { Text = "Ngày sinh:", Location = new System.Drawing.Point(330, 90), AutoSize = true }; // Đặt ở bên phải
            dateDayOfBirth = new DateTimePicker { Location = new System.Drawing.Point(400, 90), Size = new System.Drawing.Size(100, 100), Enabled = false }; // Tương tự, đặt bên phải

            // Tạo Button để chuyển sang Form Mã Giảm Giá
            Button btnGoToPromotions = new Button
            {
                Text = "Sang trang mã giảm giá",
                Location = new System.Drawing.Point(10, 130), // Đặt nút bên dưới các trường khác
                Size = new System.Drawing.Size(150, 30)
            };

            // Gán sự kiện Click cho nút
            btnGoToPromotions.Click += (sender, e) =>
            {
                String customerID = txtCustomerID.Text;

                // Kiểm tra nếu mã khách hàng rỗng
                if (string.IsNullOrEmpty(txtCustomerID.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã khách hàng.");
                    return;
                }
                this.Hide();

                // Mở Form2 và truyền mã khách hàng
                CustomerPromotionPanel promotionForm = new CustomerPromotionPanel(customerID);
                promotionForm.customerID = customerID;
                promotionForm.Show();
            };

            // Thêm các control vào Panel
            inputPanel.Controls.Add(lblCustomerID);
            inputPanel.Controls.Add(txtCustomerID);
            inputPanel.Controls.Add(lblName);
            inputPanel.Controls.Add(txtName);
            inputPanel.Controls.Add(lblPhone);
            inputPanel.Controls.Add(txtPhone);
            inputPanel.Controls.Add(lblGender);
            inputPanel.Controls.Add(txtGender);
            inputPanel.Controls.Add(lblRewardPoint);
            inputPanel.Controls.Add(txtRewardPoint);
            inputPanel.Controls.Add(lblDayOfBirth);
            inputPanel.Controls.Add(dateDayOfBirth);
            inputPanel.Controls.Add(btnGoToPromotions);

            // Thêm Panel vào Form
            this.Controls.Add(inputPanel);
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Kiểm tra giá trị và gán vào TextBox
                txtCustomerID.Text = row.Cells["CustomerID"].Value?.ToString() ?? string.Empty;
                txtName.Text = row.Cells["Name"].Value?.ToString() ?? string.Empty;
                txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? string.Empty;
                txtGender.Text = row.Cells["Gender"].Value?.ToString() ?? string.Empty;
                txtRewardPoint.Text = row.Cells["RewardPoint"].Value?.ToString() ?? string.Empty;

                // Chuyển đổi giá trị ngày sinh
                if (row.Cells["DayOfBirth"].Value != null && DateTime.TryParse(row.Cells["DayOfBirth"].Value.ToString(), out DateTime dayOfBirth))
                {
                    dateDayOfBirth.Value = dayOfBirth;
                }
                else
                {
                    dateDayOfBirth.Value = DateTime.Today;
                }
            }
        }
    }
}
