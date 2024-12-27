namespace SieuThiMini.Panel
{
    partial class EmployeesManagementPanel
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
            label1 = new Label();
            list_dsnv = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            panel1 = new System.Windows.Forms.Panel();
            lbltenanh = new Label();
            panelChangePass = new System.Windows.Forms.Panel();
            btnConfirm = new Button();
            lblConfirmPass = new Label();
            txtConfirmPass = new TextBox();
            btnDoiMatKhau = new LinkLabel();
            panel2 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();
            btnReLoad = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            btnEditImage = new Button();
            cbbDayOfBirth = new DateTimePicker();
            cbbStatus = new ComboBox();
            cbbRole = new ComboBox();
            txtPhoneNumber = new TextBox();
            txtPassword = new TextBox();
            groupGioiTinh = new GroupBox();
            rdbKhac = new RadioButton();
            rdbNu = new RadioButton();
            rdnNam = new RadioButton();
            txtName = new TextBox();
            txtEmail = new TextBox();
            txtID = new TextBox();
            avatar = new PictureBox();
            txtCreateAt = new TextBox();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label3 = new Label();
            imageList1 = new ImageList(components);
            panel4 = new System.Windows.Forms.Panel();
            cbbStatusSearch = new ComboBox();
            label20 = new Label();
            btnLoc = new Button();
            txtTo = new TextBox();
            label19 = new Label();
            label18 = new Label();
            txtFrom = new TextBox();
            label17 = new Label();
            label16 = new Label();
            groupGenderSearch = new GroupBox();
            rdbKhacS = new RadioButton();
            rdbNuS = new RadioButton();
            rdbNamS = new RadioButton();
            label15 = new Label();
            txtSearch = new TextBox();
            label14 = new Label();
            button1 = new Button();
            timerHideMessage = new System.Windows.Forms.Timer(components);
            lblSuccess = new Label();
            errorName = new ErrorProvider(components);
            errorDateOfBirth = new ErrorProvider(components);
            errorPhoneNumber = new ErrorProvider(components);
            errorGender = new ErrorProvider(components);
            errorPass = new ErrorProvider(components);
            errorConfirmPass = new ErrorProvider(components);
            errorEmail = new ErrorProvider(components);
            errorID = new ErrorProvider(components);
            errorAgeSearch = new ErrorProvider(components);
            panel1.SuspendLayout();
            panelChangePass.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            groupGioiTinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)avatar).BeginInit();
            panel4.SuspendLayout();
            groupGenderSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorDateOfBirth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorPhoneNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorGender).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorPass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorConfirmPass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorEmail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorAgeSearch).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(24, 119, 242);
            label1.Location = new Point(570, 9);
            label1.Name = "label1";
            label1.Size = new Size(192, 30);
            label1.TabIndex = 0;
            label1.Text = "Quản lý nhân viên";
            // 
            // list_dsnv
            // 
            list_dsnv.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader8, columnHeader9 });
            list_dsnv.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            list_dsnv.FullRowSelect = true;
            list_dsnv.GridLines = true;
            list_dsnv.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3, listViewItem4 });
            list_dsnv.Location = new Point(583, 282);
            list_dsnv.Name = "list_dsnv";
            list_dsnv.Size = new Size(567, 306);
            list_dsnv.TabIndex = 1;
            list_dsnv.UseCompatibleStateImageBehavior = false;
            list_dsnv.View = View.Details;
            list_dsnv.MouseClick += list_dsnv_MouseClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "";
            columnHeader1.Width = 30;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "ID";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 40;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Email";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Tên";
            columnHeader4.TextAlign = HorizontalAlignment.Center;
            columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "G.Tính";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "SDT";
            columnHeader6.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "NgSinh";
            columnHeader7.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Chức vụ";
            columnHeader8.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Trạng thái";
            columnHeader9.TextAlign = HorizontalAlignment.Center;
            columnHeader9.Width = 80;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(lbltenanh);
            panel1.Controls.Add(panelChangePass);
            panel1.Controls.Add(btnDoiMatKhau);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btnEditImage);
            panel1.Controls.Add(cbbDayOfBirth);
            panel1.Controls.Add(cbbStatus);
            panel1.Controls.Add(cbbRole);
            panel1.Controls.Add(txtPhoneNumber);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(groupGioiTinh);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(txtID);
            panel1.Controls.Add(avatar);
            panel1.Controls.Add(txtCreateAt);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(12, 68);
            panel1.Name = "panel1";
            panel1.Size = new Size(565, 559);
            panel1.TabIndex = 2;
            // 
            // lbltenanh
            // 
            lbltenanh.AutoSize = true;
            lbltenanh.Location = new Point(451, 208);
            lbltenanh.Name = "lbltenanh";
            lbltenanh.Size = new Size(44, 15);
            lbltenanh.TabIndex = 27;
            lbltenanh.Text = "label15";
            lbltenanh.Visible = false;
            // 
            // panelChangePass
            // 
            panelChangePass.Controls.Add(btnConfirm);
            panelChangePass.Controls.Add(lblConfirmPass);
            panelChangePass.Controls.Add(txtConfirmPass);
            panelChangePass.Location = new Point(16, 356);
            panelChangePass.Name = "panelChangePass";
            panelChangePass.Size = new Size(530, 38);
            panelChangePass.TabIndex = 26;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.FromArgb(24, 119, 242);
            btnConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnConfirm.ForeColor = SystemColors.ControlLightLight;
            btnConfirm.Location = new Point(343, 6);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(100, 29);
            btnConfirm.TabIndex = 26;
            btnConfirm.Text = "Xác nhận";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            btnConfirm.MouseEnter += btnConfirm_MouseEnter;
            btnConfirm.MouseLeave += btnConfirm_MouseLeave;
            // 
            // lblConfirmPass
            // 
            lblConfirmPass.AutoSize = true;
            lblConfirmPass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblConfirmPass.Location = new Point(4, 8);
            lblConfirmPass.Name = "lblConfirmPass";
            lblConfirmPass.Size = new Size(142, 21);
            lblConfirmPass.TabIndex = 24;
            lblConfirmPass.Text = "Xác nhận mật khẩu";
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.Location = new Point(149, 8);
            txtConfirmPass.Multiline = true;
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.Size = new Size(177, 23);
            txtConfirmPass.TabIndex = 25;
            // 
            // btnDoiMatKhau
            // 
            btnDoiMatKhau.AutoSize = true;
            btnDoiMatKhau.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnDoiMatKhau.Location = new Point(359, 331);
            btnDoiMatKhau.Name = "btnDoiMatKhau";
            btnDoiMatKhau.Size = new Size(81, 15);
            btnDoiMatKhau.TabIndex = 23;
            btnDoiMatKhau.TabStop = true;
            btnDoiMatKhau.Text = "Đổi mật khẩu";
            btnDoiMatKhau.LinkClicked += btnDoiMatKhau_LinkClicked;
            btnDoiMatKhau.MouseEnter += btnDoiMatKhau_MouseEnter;
            btnDoiMatKhau.MouseLeave += btnDoiMatKhau_MouseLeave;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(3, 404);
            panel2.Name = "panel2";
            panel2.Size = new Size(555, 110);
            panel2.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLight;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(btnReLoad);
            panel3.Controls.Add(btnDelete);
            panel3.Controls.Add(btnEdit);
            panel3.Controls.Add(btnAdd);
            panel3.Location = new Point(3, 15);
            panel3.Name = "panel3";
            panel3.Size = new Size(549, 63);
            panel3.TabIndex = 0;
            // 
            // btnReLoad
            // 
            btnReLoad.BackColor = Color.FromArgb(24, 119, 242);
            btnReLoad.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnReLoad.ForeColor = SystemColors.ButtonHighlight;
            btnReLoad.Location = new Point(415, 8);
            btnReLoad.Name = "btnReLoad";
            btnReLoad.Size = new Size(100, 40);
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
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.ForeColor = SystemColors.ButtonHighlight;
            btnDelete.Location = new Point(284, 8);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 40);
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
            btnEdit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnEdit.ForeColor = SystemColors.ButtonHighlight;
            btnEdit.Location = new Point(157, 8);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 40);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            btnEdit.MouseEnter += btnEdit_MouseEnter;
            btnEdit.MouseLeave += btnEdit_MouseLeave;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(0, 192, 0);
            btnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.ForeColor = SystemColors.ButtonHighlight;
            btnAdd.Location = new Point(29, 8);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 40);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            btnAdd.MouseEnter += btnAdd_MouseEnter;
            btnAdd.MouseLeave += btnAdd_MouseLeave;
            // 
            // btnEditImage
            // 
            btnEditImage.BackColor = Color.FromArgb(24, 119, 242);
            btnEditImage.FlatStyle = FlatStyle.Popup;
            btnEditImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditImage.ForeColor = SystemColors.ButtonHighlight;
            btnEditImage.ImageIndex = 5;
            btnEditImage.Location = new Point(425, 168);
            btnEditImage.Name = "btnEditImage";
            btnEditImage.Size = new Size(91, 28);
            btnEditImage.TabIndex = 22;
            btnEditImage.Text = "Chỉnh sửa";
            btnEditImage.UseVisualStyleBackColor = false;
            btnEditImage.Click += btnEditImage_Click;
            btnEditImage.MouseEnter += btnEditImage_MouseEnter;
            btnEditImage.MouseLeave += btnEditImage_MouseLeave;
            // 
            // cbbDayOfBirth
            // 
            cbbDayOfBirth.Location = new Point(162, 173);
            cbbDayOfBirth.Name = "cbbDayOfBirth";
            cbbDayOfBirth.Size = new Size(177, 23);
            cbbDayOfBirth.TabIndex = 21;
            // 
            // cbbStatus
            // 
            cbbStatus.FormattingEnabled = true;
            cbbStatus.Items.AddRange(new object[] { "Đang làm việc", "Nghỉ việc", "Nghỉ phép" });
            cbbStatus.Location = new Point(163, 267);
            cbbStatus.Name = "cbbStatus";
            cbbStatus.Size = new Size(177, 23);
            cbbStatus.TabIndex = 20;
            // 
            // cbbRole
            // 
            cbbRole.FormattingEnabled = true;
            cbbRole.Items.AddRange(new object[] { "Nhân viên bán hàng", "Nhân viên nhập hàng", "Admin" });
            cbbRole.Location = new Point(162, 236);
            cbbRole.Name = "cbbRole";
            cbbRole.Size = new Size(177, 23);
            cbbRole.TabIndex = 19;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(163, 205);
            txtPhoneNumber.Multiline = true;
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(177, 23);
            txtPhoneNumber.TabIndex = 18;
            txtPhoneNumber.KeyPress += txtPhoneNumber_KeyPress;
            // 
            // txtPassword
            // 
            txtPassword.Enabled = false;
            txtPassword.Location = new Point(162, 327);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(177, 23);
            txtPassword.TabIndex = 17;
            // 
            // groupGioiTinh
            // 
            groupGioiTinh.Controls.Add(rdbKhac);
            groupGioiTinh.Controls.Add(rdbNu);
            groupGioiTinh.Controls.Add(rdnNam);
            groupGioiTinh.FlatStyle = FlatStyle.System;
            groupGioiTinh.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupGioiTinh.Location = new Point(162, 118);
            groupGioiTinh.Name = "groupGioiTinh";
            groupGioiTinh.Size = new Size(198, 45);
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
            rdbNu.Location = new Point(73, 11);
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
            // txtName
            // 
            txtName.Location = new Point(162, 85);
            txtName.Multiline = true;
            txtName.Name = "txtName";
            txtName.Size = new Size(177, 23);
            txtName.TabIndex = 15;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(163, 50);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(177, 23);
            txtEmail.TabIndex = 14;
            // 
            // txtID
            // 
            txtID.Enabled = false;
            txtID.Location = new Point(163, 19);
            txtID.Multiline = true;
            txtID.Name = "txtID";
            txtID.Size = new Size(177, 23);
            txtID.TabIndex = 13;
            // 
            // avatar
            // 
            avatar.Image = Properties.Resources.user;
            avatar.Location = new Point(405, 17);
            avatar.Name = "avatar";
            avatar.Size = new Size(128, 137);
            avatar.SizeMode = PictureBoxSizeMode.Zoom;
            avatar.TabIndex = 12;
            avatar.TabStop = false;
            // 
            // txtCreateAt
            // 
            txtCreateAt.Enabled = false;
            txtCreateAt.Location = new Point(163, 296);
            txtCreateAt.Multiline = true;
            txtCreateAt.Name = "txtCreateAt";
            txtCreateAt.ReadOnly = true;
            txtCreateAt.Size = new Size(177, 23);
            txtCreateAt.TabIndex = 11;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(19, 293);
            label13.Name = "label13";
            label13.Size = new Size(141, 21);
            label13.TabIndex = 9;
            label13.Text = "Ngày tạo tài khoản";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(22, 325);
            label12.Name = "label12";
            label12.Size = new Size(75, 21);
            label12.TabIndex = 8;
            label12.Text = "Mật khẩu";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(16, 265);
            label11.Name = "label11";
            label11.Size = new Size(79, 21);
            label11.TabIndex = 7;
            label11.Text = "Trạng thái";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(16, 234);
            label10.Name = "label10";
            label10.Size = new Size(66, 21);
            label10.TabIndex = 6;
            label10.Text = "Chức vụ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(16, 203);
            label9.Name = "label9";
            label9.Size = new Size(101, 21);
            label9.TabIndex = 5;
            label9.Text = "Số điện thoại";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(16, 168);
            label8.Name = "label8";
            label8.Size = new Size(80, 21);
            label8.TabIndex = 4;
            label8.Text = "Ngày sinh";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(16, 118);
            label7.Name = "label7";
            label7.Size = new Size(70, 21);
            label7.TabIndex = 3;
            label7.Text = "Giới tính";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(16, 83);
            label6.Name = "label6";
            label6.Size = new Size(33, 21);
            label6.TabIndex = 2;
            label6.Text = "Tên";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(16, 48);
            label5.Name = "label5";
            label5.Size = new Size(48, 21);
            label5.TabIndex = 1;
            label5.Text = "Email";
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(589, 254);
            label2.Name = "label2";
            label2.Size = new Size(137, 17);
            label2.TabIndex = 3;
            label2.Text = "Danh sách nhân viên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(7, 44);
            label3.Name = "label3";
            label3.Size = new Size(88, 21);
            label3.TabIndex = 4;
            label3.Text = "Thông tin ";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // panel4
            // 
            panel4.Controls.Add(cbbStatusSearch);
            panel4.Controls.Add(label20);
            panel4.Controls.Add(btnLoc);
            panel4.Controls.Add(txtTo);
            panel4.Controls.Add(label19);
            panel4.Controls.Add(label18);
            panel4.Controls.Add(txtFrom);
            panel4.Controls.Add(label17);
            panel4.Controls.Add(label16);
            panel4.Controls.Add(groupGenderSearch);
            panel4.Controls.Add(label15);
            panel4.Controls.Add(txtSearch);
            panel4.Controls.Add(label14);
            panel4.Location = new Point(589, 62);
            panel4.Name = "panel4";
            panel4.Size = new Size(561, 179);
            panel4.TabIndex = 1;
            // 
            // cbbStatusSearch
            // 
            cbbStatusSearch.FormattingEnabled = true;
            cbbStatusSearch.Location = new Point(354, 115);
            cbbStatusSearch.Name = "cbbStatusSearch";
            cbbStatusSearch.Size = new Size(164, 23);
            cbbStatusSearch.TabIndex = 26;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label20.Location = new Point(288, 118);
            label20.Name = "label20";
            label20.Size = new Size(60, 15);
            label20.TabIndex = 25;
            label20.Text = "Trạng thái";
            // 
            // btnLoc
            // 
            btnLoc.BackColor = Color.FromArgb(24, 119, 242);
            btnLoc.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnLoc.ForeColor = SystemColors.ControlLightLight;
            btnLoc.Location = new Point(219, 141);
            btnLoc.Name = "btnLoc";
            btnLoc.Size = new Size(75, 30);
            btnLoc.TabIndex = 24;
            btnLoc.Text = "Lọc";
            btnLoc.UseVisualStyleBackColor = false;
            btnLoc.Click += btnLoc_Click;
            btnLoc.MouseEnter += btnLoc_MouseEnter;
            btnLoc.MouseLeave += btnLoc_MouseLeave;
            // 
            // txtTo
            // 
            txtTo.Location = new Point(197, 112);
            txtTo.Name = "txtTo";
            txtTo.Size = new Size(76, 23);
            txtTo.TabIndex = 23;
            txtTo.KeyPress += txtTo_KeyPress;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(163, 118);
            label19.Name = "label19";
            label19.Size = new Size(28, 15);
            label19.TabIndex = 22;
            label19.Text = "Đến";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(67, 115);
            label18.Name = "label18";
            label18.Size = new Size(20, 15);
            label18.TabIndex = 21;
            label18.Text = "Từ";
            // 
            // txtFrom
            // 
            txtFrom.Location = new Point(94, 110);
            txtFrom.Name = "txtFrom";
            txtFrom.Size = new Size(63, 23);
            txtFrom.TabIndex = 20;
            txtFrom.KeyPress += txtFrom_KeyPress;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label17.Location = new Point(4, 113);
            label17.Name = "label17";
            label17.Size = new Size(47, 15);
            label17.TabIndex = 19;
            label17.Text = "Độ tuổi";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label16.Location = new Point(4, 58);
            label16.Name = "label16";
            label16.Size = new Size(52, 15);
            label16.TabIndex = 18;
            label16.Text = "Giới tính";
            // 
            // groupGenderSearch
            // 
            groupGenderSearch.Controls.Add(rdbKhacS);
            groupGenderSearch.Controls.Add(rdbNuS);
            groupGenderSearch.Controls.Add(rdbNamS);
            groupGenderSearch.FlatStyle = FlatStyle.System;
            groupGenderSearch.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupGenderSearch.Location = new Point(75, 47);
            groupGenderSearch.Name = "groupGenderSearch";
            groupGenderSearch.Size = new Size(257, 45);
            groupGenderSearch.TabIndex = 17;
            groupGenderSearch.TabStop = false;
            // 
            // rdbKhacS
            // 
            rdbKhacS.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rdbKhacS.Location = new Point(177, 11);
            rdbKhacS.Name = "rdbKhacS";
            rdbKhacS.Size = new Size(63, 32);
            rdbKhacS.TabIndex = 2;
            rdbKhacS.TabStop = true;
            rdbKhacS.Text = "Khác";
            rdbKhacS.UseVisualStyleBackColor = true;
            // 
            // rdbNuS
            // 
            rdbNuS.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rdbNuS.Location = new Point(97, 11);
            rdbNuS.Name = "rdbNuS";
            rdbNuS.Size = new Size(63, 32);
            rdbNuS.TabIndex = 1;
            rdbNuS.TabStop = true;
            rdbNuS.Text = "Nữ";
            rdbNuS.UseVisualStyleBackColor = true;
            // 
            // rdbNamS
            // 
            rdbNamS.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rdbNamS.Location = new Point(17, 11);
            rdbNamS.Name = "rdbNamS";
            rdbNamS.Size = new Size(63, 32);
            rdbNamS.TabIndex = 0;
            rdbNamS.TabStop = true;
            rdbNamS.Text = "Nam";
            rdbNamS.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(80, 85);
            label15.Name = "label15";
            label15.Size = new Size(0, 15);
            label15.TabIndex = 3;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(75, 13);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập tên hoặc email hoặc SDT cần tìm kiếm";
            txtSearch.Size = new Size(289, 23);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label14.Location = new Point(3, 19);
            label14.Name = "label14";
            label14.Size = new Size(66, 17);
            label14.TabIndex = 0;
            label14.Text = "Tìm kiếm";
            // 
            // button1
            // 
            button1.BackgroundImage = Properties.Resources.icon_reload;
            button1.Location = new Point(1114, 247);
            button1.Name = "button1";
            button1.Size = new Size(36, 33);
            button1.TabIndex = 3;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // timerHideMessage
            // 
            timerHideMessage.Tick += timerHideMessage_Tick;
            // 
            // lblSuccess
            // 
            lblSuccess.AutoSize = true;
            lblSuccess.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblSuccess.ForeColor = Color.ForestGreen;
            lblSuccess.Location = new Point(122, 48);
            lblSuccess.Name = "lblSuccess";
            lblSuccess.Size = new Size(52, 17);
            lblSuccess.TabIndex = 23;
            lblSuccess.Text = "label11";
            // 
            // errorName
            // 
            errorName.ContainerControl = this;
            // 
            // errorDateOfBirth
            // 
            errorDateOfBirth.ContainerControl = this;
            // 
            // errorPhoneNumber
            // 
            errorPhoneNumber.ContainerControl = this;
            // 
            // errorGender
            // 
            errorGender.ContainerControl = this;
            // 
            // errorPass
            // 
            errorPass.ContainerControl = this;
            // 
            // errorConfirmPass
            // 
            errorConfirmPass.ContainerControl = this;
            // 
            // errorEmail
            // 
            errorEmail.ContainerControl = this;
            // 
            // errorID
            // 
            errorID.ContainerControl = this;
            // 
            // errorAgeSearch
            // 
            errorAgeSearch.ContainerControl = this;
            // 
            // EmployeesManagementPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1169, 594);
            Controls.Add(panel4);
            Controls.Add(lblSuccess);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(list_dsnv);
            Controls.Add(label1);
            Name = "EmployeesManagementPanel";
            Text = "EmployeesManagementPanel";
            Load += EmployeesManagementPanel_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelChangePass.ResumeLayout(false);
            panelChangePass.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            groupGioiTinh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)avatar).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            groupGenderSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorName).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorDateOfBirth).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorPhoneNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorGender).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorPass).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorConfirmPass).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorEmail).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorID).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorAgeSearch).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListView list_dsnv;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private System.Windows.Forms.Panel panel1;
        private Label label2;
        private Label label3;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private ImageList imageList1;
        private Label label13;
        private Label label12;
        private TextBox txtCreateAt;
        private PictureBox avatar;
        private GroupBox groupGioiTinh;
        private RadioButton rdnNam;
        private TextBox txtName;
        private TextBox txtEmail;
        private TextBox txtID;
        private RadioButton rdbKhac;
        private RadioButton rdbNu;
        private DateTimePicker cbbDayOfBirth;
        private ComboBox cbbStatus;
        private ComboBox cbbRole;
        private TextBox txtPhoneNumber;
        private TextBox txtPassword;
        private Button btnEditImage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnAdd;
        private System.Windows.Forms.Panel panel4;
        private TextBox txtSearch;
        private Label label14;
        private Button btnReLoad;
        private Button button1;
        private ColumnHeader columnHeader9;
        private LinkLabel btnDoiMatKhau;
        private TextBox txtConfirmPass;
        private Label lblConfirmPass;
        private System.Windows.Forms.Timer timerHideMessage;
        private Label lblSuccess;
        private ErrorProvider errorName;
        private ErrorProvider errorDateOfBirth;
        private ErrorProvider errorPhoneNumber;
        private System.Windows.Forms.Panel panelChangePass;
        private ErrorProvider errorGender;
        private Button btnConfirm;
        private ErrorProvider errorPass;
        private ErrorProvider errorConfirmPass;
        private ErrorProvider errorEmail;
        private ErrorProvider errorID;
        private Label lbltenanh;
        private Label label15;
        private TextBox txtTo;
        private Label label19;
        private Label label18;
        private TextBox txtFrom;
        private Label label17;
        private Label label16;
        private GroupBox groupGenderSearch;
        private RadioButton rdbKhacS;
        private RadioButton rdbNuS;
        private RadioButton rdbNamS;
        private Button btnLoc;
        private ErrorProvider errorAgeSearch;
        private ComboBox cbbStatusSearch;
        private Label label20;
    }
}