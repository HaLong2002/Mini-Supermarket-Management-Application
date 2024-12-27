namespace SieuThiMini.Panel
{
    partial class ResetPasswordPanel
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
            btnDangNhap = new LinkLabel();
            btnXacNhan = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtNhapLaiMatKhauMoi = new TextBox();
            txtMatKhauMoi = new TextBox();
            label1 = new Label();
            errorPass = new ErrorProvider(components);
            errorConfirmPass = new ErrorProvider(components);
            label6 = new Label();
            timerHideMessage = new System.Windows.Forms.Timer(components);
            lblSuccess = new Label();
            ((System.ComponentModel.ISupportInitialize)errorPass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorConfirmPass).BeginInit();
            SuspendLayout();
            // 
            // btnDangNhap
            // 
            btnDangNhap.AutoSize = true;
            btnDangNhap.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnDangNhap.Location = new Point(201, 395);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(129, 17);
            btnDangNhap.TabIndex = 20;
            btnDangNhap.TabStop = true;
            btnDangNhap.Text = "Quay lại đăng nhập";
            btnDangNhap.LinkClicked += btnDangNhap_LinkClicked;
            btnDangNhap.MouseEnter += btnDangNhap_MouseEnter;
            btnDangNhap.MouseLeave += btnDangNhap_MouseLeave;
            // 
            // btnXacNhan
            // 
            btnXacNhan.BackColor = Color.FromArgb(24, 119, 242);
            btnXacNhan.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnXacNhan.ForeColor = SystemColors.ControlLightLight;
            btnXacNhan.Location = new Point(155, 343);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(226, 38);
            btnXacNhan.TabIndex = 19;
            btnXacNhan.Text = "Xác nhận";
            btnXacNhan.UseVisualStyleBackColor = false;
            btnXacNhan.Click += btnXacNhan_Click;
            btnXacNhan.MouseEnter += btnXacNhan_MouseEnter;
            btnXacNhan.MouseLeave += btnXacNhan_MouseLeave;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(201, 217);
            label5.Name = "label5";
            label5.Size = new Size(17, 21);
            label5.TabIndex = 18;
            label5.Text = "*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(155, 144);
            label4.Name = "label4";
            label4.Size = new Size(17, 21);
            label4.TabIndex = 17;
            label4.Text = "*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(76, 222);
            label3.Name = "label3";
            label3.Size = new Size(128, 15);
            label3.TabIndex = 16;
            label3.Text = "Nhập lại mật khẩu mới";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(76, 153);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 15;
            label2.Text = "Mật khẩu mới";
            // 
            // txtNhapLaiMatKhauMoi
            // 
            txtNhapLaiMatKhauMoi.Location = new Point(76, 246);
            txtNhapLaiMatKhauMoi.Multiline = true;
            txtNhapLaiMatKhauMoi.Name = "txtNhapLaiMatKhauMoi";
            txtNhapLaiMatKhauMoi.Size = new Size(400, 35);
            txtNhapLaiMatKhauMoi.TabIndex = 14;
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Location = new Point(76, 174);
            txtMatKhauMoi.Multiline = true;
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.PasswordChar = '*';
            txtMatKhauMoi.Size = new Size(400, 35);
            txtMatKhauMoi.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(24, 119, 242);
            label1.Location = new Point(136, 25);
            label1.Name = "label1";
            label1.Size = new Size(266, 45);
            label1.TabIndex = 12;
            label1.Text = "Đặt lại mật khẩu";
            // 
            // errorPass
            // 
            errorPass.ContainerControl = this;
            // 
            // errorConfirmPass
            // 
            errorConfirmPass.ContainerControl = this;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.ControlDarkDark;
            label6.Location = new Point(76, 302);
            label6.Name = "label6";
            label6.Size = new Size(278, 15);
            label6.TabIndex = 21;
            label6.Text = "Mật khẩu phải có ít nhất 6 ký tự bao gồm chữ và số";
            // 
            // timerHideMessage
            // 
            timerHideMessage.Tick += timerHideMessage_Tick;
            // 
            // lblSuccess
            // 
            lblSuccess.AutoSize = true;
            lblSuccess.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblSuccess.ForeColor = Color.Green;
            lblSuccess.Location = new Point(12, 84);
            lblSuccess.Name = "lblSuccess";
            lblSuccess.Size = new Size(45, 17);
            lblSuccess.TabIndex = 22;
            lblSuccess.Text = "label7";
            lblSuccess.Visible = false;
            // 
            // ResetPasswordPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            ClientSize = new Size(557, 475);
            Controls.Add(lblSuccess);
            Controls.Add(label6);
            Controls.Add(btnDangNhap);
            Controls.Add(btnXacNhan);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtNhapLaiMatKhauMoi);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(label1);
            Name = "ResetPasswordPanel";
            Text = "ResetPasswordPanel";
            Load += ResetPasswordPanel_Load;
            ((System.ComponentModel.ISupportInitialize)errorPass).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorConfirmPass).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel btnDangNhap;
        private Button btnXacNhan;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtNhapLaiMatKhauMoi;
        private TextBox txtMatKhauMoi;
        private Label label1;
        private ErrorProvider errorPass;
        private ErrorProvider errorConfirmPass;
        private Label label6;
        private Label lblSuccess;
        private System.Windows.Forms.Timer timerHideMessage;
    }
}