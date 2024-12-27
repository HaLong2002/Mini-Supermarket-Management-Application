using SieuThiMini.BUS;
using SieuThiMini.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SieuThiMini.Panel
{
    public partial class StatisticsPanel : Form
    {
        private InvoiceBUS invoiceBUS = new InvoiceBUS();
        private InvoiceDetailBUS invoicedetailBUS = new InvoiceDetailBUS();
        private List<TopProductDTO> topSellingProducts = new List<TopProductDTO>();
        private List<TopLoyalCustomers> topLoyalCustomers = new List<TopLoyalCustomers>();

        private ProductBUS productBUS = new ProductBUS();
        private List<ProductDTO> productsNearExpiration = new List<ProductDTO>();


        public StatisticsPanel()
        {
            InitializeComponent();
        }

        private void StatisticsPanel_Load(object sender, EventArgs e)
        {
            LoadYears();

            // Load biểu đồ các sản phẩm sắp hết hạn
            LoadExpirationChart();

            LoadTopSellingProducts(DateTime.Now.Year); // Tải dữ liệu sản phẩm bán chạy nhất
            LoadMonthlyRevenue(DateTime.Now.Year); // Tải doanh thu theo tháng cho năm hiện tại

            // Load top 5 khách hàng thân thiết
            LoadTop5LoyalCustomers();
        }

        private void LoadExpirationChart()
        {
            try
            {
                // Get products near expiration from database
                productsNearExpiration = productBUS.GetProductsNearExpiration();
                DateTime today = DateTime.Today;

                // Get the series and clear existing points
                var series = chartSanPhamSapHetHan.Series["Số ngày còn lại trước khi hết hạn"];
                series.Points.Clear();

                // Set chart type to Column
                series.ChartType = SeriesChartType.Column;

                // Configure series
                series.IsXValueIndexed = true;
                series["DrawSideBySide"] = "true";

                // Configure labels to appear above columns
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "{0}";  // Format for all points
                //series.LabelFormat = "{0} ngày";
                series.Font = new Font("Arial", 9f, FontStyle.Regular);
                series["LabelStyle"] = "Top";  // Position labels above bars

                // Configure chart area
                ChartArea chartArea = chartSanPhamSapHetHan.ChartAreas["ChartArea1"];

                // Configure Y-axis
                chartArea.AxisY.Maximum = Double.NaN; // Auto-scale
                chartArea.AxisY.Minimum = 0;
                chartArea.AxisY.Interval = 5;
                chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;

                // Configure X-axis
                chartArea.AxisX.Interval = 1;
                chartArea.AxisX.IsReversed = false;
                chartArea.AxisX.LabelStyle.Font = new Font("Arial", 9f);
                chartArea.AxisX.MajorGrid.Enabled = false;  // Remove vertical grid lines

                // Set column width and add spacing between columns
                series["PointWidth"] = "0.8"; // Width of each column (0 to 1)

                // Add data points
                foreach (var product in productsNearExpiration)
                {
                    TimeSpan difference = product.ExpirationDate - today;
                    int days = difference.Days;
                    string label = $"{product.ProductId} - {product.ProductName}";

                    // Add the point directly with label and value
                    series.Points.AddXY(label, days);

                    // Get the last added point to customize it
                    DataPoint lastPoint = series.Points[series.Points.Count - 1];
                    lastPoint.Color = days <= 7 ? Color.Red : Color.CornflowerBlue;
                }

                // Set axis titles
                chartArea.AxisX.Title = "Tên sản phẩm";
                chartArea.AxisX.TitleFont = new Font("Arial", 10f, FontStyle.Bold);
                chartArea.AxisY.Title = "Số ngày còn lại";
                chartArea.AxisY.TitleFont = new Font("Arial", 10f, FontStyle.Bold);

                // Configure plot area
                chartArea.InnerPlotPosition.Auto = false;
                chartArea.InnerPlotPosition.Width = 85;
                chartArea.InnerPlotPosition.Height = 73;
                chartArea.InnerPlotPosition.X = 15;
                chartArea.InnerPlotPosition.Y = 5;

                // Enable scrolling
                chartArea.AxisX.ScaleView.Zoomable = true;
                chartArea.AxisX.ScrollBar.Enabled = true;
                chartArea.AxisX.ScrollBar.Size = 10;
                chartArea.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;

                // Configure the visible number of columns when scrolling
                int visibleColumns = 10; // Adjust this number to control how many columns fit on the chart
                if (series.Points.Count > visibleColumns)
                {
                    chartArea.AxisX.ScaleView.Size = visibleColumns;
                    chartArea.AxisX.ScaleView.Position = 0;

                    // Set minimum size to prevent zooming too far in
                    chartArea.AxisX.ScaleView.MinSize = 5;

                    // Set the scroll bar's small change to 1 column
                    chartArea.AxisX.ScaleView.SmallScrollSize = 1;
                }

                // Add title
                chartSanPhamSapHetHan.Titles.Clear();
                Title title = new Title("SẢN PHẨM SẮP HẾT HẠN", Docking.Top);
                title.Font = new Font("Arial", 13f, FontStyle.Bold);
                chartSanPhamSapHetHan.Titles.Add(title);

                chartSanPhamSapHetHan.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading expiration chart: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTop5LoyalCustomers()
        {
            try
            {
                // Get the top 5 loyal customers
                topLoyalCustomers = invoiceBUS.GetTop5LoyalCustomers();

                // Clear the chart before adding new data
                chartKhachHangThanThiet.Series.Clear();
                chartKhachHangThanThiet.Titles.Clear();

                // Add each customer as a separate series
                foreach (var customer in topLoyalCustomers)
                {
                    Series series = new Series(customer.CustomerID + " - " + customer.Name);
                    series.ChartType = SeriesChartType.Column;

                    // Add a single point for this customer
                    DataPoint point = new DataPoint();
                    point.SetValueY(Convert.ToDouble(customer.TotalSpent));
                    point.Label = customer.TotalSpent.ToString("N0") + "đ";
                    series.Points.Add(point);

                    // Add the series to the chart
                    chartKhachHangThanThiet.Series.Add(series);
                }

                // Configure chart area
                ChartArea chartArea = chartKhachHangThanThiet.ChartAreas[0];

                // Set axis titles
                chartArea.AxisX.Title = "Tên khách hàng";
                chartArea.AxisX.TitleFont = new Font("Arial", 10f, FontStyle.Bold);
                chartArea.AxisY.Title = "Tổng chi tiêu (đ)";
                chartArea.AxisY.TitleFont = new Font("Arial", 10f, FontStyle.Bold);

                // Configure X-axis
                chartArea.AxisX.LabelStyle.Angle = -45;
                chartArea.AxisX.LabelStyle.Font = new Font("Arial", 10f);
                chartArea.AxisX.MajorGrid.Enabled = false;
                chartArea.AxisX.Interval = 1; // Ensure all labels are shown

                // Configure Y-axis
                chartArea.AxisY.LabelStyle.Format = "N0";
                chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;

                // Enable legend
                chartKhachHangThanThiet.Legends[0].Enabled = true;
                chartKhachHangThanThiet.Legends[0].Docking = Docking.Right;

                // Add chart title
                Title title = new Title("TOP 5 KHÁCH HÀNG THÂN THIẾT");
                title.Font = new Font("Arial", 13f, FontStyle.Bold);
                chartKhachHangThanThiet.Titles.Add(title);

                // Auto-fit the chart
                chartKhachHangThanThiet.Dock = DockStyle.Fill;

                // Refresh the chart
                chartKhachHangThanThiet.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thống kê Top 5 sản phẩm bán chạy nhất (theo năm)
        private void LoadTopSellingProducts(int year)
        {
            dataGridViewTop5SanPham.Columns.Clear(); // Xóa các cột cũ trong DataGridView

            // Lấy danh sách top 5 sản phẩm bán chạy trong năm được chọn
            var topProducts = invoicedetailBUS.GetTopSellingProductsByYear(year);

            // Kiểm tra nếu danh sách sản phẩm bán chạy không trống
            if (topProducts == null || topProducts.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm bán chạy trong năm này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // Dừng hàm nếu không có dữ liệu
            }

            // Xóa dữ liệu cũ trong danh sách
            topSellingProducts.Clear();

            // Thêm các sản phẩm bán chạy vào danh sách
            topSellingProducts.AddRange(topProducts);

            // Cập nhật lại DataGridView sau khi thay đổi DataSource
            dataGridViewTop5SanPham.DataSource = null; // Xóa DataSource cũ để tránh lỗi
            dataGridViewTop5SanPham.DataSource = topSellingProducts; // Gán lại DataSource mới

            // Refresh lại DataGridView để hiển thị dữ liệu
            dataGridViewTop5SanPham.Refresh();
        }

        // Thống kê doanh thu theo tháng (lọc theo năm)
        private void LoadMonthlyRevenue(int year)
        {
            var monthlyRevenue = invoiceBUS.GetRevenueByMonth(year); // Lấy doanh thu theo tháng

            // Kiểm tra và tạo series "Doanh thu theo tháng" nếu chưa tồn tại
            if (!chartDoanhThu.Series.Any(s => s.Name == "Doanh thu theo tháng"))
            {
                chartDoanhThu.Series.Add("Doanh thu theo tháng"); // Thêm series mới với tên "Doanh thu theo tháng"
                chartDoanhThu.Series["Doanh thu theo tháng"].ChartType = SeriesChartType.Column; // Đặt loại biểu đồ là cột (hoặc loại khác)
            }

            // Lấy series "Doanh thu theo tháng"
            var series = chartDoanhThu.Series["Doanh thu theo tháng"];
            series.Points.Clear(); // Xóa dữ liệu cũ trước khi thêm dữ liệu mới

            // Duyệt qua tất cả 12 tháng (1 đến 12)
            for (int month = 1; month <= 12; month++)
            {
                // Tìm doanh thu cho tháng hiện tại
                var revenue = monthlyRevenue.FirstOrDefault(r => r.Month == month);

                // Nếu có doanh thu, thêm vào biểu đồ, nếu không thì thêm giá trị 0
                decimal totalRevenue = revenue != null ? revenue.TotalRevenue : 0;

                // Chỉ thêm điểm vào biểu đồ nếu tháng hợp lệ
                series.Points.AddXY(month, totalRevenue);
            }

            // Cấu hình biểu đồ cho doanh thu
            chartDoanhThu.ChartAreas["ChartArea1"].AxisX.Title = "Tháng";
            chartDoanhThu.ChartAreas["ChartArea1"].AxisY.Title = "Doanh thu (VND)";
            chartDoanhThu.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            // Thiết lập font chữ đậm cho tiêu đề trục X và trục Y
            chartDoanhThu.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 10, FontStyle.Bold);
            chartDoanhThu.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 10, FontStyle.Bold);
            // Xóa các giá trị không hợp lệ trong trục X
            chartDoanhThu.ChartAreas["ChartArea1"].AxisX.CustomLabels.Clear();
            for (int i = 1; i <= 12; i++)
            {
                chartDoanhThu.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(i - 0.5, i + 0.5, i.ToString());
            }
        }

        private void LoadYears()
        {
            // Lấy năm hiện tại
            int currentYear = DateTime.Now.Year;

            // Thêm các năm vào ComboBox (ví dụ: từ năm hiện tại đến năm 5 năm trước)
            for (int year = currentYear; year >= currentYear - 5; year--)
            {
                cbbYear.Items.Add(year);
            }

            // Chọn năm mặc định là năm hiện tại
            cbbYear.SelectedItem = currentYear;
        }

        // Khi người dùng chọn năm từ ComboBox, cập nhật biểu đồ doanh thu
        private void cbbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy năm được chọn từ ComboBox
            int selectedYear = (int)cbbYear.SelectedItem;

            // Cập nhật biểu đồ doanh thu theo năm đã chọn
            LoadMonthlyRevenue(selectedYear);// Cập nhật doanh thu theo năm được chọn
            LoadTopSellingProducts(selectedYear); // Cập nhật top sản phẩm bán chạy theo năm được chọn
        }


    }
}


