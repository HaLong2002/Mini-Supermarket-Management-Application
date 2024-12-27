namespace SieuThiMini.Panel
{
    partial class SearchProductPanel
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblMinPrice;
        private System.Windows.Forms.Label lblMaxPrice;
        private System.Windows.Forms.TextBox txtMinPrice;
        private System.Windows.Forms.TextBox txtMaxPrice;
        private System.Windows.Forms.ComboBox cmbProductType;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.CheckBox chkProductType;
        private System.Windows.Forms.CheckBox chkBrand;
        private System.Windows.Forms.CheckBox chkCountry;
        private System.Windows.Forms.Button btnAdvancedSearch;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblMinPrice = new Label();
            lblMaxPrice = new Label();
            txtMinPrice = new TextBox();
            txtMaxPrice = new TextBox();
            cmbProductType = new ComboBox();
            cmbBrand = new ComboBox();
            cmbCountry = new ComboBox();
            chkProductType = new CheckBox();
            chkBrand = new CheckBox();
            chkCountry = new CheckBox();
            btnAdvancedSearch = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnTroVe = new Button();
            SuspendLayout();
            // 
            // lblMinPrice
            // 
            lblMinPrice.AutoSize = true;
            lblMinPrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblMinPrice.Location = new Point(33, 56);
            lblMinPrice.Name = "lblMinPrice";
            lblMinPrice.Size = new Size(78, 15);
            lblMinPrice.TabIndex = 0;
            lblMinPrice.Text = "Giá tối thiểu:";
            // 
            // lblMaxPrice
            // 
            lblMaxPrice.AutoSize = true;
            lblMaxPrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblMaxPrice.Location = new Point(163, 56);
            lblMaxPrice.Name = "lblMaxPrice";
            lblMaxPrice.Size = new Size(63, 15);
            lblMaxPrice.TabIndex = 2;
            lblMaxPrice.Text = "Giá tối đa:";
            // 
            // txtMinPrice
            // 
            txtMinPrice.Location = new Point(33, 76);
            txtMinPrice.Name = "txtMinPrice";
            txtMinPrice.Size = new Size(114, 23);
            txtMinPrice.TabIndex = 1;
            // 
            // txtMaxPrice
            // 
            txtMaxPrice.Location = new Point(163, 76);
            txtMaxPrice.Name = "txtMaxPrice";
            txtMaxPrice.Size = new Size(100, 23);
            txtMaxPrice.TabIndex = 3;
            // 
            // cmbProductType
            // 
            cmbProductType.FormattingEnabled = true;
            cmbProductType.Location = new Point(33, 120);
            cmbProductType.Name = "cmbProductType";
            cmbProductType.Size = new Size(230, 23);
            cmbProductType.TabIndex = 4;
            // 
            // cmbBrand
            // 
            cmbBrand.FormattingEnabled = true;
            cmbBrand.Location = new Point(33, 166);
            cmbBrand.Name = "cmbBrand";
            cmbBrand.Size = new Size(230, 23);
            cmbBrand.TabIndex = 5;
            // 
            // cmbCountry
            // 
            cmbCountry.FormattingEnabled = true;
            cmbCountry.Location = new Point(33, 211);
            cmbCountry.Name = "cmbCountry";
            cmbCountry.Size = new Size(230, 23);
            cmbCountry.TabIndex = 6;
            // 
            // chkProductType
            // 
            chkProductType.AutoSize = true;
            chkProductType.Location = new Point(273, 124);
            chkProductType.Name = "chkProductType";
            chkProductType.Size = new Size(15, 14);
            chkProductType.TabIndex = 7;
            chkProductType.UseVisualStyleBackColor = true;
            // 
            // chkBrand
            // 
            chkBrand.AutoSize = true;
            chkBrand.Location = new Point(273, 170);
            chkBrand.Name = "chkBrand";
            chkBrand.Size = new Size(15, 14);
            chkBrand.TabIndex = 8;
            chkBrand.UseVisualStyleBackColor = true;
            // 
            // chkCountry
            // 
            chkCountry.AutoSize = true;
            chkCountry.Location = new Point(273, 211);
            chkCountry.Name = "chkCountry";
            chkCountry.Size = new Size(15, 14);
            chkCountry.TabIndex = 9;
            chkCountry.UseVisualStyleBackColor = true;
            // 
            // btnAdvancedSearch
            // 
            btnAdvancedSearch.Location = new Point(33, 266);
            btnAdvancedSearch.Name = "btnAdvancedSearch";
            btnAdvancedSearch.Size = new Size(120, 30);
            btnAdvancedSearch.TabIndex = 10;
            btnAdvancedSearch.Text = "Tìm kiếm nâng cao";
            btnAdvancedSearch.UseVisualStyleBackColor = true;
            btnAdvancedSearch.Click += btnAdvancedSearch_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(33, 9);
            label1.Name = "label1";
            label1.Size = new Size(247, 24);
            label1.TabIndex = 11;
            label1.Text = "Hãy chọn các điều kiện lọc";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(33, 102);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 12;
            label2.Text = "Loại sản phẩm";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(33, 148);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 13;
            label3.Text = "Hãng ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(33, 193);
            label4.Name = "label4";
            label4.Size = new Size(104, 15);
            label4.TabIndex = 14;
            label4.Text = "Quốc gia sản xuất";
            // 
            // btnTroVe
            // 
            btnTroVe.Location = new Point(188, 266);
            btnTroVe.Name = "btnTroVe";
            btnTroVe.Size = new Size(100, 30);
            btnTroVe.TabIndex = 15;
            btnTroVe.Text = "Trở về";
            btnTroVe.UseVisualStyleBackColor = true;
            btnTroVe.Click += btnTroVe_Click;
            // 
            // SearchProductPanel
            // 
            BackColor = SystemColors.GradientActiveCaption;
            Controls.Add(btnTroVe);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblMinPrice);
            Controls.Add(txtMinPrice);
            Controls.Add(lblMaxPrice);
            Controls.Add(txtMaxPrice);
            Controls.Add(cmbProductType);
            Controls.Add(cmbBrand);
            Controls.Add(cmbCountry);
            Controls.Add(chkProductType);
            Controls.Add(chkBrand);
            Controls.Add(chkCountry);
            Controls.Add(btnAdvancedSearch);
            Name = "SearchProductPanel";
            Size = new Size(331, 320);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnTroVe;
    }
}
