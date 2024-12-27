namespace SieuThiMini.Panel
{
    partial class LoginPanel
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
            btnQuenMatKhau = new LinkLabel();
            btnDangNhap = new Button();
            txtMatKhau = new TextBox();
            textBox1 = new TextBox();
            txtEmail = new TextBox();
            titleDangNhap = new Label();
            pictureBox_LogoStore = new PictureBox();
            errorEmail = new ErrorProvider(components);
            errorPass = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox_LogoStore).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorEmail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorPass).BeginInit();
            SuspendLayout();
            // 
            // btnQuenMatKhau
            // 
            btnQuenMatKhau.AutoSize = true;
            btnQuenMatKhau.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnQuenMatKhau.Location = new Point(183, 401);
            btnQuenMatKhau.Name = "btnQuenMatKhau";
            btnQuenMatKhau.RightToLeft = RightToLeft.No;
            btnQuenMatKhau.Size = new Size(113, 17);
            btnQuenMatKhau.TabIndex = 14;
            btnQuenMatKhau.TabStop = true;
            btnQuenMatKhau.Text = "Quên mật khẩu ?";
            btnQuenMatKhau.LinkClicked += btnQuenMatKhau_LinkClicked;
            btnQuenMatKhau.MouseEnter += btnQuenMatKhau_MouseEnter;
            btnQuenMatKhau.MouseLeave += btnQuenMatKhau_MouseLeave;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.FromArgb(24, 119, 242);
            btnDangNhap.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDangNhap.ForeColor = SystemColors.ControlLightLight;
            btnDangNhap.Location = new Point(132, 346);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(226, 38);
            btnDangNhap.TabIndex = 13;
            btnDangNhap.Text = "Đăng Nhập";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            btnDangNhap.MouseEnter += btnDangNhap_MouseEnter;
            btnDangNhap.MouseLeave += btnDangNhap_MouseLeave;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtMatKhau.Location = new Point(47, 278);
            txtMatKhau.Multiline = true;
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.PlaceholderText = "Mật khẩu";
            txtMatKhau.Size = new Size(400, 35);
            txtMatKhau.TabIndex = 12;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(19, 208);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(0, 0);
            textBox1.TabIndex = 11;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(47, 208);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(400, 35);
            txtEmail.TabIndex = 10;
            txtEmail.TabStop = false;
            // 
            // titleDangNhap
            // 
            titleDangNhap.AutoSize = true;
            titleDangNhap.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            titleDangNhap.ForeColor = Color.FromArgb(24, 119, 242);
            titleDangNhap.Location = new Point(157, 126);
            titleDangNhap.Name = "titleDangNhap";
            titleDangNhap.Size = new Size(190, 45);
            titleDangNhap.TabIndex = 9;
            titleDangNhap.Text = "Đăng Nhập";
            // 
            // pictureBox_LogoStore
            // 
            pictureBox_LogoStore.BackColor = Color.FromArgb(24, 119, 242);
            pictureBox_LogoStore.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox_LogoStore.Dock = DockStyle.Top;
            pictureBox_LogoStore.Image = Properties.Resources.logo_mini_store;
            pictureBox_LogoStore.Location = new Point(0, 0);
            pictureBox_LogoStore.Margin = new Padding(3, 2, 3, 0);
            pictureBox_LogoStore.Name = "pictureBox_LogoStore";
            pictureBox_LogoStore.Size = new Size(501, 126);
            pictureBox_LogoStore.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_LogoStore.TabIndex = 17;
            pictureBox_LogoStore.TabStop = false;
            // 
            // errorEmail
            // 
            errorEmail.ContainerControl = this;
            // 
            // errorPass
            // 
            errorPass.ContainerControl = this;
            // 
            // LoginPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            ClientSize = new Size(501, 564);
            Controls.Add(pictureBox_LogoStore);
            Controls.Add(btnQuenMatKhau);
            Controls.Add(btnDangNhap);
            Controls.Add(txtMatKhau);
            Controls.Add(textBox1);
            Controls.Add(txtEmail);
            Controls.Add(titleDangNhap);
            Name = "LoginPanel";
            Text = "LoginPanel";
            Load += LoginPanel_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox_LogoStore).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorEmail).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorPass).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private LinkLabel btnQuenMatKhau;
        private Button btnDangNhap;
        private TextBox txtMatKhau;
        private TextBox textBox1;
        private TextBox txtEmail;
        private Label titleDangNhap;
        private PictureBox pictureBox_LogoStore;
        private ErrorProvider errorEmail;
        private ErrorProvider errorPass;
    }
}