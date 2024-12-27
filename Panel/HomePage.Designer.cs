namespace SieuThiMini.Panel
{
    partial class HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            panel_ChucNang = new System.Windows.Forms.Panel();
            tableLayoutPanel_ChucNang = new TableLayoutPanel();
            btnBanHang = new Button();
            imageList_icon = new ImageList(components);
            btnKhuyenMai = new Button();
            btnKhachHang = new Button();
            btnTaiKhoan = new Button();
            btnSanPham = new Button();
            btnNhaCungCap = new Button();
            btnHoaDon = new Button();
            btnNhanVien = new Button();
            btnDangXuat = new Button();
            btnThongKe = new Button();
            pictureBox_LogoStore = new PictureBox();
            panelContainer = new System.Windows.Forms.Panel();
            VideoIntroduction = new AxWMPLib.AxWindowsMediaPlayer();
            panel_ChucNang.SuspendLayout();
            tableLayoutPanel_ChucNang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_LogoStore).BeginInit();
            panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)VideoIntroduction).BeginInit();
            SuspendLayout();
            // 
            // panel_ChucNang
            // 
            panel_ChucNang.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_ChucNang.BackColor = Color.FromArgb(123, 196, 77);
            panel_ChucNang.Controls.Add(tableLayoutPanel_ChucNang);
            panel_ChucNang.Controls.Add(pictureBox_LogoStore);
            panel_ChucNang.Dock = DockStyle.Left;
            panel_ChucNang.Location = new Point(0, 0);
            panel_ChucNang.Margin = new Padding(3, 0, 3, 2);
            panel_ChucNang.Name = "panel_ChucNang";
            panel_ChucNang.Size = new Size(203, 698);
            panel_ChucNang.TabIndex = 0;
            // 
            // tableLayoutPanel_ChucNang
            // 
            tableLayoutPanel_ChucNang.AutoSize = true;
            tableLayoutPanel_ChucNang.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel_ChucNang.BackColor = Color.FromArgb(132, 207, 85);
            tableLayoutPanel_ChucNang.ColumnCount = 1;
            tableLayoutPanel_ChucNang.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_ChucNang.Controls.Add(btnBanHang, 0, 5);
            tableLayoutPanel_ChucNang.Controls.Add(btnKhuyenMai, 1, 5);
            tableLayoutPanel_ChucNang.Controls.Add(btnKhachHang, 1, 4);
            tableLayoutPanel_ChucNang.Controls.Add(btnTaiKhoan, 1, 0);
            tableLayoutPanel_ChucNang.Controls.Add(btnSanPham, 1, 2);
            tableLayoutPanel_ChucNang.Controls.Add(btnNhaCungCap, 1, 1);
            tableLayoutPanel_ChucNang.Controls.Add(btnHoaDon, 1, 3);
            tableLayoutPanel_ChucNang.Controls.Add(btnNhanVien, 1, 6);
            tableLayoutPanel_ChucNang.Controls.Add(btnDangXuat, 0, 8);
            tableLayoutPanel_ChucNang.Controls.Add(btnThongKe, 0, 7);
            tableLayoutPanel_ChucNang.Dock = DockStyle.Top;
            tableLayoutPanel_ChucNang.Location = new Point(0, 137);
            tableLayoutPanel_ChucNang.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel_ChucNang.Name = "tableLayoutPanel_ChucNang";
            tableLayoutPanel_ChucNang.RowCount = 10;
            tableLayoutPanel_ChucNang.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tableLayoutPanel_ChucNang.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tableLayoutPanel_ChucNang.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tableLayoutPanel_ChucNang.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tableLayoutPanel_ChucNang.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tableLayoutPanel_ChucNang.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tableLayoutPanel_ChucNang.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tableLayoutPanel_ChucNang.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tableLayoutPanel_ChucNang.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tableLayoutPanel_ChucNang.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tableLayoutPanel_ChucNang.Size = new Size(203, 560);
            tableLayoutPanel_ChucNang.TabIndex = 1;
            // 
            // btnBanHang
            // 
            btnBanHang.AutoSize = true;
            btnBanHang.BackColor = Color.FromArgb(123, 196, 77);
            btnBanHang.Cursor = Cursors.Hand;
            btnBanHang.Dock = DockStyle.Fill;
            btnBanHang.FlatAppearance.BorderSize = 2;
            btnBanHang.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 127, 14);
            btnBanHang.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 127, 14);
            btnBanHang.FlatStyle = FlatStyle.Flat;
            btnBanHang.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnBanHang.ForeColor = Color.White;
            btnBanHang.ImageAlign = ContentAlignment.MiddleLeft;
            btnBanHang.ImageIndex = 10;
            btnBanHang.ImageList = imageList_icon;
            btnBanHang.Location = new Point(4, 283);
            btnBanHang.Margin = new Padding(4, 3, 4, 3);
            btnBanHang.Name = "btnBanHang";
            btnBanHang.Size = new Size(195, 50);
            btnBanHang.TabIndex = 3;
            btnBanHang.Text = "BÁN HÀNG";
            btnBanHang.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBanHang.UseVisualStyleBackColor = false;
            btnBanHang.MouseClick += Button_MouseClick;
            // 
            // imageList_icon
            // 
            imageList_icon.ColorDepth = ColorDepth.Depth32Bit;
            imageList_icon.ImageStream = (ImageListStreamer)resources.GetObject("imageList_icon.ImageStream");
            imageList_icon.TransparentColor = Color.White;
            imageList_icon.Images.SetKeyName(0, "analysis.png");
            imageList_icon.Images.SetKeyName(1, "customer.png");
            imageList_icon.Images.SetKeyName(2, "product.png");
            imageList_icon.Images.SetKeyName(3, "promotion.png");
            imageList_icon.Images.SetKeyName(4, "shop_store_icon.ico");
            imageList_icon.Images.SetKeyName(5, "staff.png");
            imageList_icon.Images.SetKeyName(6, "supplier.png");
            imageList_icon.Images.SetKeyName(7, "logout.png");
            imageList_icon.Images.SetKeyName(8, "user.png");
            imageList_icon.Images.SetKeyName(9, "invoice.png");
            imageList_icon.Images.SetKeyName(10, "sell.png");
            // 
            // btnKhuyenMai
            // 
            btnKhuyenMai.AutoSize = true;
            btnKhuyenMai.BackColor = Color.FromArgb(123, 196, 77);
            btnKhuyenMai.Cursor = Cursors.Hand;
            btnKhuyenMai.Dock = DockStyle.Fill;
            btnKhuyenMai.FlatAppearance.BorderSize = 2;
            btnKhuyenMai.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 127, 14);
            btnKhuyenMai.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 127, 14);
            btnKhuyenMai.FlatStyle = FlatStyle.Flat;
            btnKhuyenMai.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnKhuyenMai.ForeColor = Color.White;
            btnKhuyenMai.ImageAlign = ContentAlignment.MiddleLeft;
            btnKhuyenMai.ImageIndex = 3;
            btnKhuyenMai.ImageList = imageList_icon;
            btnKhuyenMai.Location = new Point(4, 339);
            btnKhuyenMai.Margin = new Padding(4, 3, 4, 3);
            btnKhuyenMai.Name = "btnKhuyenMai";
            btnKhuyenMai.Size = new Size(195, 50);
            btnKhuyenMai.TabIndex = 1;
            btnKhuyenMai.Text = "KHUYẾN MÃI";
            btnKhuyenMai.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnKhuyenMai.UseVisualStyleBackColor = false;
            btnKhuyenMai.MouseClick += Button_MouseClick;
            // 
            // btnKhachHang
            // 
            btnKhachHang.AutoSize = true;
            btnKhachHang.BackColor = Color.FromArgb(123, 196, 77);
            btnKhachHang.Cursor = Cursors.Hand;
            btnKhachHang.Dock = DockStyle.Fill;
            btnKhachHang.FlatAppearance.BorderSize = 2;
            btnKhachHang.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 127, 14);
            btnKhachHang.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 127, 14);
            btnKhachHang.FlatStyle = FlatStyle.Flat;
            btnKhachHang.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnKhachHang.ForeColor = Color.White;
            btnKhachHang.ImageAlign = ContentAlignment.MiddleLeft;
            btnKhachHang.ImageIndex = 1;
            btnKhachHang.ImageList = imageList_icon;
            btnKhachHang.Location = new Point(4, 227);
            btnKhachHang.Margin = new Padding(4, 3, 4, 3);
            btnKhachHang.Name = "btnKhachHang";
            btnKhachHang.Size = new Size(195, 50);
            btnKhachHang.TabIndex = 1;
            btnKhachHang.Text = "KHÁCH HÀNG";
            btnKhachHang.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnKhachHang.UseVisualStyleBackColor = false;
            btnKhachHang.MouseClick += Button_MouseClick;
            // 
            // btnTaiKhoan
            // 
            btnTaiKhoan.BackColor = Color.FromArgb(123, 196, 77);
            btnTaiKhoan.BackgroundImageLayout = ImageLayout.Zoom;
            btnTaiKhoan.Cursor = Cursors.Hand;
            btnTaiKhoan.Dock = DockStyle.Fill;
            btnTaiKhoan.FlatAppearance.BorderSize = 0;
            btnTaiKhoan.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 127, 14);
            btnTaiKhoan.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 127, 14);
            btnTaiKhoan.FlatStyle = FlatStyle.Flat;
            btnTaiKhoan.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnTaiKhoan.ForeColor = Color.White;
            btnTaiKhoan.ImageAlign = ContentAlignment.MiddleLeft;
            btnTaiKhoan.ImageIndex = 8;
            btnTaiKhoan.ImageList = imageList_icon;
            btnTaiKhoan.Location = new Point(3, 2);
            btnTaiKhoan.Margin = new Padding(3, 2, 3, 2);
            btnTaiKhoan.Name = "btnTaiKhoan";
            btnTaiKhoan.Size = new Size(197, 52);
            btnTaiKhoan.TabIndex = 2;
            btnTaiKhoan.Text = "Tên Tài Khoản";
            btnTaiKhoan.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTaiKhoan.UseVisualStyleBackColor = false;
            btnTaiKhoan.MouseClick += Button_MouseClick;
            // 
            // btnSanPham
            // 
            btnSanPham.AutoSize = true;
            btnSanPham.BackColor = Color.FromArgb(123, 196, 77);
            btnSanPham.Cursor = Cursors.Hand;
            btnSanPham.Dock = DockStyle.Fill;
            btnSanPham.FlatAppearance.BorderSize = 2;
            btnSanPham.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 127, 14);
            btnSanPham.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 127, 14);
            btnSanPham.FlatStyle = FlatStyle.Flat;
            btnSanPham.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnSanPham.ForeColor = Color.White;
            btnSanPham.ImageAlign = ContentAlignment.MiddleLeft;
            btnSanPham.ImageIndex = 2;
            btnSanPham.ImageList = imageList_icon;
            btnSanPham.Location = new Point(4, 115);
            btnSanPham.Margin = new Padding(4, 3, 4, 3);
            btnSanPham.Name = "btnSanPham";
            btnSanPham.Size = new Size(195, 50);
            btnSanPham.TabIndex = 1;
            btnSanPham.Text = "SẢN PHẨM";
            btnSanPham.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSanPham.UseVisualStyleBackColor = false;
            btnSanPham.MouseClick += Button_MouseClick;
            // 
            // btnNhaCungCap
            // 
            btnNhaCungCap.BackColor = Color.FromArgb(123, 196, 77);
            btnNhaCungCap.BackgroundImageLayout = ImageLayout.None;
            btnNhaCungCap.Cursor = Cursors.Hand;
            btnNhaCungCap.Dock = DockStyle.Fill;
            btnNhaCungCap.FlatAppearance.BorderSize = 2;
            btnNhaCungCap.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 127, 14);
            btnNhaCungCap.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 127, 14);
            btnNhaCungCap.FlatStyle = FlatStyle.Flat;
            btnNhaCungCap.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnNhaCungCap.ForeColor = Color.White;
            btnNhaCungCap.ImageAlign = ContentAlignment.MiddleLeft;
            btnNhaCungCap.ImageIndex = 6;
            btnNhaCungCap.ImageList = imageList_icon;
            btnNhaCungCap.Location = new Point(4, 59);
            btnNhaCungCap.Margin = new Padding(4, 3, 4, 3);
            btnNhaCungCap.Name = "btnNhaCungCap";
            btnNhaCungCap.Size = new Size(195, 50);
            btnNhaCungCap.TabIndex = 1;
            btnNhaCungCap.Text = "NHÀ CUNG CẤP";
            btnNhaCungCap.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNhaCungCap.UseVisualStyleBackColor = false;
            btnNhaCungCap.MouseClick += Button_MouseClick;
            // 
            // btnHoaDon
            // 
            btnHoaDon.AutoSize = true;
            btnHoaDon.BackColor = Color.FromArgb(123, 196, 77);
            btnHoaDon.Cursor = Cursors.Hand;
            btnHoaDon.Dock = DockStyle.Fill;
            btnHoaDon.FlatAppearance.BorderSize = 2;
            btnHoaDon.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 127, 14);
            btnHoaDon.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 127, 14);
            btnHoaDon.FlatStyle = FlatStyle.Flat;
            btnHoaDon.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnHoaDon.ForeColor = Color.White;
            btnHoaDon.ImageAlign = ContentAlignment.MiddleLeft;
            btnHoaDon.ImageIndex = 9;
            btnHoaDon.ImageList = imageList_icon;
            btnHoaDon.Location = new Point(4, 171);
            btnHoaDon.Margin = new Padding(4, 3, 4, 3);
            btnHoaDon.Name = "btnHoaDon";
            btnHoaDon.Size = new Size(195, 50);
            btnHoaDon.TabIndex = 1;
            btnHoaDon.Text = "HÓA ĐƠN";
            btnHoaDon.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHoaDon.UseVisualStyleBackColor = false;
            btnHoaDon.MouseClick += Button_MouseClick;
            // 
            // btnNhanVien
            // 
            btnNhanVien.AutoSize = true;
            btnNhanVien.BackColor = Color.FromArgb(123, 196, 77);
            btnNhanVien.Cursor = Cursors.Hand;
            btnNhanVien.Dock = DockStyle.Fill;
            btnNhanVien.FlatAppearance.BorderSize = 2;
            btnNhanVien.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 127, 14);
            btnNhanVien.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 127, 14);
            btnNhanVien.FlatStyle = FlatStyle.Flat;
            btnNhanVien.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnNhanVien.ForeColor = Color.White;
            btnNhanVien.ImageAlign = ContentAlignment.MiddleLeft;
            btnNhanVien.ImageIndex = 5;
            btnNhanVien.ImageList = imageList_icon;
            btnNhanVien.Location = new Point(4, 395);
            btnNhanVien.Margin = new Padding(4, 3, 4, 3);
            btnNhanVien.Name = "btnNhanVien";
            btnNhanVien.Size = new Size(195, 50);
            btnNhanVien.TabIndex = 1;
            btnNhanVien.Text = "NHÂN VIÊN";
            btnNhanVien.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNhanVien.UseVisualStyleBackColor = false;
            btnNhanVien.MouseClick += Button_MouseClick;
            // 
            // btnDangXuat
            // 
            btnDangXuat.AutoSize = true;
            btnDangXuat.BackColor = Color.FromArgb(123, 196, 77);
            btnDangXuat.Cursor = Cursors.Hand;
            btnDangXuat.Dock = DockStyle.Fill;
            btnDangXuat.FlatAppearance.BorderSize = 2;
            btnDangXuat.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 127, 14);
            btnDangXuat.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 127, 14);
            btnDangXuat.FlatStyle = FlatStyle.Flat;
            btnDangXuat.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnDangXuat.ForeColor = Color.White;
            btnDangXuat.ImageAlign = ContentAlignment.MiddleLeft;
            btnDangXuat.ImageIndex = 7;
            btnDangXuat.ImageList = imageList_icon;
            btnDangXuat.Location = new Point(4, 507);
            btnDangXuat.Margin = new Padding(4, 3, 4, 3);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(195, 50);
            btnDangXuat.TabIndex = 2;
            btnDangXuat.Text = "ĐĂNG XUẤT";
            btnDangXuat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDangXuat.UseVisualStyleBackColor = false;
            btnDangXuat.MouseClick += Button_MouseClick;
            // 
            // btnThongKe
            // 
            btnThongKe.AutoSize = true;
            btnThongKe.BackColor = Color.FromArgb(123, 196, 77);
            btnThongKe.Cursor = Cursors.Hand;
            btnThongKe.Dock = DockStyle.Fill;
            btnThongKe.FlatAppearance.BorderSize = 2;
            btnThongKe.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 127, 14);
            btnThongKe.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 127, 14);
            btnThongKe.FlatStyle = FlatStyle.Flat;
            btnThongKe.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnThongKe.ForeColor = Color.White;
            btnThongKe.ImageAlign = ContentAlignment.MiddleLeft;
            btnThongKe.ImageIndex = 0;
            btnThongKe.ImageList = imageList_icon;
            btnThongKe.Location = new Point(4, 451);
            btnThongKe.Margin = new Padding(4, 3, 4, 3);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(195, 50);
            btnThongKe.TabIndex = 2;
            btnThongKe.Text = "THỐNG KÊ";
            btnThongKe.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThongKe.UseVisualStyleBackColor = false;
            btnThongKe.MouseClick += Button_MouseClick;
            // 
            // pictureBox_LogoStore
            // 
            pictureBox_LogoStore.BackColor = Color.FromArgb(123, 196, 77);
            pictureBox_LogoStore.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox_LogoStore.Dock = DockStyle.Top;
            pictureBox_LogoStore.Image = Properties.Resources.logo_mini_store;
            pictureBox_LogoStore.Location = new Point(0, 0);
            pictureBox_LogoStore.Margin = new Padding(3, 2, 3, 0);
            pictureBox_LogoStore.Name = "pictureBox_LogoStore";
            pictureBox_LogoStore.Size = new Size(203, 137);
            pictureBox_LogoStore.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_LogoStore.TabIndex = 0;
            pictureBox_LogoStore.TabStop = false;
            pictureBox_LogoStore.Click += pictureBox_LogoStore_Click;
            // 
            // panelContainer
            // 
            panelContainer.AutoSize = true;
            panelContainer.Controls.Add(VideoIntroduction);
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.ForeColor = SystemColors.ControlText;
            panelContainer.Location = new Point(203, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(920, 698);
            panelContainer.TabIndex = 1;
            // 
            // VideoIntroduction
            // 
            VideoIntroduction.Dock = DockStyle.Fill;
            VideoIntroduction.Enabled = true;
            VideoIntroduction.Location = new Point(0, 0);
            VideoIntroduction.Margin = new Padding(3, 2, 3, 2);
            VideoIntroduction.Name = "VideoIntroduction";
            VideoIntroduction.OcxState = (AxHost.State)resources.GetObject("VideoIntroduction.OcxState");
            VideoIntroduction.Size = new Size(920, 698);
            VideoIntroduction.TabIndex = 0;
            VideoIntroduction.PlayStateChange += VideoIntroduce_PlayStateChange;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1123, 698);
            Controls.Add(panelContainer);
            Controls.Add(panel_ChucNang);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "HomePage";
            Text = "Siêu Thị Mini";
            Load += HomePage_Load;
            panel_ChucNang.ResumeLayout(false);
            panel_ChucNang.PerformLayout();
            tableLayoutPanel_ChucNang.ResumeLayout(false);
            tableLayoutPanel_ChucNang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_LogoStore).EndInit();
            panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)VideoIntroduction).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel_ChucNang;
        private Button btnNhaCungCap;
        private Button btnSanPham;
        private Button btnNhanVien;
        private Button btnKhachHang;
        private Button btnHoaDon;
        private Button btnKhuyenMai;
        private PictureBox pictureBox_LogoStore;
        private TableLayoutPanel tableLayoutPanel_ChucNang;
        private Button btnTaiKhoan;
        private Button btnDangXuat;
        private ImageList imageList_icon;
        private Button btnThongKe;
        private System.Windows.Forms.Panel panelContainer;
        private AxWMPLib.AxWindowsMediaPlayer VideoIntroduction;
        private Button btnBanHang;
    }
}