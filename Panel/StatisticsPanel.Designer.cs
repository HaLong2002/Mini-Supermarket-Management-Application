namespace SieuThiMini.Panel
{
    partial class StatisticsPanel
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            tableLayoutPanel1 = new TableLayoutPanel();
            panelSanPhamBanChay = new System.Windows.Forms.Panel();
            cbbYear = new ComboBox();
            dataGridViewTop5SanPham = new DataGridView();
            SoThuTu = new DataGridViewTextBoxColumn();
            IDSanPham = new DataGridViewTextBoxColumn();
            TenSanPham = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            DoanhThu = new DataGridViewTextBoxColumn();
            labelTop5SanPham = new Label();
            panelDoanhThu = new System.Windows.Forms.Panel();
            chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panelKhachHangThanThiet = new System.Windows.Forms.Panel();
            chartKhachHangThanThiet = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panelSanPhamSapHetHan = new System.Windows.Forms.Panel();
            chartSanPhamSapHetHan = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tableLayoutPanel1.SuspendLayout();
            panelSanPhamBanChay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTop5SanPham).BeginInit();
            panelDoanhThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartDoanhThu).BeginInit();
            panelKhachHangThanThiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartKhachHangThanThiet).BeginInit();
            panelSanPhamSapHetHan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartSanPhamSapHetHan).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panelSanPhamBanChay, 0, 0);
            tableLayoutPanel1.Controls.Add(panelDoanhThu, 1, 0);
            tableLayoutPanel1.Controls.Add(panelKhachHangThanThiet, 0, 1);
            tableLayoutPanel1.Controls.Add(panelSanPhamSapHetHan, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(5);
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1359, 599);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panelSanPhamBanChay
            // 
            panelSanPhamBanChay.Controls.Add(cbbYear);
            panelSanPhamBanChay.Controls.Add(dataGridViewTop5SanPham);
            panelSanPhamBanChay.Controls.Add(labelTop5SanPham);
            panelSanPhamBanChay.Dock = DockStyle.Fill;
            panelSanPhamBanChay.Location = new Point(9, 9);
            panelSanPhamBanChay.Name = "panelSanPhamBanChay";
            panelSanPhamBanChay.Size = new Size(667, 287);
            panelSanPhamBanChay.TabIndex = 1;
            // 
            // cbbYear
            // 
            cbbYear.FormattingEnabled = true;
            cbbYear.Location = new Point(0, 0);
            cbbYear.Margin = new Padding(3, 4, 3, 4);
            cbbYear.Name = "cbbYear";
            cbbYear.Size = new Size(98, 28);
            cbbYear.TabIndex = 1;
            cbbYear.SelectedIndexChanged += cbbYear_SelectedIndexChanged;
            // 
            // dataGridViewTop5SanPham
            // 
            dataGridViewTop5SanPham.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewTop5SanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewTop5SanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTop5SanPham.Columns.AddRange(new DataGridViewColumn[] { SoThuTu, IDSanPham, TenSanPham, SoLuong, DoanhThu });
            dataGridViewTop5SanPham.Dock = DockStyle.Fill;
            dataGridViewTop5SanPham.Location = new Point(0, 36);
            dataGridViewTop5SanPham.Name = "dataGridViewTop5SanPham";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewTop5SanPham.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewTop5SanPham.RowHeadersWidth = 51;
            dataGridViewTop5SanPham.RowTemplate.Height = 29;
            dataGridViewTop5SanPham.Size = new Size(667, 251);
            dataGridViewTop5SanPham.TabIndex = 1;
            // 
            // SoThuTu
            // 
            SoThuTu.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            SoThuTu.HeaderText = "STT";
            SoThuTu.MinimumWidth = 6;
            SoThuTu.Name = "SoThuTu";
            SoThuTu.ReadOnly = true;
            SoThuTu.Width = 66;
            // 
            // IDSanPham
            // 
            IDSanPham.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            IDSanPham.HeaderText = "ID Sản phẩm";
            IDSanPham.MinimumWidth = 6;
            IDSanPham.Name = "IDSanPham";
            IDSanPham.ReadOnly = true;
            IDSanPham.Width = 127;
            // 
            // TenSanPham
            // 
            TenSanPham.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TenSanPham.HeaderText = "Tên Sản Phẩm";
            TenSanPham.MinimumWidth = 6;
            TenSanPham.Name = "TenSanPham";
            TenSanPham.ReadOnly = true;
            // 
            // SoLuong
            // 
            SoLuong.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            SoLuong.HeaderText = "Số Lượng";
            SoLuong.MinimumWidth = 6;
            SoLuong.Name = "SoLuong";
            SoLuong.ReadOnly = true;
            SoLuong.Width = 102;
            // 
            // DoanhThu
            // 
            DoanhThu.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DoanhThu.HeaderText = "Doanh Thu";
            DoanhThu.MinimumWidth = 6;
            DoanhThu.Name = "DoanhThu";
            DoanhThu.ReadOnly = true;
            DoanhThu.Width = 114;
            // 
            // labelTop5SanPham
            // 
            labelTop5SanPham.BackColor = Color.White;
            labelTop5SanPham.Dock = DockStyle.Top;
            labelTop5SanPham.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelTop5SanPham.Location = new Point(0, 0);
            labelTop5SanPham.Name = "labelTop5SanPham";
            labelTop5SanPham.Size = new Size(667, 36);
            labelTop5SanPham.TabIndex = 0;
            labelTop5SanPham.Text = "TOP 5 SẢN PHẨM BÁN CHẠY NHẤT";
            labelTop5SanPham.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelDoanhThu
            // 
            panelDoanhThu.Controls.Add(chartDoanhThu);
            panelDoanhThu.Dock = DockStyle.Fill;
            panelDoanhThu.Location = new Point(683, 9);
            panelDoanhThu.Name = "panelDoanhThu";
            panelDoanhThu.Size = new Size(667, 287);
            panelDoanhThu.TabIndex = 3;
            // 
            // chartDoanhThu
            // 
            chartDoanhThu.BorderlineColor = Color.Transparent;
            chartArea1.Name = "ChartArea1";
            chartDoanhThu.ChartAreas.Add(chartArea1);
            chartDoanhThu.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            chartDoanhThu.Legends.Add(legend1);
            chartDoanhThu.Location = new Point(0, 0);
            chartDoanhThu.Name = "chartDoanhThu";
            series1.ChartArea = "ChartArea1";
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Doanh Thu";
            chartDoanhThu.Series.Add(series1);
            chartDoanhThu.Size = new Size(667, 287);
            chartDoanhThu.TabIndex = 0;
            // 
            // panelKhachHangThanThiet
            // 
            panelKhachHangThanThiet.Controls.Add(chartKhachHangThanThiet);
            panelKhachHangThanThiet.Dock = DockStyle.Fill;
            panelKhachHangThanThiet.Location = new Point(9, 303);
            panelKhachHangThanThiet.Name = "panelKhachHangThanThiet";
            panelKhachHangThanThiet.Size = new Size(667, 287);
            panelKhachHangThanThiet.TabIndex = 4;
            // 
            // chartKhachHangThanThiet
            // 
            chartArea2.Name = "ChartArea1";
            chartKhachHangThanThiet.ChartAreas.Add(chartArea2);
            chartKhachHangThanThiet.Dock = DockStyle.Fill;
            legend2.Name = "Legend1";
            chartKhachHangThanThiet.Legends.Add(legend2);
            chartKhachHangThanThiet.Location = new Point(0, 0);
            chartKhachHangThanThiet.Name = "chartKhachHangThanThiet";
            chartKhachHangThanThiet.Size = new Size(667, 287);
            chartKhachHangThanThiet.TabIndex = 2;
            chartKhachHangThanThiet.Text = "chart1";
            title1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            title1.Name = "TitleTop5KhachHangThanThiet";
            title1.Text = "TOP 5 KHÁCH HÀNG THÂN THIẾT";
            chartKhachHangThanThiet.Titles.Add(title1);
            // 
            // panelSanPhamSapHetHan
            // 
            panelSanPhamSapHetHan.Controls.Add(chartSanPhamSapHetHan);
            panelSanPhamSapHetHan.Dock = DockStyle.Fill;
            panelSanPhamSapHetHan.Location = new Point(683, 303);
            panelSanPhamSapHetHan.Name = "panelSanPhamSapHetHan";
            panelSanPhamSapHetHan.Size = new Size(667, 287);
            panelSanPhamSapHetHan.TabIndex = 5;
            // 
            // chartSanPhamSapHetHan
            // 
            chartArea3.AxisX.TitleFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chartArea3.AxisX2.TitleFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chartArea3.AxisY.TitleFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chartArea3.AxisY2.TitleFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chartArea3.Name = "ChartArea1";
            chartSanPhamSapHetHan.ChartAreas.Add(chartArea3);
            chartSanPhamSapHetHan.Dock = DockStyle.Fill;
            legend3.Name = "Legend1";
            chartSanPhamSapHetHan.Legends.Add(legend3);
            chartSanPhamSapHetHan.Location = new Point(0, 0);
            chartSanPhamSapHetHan.Name = "chartSanPhamSapHetHan";
            chartSanPhamSapHetHan.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series2.ChartArea = "ChartArea1";
            series2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            series2.Legend = "Legend1";
            series2.MarkerSize = 2;
            series2.Name = "Số ngày còn lại trước khi hết hạn";
            series2.ShadowColor = Color.Transparent;
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            chartSanPhamSapHetHan.Series.Add(series2);
            chartSanPhamSapHetHan.Size = new Size(667, 287);
            chartSanPhamSapHetHan.TabIndex = 3;
            chartSanPhamSapHetHan.Text = "chart1";
            title2.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            title2.Name = "TitleSanPhamSapHetHan";
            title2.Text = "CÁC SẢN PHẨM SẮP HẾT HẠN";
            chartSanPhamSapHetHan.Titles.Add(title2);
            // 
            // StatisticsPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1359, 599);
            Controls.Add(tableLayoutPanel1);
            Name = "StatisticsPanel";
            Text = " ";
            Load += StatisticsPanel_Load;
            tableLayoutPanel1.ResumeLayout(false);
            panelSanPhamBanChay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewTop5SanPham).EndInit();
            panelDoanhThu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartDoanhThu).EndInit();
            panelKhachHangThanThiet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartKhachHangThanThiet).EndInit();
            panelSanPhamSapHetHan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartSanPhamSapHetHan).EndInit();
            ResumeLayout(false);
        }




        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.Panel panelSanPhamBanChay;
        private Label labelTop5SanPham;
        private DataGridViewTextBoxColumn SoThuTu;
        private DataGridViewTextBoxColumn IDSanPham;
        private DataGridViewTextBoxColumn TenSanPham;
        private DataGridViewTextBoxColumn SoLuong;
        private DataGridViewTextBoxColumn DoanhThu;
        private System.Windows.Forms.Panel panelDoanhThu;
        private DataGridView dataGridViewTop5SanPham;
        private System.Windows.Forms.Panel panelKhachHangThanThiet;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartKhachHangThanThiet;
        private System.Windows.Forms.Panel panelSanPhamSapHetHan;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSanPhamSapHetHan;
        private ComboBox cbbYear;
    }
}