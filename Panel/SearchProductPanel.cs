using SieuThiMini.BUS;
using SieuThiMini.DTO;
using System;
using System.Collections.Generic; // Thêm namespace này nếu chưa có
using System.Globalization;
using System.Windows.Forms;

namespace SieuThiMini.Panel
{
    public partial class SearchProductPanel : UserControl
    {
        private ProductBUS productBUS = new ProductBUS();

        public event Action<List<ProductDTO>> SearchCompleted;


        public SearchProductPanel()
        {
            InitializeComponent();
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            cmbCountry.DataSource = productBUS.GetUniqueCountries();
            cmbBrand.DataSource = productBUS.GetUniqueBrands();
            cmbProductType.DataSource = productBUS.GetUniqueProductTypes();
            //cmbProductType.ValueMember = "ProductTypeID";
        }

        private void btnAdvancedSearch_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các combobox
            string selectedCountry = cmbCountry.SelectedItem?.ToString();
            string selectedBrand = cmbBrand.SelectedItem?.ToString();
            string selectedProductType = cmbProductType.SelectedItem?.ToString();
            int selectedProductTypeId = int.Parse(selectedProductType.Split('-')[0].Trim());

            // Lấy giá trị từ các TextBox cho minPrice và maxPrice (nếu có)
            decimal minPrice;
            decimal maxPrice;

            bool isMinPriceValid = decimal.TryParse(txtMinPrice.Text, out minPrice);
            bool isMaxPriceValid = decimal.TryParse(txtMaxPrice.Text, out maxPrice);

            // Tạo điều kiện tìm kiếm
            List<string> conditions = new List<string>();

            // Kiểm tra checkbox cho quốc gia
            if (chkCountry.Checked && !string.IsNullOrEmpty(selectedCountry))
                conditions.Add($"CountryOfOrigin = N'{selectedCountry}'");

            // Kiểm tra checkbox cho thương hiệu
            if (chkBrand.Checked && !string.IsNullOrEmpty(selectedBrand))
                conditions.Add($"Brand = N'{selectedBrand}'");

            // Kiểm tra checkbox cho loại sản phẩm
            if (chkProductType.Checked && !string.IsNullOrEmpty(selectedProductType))
                conditions.Add($"ProductTypeID = '{selectedProductTypeId}'");

            // Chỉ thêm điều kiện giá nếu nó hợp lệ
            if (isMinPriceValid)
                conditions.Add($"Price >= {minPrice.ToString(CultureInfo.InvariantCulture)}"); // Đảm bảo định dạng

            if (isMaxPriceValid)
                conditions.Add($"Price <= {maxPrice.ToString(CultureInfo.InvariantCulture)}"); // Đảm bảo định dạng

            // Gọi phương thức tìm kiếm trong ProductBUS
            var products = productBUS.AdvancedSearch(conditions);

            // Gọi sự kiện để thông báo cho ProductPanel
            SearchCompleted?.Invoke(products);

            MessageBox.Show($"Tìm thấy {products.Count} sản phẩm.");

            // Đóng SearchProductPanel nếu cần
            this.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
