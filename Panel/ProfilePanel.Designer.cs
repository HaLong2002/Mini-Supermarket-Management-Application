namespace SieuThiMini.Panel
{
    partial class ProfilePanel
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
            label1 = new Label();
            btnEditImage = new Button();
            avatar = new PictureBox();
            panel1 = new System.Windows.Forms.Panel();
            lbltenanh = new Label();
            panel3 = new System.Windows.Forms.Panel();
            btnReLoad = new Button();
            txtRole = new TextBox();
            lblSucsess = new Label();
            btnEdit = new Button();
            lblKQ = new Label();
            panelChangePass = new System.Windows.Forms.Panel();
            btnConfirm = new Button();
            txtConfirmPass = new TextBox();
            lblConfirmPass = new Label();
            btnDoiMatKhau = new LinkLabel();
            cbbDayOfBirth = new DateTimePicker();
            cbbStatus = new ComboBox();
            txtPhoneNumber = new TextBox();
            txtPassword = new TextBox();
            groupGioiTinh = new GroupBox();
            rdbKhac = new RadioButton();
            rdbNu = new RadioButton();
            rdnNam = new RadioButton();
            txtName = new TextBox();
            txtEmail = new TextBox();
            txtID = new TextBox();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            errorName = new ErrorProvider(components);
            errorPhoneNumber = new ErrorProvider(components);
            errorPass = new ErrorProvider(components);
            errorConfirmPass = new ErrorProvider(components);
            timerHideMessage = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)avatar).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panelChangePass.SuspendLayout();
            groupGioiTinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorPhoneNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorPass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorConfirmPass).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(24, 119, 242);
            label1.Location = new Point(533, 9);
            label1.Name = "label1";
            label1.Size = new Size(246, 37);
            label1.TabIndex = 0;
            label1.Text = "Thông tin cá nhân";
            // 
            // btnEditImage
            // 
            btnEditImage.BackColor = Color.FromArgb(24, 119, 242);
            btnEditImage.FlatStyle = FlatStyle.Popup;
            btnEditImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditImage.ForeColor = SystemColors.ButtonHighlight;
            btnEditImage.ImageIndex = 5;
            btnEditImage.Location = new Point(59, 195);
            btnEditImage.Name = "btnEditImage";
            btnEditImage.Size = new Size(91, 28);
            btnEditImage.TabIndex = 24;
            btnEditImage.Text = "Chỉnh sửa";
            btnEditImage.UseVisualStyleBackColor = false;
            btnEditImage.Click += btnEditImage_Click;
            btnEditImage.MouseEnter += btnEditImage_MouseEnter;
            btnEditImage.MouseLeave += btnEditImage_MouseLeave;
            // 
            // avatar
            // 
            avatar.Image = Properties.Resources.user;
            avatar.Location = new Point(21, 18);
            avatar.Name = "avatar";
            avatar.Size = new Size(182, 171);
            avatar.SizeMode = PictureBoxSizeMode.Zoom;
            avatar.TabIndex = 23;
            avatar.TabStop = false;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(lbltenanh);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(avatar);
            panel1.Controls.Add(btnEditImage);
            panel1.Location = new Point(12, 58);
            panel1.Name = "panel1";
            panel1.Size = new Size(1154, 653);
            panel1.TabIndex = 25;
            // 
            // lbltenanh
            // 
            lbltenanh.AutoSize = true;
            lbltenanh.Location = new Point(96, 245);
            lbltenanh.Name = "lbltenanh";
            lbltenanh.Size = new Size(0, 15);
            lbltenanh.TabIndex = 29;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLight;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(btnReLoad);
            panel3.Controls.Add(txtRole);
            panel3.Controls.Add(lblSucsess);
            panel3.Controls.Add(btnEdit);
            panel3.Controls.Add(lblKQ);
            panel3.Controls.Add(panelChangePass);
            panel3.Controls.Add(btnDoiMatKhau);
            panel3.Controls.Add(cbbDayOfBirth);
            panel3.Controls.Add(cbbStatus);
            panel3.Controls.Add(txtPhoneNumber);
            panel3.Controls.Add(txtPassword);
            panel3.Controls.Add(groupGioiTinh);
            panel3.Controls.Add(txtName);
            panel3.Controls.Add(txtEmail);
            panel3.Controls.Add(txtID);
            panel3.Controls.Add(label12);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(209, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(929, 526);
            panel3.TabIndex = 3;
            // 
            // btnReLoad
            // 
            btnReLoad.BackColor = Color.FromArgb(24, 119, 242);
            btnReLoad.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnReLoad.ForeColor = SystemColors.ControlLightLight;
            btnReLoad.Location = new Point(536, 464);
            btnReLoad.Name = "btnReLoad";
            btnReLoad.Size = new Size(98, 35);
            btnReLoad.TabIndex = 30;
            btnReLoad.Text = "Làm mới";
            btnReLoad.UseVisualStyleBackColor = false;
            btnReLoad.Click += btnReLoad_Click;
            btnReLoad.MouseEnter += btnReLoad_MouseEnter;
            btnReLoad.MouseLeave += btnReLoad_MouseLeave;
            // 
            // txtRole
            // 
            txtRole.Enabled = false;
            txtRole.Location = new Point(161, 250);
            txtRole.Multiline = true;
            txtRole.Name = "txtRole";
            txtRole.Size = new Size(529, 29);
            txtRole.TabIndex = 30;
            // 
            // lblSucsess
            // 
            lblSucsess.AutoSize = true;
            lblSucsess.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblSucsess.ForeColor = Color.ForestGreen;
            lblSucsess.Location = new Point(17, 431);
            lblSucsess.Name = "lblSucsess";
            lblSucsess.Size = new Size(57, 21);
            lblSucsess.TabIndex = 29;
            lblSucsess.Text = "label2";
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(24, 119, 242);
            btnEdit.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnEdit.ForeColor = SystemColors.ControlLightLight;
            btnEdit.Location = new Point(300, 464);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(99, 38);
            btnEdit.TabIndex = 28;
            btnEdit.Text = "Cập nhật";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            btnEdit.MouseEnter += btnEdit_MouseEnter;
            btnEdit.MouseLeave += btnEdit_MouseLeave;
            // 
            // lblKQ
            // 
            lblKQ.AutoSize = true;
            lblKQ.Location = new Point(153, 531);
            lblKQ.Name = "lblKQ";
            lblKQ.Size = new Size(0, 15);
            lblKQ.TabIndex = 28;
            // 
            // panelChangePass
            // 
            panelChangePass.Controls.Add(btnConfirm);
            panelChangePass.Controls.Add(txtConfirmPass);
            panelChangePass.Controls.Add(lblConfirmPass);
            panelChangePass.Location = new Point(3, 366);
            panelChangePass.Name = "panelChangePass";
            panelChangePass.Size = new Size(808, 62);
            panelChangePass.TabIndex = 27;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.FromArgb(24, 119, 242);
            btnConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnConfirm.ForeColor = SystemColors.ControlLightLight;
            btnConfirm.Location = new Point(715, 19);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(90, 35);
            btnConfirm.TabIndex = 26;
            btnConfirm.Text = "Xác nhận";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            btnConfirm.MouseEnter += btnConfirm_MouseEnter;
            btnConfirm.MouseLeave += btnConfirm_MouseLeave;
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.Location = new Point(163, 22);
            txtConfirmPass.Multiline = true;
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.Size = new Size(529, 29);
            txtConfirmPass.TabIndex = 25;
            // 
            // lblConfirmPass
            // 
            lblConfirmPass.AutoSize = true;
            lblConfirmPass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblConfirmPass.Location = new Point(15, 24);
            lblConfirmPass.Name = "lblConfirmPass";
            lblConfirmPass.Size = new Size(142, 21);
            lblConfirmPass.TabIndex = 24;
            lblConfirmPass.Text = "Xác nhận mật khẩu";
            // 
            // btnDoiMatKhau
            // 
            btnDoiMatKhau.AutoSize = true;
            btnDoiMatKhau.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnDoiMatKhau.Location = new Point(719, 339);
            btnDoiMatKhau.Name = "btnDoiMatKhau";
            btnDoiMatKhau.Size = new Size(81, 15);
            btnDoiMatKhau.TabIndex = 23;
            btnDoiMatKhau.TabStop = true;
            btnDoiMatKhau.Text = "Đổi mật khẩu";
            btnDoiMatKhau.LinkClicked += btnDoiMatKhau_LinkClicked;
            btnDoiMatKhau.MouseEnter += btnDoiMatKhau_MouseEnter;
            btnDoiMatKhau.MouseLeave += btnDoiMatKhau_MouseLeave;
            // 
            // cbbDayOfBirth
            // 
            cbbDayOfBirth.Enabled = false;
            cbbDayOfBirth.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbDayOfBirth.Location = new Point(161, 154);
            cbbDayOfBirth.Name = "cbbDayOfBirth";
            cbbDayOfBirth.Size = new Size(530, 29);
            cbbDayOfBirth.TabIndex = 21;
            // 
            // cbbStatus
            // 
            cbbStatus.Enabled = false;
            cbbStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbStatus.FormattingEnabled = true;
            cbbStatus.Items.AddRange(new object[] { "Đang làm việc", "Nghỉ việc", "Nghỉ phép" });
            cbbStatus.Location = new Point(161, 292);
            cbbStatus.Name = "cbbStatus";
            cbbStatus.Size = new Size(529, 29);
            cbbStatus.TabIndex = 20;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtPhoneNumber.Location = new Point(161, 201);
            txtPhoneNumber.Multiline = true;
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(529, 29);
            txtPhoneNumber.TabIndex = 18;
            txtPhoneNumber.KeyPress += txtPhoneNumber_KeyPress;
            // 
            // txtPassword
            // 
            txtPassword.Enabled = false;
            txtPassword.Location = new Point(161, 331);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(529, 29);
            txtPassword.TabIndex = 17;
            // 
            // groupGioiTinh
            // 
            groupGioiTinh.Controls.Add(rdbKhac);
            groupGioiTinh.Controls.Add(rdbNu);
            groupGioiTinh.Controls.Add(rdnNam);
            groupGioiTinh.FlatStyle = FlatStyle.System;
            groupGioiTinh.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupGioiTinh.Location = new Point(163, 94);
            groupGioiTinh.Name = "groupGioiTinh";
            groupGioiTinh.Size = new Size(529, 45);
            groupGioiTinh.TabIndex = 16;
            groupGioiTinh.TabStop = false;
            // 
            // rdbKhac
            // 
            rdbKhac.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rdbKhac.Location = new Point(355, 11);
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
            rdbNu.Location = new Point(173, 11);
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
            txtName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtName.Location = new Point(412, 22);
            txtName.Multiline = true;
            txtName.Name = "txtName";
            txtName.Size = new Size(283, 29);
            txtName.TabIndex = 15;
            // 
            // txtEmail
            // 
            txtEmail.Enabled = false;
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(163, 59);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(529, 29);
            txtEmail.TabIndex = 14;
            // 
            // txtID
            // 
            txtID.Enabled = false;
            txtID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtID.Location = new Point(163, 19);
            txtID.Multiline = true;
            txtID.Name = "txtID";
            txtID.Size = new Size(199, 29);
            txtID.TabIndex = 13;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(21, 339);
            label12.Name = "label12";
            label12.Size = new Size(75, 21);
            label12.TabIndex = 8;
            label12.Text = "Mật khẩu";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(17, 295);
            label11.Name = "label11";
            label11.Size = new Size(79, 21);
            label11.TabIndex = 7;
            label11.Text = "Trạng thái";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(17, 250);
            label10.Name = "label10";
            label10.Size = new Size(66, 21);
            label10.TabIndex = 6;
            label10.Text = "Chức vụ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(17, 204);
            label9.Name = "label9";
            label9.Size = new Size(101, 21);
            label9.TabIndex = 5;
            label9.Text = "Số điện thoại";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(16, 160);
            label8.Name = "label8";
            label8.Size = new Size(80, 21);
            label8.TabIndex = 4;
            label8.Text = "Ngày sinh";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(16, 108);
            label7.Name = "label7";
            label7.Size = new Size(70, 21);
            label7.TabIndex = 3;
            label7.Text = "Giới tính";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(373, 22);
            label6.Name = "label6";
            label6.Size = new Size(33, 21);
            label6.TabIndex = 2;
            label6.Text = "Tên";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(16, 61);
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
            // errorName
            // 
            errorName.ContainerControl = this;
            // 
            // errorPhoneNumber
            // 
            errorPhoneNumber.ContainerControl = this;
            // 
            // errorPass
            // 
            errorPass.ContainerControl = this;
            // 
            // errorConfirmPass
            // 
            errorConfirmPass.ContainerControl = this;
            // 
            // timerHideMessage
            // 
            timerHideMessage.Tick += timerHideMessage_Tick;
            // 
            // ProfilePanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1169, 594);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "ProfilePanel";
            Text = "ProfilePanel";
            Load += ProfilePanel_Load;
            ((System.ComponentModel.ISupportInitialize)avatar).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panelChangePass.ResumeLayout(false);
            panelChangePass.PerformLayout();
            groupGioiTinh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorName).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorPhoneNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorPass).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorConfirmPass).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnEditImage;
        private PictureBox avatar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private TextBox txtConfirmPass;
        private Label lblConfirmPass;
        private LinkLabel btnDoiMatKhau;
        private DateTimePicker cbbDayOfBirth;
        private ComboBox cbbStatus;
        private TextBox txtPhoneNumber;
        private TextBox txtPassword;
        private GroupBox groupGioiTinh;
        private RadioButton rdbKhac;
        private RadioButton rdbNu;
        private RadioButton rdnNam;
        private TextBox txtName;
        private TextBox txtEmail;
        private TextBox txtID;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private System.Windows.Forms.Panel panelChangePass;
        private Button btnConfirm;
        private Button btnEdit;
        private Label lblKQ;
        private Label lblSucsess;
        private Label lbltenanh;
        private ErrorProvider errorName;
        private ErrorProvider errorPhoneNumber;
        private TextBox txtRole;
        private ErrorProvider errorPass;
        private ErrorProvider errorConfirmPass;
        private Button btnReLoad;
        private System.Windows.Forms.Timer timerHideMessage;
    }
}