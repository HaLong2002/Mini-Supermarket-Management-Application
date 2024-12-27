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
    public partial class SignUpPanel : Form
    {
        public SignUpPanel()
        {
            InitializeComponent();
        }

        private void btnDangNhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginPanel login = new LoginPanel();
            this.Hide();
        }
    }
}
