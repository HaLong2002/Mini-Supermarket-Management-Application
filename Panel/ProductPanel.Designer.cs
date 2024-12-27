using OfficeOpenXml;
using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SieuThiMini.Panel
{
    partial class ProductPanel
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private SearchProductPanel SearchProductPanel;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductPanel));
            tabControl = new TabControl();
            tabPageProductList = new TabPage();
            pictureBoxLoading = new PictureBox();
            btnExportPdf = new Button();
            btnFilter = new Button();
            btnExportExcel = new Button();
            btnImportExcel = new Button();
            dataGridViewProducts = new DataGridView();
            txtProductId = new TextBox();
            txtProductName = new TextBox();
            comboBoxProductType = new ComboBox();
            txtBrand = new TextBox();
            txtCountryOfOrigin = new TextBox();
            txtPrice = new TextBox();
            txtStockQuantity = new TextBox();
            txtUnit = new TextBox();
            txtDescription = new TextBox();
            txtIngredients = new TextBox();
            txtBenefits = new TextBox();
            txtWeight = new TextBox();
            txtFlavor = new TextBox();
            comboBoxStatus = new ComboBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            dateTimePickerManufactureDate = new DateTimePicker();
            dateTimePickerExpirationDate = new DateTimePicker();
            pictureBoxProductImage = new PictureBox();
            btnEditImage = new Button();
            tabPageProductCategory = new TabPage();
            tabControl.SuspendLayout();
            tabPageProductList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoading).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProductImage).BeginInit();
            SuspendLayout();
            //khởi tạo phân loại sp
            CategoryPanel categoryPanel = new CategoryPanel(id);
            categoryPanel.Dock = DockStyle.Fill; // Để chiếm toàn bộ không gian của tab
            tabPageProductCategory.Controls.Add(categoryPanel);

            //
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageProductList);
            tabControl.Controls.Add(tabPageProductCategory);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(4, 3, 4, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1169, 654);
            tabControl.TabIndex = 0;
            // 
            // tabPageProductList
            // 
            tabPageProductList.BackColor = Color.White;
            tabPageProductList.Controls.Add(pictureBoxLoading);
            tabPageProductList.Controls.Add(btnExportPdf);
            tabPageProductList.Controls.Add(btnFilter);
            tabPageProductList.Controls.Add(btnExportExcel);
            tabPageProductList.Controls.Add(btnImportExcel);
            tabPageProductList.Controls.Add(dataGridViewProducts);
            tabPageProductList.Controls.Add(txtProductId);
            tabPageProductList.Controls.Add(txtProductName);
            tabPageProductList.Controls.Add(comboBoxProductType);
            tabPageProductList.Controls.Add(txtBrand);
            tabPageProductList.Controls.Add(txtCountryOfOrigin);
            tabPageProductList.Controls.Add(txtPrice);
            tabPageProductList.Controls.Add(txtStockQuantity);
            tabPageProductList.Controls.Add(txtUnit);
            tabPageProductList.Controls.Add(txtDescription);
            tabPageProductList.Controls.Add(txtIngredients);
            tabPageProductList.Controls.Add(txtBenefits);
            tabPageProductList.Controls.Add(txtWeight);
            tabPageProductList.Controls.Add(txtFlavor);
            tabPageProductList.Controls.Add(comboBoxStatus);
            tabPageProductList.Controls.Add(btnAdd);
            tabPageProductList.Controls.Add(btnUpdate);
            tabPageProductList.Controls.Add(btnDelete);
            tabPageProductList.Controls.Add(btnSearch);
            tabPageProductList.Controls.Add(txtSearch);
            tabPageProductList.Controls.Add(dateTimePickerManufactureDate);
            tabPageProductList.Controls.Add(dateTimePickerExpirationDate);
            tabPageProductList.Controls.Add(pictureBoxProductImage);
            tabPageProductList.Controls.Add(btnEditImage);
            tabPageProductList.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            tabPageProductList.Location = new Point(4, 24);
            tabPageProductList.Margin = new Padding(4, 3, 4, 3);
            tabPageProductList.Name = "tabPageProductList";
            tabPageProductList.Padding = new Padding(4, 3, 4, 3);
            tabPageProductList.Size = new Size(1161, 626);
            tabPageProductList.TabIndex = 0;
            tabPageProductList.Text = "Sản phẩm";
            // 
            // pictureBoxLoading
            // 
            pictureBoxLoading.BackColor = Color.Transparent;
            pictureBoxLoading.Image = (Image)resources.GetObject("pictureBoxLoading.Image");
            pictureBoxLoading.Location = new Point(4, 38);
            pictureBoxLoading.Name = "pictureBoxLoading";
            pictureBoxLoading.Size = new Size(1145, 372);
            pictureBoxLoading.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLoading.TabIndex = 29;
            pictureBoxLoading.TabStop = false;
            pictureBoxLoading.Visible = false;
            // 
            // btnExportPdf
            // 
            btnExportPdf.BackColor = Color.SkyBlue;
            btnExportPdf.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnExportPdf.Location = new Point(970, 554);
            btnExportPdf.Margin = new Padding(4, 3, 4, 3);
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.Size = new Size(102, 37);
            btnExportPdf.TabIndex = 28;
            btnExportPdf.Text = "In ra PDF";
            btnExportPdf.UseVisualStyleBackColor = false;
            btnExportPdf.Click += btnExportPdf_Click;
            // 
            // btnFilter
            // 
            btnFilter.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnFilter.Location = new Point(619, 9);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(75, 25);
            btnFilter.TabIndex = 27;
            btnFilter.Text = "Lọc";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnExportExcel
            // 
            btnExportExcel.BackColor = Color.SkyBlue;
            btnExportExcel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnExportExcel.Location = new Point(860, 554);
            btnExportExcel.Margin = new Padding(4, 3, 4, 3);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(102, 37);
            btnExportExcel.TabIndex = 26;
            btnExportExcel.Text = "Xuất ra Excel";
            btnExportExcel.UseVisualStyleBackColor = false;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // btnImportExcel
            // 
            btnImportExcel.BackColor = Color.SkyBlue;
            btnImportExcel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnImportExcel.Location = new Point(750, 554);
            btnImportExcel.Margin = new Padding(4, 3, 4, 3);
            btnImportExcel.Name = "btnImportExcel";
            btnImportExcel.Size = new Size(102, 37);
            btnImportExcel.TabIndex = 25;
            btnImportExcel.Text = "Nhập từ Excel";
            btnImportExcel.UseVisualStyleBackColor = false;
            btnImportExcel.Click += btnImportExcel_Click;
            // 
            // dataGridViewProducts
            // 
            dataGridViewProducts.BackgroundColor = SystemColors.ControlLightLight;
            dataGridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProducts.GridColor = SystemColors.GradientActiveCaption;
            dataGridViewProducts.Location = new Point(4, 38);
            dataGridViewProducts.Margin = new Padding(4, 3, 4, 3);
            dataGridViewProducts.Name = "dataGridViewProducts";
            dataGridViewProducts.Size = new Size(1145, 372);
            dataGridViewProducts.TabIndex = 0;
            dataGridViewProducts.CellClick += dataGridViewProducts_CellClick;
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(136, 416);
            txtProductId.Margin = new Padding(4, 3, 4, 3);
            txtProductId.Name = "txtProductId";
            txtProductId.PlaceholderText = "Product ID";
            txtProductId.ReadOnly = true;
            txtProductId.Size = new Size(270, 25);
            txtProductId.TabIndex = 1;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(136, 450);
            txtProductName.Margin = new Padding(4, 3, 4, 3);
            txtProductName.Name = "txtProductName";
            txtProductName.PlaceholderText = "Product Name";
            txtProductName.Size = new Size(270, 25);
            txtProductName.TabIndex = 2;
            // 
            // comboBoxProductType
            // 
            comboBoxProductType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProductType.FormattingEnabled = true;
            comboBoxProductType.Items.AddRange(new object[] { "A", "B" });
            comboBoxProductType.Location = new Point(136, 485);
            comboBoxProductType.Margin = new Padding(4, 3, 4, 3);
            comboBoxProductType.Name = "comboBoxProductType";
            comboBoxProductType.Size = new Size(270, 25);
            comboBoxProductType.TabIndex = 3;
            // 
            // txtBrand
            // 
            txtBrand.Location = new Point(136, 520);
            txtBrand.Margin = new Padding(4, 3, 4, 3);
            txtBrand.Name = "txtBrand";
            txtBrand.PlaceholderText = "Brand";
            txtBrand.Size = new Size(270, 25);
            txtBrand.TabIndex = 4;
            // 
            // txtCountryOfOrigin
            // 
            txtCountryOfOrigin.Location = new Point(136, 554);
            txtCountryOfOrigin.Margin = new Padding(4, 3, 4, 3);
            txtCountryOfOrigin.Name = "txtCountryOfOrigin";
            txtCountryOfOrigin.PlaceholderText = "Country of Origin";
            txtCountryOfOrigin.Size = new Size(270, 25);
            txtCountryOfOrigin.TabIndex = 5;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(414, 416);
            txtPrice.Margin = new Padding(4, 3, 4, 3);
            txtPrice.Name = "txtPrice";
            txtPrice.PlaceholderText = "Price";
            txtPrice.Size = new Size(270, 25);
            txtPrice.TabIndex = 6;
            // 
            // txtStockQuantity
            // 
            txtStockQuantity.Location = new Point(414, 450);
            txtStockQuantity.Margin = new Padding(4, 3, 4, 3);
            txtStockQuantity.Name = "txtStockQuantity";
            txtStockQuantity.PlaceholderText = "Stock Quantity";
            txtStockQuantity.ReadOnly = true;
            txtStockQuantity.Size = new Size(270, 25);
            txtStockQuantity.TabIndex = 7;
            txtStockQuantity.Text = "0";
            // 
            // txtUnit
            // 
            txtUnit.Location = new Point(414, 485);
            txtUnit.Margin = new Padding(4, 3, 4, 3);
            txtUnit.Name = "txtUnit";
            txtUnit.PlaceholderText = "Unit";
            txtUnit.Size = new Size(270, 25);
            txtUnit.TabIndex = 8;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(414, 520);
            txtDescription.Margin = new Padding(4, 3, 4, 3);
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Description";
            txtDescription.Size = new Size(270, 25);
            txtDescription.TabIndex = 9;
            // 
            // txtIngredients
            // 
            txtIngredients.Location = new Point(414, 554);
            txtIngredients.Margin = new Padding(4, 3, 4, 3);
            txtIngredients.Name = "txtIngredients";
            txtIngredients.PlaceholderText = "Ingredients";
            txtIngredients.Size = new Size(270, 25);
            txtIngredients.TabIndex = 10;
            // 
            // txtBenefits
            // 
            txtBenefits.Location = new Point(692, 417);
            txtBenefits.Margin = new Padding(4, 3, 4, 3);
            txtBenefits.Name = "txtBenefits";
            txtBenefits.PlaceholderText = "Benefits";
            txtBenefits.Size = new Size(270, 25);
            txtBenefits.TabIndex = 11;
            // 
            // txtWeight
            // 
            txtWeight.Location = new Point(692, 451);
            txtWeight.Margin = new Padding(4, 3, 4, 3);
            txtWeight.Name = "txtWeight";
            txtWeight.PlaceholderText = "Weight";
            txtWeight.Size = new Size(270, 25);
            txtWeight.TabIndex = 12;
            // 
            // txtFlavor
            // 
            txtFlavor.Location = new Point(692, 486);
            txtFlavor.Margin = new Padding(4, 3, 4, 3);
            txtFlavor.Name = "txtFlavor";
            txtFlavor.PlaceholderText = "Flavor";
            txtFlavor.Size = new Size(270, 25);
            txtFlavor.TabIndex = 13;
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Items.AddRange(new object[] { "Còn hạn lâu dài", "Gần hết hạn", "Hết hạn sử dụng", "Hư hỏng" });
            comboBoxStatus.Location = new Point(692, 520);
            comboBoxStatus.Margin = new Padding(4, 3, 4, 3);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(270, 25);
            comboBoxStatus.TabIndex = 15;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.SkyBlue;
            btnAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.Location = new Point(970, 417);
            btnAdd.Margin = new Padding(4, 3, 4, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(102, 37);
            btnAdd.TabIndex = 16;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.SkyBlue;
            btnUpdate.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdate.Location = new Point(970, 460);
            btnUpdate.Margin = new Padding(4, 3, 4, 3);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(102, 37);
            btnUpdate.TabIndex = 17;
            btnUpdate.Text = "Sửa";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.SkyBlue;
            btnDelete.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.Location = new Point(970, 503);
            btnDelete.Margin = new Padding(4, 3, 4, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(102, 37);
            btnDelete.TabIndex = 18;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnSearch.Location = new Point(1061, 9);
            btnSearch.Margin = new Padding(4, 3, 4, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(88, 25);
            btnSearch.TabIndex = 19;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(701, 9);
            txtSearch.Margin = new Padding(4, 3, 4, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search...";
            txtSearch.Size = new Size(352, 25);
            txtSearch.TabIndex = 20;
            // 
            // dateTimePickerManufactureDate
            // 
            dateTimePickerManufactureDate.Location = new Point(136, 585);
            dateTimePickerManufactureDate.Margin = new Padding(4, 3, 4, 3);
            dateTimePickerManufactureDate.Name = "dateTimePickerManufactureDate";
            dateTimePickerManufactureDate.Size = new Size(270, 25);
            dateTimePickerManufactureDate.TabIndex = 21;
            // 
            // dateTimePickerExpirationDate
            // 
            dateTimePickerExpirationDate.Location = new Point(414, 585);
            dateTimePickerExpirationDate.Margin = new Padding(4, 3, 4, 3);
            dateTimePickerExpirationDate.Name = "dateTimePickerExpirationDate";
            dateTimePickerExpirationDate.Size = new Size(270, 25);
            dateTimePickerExpirationDate.TabIndex = 22;
            // 
            // pictureBoxProductImage
            // 
            pictureBoxProductImage.BackColor = Color.LightGray;
            pictureBoxProductImage.Image = Properties.Resources.product_default;
            pictureBoxProductImage.Location = new Point(4, 416);
            pictureBoxProductImage.Margin = new Padding(4, 3, 4, 3);
            pictureBoxProductImage.Name = "pictureBoxProductImage";
            pictureBoxProductImage.Size = new Size(120, 161);
            pictureBoxProductImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxProductImage.TabIndex = 23;
            pictureBoxProductImage.TabStop = false;
            // 
            // btnEditImage
            // 
            btnEditImage.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditImage.Location = new Point(20, 581);
            btnEditImage.Margin = new Padding(4, 3, 4, 3);
            btnEditImage.Name = "btnEditImage";
            btnEditImage.Size = new Size(88, 27);
            btnEditImage.TabIndex = 24;
            btnEditImage.Text = "Chọn ảnh";
            btnEditImage.UseVisualStyleBackColor = true;
            btnEditImage.Click += btnEditImage_Click;
            // 
            // tabPageProductCategory
            // 
            tabPageProductCategory.Location = new Point(4, 24);
            tabPageProductCategory.Margin = new Padding(4, 3, 4, 3);
            tabPageProductCategory.Name = "tabPageProductCategory";
            tabPageProductCategory.Padding = new Padding(4, 3, 4, 3);
            tabPageProductCategory.Size = new Size(1161, 566);
            tabPageProductCategory.TabIndex = 1;
            tabPageProductCategory.Text = "Loại sản phẩm";
            tabPageProductCategory.UseVisualStyleBackColor = true;
            // 
            // ProductPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1169, 654);
            Controls.Add(tabControl);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ProductPanel";
            tabControl.ResumeLayout(false);
            tabPageProductList.ResumeLayout(false);
            tabPageProductList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoading).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProductImage).EndInit();
            ResumeLayout(false);
        }

        private TabControl tabControl;
        private TabPage tabPageProductList;
        private TabPage tabPageProductCategory;
        private DataGridView dataGridViewProducts;
        private TextBox txtProductId;
        private TextBox txtProductName;
        private ComboBox comboBoxProductType;
        private TextBox txtBrand;
        private TextBox txtCountryOfOrigin;
        private TextBox txtPrice;
        private TextBox txtStockQuantity;
        private TextBox txtUnit;
        private TextBox txtDescription;
        private TextBox txtIngredients;
        private TextBox txtBenefits;
        private TextBox txtWeight;
        private TextBox txtFlavor;
        private ComboBox comboBoxStatus;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnSearch;
        private TextBox txtSearch;
        private DateTimePicker dateTimePickerManufactureDate;
        private DateTimePicker dateTimePickerExpirationDate;
        private PictureBox pictureBoxProductImage;
        private Button btnEditImage;
        private CategoryPanel categoryPanel;
        private Button btnImportExcel;
        private Button btnExportExcel;
        private Button btnFilter;
        private Button btnExportPdf;
        private PictureBox pictureBoxLoading;
    }
}