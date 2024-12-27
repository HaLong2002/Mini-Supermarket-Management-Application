namespace SieuThiMini.Panel
{
    partial class SignUpPanel
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
            rdbGioiTinh = new GroupBox();
            rdbkhac = new RadioButton();
            rdbNu = new RadioButton();
            rdbNam = new RadioButton();
            btnDangKy = new Button();
            txtXacNhanMatKhau = new TextBox();
            txtMatKhau = new TextBox();
            txtEmail = new TextBox();
            label2 = new Label();
            cbbBirthday = new DateTimePicker();
            label1 = new Label();
            txtHoTen = new TextBox();
            titleDangNhap = new Label();
            btnDangNhap = new LinkLabel();
            label3 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            rdbGioiTinh.SuspendLayout();
            SuspendLayout();
            // 
            // rdbGioiTinh
            // 
            rdbGioiTinh.Controls.Add(rdbkhac);
            rdbGioiTinh.Controls.Add(rdbNu);
            rdbGioiTinh.Controls.Add(rdbNam);
            rdbGioiTinh.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rdbGioiTinh.Location = new Point(52, 225);
            rdbGioiTinh.Name = "rdbGioiTinh";
            rdbGioiTinh.Size = new Size(398, 45);
            rdbGioiTinh.TabIndex = 25;
            rdbGioiTinh.TabStop = false;
            // 
            // rdbkhac
            // 
            rdbkhac.AutoSize = true;
            rdbkhac.Location = new Point(331, 14);
            rdbkhac.Name = "rdbkhac";
            rdbkhac.Size = new Size(61, 25);
            rdbkhac.TabIndex = 2;
            rdbkhac.TabStop = true;
            rdbkhac.Text = "Khác";
            rdbkhac.UseVisualStyleBackColor = true;
            // 
            // rdbNu
            // 
            rdbNu.AutoSize = true;
            rdbNu.Location = new Point(176, 14);
            rdbNu.Name = "rdbNu";
            rdbNu.Size = new Size(49, 25);
            rdbNu.TabIndex = 1;
            rdbNu.TabStop = true;
            rdbNu.Text = "Nữ";
            rdbNu.UseVisualStyleBackColor = true;
            // 
            // rdbNam
            // 
            rdbNam.AutoSize = true;
            rdbNam.Location = new Point(6, 14);
            rdbNam.Name = "rdbNam";
            rdbNam.Size = new Size(62, 25);
            rdbNam.TabIndex = 0;
            rdbNam.TabStop = true;
            rdbNam.Text = "Nam";
            rdbNam.UseVisualStyleBackColor = true;
            // 
            // btnDangKy
            // 
            btnDangKy.BackColor = Color.FromArgb(24, 119, 242);
            btnDangKy.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDangKy.ForeColor = SystemColors.ControlLightLight;
            btnDangKy.Location = new Point(127, 439);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(226, 38);
            btnDangKy.TabIndex = 24;
            btnDangKy.Text = "Đăng Ký";
            btnDangKy.UseVisualStyleBackColor = false;
            // 
            // txtXacNhanMatKhau
            // 
            txtXacNhanMatKhau.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtXacNhanMatKhau.Location = new Point(50, 385);
            txtXacNhanMatKhau.Multiline = true;
            txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            txtXacNhanMatKhau.PlaceholderText = "Xác nhận mật khẩu";
            txtXacNhanMatKhau.Size = new Size(400, 29);
            txtXacNhanMatKhau.TabIndex = 23;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtMatKhau.Location = new Point(50, 337);
            txtMatKhau.Multiline = true;
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.PlaceholderText = "Mật khẩu";
            txtMatKhau.Size = new Size(400, 29);
            txtMatKhau.TabIndex = 22;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(50, 289);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(400, 29);
            txtEmail.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 207);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 20;
            label2.Text = "Giới tính";
            // 
            // cbbBirthday
            // 
            cbbBirthday.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbBirthday.Location = new Point(50, 163);
            cbbBirthday.Name = "cbbBirthday";
            cbbBirthday.Size = new Size(400, 29);
            cbbBirthday.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 145);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 18;
            label1.Text = "Ngày sinh";
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtHoTen.Location = new Point(50, 101);
            txtHoTen.Multiline = true;
            txtHoTen.Name = "txtHoTen";
            txtHoTen.PlaceholderText = "Họ tên";
            txtHoTen.Size = new Size(400, 29);
            txtHoTen.TabIndex = 17;
            // 
            // titleDangNhap
            // 
            titleDangNhap.AutoSize = true;
            titleDangNhap.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            titleDangNhap.ForeColor = Color.FromArgb(24, 119, 242);
            titleDangNhap.Location = new Point(173, 26);
            titleDangNhap.Name = "titleDangNhap";
            titleDangNhap.Size = new Size(146, 45);
            titleDangNhap.TabIndex = 16;
            titleDangNhap.Text = "Đăng Ký";
            // 
            // btnDangNhap
            // 
            btnDangNhap.AutoSize = true;
            btnDangNhap.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnDangNhap.Location = new Point(261, 489);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(76, 17);
            btnDangNhap.TabIndex = 27;
            btnDangNhap.TabStop = true;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.LinkClicked += btnDangNhap_LinkClicked;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(127, 489);
            label3.Name = "label3";
            label3.Size = new Size(144, 17);
            label3.TabIndex = 26;
            label3.Text = "Bạn đã có tài khoản ? ";
            // 
            // SignUpPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(501, 532);
            Controls.Add(rdbGioiTinh);
            Controls.Add(btnDangKy);
            Controls.Add(txtXacNhanMatKhau);
            Controls.Add(txtMatKhau);
            Controls.Add(txtEmail);
            Controls.Add(label2);
            Controls.Add(cbbBirthday);
            Controls.Add(label1);
            Controls.Add(txtHoTen);
            Controls.Add(titleDangNhap);
            Controls.Add(btnDangNhap);
            Controls.Add(label3);
            Name = "SignUpPanel";
            Text = "SignUpPanel";
            rdbGioiTinh.ResumeLayout(false);
            rdbGioiTinh.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox rdbGioiTinh;
        private RadioButton rdbkhac;
        private RadioButton rdbNu;
        private RadioButton rdbNam;
        private Button btnDangKy;
        private TextBox txtXacNhanMatKhau;
        private TextBox txtMatKhau;
        private TextBox txtEmail;
        private Label label2;
        private DateTimePicker cbbBirthday;
        private Label label1;
        private TextBox txtHoTen;
        private Label titleDangNhap;
        private LinkLabel btnDangNhap;
        private Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}