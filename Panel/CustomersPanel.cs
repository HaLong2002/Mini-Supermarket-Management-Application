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
    public partial class CustomersPanel : Form
    {
        private CustomerBUS customerBUS = new CustomerBUS();
       // private int selectId;
        public CustomersPanel()
        {
            InitializeComponent();
            LoadCustomer();
        }

        public void LoadCustomer()
        {
            var customers = customerBUS.GetAllCustomers();
            ViewKH.DataSource = customers;
        }

        public void Reset()
        {
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtSĐT.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }

        private void btnLock_Click(object sender, EventArgs e)
        {

        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void ViewKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CustomersPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
