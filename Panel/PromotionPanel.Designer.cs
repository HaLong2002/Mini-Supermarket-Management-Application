namespace SieuThiMini.Panel
{
    partial class PromotionPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PromotionPanel));
            ViewPromotion = new DataGridView();
            txtPromotionId = new TextBox();
            txtPromotionName = new TextBox();
            txtPoint = new TextBox();
            txtDiscountPercent = new TextBox();
            dateStartDate = new DateTimePicker();
            dateEndDate = new DateTimePicker();
            btnExportExcel = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            txtSearchPromotion = new TextBox();
            btnLock = new Button();
            btnUnLock = new Button();
            txtProductID = new TextBox();
            txtSearchProduct = new TextBox();
            ViewProduct = new DataGridView();
            lblEmployeeName = new Label();
            btnNext = new Button();
            ((System.ComponentModel.ISupportInitialize)ViewPromotion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ViewProduct).BeginInit();
            SuspendLayout();
            // 
            // ViewPromotion
            // 
            ViewPromotion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ViewPromotion.Location = new Point(14, 83);
            ViewPromotion.Name = "ViewPromotion";
            ViewPromotion.ReadOnly = true;
            ViewPromotion.RowTemplate.Height = 25;
            ViewPromotion.Size = new Size(880, 143);
            ViewPromotion.TabIndex = 0;
            ViewPromotion.CellContentClick += ViewPromotion_CellContentClick;
            // 
            // txtPromotionId
            // 
            txtPromotionId.Location = new Point(10, 434);
            txtPromotionId.Margin = new Padding(4, 3, 4, 3);
            txtPromotionId.Name = "txtPromotionId";
            txtPromotionId.PlaceholderText = "Promotion ID";
            txtPromotionId.ReadOnly = true;
            txtPromotionId.Size = new Size(270, 23);
            txtPromotionId.TabIndex = 2;
            // 
            // txtPromotionName
            // 
            txtPromotionName.Location = new Point(10, 497);
            txtPromotionName.Margin = new Padding(4, 3, 4, 3);
            txtPromotionName.Name = "txtPromotionName";
            txtPromotionName.PlaceholderText = "Promotion Name";
            txtPromotionName.Size = new Size(270, 23);
            txtPromotionName.TabIndex = 4;
            // 
            // txtPoint
            // 
            txtPoint.Location = new Point(288, 443);
            txtPoint.Margin = new Padding(4, 3, 4, 3);
            txtPoint.Name = "txtPoint";
            txtPoint.PlaceholderText = "Point";
            txtPoint.Size = new Size(270, 23);
            txtPoint.TabIndex = 5;
            // 
            // txtDiscountPercent
            // 
            txtDiscountPercent.Location = new Point(288, 483);
            txtDiscountPercent.Margin = new Padding(4, 3, 4, 3);
            txtDiscountPercent.Name = "txtDiscountPercent";
            txtDiscountPercent.PlaceholderText = "Discount Percent ";
            txtDiscountPercent.Size = new Size(270, 23);
            txtDiscountPercent.TabIndex = 6;
            // 
            // dateStartDate
            // 
            dateStartDate.Location = new Point(10, 531);
            dateStartDate.Margin = new Padding(4, 3, 4, 3);
            dateStartDate.Name = "dateStartDate";
            dateStartDate.Size = new Size(270, 23);
            dateStartDate.TabIndex = 22;
            // 
            // dateEndDate
            // 
            dateEndDate.Location = new Point(288, 531);
            dateEndDate.Margin = new Padding(4, 3, 4, 3);
            dateEndDate.Name = "dateEndDate";
            dateEndDate.Size = new Size(270, 23);
            dateEndDate.TabIndex = 23;
            // 
            // btnExportExcel
            // 
            btnExportExcel.BackColor = Color.SkyBlue;
            btnExportExcel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnExportExcel.Location = new Point(787, 483);
            btnExportExcel.Margin = new Padding(4, 3, 4, 3);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(102, 37);
            btnExportExcel.TabIndex = 31;
            btnExportExcel.Text = "Xuất ra Excel";
            btnExportExcel.UseVisualStyleBackColor = false;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.SkyBlue;
            btnAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.Location = new Point(573, 434);
            btnAdd.Margin = new Padding(4, 3, 4, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(102, 37);
            btnAdd.TabIndex = 27;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.SkyBlue;
            btnUpdate.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdate.Location = new Point(573, 483);
            btnUpdate.Margin = new Padding(4, 3, 4, 3);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(102, 37);
            btnUpdate.TabIndex = 28;
            btnUpdate.Text = "Sửa";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.SkyBlue;
            btnDelete.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.Location = new Point(573, 531);
            btnDelete.Margin = new Padding(4, 3, 4, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(102, 37);
            btnDelete.TabIndex = 29;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtSearchPromotion
            // 
            txtSearchPromotion.Location = new Point(15, 54);
            txtSearchPromotion.Margin = new Padding(4, 3, 4, 3);
            txtSearchPromotion.Name = "txtSearchPromotion";
            txtSearchPromotion.PlaceholderText = "Search Promotion";
            txtSearchPromotion.Size = new Size(270, 23);
            txtSearchPromotion.TabIndex = 34;
            txtSearchPromotion.TextChanged += txtSearchPromotion_TextChanged;
            // 
            // btnLock
            // 
            btnLock.BackColor = Color.SkyBlue;
            btnLock.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnLock.Location = new Point(693, 459);
            btnLock.Margin = new Padding(4, 3, 4, 3);
            btnLock.Name = "btnLock";
            btnLock.Size = new Size(86, 37);
            btnLock.TabIndex = 35;
            btnLock.Text = "Lock";
            btnLock.UseVisualStyleBackColor = false;
            btnLock.Click += btnLock_Click;
            // 
            // btnUnLock
            // 
            btnUnLock.BackColor = Color.SkyBlue;
            btnUnLock.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnUnLock.Location = new Point(693, 506);
            btnUnLock.Margin = new Padding(4, 3, 4, 3);
            btnUnLock.Name = "btnUnLock";
            btnUnLock.Size = new Size(86, 37);
            btnUnLock.TabIndex = 36;
            btnUnLock.Text = "UnLock";
            btnUnLock.UseVisualStyleBackColor = false;
            btnUnLock.Click += btnUnLock_Click;
            // 
            // txtProductID
            // 
            txtProductID.Location = new Point(10, 468);
            txtProductID.Margin = new Padding(4, 3, 4, 3);
            txtProductID.Name = "txtProductID";
            txtProductID.PlaceholderText = "Product ID";
            txtProductID.ReadOnly = true;
            txtProductID.Size = new Size(270, 23);
            txtProductID.TabIndex = 37;
            // 
            // txtSearchProduct
            // 
            txtSearchProduct.Location = new Point(11, 241);
            txtSearchProduct.Margin = new Padding(4, 3, 4, 3);
            txtSearchProduct.Name = "txtSearchProduct";
            txtSearchProduct.PlaceholderText = "Search Product";
            txtSearchProduct.Size = new Size(270, 23);
            txtSearchProduct.TabIndex = 39;
            txtSearchProduct.TextChanged += txtSearchProduct_TextChanged;
            // 
            // ViewProduct
            // 
            ViewProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ViewProduct.Location = new Point(10, 270);
            ViewProduct.Name = "ViewProduct";
            ViewProduct.ReadOnly = true;
            ViewProduct.RowTemplate.Height = 25;
            ViewProduct.Size = new Size(880, 143);
            ViewProduct.TabIndex = 38;
            ViewProduct.CellContentClick += ViewProduct_CellContentClick;
            // 
            // lblEmployeeName
            // 
            lblEmployeeName.AutoSize = true;
            lblEmployeeName.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblEmployeeName.Location = new Point(14, 9);
            lblEmployeeName.Name = "lblEmployeeName";
            lblEmployeeName.Size = new Size(0, 28);
            lblEmployeeName.TabIndex = 40;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.SkyBlue;
            btnNext.BackgroundImage = (Image)resources.GetObject("btnNext.BackgroundImage");
            btnNext.BackgroundImageLayout = ImageLayout.Center;
            btnNext.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnNext.Location = new Point(854, 531);
            btnNext.Margin = new Padding(4, 3, 4, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(49, 50);
            btnNext.TabIndex = 41;
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // PromotionPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(904, 577);
            Controls.Add(btnNext);
            Controls.Add(lblEmployeeName);
            Controls.Add(txtSearchProduct);
            Controls.Add(ViewProduct);
            Controls.Add(txtProductID);
            Controls.Add(btnUnLock);
            Controls.Add(btnLock);
            Controls.Add(txtSearchPromotion);
            Controls.Add(btnExportExcel);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(dateEndDate);
            Controls.Add(dateStartDate);
            Controls.Add(txtDiscountPercent);
            Controls.Add(txtPoint);
            Controls.Add(txtPromotionName);
            Controls.Add(txtPromotionId);
            Controls.Add(ViewPromotion);
            Name = "PromotionPanel";
            Text = "PromotionPanel";
            ((System.ComponentModel.ISupportInitialize)ViewPromotion).EndInit();
            ((System.ComponentModel.ISupportInitialize)ViewProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView ViewPromotion;
        private TextBox txtPromotionId;
        private TextBox txtPromotionName;
        private TextBox txtPoint;
        private TextBox txtDiscountPercent;
        private DateTimePicker dateStartDate;
        private DateTimePicker dateEndDate;
        private Button btnExportExcel;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private TextBox txtSearchPromotion;
        private Button btnLock;
        private Button btnUnLock;
        private TextBox txtProductID;
        private TextBox txtSearchProduct;
        private DataGridView ViewProduct;
        private Label lblEmployeeName;
        private Button btnNext;
    }
}