namespace SieuThiMini.Panel
{
    partial class ProductEntryPage
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
            btnDelNCC = new Button();
            txtSearchNCC = new TextBox();
            ViewNCC = new DataGridView();
            tabPage2 = new TabPage();
            txtTotal = new TextBox();
            ViewCartItem = new DataGridView();
            btnCreate = new Button();
            lblEmployeeID = new Label();
            label2 = new Label();
            lblTotal = new Label();
            label1 = new Label();
            tabPage3 = new TabPage();
            btnExport = new Button();
            ViewCTHD = new DataGridView();
            ViewHDN = new DataGridView();
            txtHDN = new TextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ViewNCC).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ViewCartItem).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ViewCTHD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ViewHDN).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(0, 2);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1078, 657);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnDelNCC);
            tabPage1.Controls.Add(txtSearchNCC);
            tabPage1.Controls.Add(ViewNCC);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(3, 2, 3, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 2, 3, 2);
            tabPage1.Size = new Size(1070, 629);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Chọn Hàng";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnDelNCC
            // 
            btnDelNCC.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelNCC.Location = new Point(791, 23);
            btnDelNCC.Name = "btnDelNCC";
            btnDelNCC.Size = new Size(276, 36);
            btnDelNCC.TabIndex = 2;
            btnDelNCC.Text = "Bỏ Chọn Nhà Cung Cấp";
            btnDelNCC.UseVisualStyleBackColor = true;
            btnDelNCC.MouseClick += btnDelNCC_MouseClick;
            // 
            // txtSearchNCC
            // 
            txtSearchNCC.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearchNCC.Location = new Point(7, 23);
            txtSearchNCC.Margin = new Padding(3, 2, 3, 2);
            txtSearchNCC.Name = "txtSearchNCC";
            txtSearchNCC.PlaceholderText = "Tìm Nhà Cung Cấp";
            txtSearchNCC.Size = new Size(208, 36);
            txtSearchNCC.TabIndex = 1;
            txtSearchNCC.TextChanged += txtSearchNCC_TextChanged;
            // 
            // ViewNCC
            // 
            ViewNCC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ViewNCC.Location = new Point(5, 60);
            ViewNCC.Margin = new Padding(3, 2, 3, 2);
            ViewNCC.Name = "ViewNCC";
            ViewNCC.ReadOnly = true;
            ViewNCC.RowHeadersWidth = 51;
            ViewNCC.RowTemplate.Height = 29;
            ViewNCC.Size = new Size(1060, 183);
            ViewNCC.TabIndex = 0;
            ViewNCC.CellDoubleClick += ViewNCC_CellDoubleClick;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(txtTotal);
            tabPage2.Controls.Add(ViewCartItem);
            tabPage2.Controls.Add(btnCreate);
            tabPage2.Controls.Add(lblEmployeeID);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(lblTotal);
            tabPage2.Controls.Add(label1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new Size(1070, 629);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Giỏ Hàng";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtTotal
            // 
            txtTotal.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtTotal.Location = new Point(137, 327);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(273, 35);
            txtTotal.TabIndex = 6;
            // 
            // ViewCartItem
            // 
            ViewCartItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ViewCartItem.Location = new Point(416, 332);
            ViewCartItem.Name = "ViewCartItem";
            ViewCartItem.RowTemplate.Height = 25;
            ViewCartItem.Size = new Size(654, 129);
            ViewCartItem.TabIndex = 5;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.Transparent;
            btnCreate.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnCreate.Location = new Point(416, 486);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(169, 42);
            btnCreate.TabIndex = 4;
            btnCreate.Text = "Tạo Hóa Đơn";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // lblEmployeeID
            // 
            lblEmployeeID.AutoSize = true;
            lblEmployeeID.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblEmployeeID.Location = new Point(154, 377);
            lblEmployeeID.Name = "lblEmployeeID";
            lblEmployeeID.Size = new Size(0, 25);
            lblEmployeeID.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(3, 373);
            label2.Name = "label2";
            label2.Size = new Size(145, 30);
            label2.TabIndex = 2;
            label2.Text = "ID Nhân Viên";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblTotal.Location = new Point(93, 335);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(0, 25);
            lblTotal.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(3, 332);
            label1.Name = "label1";
            label1.Size = new Size(128, 30);
            label1.TabIndex = 0;
            label1.Text = "Tổng Tiền :";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btnExport);
            tabPage3.Controls.Add(ViewCTHD);
            tabPage3.Controls.Add(ViewHDN);
            tabPage3.Controls.Add(txtHDN);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1070, 629);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Trang Chủ";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            btnExport.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnExport.Location = new Point(438, 463);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(170, 42);
            btnExport.TabIndex = 4;
            btnExport.Text = "Xuất Hóa Đơn";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // ViewCTHD
            // 
            ViewCTHD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ViewCTHD.Location = new Point(6, 266);
            ViewCTHD.Name = "ViewCTHD";
            ViewCTHD.ReadOnly = true;
            ViewCTHD.RowTemplate.Height = 25;
            ViewCTHD.Size = new Size(1058, 166);
            ViewCTHD.TabIndex = 3;
            ViewCTHD.CellDoubleClick += ViewCTHD_CellDoubleClick;
            // 
            // ViewHDN
            // 
            ViewHDN.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ViewHDN.Location = new Point(6, 44);
            ViewHDN.Name = "ViewHDN";
            ViewHDN.ReadOnly = true;
            ViewHDN.RowTemplate.Height = 25;
            ViewHDN.Size = new Size(1058, 166);
            ViewHDN.TabIndex = 1;
            ViewHDN.CellDoubleClick += ViewHDN_CellDoubleClick;
            // 
            // txtHDN
            // 
            txtHDN.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtHDN.Location = new Point(3, 3);
            txtHDN.Name = "txtHDN";
            txtHDN.PlaceholderText = "Tìm Hóa Đơn Nhập";
            txtHDN.Size = new Size(191, 35);
            txtHDN.TabIndex = 0;
            txtHDN.TextChanged += txtHDN_TextChanged;
            // 
            // ProductEntryPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1076, 634);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ProductEntryPage";
            Text = "ProductEntryPage";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ViewNCC).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ViewCartItem).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ViewCTHD).EndInit();
            ((System.ComponentModel.ISupportInitialize)ViewHDN).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private Label lblTotal;
        private DataGridView ViewNCC;
        private TextBox txtSearchNCC;
        private Label lblEmployeeID;
        private Label label2;
        private Button btnCreate;
        private DataGridView ViewCartItem;
        private TextBox txtTotal;
        private Button btnDelNCC;
        private TabPage tabPage3;
        private TextBox txtHDN;
        private DataGridView ViewHDN;
        private Button btnExport;
        private DataGridView ViewCTHD;
    }
}