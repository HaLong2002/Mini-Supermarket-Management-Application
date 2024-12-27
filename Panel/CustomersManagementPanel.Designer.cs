namespace SieuThiMini.Panel
{
    partial class CustomersManagementPanel
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
            ListViewItem listViewItem1 = new ListViewItem("");
            ListViewItem listViewItem2 = new ListViewItem("");
            ListViewItem listViewItem3 = new ListViewItem("");
            ListViewItem listViewItem4 = new ListViewItem("");
            rdnNam = new RadioButton();
            cbbDayOfBirth = new DateTimePicker();
            txtPoint = new TextBox();
            btnAdd = new Button();
            groupGioiTinh = new GroupBox();
            rdbKhac = new RadioButton();
            rdbNu = new RadioButton();
            button1 = new Button();
            imageList1 = new ImageList(components);
            panel2 = new System.Windows.Forms.Panel();
            btnLoc = new Button();
            panelSearchPoint = new System.Windows.Forms.Panel();
            groupSearch = new GroupBox();
            rdbMin = new RadioButton();
            rdbMax = new RadioButton();
            rdbAll = new RadioButton();
            panelSearchDate = new System.Windows.Forms.Panel();
            cbbDayE = new DateTimePicker();
            cbbDayS = new DateTimePicker();
            label15 = new Label();
            label13 = new Label();
            cbbSearch = new ComboBox();
            label12 = new Label();
            panel4 = new System.Windows.Forms.Panel();
            txtSearch = new TextBox();
            label14 = new Label();
            panel3 = new System.Windows.Forms.Panel();
            btnReLoad = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            label3 = new Label();
            label2 = new Label();
            txtPhoneNumber = new TextBox();
            columnHeader6 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            txtName = new TextBox();
            txtID = new TextBox();
            columnHeader3 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            label9 = new Label();
            label8 = new Label();
            label6 = new Label();
            columnHeader5 = new ColumnHeader();
            list_dskh = new ListView();
            columnHeader7 = new ColumnHeader();
            label7 = new Label();
            label1 = new Label();
            label5 = new Label();
            label4 = new Label();
            panel1 = new System.Windows.Forms.Panel();
            list_dshd = new ListView();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader11 = new ColumnHeader();
            label10 = new Label();
            errorName = new ErrorProvider(components);
            errorPhoneNumber = new ErrorProvider(components);
            errorGender = new ErrorProvider(components);
            errorDateOfBirth = new ErrorProvider(components);
            lblSuccess = new Label();
            timerHideMessage = new System.Windows.Forms.Timer(components);
            errorID = new ErrorProvider(components);
            label11 = new Label();
            list_cthd = new ListView();
            columnHeader12 = new ColumnHeader();
            columnHeader13 = new ColumnHeader();
            columnHeader14 = new ColumnHeader();
            columnHeader15 = new ColumnHeader();
            columnHeader16 = new ColumnHeader();
            columnHeader17 = new ColumnHeader();
            columnHeader18 = new ColumnHeader();
            groupGioiTinh.SuspendLayout();
            panel2.SuspendLayout();
            panelSearchPoint.SuspendLayout();
            groupSearch.SuspendLayout();
            panelSearchDate.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorPhoneNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorGender).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorDateOfBirth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorID).BeginInit();
            SuspendLayout();
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
            // cbbDayOfBirth
            // 
            cbbDayOfBirth.Location = new Point(122, 113);
            cbbDayOfBirth.Name = "cbbDayOfBirth";
            cbbDayOfBirth.Size = new Size(177, 23);
            cbbDayOfBirth.TabIndex = 21;
            // 
            // txtPoint
            // 
            txtPoint.Enabled = false;
            txtPoint.Location = new Point(412, 117);
            txtPoint.Multiline = true;
            txtPoint.Name = "txtPoint";
            txtPoint.Size = new Size(177, 23);
            txtPoint.TabIndex = 18;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(0, 192, 0);
            btnAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.ForeColor = SystemColors.ButtonHighlight;
            btnAdd.Location = new Point(16, 8);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(80, 40);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            btnAdd.MouseEnter += btnAdd_MouseEnter;
            btnAdd.MouseLeave += btnAdd_MouseLeave;
            // 
            // groupGioiTinh
            // 
            groupGioiTinh.Controls.Add(rdbKhac);
            groupGioiTinh.Controls.Add(rdbNu);
            groupGioiTinh.Controls.Add(rdnNam);
            groupGioiTinh.FlatStyle = FlatStyle.System;
            groupGioiTinh.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupGioiTinh.Location = new Point(412, 48);
            groupGioiTinh.Name = "groupGioiTinh";
            groupGioiTinh.Size = new Size(197, 45);
            groupGioiTinh.TabIndex = 16;
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
            // button1
            // 
            button1.BackgroundImage = Properties.Resources.icon_reload;
            button1.Location = new Point(199, 348);
            button1.Name = "button1";
            button1.Size = new Size(36, 34);
            button1.TabIndex = 9;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(btnLoc);
            panel2.Controls.Add(panelSearchPoint);
            panel2.Controls.Add(panelSearchDate);
            panel2.Controls.Add(cbbSearch);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(panel4);
            panel2.Location = new Point(595, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(548, 259);
            panel2.TabIndex = 12;
            // 
            // btnLoc
            // 
            btnLoc.BackColor = Color.FromArgb(24, 119, 242);
            btnLoc.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnLoc.ForeColor = SystemColors.ControlLightLight;
            btnLoc.Location = new Point(258, 219);
            btnLoc.Name = "btnLoc";
            btnLoc.Size = new Size(97, 30);
            btnLoc.TabIndex = 6;
            btnLoc.Text = "Lọc";
            btnLoc.UseVisualStyleBackColor = false;
            btnLoc.Click += btnLoc_Click;
            btnLoc.MouseEnter += btnLoc_MouseEnter;
            btnLoc.MouseLeave += btnLoc_MouseLeave;
            // 
            // panelSearchPoint
            // 
            panelSearchPoint.Controls.Add(groupSearch);
            panelSearchPoint.Location = new Point(301, 67);
            panelSearchPoint.Name = "panelSearchPoint";
            panelSearchPoint.Size = new Size(244, 146);
            panelSearchPoint.TabIndex = 5;
            // 
            // groupSearch
            // 
            groupSearch.Controls.Add(rdbMin);
            groupSearch.Controls.Add(rdbMax);
            groupSearch.Controls.Add(rdbAll);
            groupSearch.FlatStyle = FlatStyle.System;
            groupSearch.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupSearch.Location = new Point(19, 7);
            groupSearch.Name = "groupSearch";
            groupSearch.Size = new Size(179, 129);
            groupSearch.TabIndex = 18;
            groupSearch.TabStop = false;
            groupSearch.Enter += groupBox1_Enter;
            // 
            // rdbMin
            // 
            rdbMin.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rdbMin.Location = new Point(6, 73);
            rdbMin.Name = "rdbMin";
            rdbMin.Size = new Size(167, 32);
            rdbMin.TabIndex = 2;
            rdbMin.TabStop = true;
            rdbMin.Text = "Từ bé đến lớn";
            rdbMin.UseVisualStyleBackColor = true;
            // 
            // rdbMax
            // 
            rdbMax.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rdbMax.Location = new Point(6, 43);
            rdbMax.Name = "rdbMax";
            rdbMax.Size = new Size(114, 32);
            rdbMax.TabIndex = 1;
            rdbMax.TabStop = true;
            rdbMax.Text = "Từ lớn đến bé";
            rdbMax.UseVisualStyleBackColor = true;
            // 
            // rdbAll
            // 
            rdbAll.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rdbAll.Location = new Point(6, 11);
            rdbAll.Name = "rdbAll";
            rdbAll.Size = new Size(63, 32);
            rdbAll.TabIndex = 0;
            rdbAll.TabStop = true;
            rdbAll.Text = "Tất cả";
            rdbAll.UseVisualStyleBackColor = true;
            // 
            // panelSearchDate
            // 
            panelSearchDate.Controls.Add(cbbDayE);
            panelSearchDate.Controls.Add(cbbDayS);
            panelSearchDate.Controls.Add(label15);
            panelSearchDate.Controls.Add(label13);
            panelSearchDate.Location = new Point(4, 110);
            panelSearchDate.Name = "panelSearchDate";
            panelSearchDate.Size = new Size(293, 100);
            panelSearchDate.TabIndex = 4;
            // 
            // cbbDayE
            // 
            cbbDayE.Location = new Point(81, 54);
            cbbDayE.Name = "cbbDayE";
            cbbDayE.Size = new Size(200, 23);
            cbbDayE.TabIndex = 3;
            // 
            // cbbDayS
            // 
            cbbDayS.Location = new Point(81, 8);
            cbbDayS.Name = "cbbDayS";
            cbbDayS.Size = new Size(200, 23);
            cbbDayS.TabIndex = 2;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label15.Location = new Point(7, 54);
            label15.Name = "label15";
            label15.Size = new Size(59, 15);
            label15.TabIndex = 1;
            label15.Text = "Đến ngày";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label13.Location = new Point(7, 7);
            label13.Name = "label13";
            label13.Size = new Size(51, 15);
            label13.TabIndex = 0;
            label13.Text = "Từ ngày";
            // 
            // cbbSearch
            // 
            cbbSearch.FormattingEnabled = true;
            cbbSearch.Items.AddRange(new object[] { "", "Điểm thưởng", "Ngày mua hàng" });
            cbbSearch.Location = new Point(156, 67);
            cbbSearch.Name = "cbbSearch";
            cbbSearch.Size = new Size(139, 23);
            cbbSearch.TabIndex = 3;
            cbbSearch.SelectedIndexChanged += cbbSearch_SelectedIndexChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(4, 70);
            label12.Name = "label12";
            label12.Size = new Size(146, 15);
            label12.TabIndex = 2;
            label12.Text = "Lọc thông tin khách hàng:";
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.Fixed3D;
            panel4.Controls.Add(txtSearch);
            panel4.Controls.Add(label14);
            panel4.Location = new Point(4, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(541, 58);
            panel4.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(91, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập tên hoặc SDT của khách hàng cần tìm kiếm";
            txtSearch.Size = new Size(270, 23);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label14.Location = new Point(27, 20);
            label14.Name = "label14";
            label14.Size = new Size(66, 17);
            label14.TabIndex = 0;
            label14.Text = "Tìm kiếm";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLight;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(btnReLoad);
            panel3.Controls.Add(btnDelete);
            panel3.Controls.Add(btnEdit);
            panel3.Controls.Add(btnAdd);
            panel3.Location = new Point(16, 177);
            panel3.Name = "panel3";
            panel3.Size = new Size(573, 57);
            panel3.TabIndex = 0;
            // 
            // btnReLoad
            // 
            btnReLoad.BackColor = Color.FromArgb(24, 119, 242);
            btnReLoad.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnReLoad.ForeColor = SystemColors.ButtonHighlight;
            btnReLoad.Location = new Point(468, 10);
            btnReLoad.Name = "btnReLoad";
            btnReLoad.Size = new Size(80, 40);
            btnReLoad.TabIndex = 3;
            btnReLoad.Text = "Tải lại";
            btnReLoad.UseVisualStyleBackColor = false;
            btnReLoad.Click += btnReLoad_Click;
            btnReLoad.MouseEnter += btnReLoad_MouseEnter;
            btnReLoad.MouseLeave += btnReLoad_MouseLeave;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.ForeColor = SystemColors.ButtonHighlight;
            btnDelete.Location = new Point(310, 10);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(80, 40);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            btnDelete.MouseEnter += btnDelete_MouseEnter;
            btnDelete.MouseLeave += btnDelete_MouseLeave;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(24, 119, 242);
            btnEdit.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnEdit.ForeColor = SystemColors.ButtonHighlight;
            btnEdit.Location = new Point(167, 10);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(80, 40);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            btnEdit.MouseEnter += btnEdit_MouseEnter;
            btnEdit.MouseLeave += btnEdit_MouseLeave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(12, 40);
            label3.Name = "label3";
            label3.Size = new Size(88, 21);
            label3.TabIndex = 11;
            label3.Text = "Thông tin ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(11, 353);
            label2.Name = "label2";
            label2.Size = new Size(182, 21);
            label2.TabIndex = 10;
            label2.Text = "Danh sách khách hàng";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(123, 67);
            txtPhoneNumber.Multiline = true;
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(177, 23);
            txtPhoneNumber.TabIndex = 15;
            txtPhoneNumber.KeyPress += txtPhoneNumber_KeyPress;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Ngày sinh";
            columnHeader6.TextAlign = HorizontalAlignment.Center;
            columnHeader6.Width = 70;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "SDT";
            columnHeader4.TextAlign = HorizontalAlignment.Center;
            columnHeader4.Width = 80;
            // 
            // txtName
            // 
            txtName.Location = new Point(412, 19);
            txtName.Multiline = true;
            txtName.Name = "txtName";
            txtName.Size = new Size(177, 23);
            txtName.TabIndex = 14;
            // 
            // txtID
            // 
            txtID.Enabled = false;
            txtID.Location = new Point(123, 19);
            txtID.Multiline = true;
            txtID.Name = "txtID";
            txtID.Size = new Size(177, 23);
            txtID.TabIndex = 13;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Tên";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            columnHeader3.Width = 80;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "ID";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 40;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "";
            columnHeader1.Width = 30;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(306, 115);
            label9.Name = "label9";
            label9.Size = new Size(102, 21);
            label9.TabIndex = 5;
            label9.Text = "Điểm thưởng";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(16, 113);
            label8.Name = "label8";
            label8.Size = new Size(80, 21);
            label8.TabIndex = 4;
            label8.Text = "Ngày sinh";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(16, 65);
            label6.Name = "label6";
            label6.Size = new Size(101, 21);
            label6.TabIndex = 2;
            label6.Text = "Số điện thoại";
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "G.Tính ";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            // 
            // list_dskh
            // 
            list_dskh.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7 });
            list_dskh.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            list_dskh.FullRowSelect = true;
            list_dskh.GridLines = true;
            list_dskh.GroupImageList = imageList1;
            list_dskh.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3, listViewItem4 });
            list_dskh.Location = new Point(9, 388);
            list_dskh.Name = "list_dskh";
            list_dskh.Size = new Size(413, 300);
            list_dskh.TabIndex = 7;
            list_dskh.UseCompatibleStateImageBehavior = false;
            list_dskh.View = View.Details;
            list_dskh.ColumnWidthChanging += list_dskh_ColumnWidthChanging;
            list_dskh.MouseClick += list_dskh_MouseClick;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Điểm ";
            columnHeader7.TextAlign = HorizontalAlignment.Center;
            columnHeader7.Width = 50;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(306, 67);
            label7.Name = "label7";
            label7.Size = new Size(70, 21);
            label7.TabIndex = 3;
            label7.Text = "Giới tính";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(24, 119, 242);
            label1.Location = new Point(441, 9);
            label1.Name = "label1";
            label1.Size = new Size(267, 37);
            label1.TabIndex = 6;
            label1.Text = "Quản lý khách hàng";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(306, 19);
            label5.Name = "label5";
            label5.Size = new Size(33, 21);
            label5.TabIndex = 1;
            label5.Text = "Tên";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(16, 17);
            label4.Name = "label4";
            label4.Size = new Size(25, 21);
            label4.TabIndex = 0;
            label4.Text = "ID";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(cbbDayOfBirth);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(txtPoint);
            panel1.Controls.Add(groupGioiTinh);
            panel1.Controls.Add(txtPhoneNumber);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(txtID);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(12, 73);
            panel1.Name = "panel1";
            panel1.Size = new Size(1156, 269);
            panel1.TabIndex = 8;
            // 
            // list_dshd
            // 
            list_dshd.Columns.AddRange(new ColumnHeader[] { columnHeader8, columnHeader9, columnHeader10, columnHeader11 });
            list_dshd.FullRowSelect = true;
            list_dshd.GridLines = true;
            list_dshd.Location = new Point(426, 388);
            list_dshd.Name = "list_dshd";
            list_dshd.Size = new Size(264, 300);
            list_dshd.TabIndex = 12;
            list_dshd.UseCompatibleStateImageBehavior = false;
            list_dshd.View = View.Details;
            list_dshd.MouseClick += list_dshd_MouseClick;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "";
            columnHeader8.Width = 30;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "InvoiceID";
            columnHeader9.TextAlign = HorizontalAlignment.Center;
            columnHeader9.Width = 68;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Ngày ";
            columnHeader10.TextAlign = HorizontalAlignment.Center;
            columnHeader10.Width = 90;
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "Tổng tiền";
            columnHeader11.TextAlign = HorizontalAlignment.Center;
            columnHeader11.Width = 80;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(426, 353);
            label10.Name = "label10";
            label10.Size = new Size(144, 21);
            label10.TabIndex = 13;
            label10.Text = "Lịch sử mua hàng";
            // 
            // errorName
            // 
            errorName.ContainerControl = this;
            // 
            // errorPhoneNumber
            // 
            errorPhoneNumber.ContainerControl = this;
            // 
            // errorGender
            // 
            errorGender.ContainerControl = this;
            // 
            // errorDateOfBirth
            // 
            errorDateOfBirth.ContainerControl = this;
            // 
            // lblSuccess
            // 
            lblSuccess.AutoSize = true;
            lblSuccess.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblSuccess.ForeColor = Color.ForestGreen;
            lblSuccess.Location = new Point(117, 44);
            lblSuccess.Name = "lblSuccess";
            lblSuccess.Size = new Size(52, 17);
            lblSuccess.TabIndex = 22;
            lblSuccess.Text = "label11";
            // 
            // timerHideMessage
            // 
            timerHideMessage.Interval = 3000;
            timerHideMessage.Tick += timerHideMessage_Tick;
            // 
            // errorID
            // 
            errorID.ContainerControl = this;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(694, 353);
            label11.Name = "label11";
            label11.Size = new Size(132, 21);
            label11.TabIndex = 23;
            label11.Text = "Chi tiết hóa đơn";
            // 
            // list_cthd
            // 
            list_cthd.Columns.AddRange(new ColumnHeader[] { columnHeader12, columnHeader13, columnHeader14, columnHeader15, columnHeader16, columnHeader17, columnHeader18 });
            list_cthd.FullRowSelect = true;
            list_cthd.GridLines = true;
            list_cthd.Location = new Point(696, 388);
            list_cthd.Name = "list_cthd";
            list_cthd.Size = new Size(461, 300);
            list_cthd.TabIndex = 24;
            list_cthd.UseCompatibleStateImageBehavior = false;
            list_cthd.View = View.Details;
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "";
            columnHeader12.Width = 30;
            // 
            // columnHeader13
            // 
            columnHeader13.Text = "PromID";
            columnHeader13.TextAlign = HorizontalAlignment.Center;
            columnHeader13.Width = 70;
            // 
            // columnHeader14
            // 
            columnHeader14.Text = "Khuyến mãi";
            columnHeader14.TextAlign = HorizontalAlignment.Center;
            columnHeader14.Width = 80;
            // 
            // columnHeader15
            // 
            columnHeader15.Text = "ProdID";
            columnHeader15.TextAlign = HorizontalAlignment.Center;
            columnHeader15.Width = 80;
            // 
            // columnHeader16
            // 
            columnHeader16.Text = "Sản phẩm";
            columnHeader16.TextAlign = HorizontalAlignment.Center;
            columnHeader16.Width = 100;
            // 
            // columnHeader17
            // 
            columnHeader17.Text = "SL";
            columnHeader17.TextAlign = HorizontalAlignment.Center;
            columnHeader17.Width = 40;
            // 
            // columnHeader18
            // 
            columnHeader18.Text = "Giá tiền";
            columnHeader18.TextAlign = HorizontalAlignment.Center;
            // 
            // CustomersManagementPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1169, 594);
            Controls.Add(list_dskh);
            Controls.Add(list_cthd);
            Controls.Add(label11);
            Controls.Add(lblSuccess);
            Controls.Add(label10);
            Controls.Add(list_dshd);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "CustomersManagementPanel";
            Text = "CustomersManagementPanel";
            Load += CustomersManagementPanel_Load;
            groupGioiTinh.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panelSearchPoint.ResumeLayout(false);
            groupSearch.ResumeLayout(false);
            panelSearchDate.ResumeLayout(false);
            panelSearchDate.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorName).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorPhoneNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorGender).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorDateOfBirth).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorID).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton rdnNam;
        private DateTimePicker cbbDayOfBirth;
        private TextBox txtPoint;
        private Button btnAdd;
        private GroupBox groupGioiTinh;
        private RadioButton rdbKhac;
        private RadioButton rdbNu;
        private Button button1;
        private ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private TextBox txtSearch;
        private Label label14;
        private System.Windows.Forms.Panel panel3;
        private Button btnReLoad;
        private Button btnDelete;
        private Button btnEdit;
        private Label label3;
        private Label label2;
        private TextBox txtPhoneNumber;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader4;
        private TextBox txtName;
        private TextBox txtID;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader1;
        private Label label9;
        private Label label8;
        private Label label6;
        private ColumnHeader columnHeader5;
        private ListView list_dskh;
        private ColumnHeader columnHeader7;
        private Label label7;
        private Label label1;
        private Label label5;
        private Label label4;
        private System.Windows.Forms.Panel panel1;
        private ListView list_dshd;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private Label label10;
        private ErrorProvider errorName;
        private ErrorProvider errorPhoneNumber;
        private ErrorProvider errorGender;
        private ErrorProvider errorDateOfBirth;
        private Label lblSuccess;
        private System.Windows.Forms.Timer timerHideMessage;
        private ErrorProvider errorID;
        private Label label11;
        private ListView list_cthd;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader16;
        private ColumnHeader columnHeader17;
        private ColumnHeader columnHeader18;
        private ComboBox cbbSearch;
        private Label label12;
        private System.Windows.Forms.Panel panelSearchDate;
        private System.Windows.Forms.Panel panelSearchPoint;
        private DateTimePicker cbbDayE;
        private DateTimePicker cbbDayS;
        private Label label15;
        private Label label13;
        private GroupBox groupSearch;
        private RadioButton rdbMin;
        private RadioButton rdbMax;
        private RadioButton rdbAll;
        private Button btnLoc;
    }
}