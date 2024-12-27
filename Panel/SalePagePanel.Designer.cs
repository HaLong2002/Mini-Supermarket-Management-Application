namespace SieuThiMini.Panel
{
    partial class SalePagePanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            txtSearchPromotions = new TextBox();
            ViewPromotions = new DataGridView();
            tabPage3 = new TabPage();
            btnAdd = new Button();
            cbbDayOfBirth = new DateTimePicker();
            txtPoint = new TextBox();
            groupGioiTinh = new GroupBox();
            rdbKhac = new RadioButton();
            rdbNu = new RadioButton();
            rdnNam = new RadioButton();
            txtPhoneNumber = new TextBox();
            txtName = new TextBox();
            txtID = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtSearchCustomer = new TextBox();
            ViewCustomer = new DataGridView();
            tabPage4 = new TabPage();
            lblThanhTien = new Label();
            ViewCartItem = new DataGridView();
            btnCreateInvoice = new Button();
            txtCustomerID = new TextBox();
            txtEmployeeID = new TextBox();
            lblCustomerID = new Label();
            lblUserID = new Label();
            tabPage5 = new TabPage();
            btnExport = new Button();
            ViewCTHD = new DataGridView();
            ViewHD = new DataGridView();
            textBox1 = new TextBox();
            label2 = new Label();
            btnXN = new Button();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ViewPromotions).BeginInit();
            tabPage3.SuspendLayout();
            groupGioiTinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ViewCustomer).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ViewCartItem).BeginInit();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ViewCTHD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ViewHD).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Location = new Point(2, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(903, 695);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(895, 667);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Trang Mua Hàng";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnXN);
            tabPage2.Controls.Add(txtSearchPromotions);
            tabPage2.Controls.Add(ViewPromotions);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(895, 667);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Trang Giỏ Hàng";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtSearchPromotions
            // 
            txtSearchPromotions.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearchPromotions.Location = new Point(3, 409);
            txtSearchPromotions.Name = "txtSearchPromotions";
            txtSearchPromotions.PlaceholderText = "Tìm Mã Giảm Giá";
            txtSearchPromotions.Size = new Size(191, 33);
            txtSearchPromotions.TabIndex = 1;
            txtSearchPromotions.TextChanged += txtSearchPromotions_TextChanged;
            // 
            // ViewPromotions
            // 
            ViewPromotions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ViewPromotions.Location = new Point(-3, 448);
            ViewPromotions.Name = "ViewPromotions";
            ViewPromotions.ReadOnly = true;
            ViewPromotions.RowHeadersWidth = 51;
            ViewPromotions.RowTemplate.Height = 25;
            ViewPromotions.Size = new Size(895, 115);
            ViewPromotions.TabIndex = 0;
            ViewPromotions.CellContentClick += ViewPromotions_CellContentClick;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btnAdd);
            tabPage3.Controls.Add(cbbDayOfBirth);
            tabPage3.Controls.Add(txtPoint);
            tabPage3.Controls.Add(groupGioiTinh);
            tabPage3.Controls.Add(txtPhoneNumber);
            tabPage3.Controls.Add(txtName);
            tabPage3.Controls.Add(txtID);
            tabPage3.Controls.Add(label9);
            tabPage3.Controls.Add(label8);
            tabPage3.Controls.Add(label7);
            tabPage3.Controls.Add(label6);
            tabPage3.Controls.Add(label5);
            tabPage3.Controls.Add(label4);
            tabPage3.Controls.Add(txtSearchCustomer);
            tabPage3.Controls.Add(ViewCustomer);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(895, 667);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Thông Tin Khách Hàng";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(0, 192, 0);
            btnAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.ForeColor = SystemColors.ButtonHighlight;
            btnAdd.Location = new Point(344, 234);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(80, 40);
            btnAdd.TabIndex = 34;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // cbbDayOfBirth
            // 
            cbbDayOfBirth.Location = new Point(207, 191);
            cbbDayOfBirth.Name = "cbbDayOfBirth";
            cbbDayOfBirth.Size = new Size(177, 23);
            cbbDayOfBirth.TabIndex = 33;
            // 
            // txtPoint
            // 
            txtPoint.Enabled = false;
            txtPoint.Location = new Point(497, 195);
            txtPoint.Multiline = true;
            txtPoint.Name = "txtPoint";
            txtPoint.Size = new Size(177, 23);
            txtPoint.TabIndex = 32;
            // 
            // groupGioiTinh
            // 
            groupGioiTinh.Controls.Add(rdbKhac);
            groupGioiTinh.Controls.Add(rdbNu);
            groupGioiTinh.Controls.Add(rdnNam);
            groupGioiTinh.FlatStyle = FlatStyle.System;
            groupGioiTinh.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupGioiTinh.Location = new Point(497, 126);
            groupGioiTinh.Name = "groupGioiTinh";
            groupGioiTinh.Size = new Size(197, 45);
            groupGioiTinh.TabIndex = 31;
            groupGioiTinh.TabStop = false;
            // 
            // rdbKhac
            // 
            rdbKhac.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rdbKhac.Location = new Point(134, 11);
            rdbKhac.Name = "rdbKhac";
            rdbKhac.Size = new Size(63, 32);
            rdbKhac.TabIndex = 2;
            rdbKhac.TabStop = true;
            rdbKhac.Text = "Khác";
            rdbKhac.UseVisualStyleBackColor = true;
            // 
            // rdbNu
            // 
            rdbNu.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rdbNu.Location = new Point(65, 11);
            rdbNu.Name = "rdbNu";
            rdbNu.Size = new Size(63, 32);
            rdbNu.TabIndex = 1;
            rdbNu.TabStop = true;
            rdbNu.Text = "Nữ";
            rdbNu.UseVisualStyleBackColor = true;
            // 
            // rdnNam
            // 
            rdnNam.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rdnNam.Location = new Point(6, 11);
            rdnNam.Name = "rdnNam";
            rdnNam.Size = new Size(63, 32);
            rdnNam.TabIndex = 0;
            rdnNam.TabStop = true;
            rdnNam.Text = "Nam";
            rdnNam.UseVisualStyleBackColor = true;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(208, 145);
            txtPhoneNumber.Multiline = true;
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(177, 23);
            txtPhoneNumber.TabIndex = 30;
            // 
            // txtName
            // 
            txtName.Location = new Point(497, 97);
            txtName.Multiline = true;
            txtName.Name = "txtName";
            txtName.Size = new Size(177, 23);
            txtName.TabIndex = 29;
            // 
            // txtID
            // 
            txtID.Enabled = false;
            txtID.Location = new Point(208, 97);
            txtID.Multiline = true;
            txtID.Name = "txtID";
            txtID.Size = new Size(177, 23);
            txtID.TabIndex = 28;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(391, 193);
            label9.Name = "label9";
            label9.Size = new Size(102, 21);
            label9.TabIndex = 27;
            label9.Text = "Điểm thưởng";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(101, 191);
            label8.Name = "label8";
            label8.Size = new Size(80, 21);
            label8.TabIndex = 26;
            label8.Text = "Ngày sinh";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(391, 145);
            label7.Name = "label7";
            label7.Size = new Size(70, 21);
            label7.TabIndex = 25;
            label7.Text = "Giới tính";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(101, 143);
            label6.Name = "label6";
            label6.Size = new Size(101, 21);
            label6.TabIndex = 24;
            label6.Text = "Số điện thoại";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(391, 97);
            label5.Name = "label5";
            label5.Size = new Size(33, 21);
            label5.TabIndex = 23;
            label5.Text = "Tên";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(101, 95);
            label4.Name = "label4";
            label4.Size = new Size(25, 21);
            label4.TabIndex = 22;
            label4.Text = "ID";
            // 
            // txtSearchCustomer
            // 
            txtSearchCustomer.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearchCustomer.Location = new Point(3, 321);
            txtSearchCustomer.Name = "txtSearchCustomer";
            txtSearchCustomer.PlaceholderText = "Tìm Khách Hàng";
            txtSearchCustomer.Size = new Size(227, 33);
            txtSearchCustomer.TabIndex = 1;
            txtSearchCustomer.TextChanged += txtSearchCustomer_TextChanged;
            // 
            // ViewCustomer
            // 
            ViewCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ViewCustomer.Location = new Point(-3, 357);
            ViewCustomer.Name = "ViewCustomer";
            ViewCustomer.ReadOnly = true;
            ViewCustomer.RowHeadersWidth = 51;
            ViewCustomer.RowTemplate.Height = 25;
            ViewCustomer.Size = new Size(895, 150);
            ViewCustomer.TabIndex = 0;
            ViewCustomer.CellContentClick += ViewCustomer_CellContentClick;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(lblThanhTien);
            tabPage4.Controls.Add(ViewCartItem);
            tabPage4.Controls.Add(btnCreateInvoice);
            tabPage4.Controls.Add(txtCustomerID);
            tabPage4.Controls.Add(txtEmployeeID);
            tabPage4.Controls.Add(lblCustomerID);
            tabPage4.Controls.Add(lblUserID);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(895, 667);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Tạo Hóa Đơn ";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // lblThanhTien
            // 
            lblThanhTien.AutoSize = true;
            lblThanhTien.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblThanhTien.Location = new Point(6, 387);
            lblThanhTien.Name = "lblThanhTien";
            lblThanhTien.Size = new Size(0, 25);
            lblThanhTien.TabIndex = 5;
            // 
            // ViewCartItem
            // 
            ViewCartItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ViewCartItem.Location = new Point(6, 170);
            ViewCartItem.Name = "ViewCartItem";
            ViewCartItem.ReadOnly = true;
            ViewCartItem.RowHeadersWidth = 51;
            ViewCartItem.Size = new Size(880, 214);
            ViewCartItem.TabIndex = 4;
            ViewCartItem.CellContentClick += ViewCartItem_CellContentClick;
            // 
            // btnCreateInvoice
            // 
            btnCreateInvoice.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCreateInvoice.Location = new Point(254, 109);
            btnCreateInvoice.Name = "btnCreateInvoice";
            btnCreateInvoice.Size = new Size(153, 35);
            btnCreateInvoice.TabIndex = 3;
            btnCreateInvoice.Text = "Tạo Hóa Đơn";
            btnCreateInvoice.UseVisualStyleBackColor = true;
            btnCreateInvoice.Click += btnCreateInvoice_Click;
            // 
            // txtCustomerID
            // 
            txtCustomerID.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtCustomerID.Location = new Point(402, 53);
            txtCustomerID.Name = "txtCustomerID";
            txtCustomerID.ReadOnly = true;
            txtCustomerID.Size = new Size(164, 33);
            txtCustomerID.TabIndex = 2;
            // 
            // txtEmployeeID
            // 
            txtEmployeeID.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmployeeID.Location = new Point(402, 8);
            txtEmployeeID.Name = "txtEmployeeID";
            txtEmployeeID.ReadOnly = true;
            txtEmployeeID.Size = new Size(164, 33);
            txtEmployeeID.TabIndex = 2;
            // 
            // lblCustomerID
            // 
            lblCustomerID.AutoSize = true;
            lblCustomerID.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblCustomerID.Location = new Point(254, 61);
            lblCustomerID.Name = "lblCustomerID";
            lblCustomerID.Size = new Size(137, 25);
            lblCustomerID.TabIndex = 1;
            lblCustomerID.Text = "ID Khách Hàng";
            // 
            // lblUserID
            // 
            lblUserID.AutoSize = true;
            lblUserID.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblUserID.Location = new Point(254, 16);
            lblUserID.Name = "lblUserID";
            lblUserID.Size = new Size(124, 25);
            lblUserID.TabIndex = 0;
            lblUserID.Text = "ID Nhân Viên";
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(btnExport);
            tabPage5.Controls.Add(ViewCTHD);
            tabPage5.Controls.Add(ViewHD);
            tabPage5.Controls.Add(textBox1);
            tabPage5.Controls.Add(label2);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(895, 667);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Trang Chủ";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            btnExport.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnExport.Location = new Point(372, 460);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(147, 40);
            btnExport.TabIndex = 3;
            btnExport.Text = "Xuất Hóa Đơn";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // ViewCTHD
            // 
            ViewCTHD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ViewCTHD.Location = new Point(23, 277);
            ViewCTHD.Name = "ViewCTHD";
            ViewCTHD.ReadOnly = true;
            ViewCTHD.RowTemplate.Height = 25;
            ViewCTHD.Size = new Size(848, 150);
            ViewCTHD.TabIndex = 2;
            ViewCTHD.CellDoubleClick += ViewCTHD_CellDoubleClick;
            // 
            // ViewHD
            // 
            ViewHD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ViewHD.Location = new Point(23, 96);
            ViewHD.Name = "ViewHD";
            ViewHD.ReadOnly = true;
            ViewHD.RowTemplate.Height = 25;
            ViewHD.Size = new Size(848, 150);
            ViewHD.TabIndex = 2;
            ViewHD.CellDoubleClick += VỉewHD_CellDoubleClick;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(139, 51);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(188, 29);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(23, 59);
            label2.Name = "label2";
            label2.Size = new Size(110, 21);
            label2.TabIndex = 0;
            label2.Text = "Tìm Hóa Đơn";
            // 
            // btnXN
            // 
            btnXN.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnXN.Location = new Point(375, 582);
            btnXN.Name = "btnXN";
            btnXN.Size = new Size(119, 34);
            btnXN.TabIndex = 2;
            btnXN.Text = "Xác Nhận";
            btnXN.UseVisualStyleBackColor = true;
            btnXN.Click += btnXN_Click;
            // 
            // SalePagePanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(904, 697);
            Controls.Add(tabControl1);
            Name = "SalePagePanel";
            Text = "PurchasePagePanel";
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ViewPromotions).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            groupGioiTinh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ViewCustomer).EndInit();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ViewCartItem).EndInit();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ViewCTHD).EndInit();
            ((System.ComponentModel.ISupportInitialize)ViewHD).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Label lblThanhTien;
        private DataGridView ViewCustomer;
        private TextBox txtSearchCustomer;
        private TextBox txtSearchPromotions;
        private DataGridView ViewPromotions;
        private DateTimePicker cbbDayOfBirth;
        private TextBox txtPoint;
        private GroupBox groupGioiTinh;
        private RadioButton rdbKhac;
        private RadioButton rdbNu;
        private RadioButton rdnNam;
        private TextBox txtPhoneNumber;
        private TextBox txtName;
        private TextBox txtID;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Button btnAdd;
        private TabPage tabPage4;
        private Button btnCreateInvoice;
        private TextBox txtCustomerID;
        private TextBox txtEmployeeID;
        private Label lblCustomerID;
        private Label lblUserID;
        private Label label1;
        private DataGridView ViewCartItem;
        private TabPage tabPage5;
        private TextBox textBox1;
        private Label label2;
        private DataGridView ViewCTHD;
        private DataGridView ViewHD;
        private Button btnExport;
        private Button btnXN;
    }
}