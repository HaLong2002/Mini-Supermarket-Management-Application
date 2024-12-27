namespace SieuThiMini.Panel
{
    partial class FogotPasswordPanel
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
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txttEmail = new TextBox();
            btnXacNhan = new Button();
            btnDangNhap = new LinkLabel();
            errorEmail = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorEmail).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 150);
            label3.Name = "label3";
            label3.Size = new Size(39, 17);
            label3.TabIndex = 15;
            label3.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(32, 108);
            label2.Name = "label2";
            label2.Size = new Size(451, 17);
            label2.TabIndex = 14;
            label2.Text = "Điền email gắn với tài khoản của bạn để nhận đường dẫn thay đổi mật khẩu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(24, 119, 242);
            label1.Location = new Point(118, 45);
            label1.Name = "label1";
            label1.Size = new Size(262, 45);
            label1.TabIndex = 13;
            label1.Text = "Quên Mật Khẩu ";
            // 
            // txttEmail
            // 
            txttEmail.Location = new Point(54, 179);
            txttEmail.Multiline = true;
            txttEmail.Name = "txttEmail";
            txttEmail.Size = new Size(400, 30);
            txttEmail.TabIndex = 17;
            // 
            // btnXacNhan
            // 
            btnXacNhan.BackColor = Color.FromArgb(24, 119, 242);
            btnXacNhan.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnXacNhan.ForeColor = SystemColors.ControlLightLight;
            btnXacNhan.Location = new Point(131, 244);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(226, 38);
            btnXacNhan.TabIndex = 18;
            btnXacNhan.Text = "Xác nhận";
            btnXacNhan.UseVisualStyleBackColor = false;
            btnXacNhan.Click += btnXacNhan_Click;
            btnXacNhan.MouseEnter += btnXacNhan_MouseEnter;
            btnXacNhan.MouseLeave += btnXacNhan_MouseLeave;
            // 
            // btnDangNhap
            // 
            btnDangNhap.AutoSize = true;
            btnDangNhap.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnDangNhap.Location = new Point(186, 294);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.RightToLeft = RightToLeft.No;
            btnDangNhap.Size = new Size(133, 17);
            btnDangNhap.TabIndex = 19;
            btnDangNhap.TabStop = true;
            btnDangNhap.Text = "Quay lại Đăng Nhập";
            btnDangNhap.LinkClicked += btnDangNhap_LinkClicked_1;
            btnDangNhap.MouseEnter += btnDangNhap_MouseEnter;
            btnDangNhap.MouseLeave += btnDangNhap_MouseLeave;
            // 
            // errorEmail
            // 
            errorEmail.ContainerControl = this;
            // 
            // FogotPasswordPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            ClientSize = new Size(515, 372);
            Controls.Add(btnDangNhap);
            Controls.Add(btnXacNhan);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txttEmail);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "FogotPasswordPanel";
            Text = "FogotPasswordPanel";
            Load += FogotPasswordPanel_Load;
            ((System.ComponentModel.ISupportInitialize)errorEmail).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txttEmail;
        private Button btnXacNhan;
        private LinkLabel btnDangNhap;
        private ErrorProvider errorEmail;
    }
}