namespace SieuThiMini.Panel
{
    partial class CategoryPanel
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryPanel));
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            tableLayoutPanel_Categoty = new TableLayoutPanel();
            labelCategory = new Label();
            panelSearch_TableCategory = new System.Windows.Forms.Panel();
            panelTableCategory = new System.Windows.Forms.Panel();
            dataGridView_Category = new DataGridView();
            CategoryID = new DataGridViewTextBoxColumn();
            CategoryName = new DataGridViewTextBoxColumn();
            panelSearchCategory = new System.Windows.Forms.Panel();
            btnReloadCategory = new Button();
            imageList1 = new ImageList(components);
            cbboxSearchCategory = new ComboBox();
            btnSearchCategory = new Button();
            txtSearchCategory = new TextBox();
            labelType = new Label();
            panelSearch_TableType = new System.Windows.Forms.Panel();
            panelTableType = new System.Windows.Forms.Panel();
            dataGridView_Type = new DataGridView();
            TypeID = new DataGridViewTextBoxColumn();
            TypeName = new DataGridViewTextBoxColumn();
            CategoryID_TypeTable = new DataGridViewTextBoxColumn();
            panelSearchType = new System.Windows.Forms.Panel();
            btnReloadType = new Button();
            cbboxSearchType = new ComboBox();
            btnSearchType = new Button();
            txtSearchType = new TextBox();
            panelDetailType = new System.Windows.Forms.Panel();
            panelButtonType = new System.Windows.Forms.Panel();
            btnEditType = new Button();
            btnDeleteType = new Button();
            btnAddType = new Button();
            panelTextType = new System.Windows.Forms.Panel();
            cbboxIDDanhMuc = new ComboBox();
            labelIDType = new Label();
            txtIDType = new TextBox();
            labelIDCategory_Type = new Label();
            labelTypeName = new Label();
            txtTypeName = new TextBox();
            panelChucNangCategory = new System.Windows.Forms.Panel();
            panelButtonCategory = new System.Windows.Forms.Panel();
            btnEditCategory = new Button();
            btnDeleteCategory = new Button();
            btnAddCategory = new Button();
            panelTextCategory = new System.Windows.Forms.Panel();
            label_CategoryID = new Label();
            txtCategoryID = new TextBox();
            label_CategoryName = new Label();
            txtCategoryName = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            tableLayoutPanel_Categoty.SuspendLayout();
            panelSearch_TableCategory.SuspendLayout();
            panelTableCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Category).BeginInit();
            panelSearchCategory.SuspendLayout();
            panelSearch_TableType.SuspendLayout();
            panelTableType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Type).BeginInit();
            panelSearchType.SuspendLayout();
            panelDetailType.SuspendLayout();
            panelButtonType.SuspendLayout();
            panelTextType.SuspendLayout();
            panelChucNangCategory.SuspendLayout();
            panelButtonCategory.SuspendLayout();
            panelTextCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel_Categoty
            // 
            tableLayoutPanel_Categoty.AutoSize = true;
            tableLayoutPanel_Categoty.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel_Categoty.BackColor = Color.White;
            tableLayoutPanel_Categoty.ColumnCount = 2;
            tableLayoutPanel_Categoty.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel_Categoty.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel_Categoty.Controls.Add(labelCategory, 0, 0);
            tableLayoutPanel_Categoty.Controls.Add(panelSearch_TableCategory, 0, 1);
            tableLayoutPanel_Categoty.Controls.Add(labelType, 0, 2);
            tableLayoutPanel_Categoty.Controls.Add(panelSearch_TableType, 0, 3);
            tableLayoutPanel_Categoty.Controls.Add(panelDetailType, 1, 3);
            tableLayoutPanel_Categoty.Controls.Add(panelChucNangCategory, 1, 1);
            tableLayoutPanel_Categoty.Dock = DockStyle.Fill;
            tableLayoutPanel_Categoty.Location = new Point(0, 0);
            tableLayoutPanel_Categoty.Margin = new Padding(0);
            tableLayoutPanel_Categoty.Name = "tableLayoutPanel_Categoty";
            tableLayoutPanel_Categoty.RowCount = 4;
            tableLayoutPanel_Categoty.RowStyles.Add(new RowStyle());
            tableLayoutPanel_Categoty.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel_Categoty.RowStyles.Add(new RowStyle());
            tableLayoutPanel_Categoty.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutPanel_Categoty.Size = new Size(1133, 500);
            tableLayoutPanel_Categoty.TabIndex = 2;
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            labelCategory.Location = new Point(4, 0);
            labelCategory.Margin = new Padding(4, 0, 4, 0);
            labelCategory.Name = "labelCategory";
            labelCategory.Padding = new Padding(0, 10, 10, 5);
            labelCategory.Size = new Size(281, 46);
            labelCategory.TabIndex = 0;
            labelCategory.Text = "DANH MỤC SẢN PHẨM";
            labelCategory.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelSearch_TableCategory
            // 
            panelSearch_TableCategory.BorderStyle = BorderStyle.FixedSingle;
            panelSearch_TableCategory.Controls.Add(panelTableCategory);
            panelSearch_TableCategory.Controls.Add(panelSearchCategory);
            panelSearch_TableCategory.Dock = DockStyle.Fill;
            panelSearch_TableCategory.Location = new Point(4, 50);
            panelSearch_TableCategory.Margin = new Padding(4);
            panelSearch_TableCategory.Name = "panelSearch_TableCategory";
            panelSearch_TableCategory.Size = new Size(671, 155);
            panelSearch_TableCategory.TabIndex = 3;
            // 
            // panelTableCategory
            // 
            panelTableCategory.BackColor = SystemColors.Control;
            panelTableCategory.Controls.Add(dataGridView_Category);
            panelTableCategory.Dock = DockStyle.Fill;
            panelTableCategory.Location = new Point(0, 40);
            panelTableCategory.Margin = new Padding(4);
            panelTableCategory.Name = "panelTableCategory";
            panelTableCategory.Padding = new Padding(5);
            panelTableCategory.Size = new Size(669, 113);
            panelTableCategory.TabIndex = 2;
            // 
            // dataGridView_Category
            // 
            dataGridView_Category.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.SelectionBackColor = Color.Teal;
            dataGridView_Category.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView_Category.BackgroundColor = Color.White;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView_Category.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView_Category.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Category.Columns.AddRange(new DataGridViewColumn[] { CategoryID, CategoryName });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(224, 247, 250);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = Color.Teal;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridView_Category.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridView_Category.Dock = DockStyle.Fill;
            dataGridView_Category.GridColor = Color.White;
            dataGridView_Category.Location = new Point(5, 5);
            dataGridView_Category.Margin = new Padding(4);
            dataGridView_Category.Name = "dataGridView_Category";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridView_Category.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridView_Category.RowHeadersWidth = 51;
            dataGridView_Category.RowTemplate.Height = 29;
            dataGridView_Category.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_Category.Size = new Size(659, 103);
            dataGridView_Category.TabIndex = 2;
            dataGridView_Category.CellClick += dataGridView_Category_CellClick;
            // 
            // CategoryID
            // 
            CategoryID.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.SelectionBackColor = Color.Teal;
            CategoryID.DefaultCellStyle = dataGridViewCellStyle3;
            CategoryID.HeaderText = "ID";
            CategoryID.MinimumWidth = 6;
            CategoryID.Name = "CategoryID";
            CategoryID.ReadOnly = true;
            CategoryID.Resizable = DataGridViewTriState.False;
            CategoryID.Width = 61;
            // 
            // CategoryName
            // 
            CategoryName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            CategoryName.DefaultCellStyle = dataGridViewCellStyle4;
            CategoryName.HeaderText = "Tên Danh Mục";
            CategoryName.MinimumWidth = 6;
            CategoryName.Name = "CategoryName";
            CategoryName.ReadOnly = true;
            CategoryName.Resizable = DataGridViewTriState.False;
            // 
            // panelSearchCategory
            // 
            panelSearchCategory.BackColor = SystemColors.Control;
            panelSearchCategory.Controls.Add(btnReloadCategory);
            panelSearchCategory.Controls.Add(cbboxSearchCategory);
            panelSearchCategory.Controls.Add(btnSearchCategory);
            panelSearchCategory.Controls.Add(txtSearchCategory);
            panelSearchCategory.Dock = DockStyle.Top;
            panelSearchCategory.Location = new Point(0, 0);
            panelSearchCategory.Margin = new Padding(4);
            panelSearchCategory.Name = "panelSearchCategory";
            panelSearchCategory.Padding = new Padding(5);
            panelSearchCategory.Size = new Size(669, 40);
            panelSearchCategory.TabIndex = 3;
            // 
            // btnReloadCategory
            // 
            btnReloadCategory.AutoSize = true;
            btnReloadCategory.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnReloadCategory.BackColor = Color.Transparent;
            btnReloadCategory.Dock = DockStyle.Right;
            btnReloadCategory.FlatAppearance.BorderSize = 0;
            btnReloadCategory.FlatStyle = FlatStyle.Flat;
            btnReloadCategory.ImageIndex = 4;
            btnReloadCategory.ImageList = imageList1;
            btnReloadCategory.Location = new Point(632, 5);
            btnReloadCategory.Name = "btnReloadCategory";
            btnReloadCategory.Size = new Size(32, 30);
            btnReloadCategory.TabIndex = 4;
            btnReloadCategory.UseVisualStyleBackColor = false;
            btnReloadCategory.Click += Button_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "search.png");
            imageList1.Images.SetKeyName(1, "add.png");
            imageList1.Images.SetKeyName(2, "delete.png");
            imageList1.Images.SetKeyName(3, "edit.png");
            imageList1.Images.SetKeyName(4, "reload.png");
            // 
            // cbboxSearchCategory
            // 
            cbboxSearchCategory.Dock = DockStyle.Left;
            cbboxSearchCategory.FormattingEnabled = true;
            cbboxSearchCategory.Items.AddRange(new object[] { "ID", "Tên danh mục" });
            cbboxSearchCategory.Location = new Point(5, 5);
            cbboxSearchCategory.Name = "cbboxSearchCategory";
            cbboxSearchCategory.Size = new Size(151, 36);
            cbboxSearchCategory.TabIndex = 3;
            cbboxSearchCategory.Text = "Tìm kiếm theo";
            cbboxSearchCategory.SelectedIndexChanged += cbboxSearchCategory_SelectedIndexChanged;
            // 
            // btnSearchCategory
            // 
            btnSearchCategory.BackColor = SystemColors.ControlLight;
            btnSearchCategory.FlatAppearance.BorderSize = 0;
            btnSearchCategory.FlatStyle = FlatStyle.Flat;
            btnSearchCategory.ForeColor = Color.Transparent;
            btnSearchCategory.ImageIndex = 0;
            btnSearchCategory.ImageList = imageList1;
            btnSearchCategory.Location = new Point(581, 7);
            btnSearchCategory.Name = "btnSearchCategory";
            btnSearchCategory.Size = new Size(30, 30);
            btnSearchCategory.TabIndex = 2;
            btnSearchCategory.UseVisualStyleBackColor = false;
            btnSearchCategory.Click += Button_Click;
            // 
            // txtSearchCategory
            // 
            txtSearchCategory.BackColor = Color.White;
            txtSearchCategory.BorderStyle = BorderStyle.FixedSingle;
            txtSearchCategory.Cursor = Cursors.IBeam;
            txtSearchCategory.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearchCategory.ImeMode = ImeMode.NoControl;
            txtSearchCategory.Location = new Point(179, 7);
            txtSearchCategory.Margin = new Padding(10, 4, 4, 4);
            txtSearchCategory.Name = "txtSearchCategory";
            txtSearchCategory.PlaceholderText = "Tìm kiếm";
            txtSearchCategory.Size = new Size(404, 34);
            txtSearchCategory.TabIndex = 1;
            txtSearchCategory.KeyDown += txtSearch_KeyDown;
            txtSearchCategory.KeyPress += txtSearchCategory_KeyPress;
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            labelType.Location = new Point(4, 209);
            labelType.Margin = new Padding(4, 0, 4, 0);
            labelType.Name = "labelType";
            labelType.Padding = new Padding(0, 10, 10, 5);
            labelType.Size = new Size(204, 46);
            labelType.TabIndex = 0;
            labelType.Text = "LOẠI SẢN PHẨM";
            labelType.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelSearch_TableType
            // 
            panelSearch_TableType.BackColor = SystemColors.Control;
            panelSearch_TableType.BorderStyle = BorderStyle.FixedSingle;
            panelSearch_TableType.Controls.Add(panelTableType);
            panelSearch_TableType.Controls.Add(panelSearchType);
            panelSearch_TableType.Dock = DockStyle.Fill;
            panelSearch_TableType.Location = new Point(3, 258);
            panelSearch_TableType.Name = "panelSearch_TableType";
            panelSearch_TableType.Size = new Size(673, 239);
            panelSearch_TableType.TabIndex = 4;
            // 
            // panelTableType
            // 
            panelTableType.BackColor = SystemColors.Control;
            panelTableType.Controls.Add(dataGridView_Type);
            panelTableType.Dock = DockStyle.Fill;
            panelTableType.Location = new Point(0, 40);
            panelTableType.Margin = new Padding(4);
            panelTableType.Name = "panelTableType";
            panelTableType.Padding = new Padding(5);
            panelTableType.Size = new Size(671, 197);
            panelTableType.TabIndex = 3;
            // 
            // dataGridView_Type
            // 
            dataGridView_Type.AllowUserToAddRows = false;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle7.SelectionBackColor = Color.Teal;
            dataGridView_Type.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridView_Type.BackgroundColor = Color.White;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle8.SelectionBackColor = Color.White;
            dataGridViewCellStyle8.SelectionForeColor = Color.Black;
            dataGridView_Type.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dataGridView_Type.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Type.Columns.AddRange(new DataGridViewColumn[] { TypeID, TypeName, CategoryID_TypeTable });
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = Color.FromArgb(224, 247, 250);
            dataGridViewCellStyle12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle12.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = Color.Teal;
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.False;
            dataGridView_Type.DefaultCellStyle = dataGridViewCellStyle12;
            dataGridView_Type.Dock = DockStyle.Fill;
            dataGridView_Type.GridColor = Color.White;
            dataGridView_Type.Location = new Point(5, 5);
            dataGridView_Type.Margin = new Padding(4);
            dataGridView_Type.Name = "dataGridView_Type";
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
            dataGridView_Type.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            dataGridView_Type.RowHeadersWidth = 51;
            dataGridView_Type.RowTemplate.Height = 29;
            dataGridView_Type.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_Type.Size = new Size(661, 187);
            dataGridView_Type.TabIndex = 2;
            dataGridView_Type.CellClick += dataGridView_Type_CellClick;
            // 
            // TypeID
            // 
            TypeID.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            TypeID.DefaultCellStyle = dataGridViewCellStyle9;
            TypeID.HeaderText = "ID";
            TypeID.MinimumWidth = 6;
            TypeID.Name = "TypeID";
            TypeID.ReadOnly = true;
            TypeID.Resizable = DataGridViewTriState.False;
            TypeID.Width = 61;
            // 
            // TypeName
            // 
            TypeName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            TypeName.DefaultCellStyle = dataGridViewCellStyle10;
            TypeName.HeaderText = "Loại Sản Phẩm";
            TypeName.MinimumWidth = 6;
            TypeName.Name = "TypeName";
            TypeName.ReadOnly = true;
            TypeName.Resizable = DataGridViewTriState.False;
            // 
            // CategoryID_TypeTable
            // 
            CategoryID_TypeTable.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.TopLeft;
            CategoryID_TypeTable.DefaultCellStyle = dataGridViewCellStyle11;
            CategoryID_TypeTable.HeaderText = "ID Danh Mục";
            CategoryID_TypeTable.MinimumWidth = 6;
            CategoryID_TypeTable.Name = "CategoryID_TypeTable";
            CategoryID_TypeTable.ReadOnly = true;
            CategoryID_TypeTable.Resizable = DataGridViewTriState.False;
            CategoryID_TypeTable.Width = 160;
            // 
            // panelSearchType
            // 
            panelSearchType.Controls.Add(btnReloadType);
            panelSearchType.Controls.Add(cbboxSearchType);
            panelSearchType.Controls.Add(btnSearchType);
            panelSearchType.Controls.Add(txtSearchType);
            panelSearchType.Dock = DockStyle.Top;
            panelSearchType.Location = new Point(0, 0);
            panelSearchType.Name = "panelSearchType";
            panelSearchType.Padding = new Padding(5);
            panelSearchType.Size = new Size(671, 40);
            panelSearchType.TabIndex = 0;
            // 
            // btnReloadType
            // 
            btnReloadType.AutoSize = true;
            btnReloadType.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnReloadType.BackColor = Color.Transparent;
            btnReloadType.Dock = DockStyle.Right;
            btnReloadType.FlatAppearance.BorderSize = 0;
            btnReloadType.FlatStyle = FlatStyle.Flat;
            btnReloadType.ImageIndex = 4;
            btnReloadType.ImageList = imageList1;
            btnReloadType.Location = new Point(634, 5);
            btnReloadType.Name = "btnReloadType";
            btnReloadType.Size = new Size(32, 30);
            btnReloadType.TabIndex = 5;
            btnReloadType.UseVisualStyleBackColor = false;
            btnReloadType.Click += Button_Click;
            // 
            // cbboxSearchType
            // 
            cbboxSearchType.Dock = DockStyle.Left;
            cbboxSearchType.FormattingEnabled = true;
            cbboxSearchType.Items.AddRange(new object[] { "ID", "Loại sản phẩm", "ID danh mục" });
            cbboxSearchType.Location = new Point(5, 5);
            cbboxSearchType.Name = "cbboxSearchType";
            cbboxSearchType.Size = new Size(151, 36);
            cbboxSearchType.TabIndex = 4;
            cbboxSearchType.Text = "Tìm kiếm theo";
            cbboxSearchType.SelectedIndexChanged += cbboxSearchType_SelectedIndexChanged;
            // 
            // btnSearchType
            // 
            btnSearchType.BackColor = SystemColors.ControlLight;
            btnSearchType.FlatAppearance.BorderSize = 0;
            btnSearchType.FlatStyle = FlatStyle.Flat;
            btnSearchType.ForeColor = Color.Transparent;
            btnSearchType.ImageIndex = 0;
            btnSearchType.ImageList = imageList1;
            btnSearchType.Location = new Point(582, 7);
            btnSearchType.Name = "btnSearchType";
            btnSearchType.Size = new Size(30, 30);
            btnSearchType.TabIndex = 3;
            btnSearchType.UseVisualStyleBackColor = false;
            btnSearchType.Click += Button_Click;
            // 
            // txtSearchType
            // 
            txtSearchType.BorderStyle = BorderStyle.FixedSingle;
            txtSearchType.Cursor = Cursors.IBeam;
            txtSearchType.Location = new Point(180, 7);
            txtSearchType.Margin = new Padding(10, 4, 4, 4);
            txtSearchType.Name = "txtSearchType";
            txtSearchType.PlaceholderText = "Tìm kiếm";
            txtSearchType.Size = new Size(402, 34);
            txtSearchType.TabIndex = 0;
            txtSearchType.KeyDown += txtSearch_KeyDown;
            txtSearchType.KeyPress += txtSearchType_KeyPress;
            // 
            // panelDetailType
            // 
            panelDetailType.AutoSize = true;
            panelDetailType.BackColor = SystemColors.Control;
            panelDetailType.BorderStyle = BorderStyle.FixedSingle;
            panelDetailType.Controls.Add(panelButtonType);
            panelDetailType.Controls.Add(panelTextType);
            panelDetailType.Dock = DockStyle.Top;
            panelDetailType.Location = new Point(682, 258);
            panelDetailType.Name = "panelDetailType";
            panelDetailType.Size = new Size(448, 185);
            panelDetailType.TabIndex = 5;
            // 
            // panelButtonType
            // 
            panelButtonType.AutoSize = true;
            panelButtonType.Controls.Add(btnEditType);
            panelButtonType.Controls.Add(btnDeleteType);
            panelButtonType.Controls.Add(btnAddType);
            panelButtonType.Dock = DockStyle.Top;
            panelButtonType.Location = new Point(0, 134);
            panelButtonType.Name = "panelButtonType";
            panelButtonType.Size = new Size(446, 49);
            panelButtonType.TabIndex = 6;
            // 
            // btnEditType
            // 
            btnEditType.Anchor = AnchorStyles.Top;
            btnEditType.AutoSize = true;
            btnEditType.BackColor = Color.White;
            btnEditType.FlatStyle = FlatStyle.Popup;
            btnEditType.ImageIndex = 3;
            btnEditType.ImageList = imageList1;
            btnEditType.Location = new Point(180, 6);
            btnEditType.Name = "btnEditType";
            btnEditType.Size = new Size(94, 40);
            btnEditType.TabIndex = 3;
            btnEditType.Text = "Sửa";
            btnEditType.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEditType.UseVisualStyleBackColor = false;
            btnEditType.Click += Button_Click;
            // 
            // btnDeleteType
            // 
            btnDeleteType.Anchor = AnchorStyles.Top;
            btnDeleteType.AutoSize = true;
            btnDeleteType.BackColor = Color.White;
            btnDeleteType.FlatStyle = FlatStyle.Popup;
            btnDeleteType.ImageIndex = 2;
            btnDeleteType.ImageList = imageList1;
            btnDeleteType.Location = new Point(280, 6);
            btnDeleteType.Name = "btnDeleteType";
            btnDeleteType.Size = new Size(94, 40);
            btnDeleteType.TabIndex = 4;
            btnDeleteType.Text = "Xóa";
            btnDeleteType.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDeleteType.UseVisualStyleBackColor = false;
            btnDeleteType.Click += Button_Click;
            // 
            // btnAddType
            // 
            btnAddType.Anchor = AnchorStyles.Top;
            btnAddType.AutoSize = true;
            btnAddType.BackColor = Color.White;
            btnAddType.FlatStyle = FlatStyle.Popup;
            btnAddType.ImageIndex = 1;
            btnAddType.ImageList = imageList1;
            btnAddType.Location = new Point(80, 6);
            btnAddType.Name = "btnAddType";
            btnAddType.Size = new Size(96, 40);
            btnAddType.TabIndex = 2;
            btnAddType.Text = "Thêm";
            btnAddType.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAddType.UseVisualStyleBackColor = false;
            btnAddType.Click += Button_Click;
            // 
            // panelTextType
            // 
            panelTextType.AutoSize = true;
            panelTextType.BackColor = Color.Transparent;
            panelTextType.Controls.Add(cbboxIDDanhMuc);
            panelTextType.Controls.Add(labelIDType);
            panelTextType.Controls.Add(txtIDType);
            panelTextType.Controls.Add(labelIDCategory_Type);
            panelTextType.Controls.Add(labelTypeName);
            panelTextType.Controls.Add(txtTypeName);
            panelTextType.Dock = DockStyle.Top;
            panelTextType.Location = new Point(0, 0);
            panelTextType.Name = "panelTextType";
            panelTextType.Size = new Size(446, 134);
            panelTextType.TabIndex = 5;
            // 
            // cbboxIDDanhMuc
            // 
            cbboxIDDanhMuc.FormattingEnabled = true;
            cbboxIDDanhMuc.Location = new Point(166, 95);
            cbboxIDDanhMuc.Name = "cbboxIDDanhMuc";
            cbboxIDDanhMuc.Size = new Size(272, 36);
            cbboxIDDanhMuc.TabIndex = 2;
            // 
            // labelIDType
            // 
            labelIDType.AutoSize = true;
            labelIDType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelIDType.Location = new Point(4, 20);
            labelIDType.Margin = new Padding(4, 0, 4, 0);
            labelIDType.Name = "labelIDType";
            labelIDType.Size = new Size(162, 28);
            labelIDType.TabIndex = 0;
            labelIDType.Text = "ID loại sản phẩm ";
            // 
            // txtIDType
            // 
            txtIDType.BorderStyle = BorderStyle.FixedSingle;
            txtIDType.Enabled = false;
            txtIDType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtIDType.Location = new Point(166, 14);
            txtIDType.Margin = new Padding(4);
            txtIDType.Name = "txtIDType";
            txtIDType.ReadOnly = true;
            txtIDType.Size = new Size(106, 34);
            txtIDType.TabIndex = 1;
            // 
            // labelIDCategory_Type
            // 
            labelIDCategory_Type.AutoSize = true;
            labelIDCategory_Type.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelIDCategory_Type.Location = new Point(5, 102);
            labelIDCategory_Type.Margin = new Padding(4, 0, 4, 0);
            labelIDCategory_Type.Name = "labelIDCategory_Type";
            labelIDCategory_Type.Size = new Size(100, 28);
            labelIDCategory_Type.TabIndex = 0;
            labelIDCategory_Type.Text = "Danh mục";
            // 
            // labelTypeName
            // 
            labelTypeName.AutoSize = true;
            labelTypeName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelTypeName.Location = new Point(4, 60);
            labelTypeName.Margin = new Padding(4, 0, 4, 0);
            labelTypeName.Name = "labelTypeName";
            labelTypeName.Size = new Size(137, 28);
            labelTypeName.TabIndex = 0;
            labelTypeName.Text = "Loại sản phẩm";
            // 
            // txtTypeName
            // 
            txtTypeName.BorderStyle = BorderStyle.FixedSingle;
            txtTypeName.Cursor = Cursors.IBeam;
            txtTypeName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtTypeName.Location = new Point(166, 54);
            txtTypeName.Margin = new Padding(4);
            txtTypeName.Name = "txtTypeName";
            txtTypeName.Size = new Size(285, 34);
            txtTypeName.TabIndex = 1;
            // 
            // panelChucNangCategory
            // 
            panelChucNangCategory.AutoSize = true;
            panelChucNangCategory.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelChucNangCategory.BackColor = SystemColors.Control;
            panelChucNangCategory.BorderStyle = BorderStyle.FixedSingle;
            panelChucNangCategory.Controls.Add(panelButtonCategory);
            panelChucNangCategory.Controls.Add(panelTextCategory);
            panelChucNangCategory.Dock = DockStyle.Top;
            panelChucNangCategory.Location = new Point(683, 50);
            panelChucNangCategory.Margin = new Padding(4);
            panelChucNangCategory.Name = "panelChucNangCategory";
            panelChucNangCategory.Size = new Size(446, 146);
            panelChucNangCategory.TabIndex = 2;
            // 
            // panelButtonCategory
            // 
            panelButtonCategory.AutoSize = true;
            panelButtonCategory.Controls.Add(btnEditCategory);
            panelButtonCategory.Controls.Add(btnDeleteCategory);
            panelButtonCategory.Controls.Add(btnAddCategory);
            panelButtonCategory.Dock = DockStyle.Top;
            panelButtonCategory.Location = new Point(0, 95);
            panelButtonCategory.Name = "panelButtonCategory";
            panelButtonCategory.Size = new Size(444, 49);
            panelButtonCategory.TabIndex = 5;
            // 
            // btnEditCategory
            // 
            btnEditCategory.Anchor = AnchorStyles.Top;
            btnEditCategory.AutoSize = true;
            btnEditCategory.BackColor = Color.White;
            btnEditCategory.FlatStyle = FlatStyle.Popup;
            btnEditCategory.ImageIndex = 3;
            btnEditCategory.ImageList = imageList1;
            btnEditCategory.Location = new Point(179, 6);
            btnEditCategory.Name = "btnEditCategory";
            btnEditCategory.Size = new Size(94, 40);
            btnEditCategory.TabIndex = 3;
            btnEditCategory.Text = "Sửa";
            btnEditCategory.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEditCategory.UseVisualStyleBackColor = false;
            btnEditCategory.Click += Button_Click;
            // 
            // btnDeleteCategory
            // 
            btnDeleteCategory.Anchor = AnchorStyles.Top;
            btnDeleteCategory.AutoSize = true;
            btnDeleteCategory.BackColor = Color.White;
            btnDeleteCategory.FlatStyle = FlatStyle.Popup;
            btnDeleteCategory.ImageIndex = 2;
            btnDeleteCategory.ImageList = imageList1;
            btnDeleteCategory.Location = new Point(279, 6);
            btnDeleteCategory.Name = "btnDeleteCategory";
            btnDeleteCategory.Size = new Size(94, 40);
            btnDeleteCategory.TabIndex = 4;
            btnDeleteCategory.Text = "Xóa";
            btnDeleteCategory.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDeleteCategory.UseVisualStyleBackColor = false;
            btnDeleteCategory.Click += Button_Click;
            // 
            // btnAddCategory
            // 
            btnAddCategory.Anchor = AnchorStyles.Top;
            btnAddCategory.AutoSize = true;
            btnAddCategory.BackColor = Color.White;
            btnAddCategory.FlatStyle = FlatStyle.Popup;
            btnAddCategory.ImageIndex = 1;
            btnAddCategory.ImageList = imageList1;
            btnAddCategory.Location = new Point(79, 6);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(96, 40);
            btnAddCategory.TabIndex = 2;
            btnAddCategory.Text = "Thêm";
            btnAddCategory.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAddCategory.UseVisualStyleBackColor = false;
            btnAddCategory.Click += Button_Click;
            // 
            // panelTextCategory
            // 
            panelTextCategory.BackColor = Color.Transparent;
            panelTextCategory.Controls.Add(label_CategoryID);
            panelTextCategory.Controls.Add(txtCategoryID);
            panelTextCategory.Controls.Add(label_CategoryName);
            panelTextCategory.Controls.Add(txtCategoryName);
            panelTextCategory.Dock = DockStyle.Top;
            panelTextCategory.Location = new Point(0, 0);
            panelTextCategory.Name = "panelTextCategory";
            panelTextCategory.Size = new Size(444, 95);
            panelTextCategory.TabIndex = 4;
            // 
            // label_CategoryID
            // 
            label_CategoryID.AutoSize = true;
            label_CategoryID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_CategoryID.Location = new Point(4, 20);
            label_CategoryID.Margin = new Padding(4, 0, 4, 0);
            label_CategoryID.Name = "label_CategoryID";
            label_CategoryID.Size = new Size(122, 28);
            label_CategoryID.TabIndex = 0;
            label_CategoryID.Text = "ID danh mục";
            // 
            // txtCategoryID
            // 
            txtCategoryID.BorderStyle = BorderStyle.FixedSingle;
            txtCategoryID.Enabled = false;
            txtCategoryID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCategoryID.Location = new Point(145, 15);
            txtCategoryID.Margin = new Padding(4);
            txtCategoryID.Name = "txtCategoryID";
            txtCategoryID.ReadOnly = true;
            txtCategoryID.Size = new Size(106, 34);
            txtCategoryID.TabIndex = 1;
            // 
            // label_CategoryName
            // 
            label_CategoryName.AutoSize = true;
            label_CategoryName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_CategoryName.Location = new Point(4, 60);
            label_CategoryName.Margin = new Padding(4, 0, 4, 0);
            label_CategoryName.Name = "label_CategoryName";
            label_CategoryName.Size = new Size(132, 28);
            label_CategoryName.TabIndex = 0;
            label_CategoryName.Text = "Tên danh mục";
            // 
            // txtCategoryName
            // 
            txtCategoryName.BorderStyle = BorderStyle.FixedSingle;
            txtCategoryName.Cursor = Cursors.IBeam;
            txtCategoryName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCategoryName.Location = new Point(145, 54);
            txtCategoryName.Margin = new Padding(4);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(305, 34);
            txtCategoryName.TabIndex = 1;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // CategoryPanel
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel_Categoty);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "CategoryPanel";
            Size = new Size(1133, 500);
            Load += Category_Load;
            tableLayoutPanel_Categoty.ResumeLayout(false);
            tableLayoutPanel_Categoty.PerformLayout();
            panelSearch_TableCategory.ResumeLayout(false);
            panelTableCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_Category).EndInit();
            panelSearchCategory.ResumeLayout(false);
            panelSearchCategory.PerformLayout();
            panelSearch_TableType.ResumeLayout(false);
            panelTableType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_Type).EndInit();
            panelSearchType.ResumeLayout(false);
            panelSearchType.PerformLayout();
            panelDetailType.ResumeLayout(false);
            panelDetailType.PerformLayout();
            panelButtonType.ResumeLayout(false);
            panelButtonType.PerformLayout();
            panelTextType.ResumeLayout(false);
            panelTextType.PerformLayout();
            panelChucNangCategory.ResumeLayout(false);
            panelChucNangCategory.PerformLayout();
            panelButtonCategory.ResumeLayout(false);
            panelButtonCategory.PerformLayout();
            panelTextCategory.ResumeLayout(false);
            panelTextCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel_Categoty;
        private Label labelCategory;
        private TextBox txtCategoryName;
        private TextBox txtCategoryID;
        private Label label_CategoryName;
        private Label label_CategoryID;
        private System.Windows.Forms.Panel panelChucNangCategory;
        private DataGridView dataGridView_Category;
        private System.Windows.Forms.Panel panelSearchCategory;
        private Button btnSearchCategory;
        private TextBox txtSearchCategory;
        private System.Windows.Forms.Panel panelSearch_TableCategory;
        protected System.Windows.Forms.Panel panelTableCategory;
        private ImageList imageList1;
        private System.Windows.Forms.Panel panelButtonCategory;
        private Button btnEditCategory;
        private Button btnDeleteCategory;
        private Button btnAddCategory;
        private System.Windows.Forms.Panel panelTextCategory;
        private Label labelType;
        private System.Windows.Forms.Panel panelSearch_TableType;
        private System.Windows.Forms.Panel panelSearchType;
        private System.Windows.Forms.Panel panelDetailType;
        private Button btnSearchType;
        private TextBox txtSearchType;
        protected System.Windows.Forms.Panel panelTableType;
        private DataGridView dataGridView_Type;
        private System.Windows.Forms.Panel panelButtonType;
        private Button btnEditType;
        private Button btnDeleteType;
        private Button btnAddType;
        private System.Windows.Forms.Panel panelTextType;
        private Label labelIDType;
        private TextBox txtIDType;
        private Label labelTypeName;
        private TextBox txtTypeName;
        private Label labelIDCategory_Type;
        private ComboBox cbboxSearchCategory;
        private ComboBox cbboxSearchType;
        private DataGridViewTextBoxColumn CategoryID;
        private DataGridViewTextBoxColumn CategoryName;
        private DataGridViewTextBoxColumn TypeID;
        private DataGridViewTextBoxColumn TypeName;
        private DataGridViewTextBoxColumn CategoryID_TypeTable;
        private ErrorProvider errorProvider1;
        private Button btnReloadCategory;
        private Button btnReloadType;
        private ComboBox cbboxIDDanhMuc;
    }
}