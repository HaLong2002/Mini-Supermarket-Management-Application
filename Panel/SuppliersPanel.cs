using SieuThiMini.BUS;
using SieuThiMini.DTO;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SieuThiMini.Panel
{
    public partial class SuppliersPanel : Form
    {
        private int id;
        SuppliersBUS suppliersBUS = new SuppliersBUS();
        SupplierProductsBUS supplierProductsBUS = new SupplierProductsBUS();
        private ErrorProvider err;
        public SuppliersPanel(int id)
        {
            InitializeComponent();
            this.id = id;
            err = new ErrorProvider();
            err.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            load_suppliers();
        }
        private void SupplierPannel_Load() { }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Start ...");
            DAO.SuppliersDAO suppliersDAO = new DAO.SuppliersDAO();
            List<SupplierDTO> suppliers = suppliersDAO.GetSuppliersList();
            label1.Text = $"path: {suppliers.Count}";
            //Console.WriteLine($"Suppliers length: {suppliers.Count}");
            //// Display the suppliers in the console
            //foreach (SupplierDTO supplier in suppliers)
            //{
            //    Console.WriteLine($"ID: {supplier.SupplierID}, Name: {supplier.SupplierName}, Phone: {supplier.Phone}, Created At: {supplier.CreatedAt}");
            //}
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void listView1_itemActivate(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                err.Clear();
                supplierNameInput.Text = selectedItem.SubItems[1].Text;
                // phone, email, address
                supplierPhoneInput.Text = selectedItem.SubItems[2].Text;
                supplierEmailInput.Text = selectedItem.SubItems[3].Text;
                supplierAddressInput.Text = selectedItem.SubItems[4].Text;
                button2.Enabled = true;
                button3.Enabled = true;
                int supplierId = int.Parse(selectedItem.SubItems[0].Text);
                load_suppier_products(supplierId);
                button5.Enabled = true;
            }
        }

        private void listView2_itemActivate(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView2.SelectedItems[0];
                err.Clear();
                productNameInput.Text = selectedItem.SubItems[1].Text;
                productTypeInput.Text = selectedItem.SubItems[2].Text;
                brandInput.Text = selectedItem.SubItems[3].Text;
                countryOriginInput.Text = selectedItem.SubItems[4].Text;
                priceInput.Text = selectedItem.SubItems[5].Text;
                quantityInput.Text = selectedItem.SubItems[6].Text;
                unitInput.Text = selectedItem.SubItems[7].Text;
                descriptionInput.Text = selectedItem.SubItems[8].Text;
                ingredientInput.Text = selectedItem.SubItems[9].Text;
                benefitInput.Text = selectedItem.SubItems[10].Text;
                weightInput.Text = selectedItem.SubItems[11].Text;
                flavorInput.Text = selectedItem.SubItems[12].Text;
                string status = selectedItem.SubItems[13].Text;
                if (status == "Available") statusInput.SelectedIndex = 0;
                if (status == "Unavailable") statusInput.SelectedIndex = 1;
                string manufactureDate = selectedItem.SubItems[14].Text;
                dateTimePicker1.Value = DateTime.ParseExact(manufactureDate, "dd/MM/yyyy", null);
                string expirationDate = selectedItem.SubItems[15].Text;
                dateTimePicker2.Value = DateTime.ParseExact(expirationDate, "dd/MM/yyyy", null);
                //item.SubItems.Add(supplierProduct.Status);
                //item.SubItems.Add(supplierProduct.ManufactureDate.ToString());
                //item.SubItems.Add(supplierProduct.ExpirationDate.ToString());
                button6.Enabled = true;
                button7.Enabled = true;
            }
            else
            {
                button5.Enabled = false;
            }
        }

        private int load_suppliers()
        {
            listView1.Items.Clear();
            List<SupplierDTO> suppliers = suppliersBUS.GetSuppliersList();
            foreach (var supplier in suppliers)
            {
                ListViewItem item = new ListViewItem(supplier.SupplierID.ToString());
                item.SubItems.Add(supplier.SupplierName);
                item.SubItems.Add(supplier.Phone);
                item.SubItems.Add(supplier.Email);
                item.SubItems.Add(supplier.Address);

                listView1.Items.Add(item);
            }
            return suppliers.Count;
        }

        private int load_suppier_products(int supplierID)
        {
            listView2.Items.Clear();
            List<SupplierProductsDTO> supplierProducts = supplierProductsBUS.GetSupplierProductListBySupplier(supplierID);
            foreach (var supplierProduct in supplierProducts)
            {
                ListViewItem item = new ListViewItem(supplierProduct.ProductId.ToString());
                // createDate, expireDate
                item.SubItems.Add(supplierProduct.ProductName);
                item.SubItems.Add(supplierProduct.ProductTypeID.ToString());
                item.SubItems.Add(supplierProduct.Brand);
                item.SubItems.Add(supplierProduct.CountryOfOrigin);
                item.SubItems.Add(supplierProduct.Price.ToString());
                item.SubItems.Add(supplierProduct.StockQuantity.ToString());
                item.SubItems.Add(supplierProduct.Unit);
                item.SubItems.Add(supplierProduct.Description);
                item.SubItems.Add(supplierProduct.Ingredients);
                item.SubItems.Add(supplierProduct.Benefits);
                item.SubItems.Add(supplierProduct.Weight.ToString());
                item.SubItems.Add(supplierProduct.Flavor);
                item.SubItems.Add(supplierProduct.Status);
                item.SubItems.Add(supplierProduct.ManufactureDate.ToString("dd/MM/yyyy"));
                item.SubItems.Add(supplierProduct.ExpirationDate.ToString("dd/MM/yyyy"));

                listView2.Items.Add(item);
            }
            return supplierProducts.Count;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Regular expression pattern for validating email addresses
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            // Regular expression pattern for validating phone numbers
            string pattern = @"^[+]?[(]?[0-9]{1,4}[)]?[-\s\.]?[0-9]{1,4}[-\s\.]?[0-9]{1,4}[-\s\.]?[0-9]{1,9}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }
        bool IsValidFormSupplier(string name, string phone, string email, string address)
        {
            if (string.IsNullOrEmpty(name))
            {
                err.SetError(supplierNameInput, "Required");
                return false;
            }
            if (!IsValidPhoneNumber(phone))
            {
                err.SetError(supplierPhoneInput, "Invalid");
                return false;
            }
            if (string.IsNullOrEmpty(address))
            {
                err.SetError(supplierAddressInput, "Required");
                return false;
            }
            if (!IsValidEmail(email))
            {
                err.SetError(supplierEmailInput, "Invalid");
                return false;
            }
            return true;
        }
        void resetFormSupplier()
        {
            err.Clear();
            supplierNameInput.Clear();
            supplierPhoneInput.Clear();
            supplierAddressInput.Clear();
            supplierEmailInput.Clear();
            button2.Enabled = false;
            button3.Enabled = false;
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            err.Clear();
            string name = supplierNameInput.Text;
            string phone = supplierPhoneInput.Text;
            string address = supplierAddressInput.Text;
            string email = supplierEmailInput.Text;
            if (IsValidFormSupplier(name, phone, email, address))
            {
                suppliersBUS.CreateSuppilers(new SupplierDTO
                {
                    SupplierID = 0,
                    SupplierName = name,
                    Phone = phone,
                    Email = email,
                    Address = address
                });
                load_suppliers();
                resetFormSupplier();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            err.Clear();
            string name = supplierNameInput.Text;
            string phone = supplierPhoneInput.Text;
            string address = supplierAddressInput.Text;
            string email = supplierEmailInput.Text;
            ListViewItem listViewItem = listView1.SelectedItems[0];
            int id = int.Parse(listViewItem.SubItems[0].Text);
            if (IsValidFormSupplier(name, phone, email, address))
            {
                suppliersBUS.EditSuppliers(new SupplierDTO
                {
                    SupplierID = id,
                    SupplierName = name,
                    Phone = phone,
                    Email = email,
                    Address = address
                });
                load_suppliers();
                resetFormSupplier();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListViewItem listViewItem = listView1.SelectedItems[0];
            int id = int.Parse(listViewItem.SubItems[0].Text);
            supplierProductsBUS.DeleteSupplierProductBySupplier(id);
            suppliersBUS.Delete(id);
            load_suppliers();
            resetFormSupplier();
            listView2.Items.Clear();
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
        }
        public bool IsValidFormSupplierProduct(
            string name,
            string typeId,
            string brand,
            string countryOfOrigin,
            string price,
            string quantity,
            string unit,
            string description,
            string ingredient,
            string benefit,
            string flavor,
            string weight,
            DateTime manufactureDate,
            DateTime expirationDate,
            string status)
        {
            bool isValid = true;

            // Helper function to check if a string is a valid decimal
            bool IsValidDecimal(string input)
            {
                return decimal.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
            }

            // Helper function to check if a string is a valid integer
            bool IsValidInt(string input)
            {
                return int.TryParse(input, out _);
            }

            // Validate required text fields
            if (string.IsNullOrWhiteSpace(name))
            {
                err.SetError(productNameInput, "Required");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(typeId) || !IsValidInt(typeId))
            {
                err.SetError(productTypeInput, "Required and must be a valid integer.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(brand))
            {
                err.SetError(brandInput, "Required.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(countryOfOrigin))
            {
                err.SetError(countryOriginInput, "Country of origin is required.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(price) || !IsValidDecimal(price))
            {
                err.SetError(priceInput, "Required and must be a valid decimal number.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(quantity) || !IsValidInt(quantity))
            {
                err.SetError(quantityInput, "Required and must be a valid integer.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(unit))
            {
                err.SetError(unitInput, "Required.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                err.SetError(descriptionInput, "Required.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(ingredient))
            {
                err.SetError(ingredientInput, "Ingredient is required.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(benefit))
            {
                err.SetError(benefitInput, "Required.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(flavor))
            {
                err.SetError(flavorInput, "Required.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(weight) || !IsValidDecimal(weight))
            {
                err.SetError(weightInput, "Required and must be a valid decimal number.");
                isValid = false;
            }

            // Date validations
            if (manufactureDate > DateTime.Now)
            {
                err.SetError(dateTimePicker1, "Manufacture date cannot be in the future.");
                isValid = false;
            }

            if (expirationDate <= manufactureDate)
            {
                err.SetError(dateTimePicker2, "Expiration date must be after the manufacture date.");
                isValid = false;
            }

            // Optional: Check if status matches predefined set
            string[] validStatuses = { "Available", "Unavailable" };
            if (Array.IndexOf(validStatuses, status) == -1)
            {
                err.SetError(statusInput, "Invalid status. Please select a valid option." + status);
                isValid = false;
            }

            // Return whether all validations passed
            return isValid;
        }
        private void resetFormSupplierProduct()
        {
            productNameInput.Clear();
            productTypeInput.Clear();
            brandInput.Clear();
            countryOriginInput.Clear();
            priceInput.Clear();
            quantityInput.Clear();
            unitInput.Clear();
            descriptionInput.Clear();
            ingredientInput.Clear();
            benefitInput.Clear();
            flavorInput.Clear();
            weightInput.Clear();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            statusInput.SelectedIndex = -1;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            err.Clear();
            string name = productNameInput.Text;
            string typeId = productTypeInput.Text;
            string brand = brandInput.Text;
            string countryOfOrigin = countryOriginInput.Text;
            string price = priceInput.Text;
            string quantity = quantityInput.Text;
            string unit = unitInput.Text;
            string description = descriptionInput.Text;
            string ingredient = ingredientInput.Text;
            string benefit = benefitInput.Text;
            string flavor = flavorInput.Text;
            string weight = weightInput.Text;
            DateTime manufactureDate = dateTimePicker1.Value;
            DateTime expirationDate = dateTimePicker2.Value;
            string status = statusInput.Text;

            ListViewItem selectedItem = listView1.SelectedItems[0];
            int supplierID = int.Parse(selectedItem.SubItems[0].Text);

            bool check = IsValidFormSupplierProduct(name, typeId, brand, countryOfOrigin, price, quantity, unit, description, ingredient, benefit, flavor, weight, manufactureDate, expirationDate, status);
            if (check)
            {
                supplierProductsBUS.CreateSupplierProduct(new SupplierProductsDTO
                {
                    ProductId = 0,
                    ProductName = name,
                    ProductTypeID = int.Parse(typeId),
                    Brand = brand,
                    CountryOfOrigin = countryOfOrigin,
                    Price = decimal.Parse(price),
                    StockQuantity = int.Parse(quantity),
                    Unit = unit,
                    Description = description,
                    Ingredients = ingredient,
                    Benefits = benefit,
                    Weight = decimal.Parse(weight),
                    Flavor = flavor,
                    ManufactureDate = manufactureDate,
                    ExpirationDate = expirationDate,
                    ImageUrl = null,
                    Status = status,
                    SupplierID = supplierID
                });
                resetFormSupplierProduct();
                load_suppier_products(supplierID);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            err.Clear();
            string name = productNameInput.Text;
            string typeId = productTypeInput.Text;
            string brand = brandInput.Text;
            string countryOfOrigin = countryOriginInput.Text;
            string price = priceInput.Text;
            string quantity = quantityInput.Text;
            string unit = unitInput.Text;
            string description = descriptionInput.Text;
            string ingredient = ingredientInput.Text;
            string benefit = benefitInput.Text;
            string flavor = flavorInput.Text;
            string weight = weightInput.Text;
            DateTime manufactureDate = dateTimePicker1.Value;
            DateTime expirationDate = dateTimePicker2.Value;
            string status = statusInput.Text;
            ListViewItem selectedSupplier = listView1.SelectedItems[0];
            int supplierID = int.Parse(selectedSupplier.SubItems[0].Text);
            ListViewItem selectedSupplierProduct = listView2.SelectedItems[0];
            int supplierProductID = int.Parse(selectedSupplierProduct.SubItems[0].Text);
            bool check = IsValidFormSupplierProduct(name, typeId, brand, countryOfOrigin, price, quantity, unit, description, ingredient, benefit, flavor, weight, manufactureDate, expirationDate, status);
            if (check)
            {
                supplierProductsBUS.EditSupplierProduct(new SupplierProductsDTO
                {
                    ProductId = supplierProductID,
                    ProductName = name,
                    ProductTypeID = int.Parse(typeId),
                    Brand = brand,
                    CountryOfOrigin = countryOfOrigin,
                    Price = decimal.Parse(price),
                    StockQuantity = int.Parse(quantity),
                    Unit = unit,
                    Description = description,
                    Ingredients = ingredient,
                    Benefits = benefit,
                    Weight = decimal.Parse(weight),
                    Flavor = flavor,
                    ManufactureDate = manufactureDate,
                    ExpirationDate = expirationDate,
                    ImageUrl = null,
                    Status = status,
                    SupplierID = supplierID
                });
                resetFormSupplierProduct();
                load_suppier_products(supplierID);
                button6.Enabled = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ListViewItem selectedSupplier = listView1.SelectedItems[0];
            int supplierID = int.Parse(selectedSupplier.SubItems[0].Text);
            ListViewItem selectedSupplierProduct = listView2.SelectedItems[0];
            int supplierProductID = int.Parse(selectedSupplierProduct.SubItems[0].Text);
            supplierProductsBUS.DeleteSupplierProduct(supplierProductID);
            resetFormSupplierProduct();
            load_suppier_products(supplierID);
            button7.Enabled = false;
        }
    }
}
