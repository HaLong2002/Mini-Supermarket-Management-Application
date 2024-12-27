using SieuThiMini.BUS;
using SieuThiMini.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SieuThiMini.Panel
{
    public partial class CategoryPanel : UserControl
    {
        private int id;

        private ProductCategoryBUS categoryBUS;
        private readonly ProductTypeBUS productTypeBUS;

        private List<ProductCategoryDTO> categoryList = new List<ProductCategoryDTO>();
        private List<ProductTypeDTO> productTypeList = new List<ProductTypeDTO>();

        private List<Control> errorControls = new List<Control>();

        public CategoryPanel(int id)
        {
            InitializeComponent();

            this.id = id;
            productTypeBUS = new ProductTypeBUS();
            categoryBUS = new ProductCategoryBUS();
        }

        private void Category_Load(object sender, EventArgs e)
        {
            LoadCategories();

            LoadComboboxIDDanhMuc();
        }

        private void LoadComboboxIDDanhMuc()
        {
            cbboxIDDanhMuc.DataSource = categoryList;
            cbboxIDDanhMuc.DisplayMember = "CategoryName"; // No specific member needed
            cbboxIDDanhMuc.ValueMember = "CategoryID"; // Set ValueMember

            cbboxIDDanhMuc.SelectedIndex = -1;
        }

        private void LoadCategories()
        {
            LoadProductCategories_Data(); // Lấy dữ liệu từ database

            cbboxIDDanhMuc.DataSource = categoryList; // Đưa dữ liệu Category vào combobox

            LoadDataIntoDataGridView_Category(categoryList); // Đưa dữ liệu vào datagridView
        }

        private void LoadProductTypes_ByIdCategory(int idCategory)
        {
            LoadProductTypesData_ByCategoryId(idCategory); // Lấy dữ liệu từ database
            LoadDataIntoDataGridView_Type(productTypeList); // Đưa dữ liệu vào datagridView
        }

        // Lấy dữ liệu categories từ database
        private void LoadProductCategories_Data()
        {
            categoryList = categoryBUS.GetCategories();
        }

        // Lấy dữ liệu productTypes theo CategoryID từ database
        private void LoadProductTypesData_ByCategoryId(int idCategory)
        {
            productTypeList = productTypeBUS.GetProductTypesByCategoryId(idCategory);
        }

        // Lấy tất cả dữ liệu productTypes từ database
        private void LoadProductTypes_Data()
        {
            productTypeList = productTypeBUS.GetAllProductTypes();
        }

        // Đưa dữ liệu categories vào datagridView
        private void LoadDataIntoDataGridView_Category(List<ProductCategoryDTO> list)
        {
            dataGridView_Category.Rows.Clear();
            dataGridView_Type.Rows.Clear();

            txtCategoryID.Text = "";
            txtCategoryName.Text = "";
            txtIDType.Text = "";
            txtTypeName.Text = "";
            cbboxIDDanhMuc.SelectedIndex = -1;

            for (int i = 0; i < list.Count; i++)
            {
                dataGridView_Category.Rows.Add(list[i].CategoryID, list[i].CategoryName);
            }

            // Deselection the first row
            DeselectionRow(dataGridView_Category);
        }

        // Đưa dữ liệu productTypes vào datagridView
        private void LoadDataIntoDataGridView_Type(List<ProductTypeDTO> list)
        {
            txtIDType.Text = "";
            txtTypeName.Text = "";

            dataGridView_Type.Rows.Clear();

            for (int i = 0; i < list.Count; i++)
            {
                dataGridView_Type.Rows.Add(list[i].ProductTypeID, list[i].ProductTypeName, list[i].CategoryID);
            }

            // Deselection the first row
            DeselectionRow(dataGridView_Type);
        }

        // Deselection the first row
        private void DeselectionRow(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count > 0)
            {
                dataGridView.ClearSelection(); // Clear all selections
            }
        }

        private void dataGridView_Category_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked row index is valid
            if (e.RowIndex >= 0)
            {
                // Get the current row
                DataGridViewRow row = dataGridView_Category.Rows[e.RowIndex];

                // Assign each column's value to the corresponding TextBox
                txtCategoryID.Text = row.Cells["CategoryID"].Value?.ToString();
                //txtCategoryID.Text = cbboxSearchCategory.SelectedValue.ToString();
                txtCategoryName.Text = row.Cells["CategoryName"].Value?.ToString();

                int id_Category = int.Parse(row.Cells["CategoryID"].Value.ToString());

                cbboxIDDanhMuc.SelectedValue = id_Category;

                LoadProductTypes_ByIdCategory(id_Category);
            }
        }

        private void dataGridView_Type_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked row index is valid
            if (e.RowIndex >= 0)
            {
                // Get the current row
                DataGridViewRow row = dataGridView_Type.Rows[e.RowIndex];

                // Assign each column's value to the corresponding TextBox
                txtIDType.Text = row.Cells["TypeID"].Value?.ToString();
                txtTypeName.Text = row.Cells["TypeName"].Value?.ToString();
                cbboxIDDanhMuc.SelectedValue = int.Parse(row.Cells["CategoryID_TypeTable"].Value?.ToString());
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var btn = (System.Windows.Forms.Button)sender;

            if (CheckButtonCondition(btn.Name))
            {
                switch (btn.Name)
                {
                    case "btnAddCategory":
                        ConfirmAdd_Category();
                        break;

                    case "btnAddType":
                        ConfirmAdd_ProductType();
                        break;

                    case "btnEditCategory":
                        ConfirmEdit_Category();
                        break;

                    case "btnEditType":
                        ConfirmEdit_ProductType();
                        break;

                    case "btnDeleteCategory":
                        ConfirmDelete_Category();
                        break;

                    case "btnDeleteType":
                        ConfirmDelete_ProductType();
                        break;

                    case "btnReloadCategory":
                        LoadCategories();
                        break;

                    case "btnReloadType":
                        ReloadProductTypes();
                        break;

                    case "btnSearchCategory":
                        SearchCategories();
                        break;

                    case "btnSearchType":
                        SearchProductTypes();
                        break;
                }
            }
        }

        private bool CheckButtonCondition(string btnName)
        {
            ClearAllErrorProvider();

            bool result = true, result1, result2;
            switch (btnName)
            {
                case "btnAddCategory":
                    result = CheckEmpty_Textbox(txtCategoryName, "Tên danh mục không được rỗng");
                    break;

                case "btnEditCategory":
                    result1 = CheckEmpty_Textbox(txtCategoryID, "Vui lòng chọn danh mục cần sửa");
                    result2 = CheckEmpty_Textbox(txtCategoryName, "Tên danh mục không được rỗng");
                    result = result1 && result2;
                    break;

                case "btnAddType":
                    result1 = CheckEmpty_Textbox(txtTypeName, "Loại sản phẩm không được để trống");
                    result2 = CheckEmpty_Combobox(cbboxIDDanhMuc, "Vui lòng chọn 1 danh mục");
                    result = result1 && result2;
                    break;

                case "btnEditType":
                    result1 = CheckEmpty_Textbox(txtIDType, "Vui lòng chọn loại sản phẩm cần sửa");
                    result2 = CheckEmpty_Textbox(txtTypeName, "Loại sản phẩm không được để trống");
                    result = result1 && result2;
                    break;

                case "btnDeleteCategory":
                    result = CheckEmpty_Textbox(txtCategoryID, "Vui lòng chọn danh mục muốn xóa");
                    break;

                case "btnDeleteType":
                    result = CheckEmpty_Textbox(txtIDType, "Vui lòng chọn loại sản phẩm muốn xóa");
                    break;

                case "btnSearchCategory":
                    result = CheckCombobox_TextboxBeforeSearching(cbboxSearchCategory, txtSearchCategory);
                    break;

                case "btnSearchType":
                    result = CheckCombobox_TextboxBeforeSearching(cbboxSearchType, txtSearchType);
                    break;
            }
            return result;
        }

        private void ClearAllErrorProvider()
        {
            foreach (var control in errorControls)
            {
                errorProvider1.SetError(control, string.Empty);  // Clear the error
            }

            // Clear the list of saved controls
            errorControls.Clear();
        }

        private bool CheckEmpty_Textbox(System.Windows.Forms.TextBox textBox, string errorText)
        {
            if (textBox.Text.Length != 0)
            {
                errorProvider1.SetError(textBox, string.Empty);
                return true;
            }
            else
            {
                errorProvider1.SetError(textBox, errorText);
                errorControls.Add(textBox);
                return false;
            }
        }

        private bool CheckEmpty_Combobox(System.Windows.Forms.ComboBox cbbox, string errorText)
        {
            if (cbbox.SelectedIndex != -1)
            {
                errorProvider1.SetError(cbbox, string.Empty);
                return true;
            }
            else
            {
                errorProvider1.SetError(cbbox, errorText);
                errorControls.Add(cbbox);
                return false;
            }
        }

        private void ConfirmAdd_Category()
        {
            if (txtCategoryName.Text.ToLower() == "khác")
            {
                MessageBox.Show("Không được phép thêm danh mục với tên 'Khác'.", "Thêm thất bại",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }
            else
            {
                categoryBUS.AddCategory(txtCategoryName.Text);

                MessageBox.Show("Thêm thành công!" + "\nTên danh mục: " + txtCategoryName.Text, "Thêm thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                LoadCategories();
            }
        }

        private void ConfirmAdd_ProductType()
        {
            var category = cbboxIDDanhMuc.SelectedItem as ProductCategoryDTO;

            if (category.CategoryName == "Khác" && txtTypeName.Text.ToLower() == "khác")
            {
                MessageBox.Show($"Không được phép thêm loại sản phẩm với tên '{txtTypeName.Text}' trong danh mục 'Khác'!",
                    "Thêm thất bại",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
            else
            {
                int idCategory = int.Parse(cbboxIDDanhMuc.SelectedValue.ToString());

                productTypeBUS.AddProductType(txtTypeName.Text, idCategory);

                MessageBox.Show("Thêm thành công!" + "\nLoại sản phẩm: " + txtTypeName.Text + "\nID danh mục: " +
                    cbboxIDDanhMuc.SelectedValue.ToString(),
                    "Thêm thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                LoadProductTypes_ByIdCategory(idCategory);
            }
        }

        private void ConfirmEdit_Category()
        {
            if (txtCategoryName.Text.ToLower() == "khác")
            {
                MessageBox.Show($"Không được sửa tên danh mục thành '{txtCategoryName.Text}'.", "Sửa thất bại", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                bool isUpdated = categoryBUS.UpdateProductCategory(int.Parse(txtCategoryID.Text), txtCategoryName.Text);
                if (isUpdated)
                {
                    MessageBox.Show("Cập nhật thành công!" + "\nTên danh mục: " + txtCategoryName.Text, "Cập nhật thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Chỉnh sửa đối tượng đã sửa trong list
                    ModifiesTheObject_InTheCategoriesList("Edit");

                    UpdateADataGridViewRow(txtCategoryName.Text, dataGridView_Category, "CategoryName", null);

                    cbboxIDDanhMuc.DataSource = categoryList;
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Cập nhật thất bại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ConfirmEdit_ProductType()
        {
            var category = cbboxIDDanhMuc.SelectedItem as ProductCategoryDTO;

            if (category.CategoryName == "Khác" && txtTypeName.Text.ToLower() == "khác")
            {
                MessageBox.Show($"Không được phép sửa tên loại sản phẩm thành '{txtTypeName.Text}' trong danh mục 'Khác'!",
                        "Sửa thất bại",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
            else
            {
                bool isUpdated = productTypeBUS.UpdateProductType(int.Parse(txtIDType.Text), txtTypeName.Text, int.Parse(cbboxIDDanhMuc.SelectedValue.ToString()));
                if (isUpdated)
                {
                    MessageBox.Show("Cập nhật thành công!" + "\nLoại sản phẩm: " + txtTypeName.Text + "\nID danh mục: " + cbboxIDDanhMuc.SelectedValue, "Cập nhật thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Chỉnh sửa đối tượng đã sửa trong list
                    ModifiesTheObject_InTheProductTypesList("Edit");

                    UpdateADataGridViewRow(txtTypeName.Text, dataGridView_Type, "TypeName", "CategoryID_TypeTable");
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Cập nhật thất bại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ModifiesTheObject_InTheCategoriesList(string feature)
        {
            // Chỉnh sửa đối tượng đã điều chỉnh trong list
            var targetCategory = categoryList.FirstOrDefault(category => category.CategoryID == int.Parse(txtCategoryID.Text));
            if (targetCategory != null)
            {
                if (feature == "Edit")
                    targetCategory.CategoryName = txtCategoryName.Text; // This modifies the object in the list
                else
                    categoryList.Remove(targetCategory);
            }
        }

        private void ModifiesTheObject_InTheProductTypesList(string feature)
        {
            // Chỉnh sửa đối tượng đã điều chỉnh trong list
            var targetType = productTypeList.FirstOrDefault(type => type.ProductTypeID == int.Parse(txtIDType.Text));
            if (targetType != null)
            {
                if (feature == "Edit")
                {
                    targetType.ProductTypeName = txtTypeName.Text; // This modifies the object in the list
                    targetType.CategoryID = int.Parse(cbboxIDDanhMuc.SelectedValue.ToString()); // This modifies the object in the list
                }
                else
                    productTypeList.Remove(targetType);
            }
        }

        private void UpdateADataGridViewRow(string newValue, DataGridView dataGridView, string nameColumn, string categoryIDColumn)
        {
            // Get the selected row
            var selectedRow = dataGridView.SelectedRows[0];

            selectedRow.Cells[nameColumn].Value = newValue;

            if (categoryIDColumn != null)
                selectedRow.Cells[categoryIDColumn].Value = cbboxIDDanhMuc.SelectedValue;
        }

        private void ConfirmDelete_Category()
        {
            // Lấy CategoryId của danh mục "Khác"
            var CategoryId = categoryList.FirstOrDefault(c => c.CategoryName == "Khác")?.CategoryID;

            if (CategoryId != null)
            {
                if (CategoryId == int.Parse(txtCategoryID.Text))
                {
                    MessageBox.Show("Không được xóa danh mục 'Khác'!", "Xóa thất bại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Show the message box
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?\nID: " + txtCategoryID.Text + "\nTên danh mục: " + txtCategoryName.Text,
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    // Handle the result
                    if (result == DialogResult.Yes)
                    {
                        if (categoryBUS.DeleteProductCategory(int.Parse(txtCategoryID.Text)))
                        {
                            MessageBox.Show("Xóa thành công!", "Xóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ModifiesTheObject_InTheCategoriesList("Delete");

                            DeleteADataGridViewRow(dataGridView_Category);

                            dataGridView_Type.Rows.Clear();

                            txtCategoryID.Text = "";
                            txtCategoryName.Text = "";
                            txtIDType.Text = "";
                            txtTypeName.Text = "";
                            cbboxIDDanhMuc.SelectedIndex = -1;

                            DeselectionRow(dataGridView_Category);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có danh mục 'Khác'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ConfirmDelete_ProductType()
        {
            // Lấy CategoryId của danh mục "Khác"
            var CategoryId = categoryList.FirstOrDefault(c => c.CategoryName == "Khác")?.CategoryID;

            if (CategoryId != null)
            {
                // Lấy ProductTypeId của loại sản phẩm "Khác" nằm trong danh mục "Khác"
                var ProductTypeId = productTypeList.FirstOrDefault(pt => pt.ProductTypeName == "Khác" && pt.CategoryID == CategoryId)?.ProductTypeID;
                if (ProductTypeId == int.Parse(txtIDType.Text))
                {
                    MessageBox.Show("Không được phép xóa loại sản phẩm 'Khác' trong danh mục 'Khác'!", "Xóa thất bại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Show the message box
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?\nID: " + txtIDType.Text + "\nLoại sản phẩm: " + txtTypeName.Text + "\nID danh mục: " + cbboxIDDanhMuc.SelectedValue.ToString(),
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    // Handle the result
                    if (result == DialogResult.Yes)
                    {
                        if (productTypeBUS.DeleteProductType(int.Parse(txtIDType.Text)))
                        {
                            MessageBox.Show("Xóa thành công!", "Xóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ModifiesTheObject_InTheProductTypesList("Delete");

                            DeleteADataGridViewRow(dataGridView_Type);

                            txtIDType.Text = "";
                            txtTypeName.Text = "";

                            DeselectionRow(dataGridView_Type);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có danh mục 'Khác'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteADataGridViewRow(DataGridView dataGridView)
        {
            // Get the selected row
            var selectedRow = dataGridView.SelectedRows[0];

            dataGridView.Rows.Remove(selectedRow);
        }

        private void ReloadProductTypes()
        {
            if (cbboxIDDanhMuc.SelectedIndex != -1)
            {
                // Get the selected row
                var selectedRow = dataGridView_Category.SelectedRows[0];

                if (selectedRow != null)
                    cbboxIDDanhMuc.SelectedValue = int.Parse(selectedRow.Cells["CategoryID"].Value.ToString());

                LoadProductTypes_ByIdCategory(int.Parse(cbboxIDDanhMuc.SelectedValue.ToString()));
            }
            else
                MessageBox.Show("Vui lòng chọn 1 danh mục để hiển thị các loại sản phẩm của danh mục đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Check Combobox has a selected value and Textbox of Search field is not empty
        private bool CheckCombobox_TextboxBeforeSearching(System.Windows.Forms.ComboBox cbbox, System.Windows.Forms.TextBox txt)
        {
            if (cbbox.SelectedIndex != -1)
            {
                // An item is selected
                // Check search field is not empty
                if (CheckEmpty_Textbox(txt, "Trường Tìm kiếm không được rỗng"))
                    return true;
                else
                    return false;
            }
            else
            {
                // No item is selected
                MessageBox.Show("Vui lòng chọn 1 loại tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private void SearchCategories()
        {
            if (cbboxSearchCategory.SelectedIndex == 0)
            {
                // Tìm kiếm theo ID
                int targetCategoryID = int.Parse(txtSearchCategory.Text);

                // Use LINQ to filter the list
                var matchingCategories = categoryList.Where(c => c.CategoryID == targetCategoryID).ToList();

                LoadDataIntoDataGridView_Category(matchingCategories);
            }
            else if (cbboxSearchCategory.SelectedIndex == 1)
            {
                // Tìm kiếm theo Tên danh mục
                string targetCategoryName = txtSearchCategory.Text.Trim().ToLower();

                // Use LINQ to filter the list
                var matchingCategories = categoryList.Where(c => c.CategoryName.ToLower().Contains(targetCategoryName)).ToList();

                LoadDataIntoDataGridView_Category(matchingCategories);
            }
        }

        private void SearchProductTypes()
        {
            LoadProductTypes_Data();

            if (cbboxSearchType.SelectedIndex == 0)
            {
                // Tìm kiếm theo ID
                int targetTypeID = int.Parse(txtSearchType.Text.Trim());

                // Use LINQ to filter the list
                var matchingTypes = productTypeList.Where(c => c.ProductTypeID == targetTypeID).ToList();

                LoadDataIntoDataGridView_Type(matchingTypes);
            }
            else if (cbboxSearchType.SelectedIndex == 1)
            {
                // Tìm kiếm theo Tên danh mục
                string targetTypeName = txtSearchType.Text.Trim().ToLower();

                // Use LINQ to filter the list
                var matchingTypes = productTypeList.Where(c => c.ProductTypeName.ToLower().Contains(targetTypeName)).ToList();

                LoadDataIntoDataGridView_Type(matchingTypes);
            }
            else if (cbboxSearchType.SelectedIndex == 2)
            {
                // Tìm kiếm theo ID danh mục
                int targetCategoryID = int.Parse(txtSearchType.Text.Trim());

                // Use LINQ to filter the list
                var matchingTypes = productTypeList.Where(c => c.CategoryID == targetCategoryID).ToList();

                LoadDataIntoDataGridView_Type(matchingTypes);
            }
        }

        // Text Search chỉ được nhập số nếu chọn Tìm kiếm theo ID
        private void txtSearchCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbboxSearchCategory.SelectedIndex == 0)
            {
                // Check if the key is not a control key (e.g., backspace) and not a digit
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    // If the key is neither a control key nor a digit, stop it from being entered
                    e.Handled = true;
                    MessageBox.Show("Vui lòng chỉ nhập số khi chọn Tìm kiếm theo ID!", "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void txtSearchType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbboxSearchType.SelectedIndex == 0 || cbboxSearchType.SelectedIndex == 2)
            {
                // Check if the key is not a control key (e.g., backspace) and not a digit
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    // If the key is neither a control key nor a digit, stop it from being entered
                    e.Handled = true;
                    MessageBox.Show("Vui lòng chỉ nhập số khi chọn Tìm kiếm theo ID!", "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        // Tìm kiếm khi nhấn Enter
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the Enter key was pressed
            if (e.KeyCode == Keys.Enter)
            {
                // Prevent the sound of the Enter key
                e.SuppressKeyPress = true;

                var txt = (System.Windows.Forms.TextBox)sender;

                if (txt.Name == "txtSearchCategory")
                {
                    if (CheckCombobox_TextboxBeforeSearching(cbboxSearchCategory, txt))
                        SearchCategories();
                }
                else if (CheckCombobox_TextboxBeforeSearching(cbboxSearchType, txt))
                    SearchProductTypes();
            }
        }

        private void cbboxSearchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchCategory.Text = "";
        }

        private void cbboxSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchType.Text = "";
        }
    }
}

