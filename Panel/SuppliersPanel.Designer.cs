
namespace SieuThiMini.Panel
{
    partial class SuppliersPanel
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
            label1 = new Label();
            textBox1 = new TextBox();
            button4 = new Button();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader21 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            button3 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            listView2 = new ListView();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader11 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            columnHeader13 = new ColumnHeader();
            columnHeader14 = new ColumnHeader();
            columnHeader15 = new ColumnHeader();
            columnHeader16 = new ColumnHeader();
            columnHeader17 = new ColumnHeader();
            columnHeader18 = new ColumnHeader();
            columnHeader19 = new ColumnHeader();
            columnHeader20 = new ColumnHeader();
            tableLayoutPanel2 = new TableLayoutPanel();
            flavorInput = new TextBox();
            weightInput = new TextBox();
            benefitInput = new TextBox();
            ingredientInput = new TextBox();
            descriptionInput = new TextBox();
            unitInput = new TextBox();
            quantityInput = new TextBox();
            priceInput = new TextBox();
            countryOriginInput = new TextBox();
            brandInput = new TextBox();
            productTypeInput = new TextBox();
            productNameInput = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            statusInput = new ComboBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            supplierAddressInput = new TextBox();
            supplierPhoneInput = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            supplierNameInput = new TextBox();
            label6 = new Label();
            supplierEmailInput = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label1, 3);
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(1031, 56);
            label1.TabIndex = 1;
            label1.Text = "Nhà cung cấp";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(757, 12);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Nhập tên nhà cung cấp";
            textBox1.Size = new Size(190, 23);
            textBox1.TabIndex = 6;
            // 
            // button4
            // 
            button4.Location = new Point(953, 12);
            button4.Name = "button4";
            button4.Size = new Size(84, 24);
            button4.TabIndex = 7;
            button4.Text = "Tìm kiếm";
            button4.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.AutoArrange = false;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader21, columnHeader4 });
            tableLayoutPanel1.SetColumnSpan(listView1, 2);
            listView1.Dock = DockStyle.Fill;
            listView1.FullRowSelect = true;
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView1.Location = new Point(349, 115);
            listView1.Name = "listView1";
            listView1.Size = new Size(685, 106);
            listView1.TabIndex = 8;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.ItemActivate += listView1_itemActivate;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Tên";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "SDT";
            columnHeader3.Width = 100;
            // 
            // columnHeader21
            // 
            columnHeader21.Text = "Email";
            columnHeader21.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Địa chỉ";
            columnHeader4.Width = 450;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(128, 255, 128);
            button1.Dock = DockStyle.Fill;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(3, 59);
            button1.Name = "button1";
            button1.Size = new Size(340, 50);
            button1.TabIndex = 17;
            button1.Text = "Thêm";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_2;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(128, 128, 255);
            button2.Dock = DockStyle.Fill;
            button2.Enabled = false;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(349, 59);
            button2.Name = "button2";
            button2.Size = new Size(338, 50);
            button2.TabIndex = 18;
            button2.Text = "Sửa";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label2, 3);
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(3, 224);
            label2.Name = "label2";
            label2.Size = new Size(1031, 56);
            label2.TabIndex = 20;
            label2.Text = "Sản Phẩm";
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(255, 128, 128);
            button3.Dock = DockStyle.Fill;
            button3.Enabled = false;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(693, 59);
            button3.Name = "button3";
            button3.Size = new Size(341, 50);
            button3.TabIndex = 21;
            button3.Text = "Xóa";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(128, 255, 128);
            button5.Dock = DockStyle.Fill;
            button5.Enabled = false;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Location = new Point(3, 283);
            button5.Name = "button5";
            button5.Size = new Size(340, 50);
            button5.TabIndex = 22;
            button5.Text = "Thêm";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(128, 128, 255);
            button6.Dock = DockStyle.Fill;
            button6.Enabled = false;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Location = new Point(349, 283);
            button6.Name = "button6";
            button6.Size = new Size(338, 50);
            button6.TabIndex = 23;
            button6.Text = "Sửa";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(255, 128, 128);
            button7.Dock = DockStyle.Fill;
            button7.Enabled = false;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Location = new Point(693, 283);
            button7.Name = "button7";
            button7.Size = new Size(341, 50);
            button7.TabIndex = 24;
            button7.Text = "Xóa";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.408432F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.21532F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3762436F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(button3, 2, 1);
            tableLayoutPanel1.Controls.Add(button2, 1, 1);
            tableLayoutPanel1.Controls.Add(button7, 2, 4);
            tableLayoutPanel1.Controls.Add(button6, 1, 4);
            tableLayoutPanel1.Controls.Add(button1, 0, 1);
            tableLayoutPanel1.Controls.Add(button5, 0, 4);
            tableLayoutPanel1.Controls.Add(label2, 0, 3);
            tableLayoutPanel1.Controls.Add(listView1, 1, 2);
            tableLayoutPanel1.Controls.Add(listView2, 1, 5);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 5);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1037, 562);
            tableLayoutPanel1.TabIndex = 27;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // listView2
            // 
            listView2.AutoArrange = false;
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader5, columnHeader6, columnHeader7, columnHeader8, columnHeader9, columnHeader10, columnHeader11, columnHeader12, columnHeader13, columnHeader14, columnHeader15, columnHeader16, columnHeader17, columnHeader18, columnHeader19, columnHeader20 });
            tableLayoutPanel1.SetColumnSpan(listView2, 2);
            listView2.Dock = DockStyle.Fill;
            listView2.FullRowSelect = true;
            listView2.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView2.Location = new Point(349, 339);
            listView2.Name = "listView2";
            listView2.Size = new Size(685, 220);
            listView2.TabIndex = 25;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            listView2.ItemActivate += listView2_itemActivate;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "ID";
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Tên";
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Mã loại sản phẩm";
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Thương hiệu";
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Nơi sản xuất";
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Giá";
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "Số lượng tồn kho";
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "Đơn vị tính";
            // 
            // columnHeader13
            // 
            columnHeader13.Text = "Mô tả";
            // 
            // columnHeader14
            // 
            columnHeader14.Text = "Thành phần";
            // 
            // columnHeader15
            // 
            columnHeader15.Text = "Lợi ích";
            // 
            // columnHeader16
            // 
            columnHeader16.Text = "Khối lượng";
            // 
            // columnHeader17
            // 
            columnHeader17.Text = "Hương vị";
            // 
            // columnHeader18
            // 
            columnHeader18.Text = "Trạng thái";
            // 
            // columnHeader19
            // 
            columnHeader19.Text = "Ngày sản xuất";
            // 
            // columnHeader20
            // 
            columnHeader20.Text = "Ngày hết hạn";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Controls.Add(flavorInput, 2, 3);
            tableLayoutPanel2.Controls.Add(weightInput, 1, 3);
            tableLayoutPanel2.Controls.Add(benefitInput, 0, 3);
            tableLayoutPanel2.Controls.Add(ingredientInput, 2, 2);
            tableLayoutPanel2.Controls.Add(descriptionInput, 1, 2);
            tableLayoutPanel2.Controls.Add(unitInput, 0, 2);
            tableLayoutPanel2.Controls.Add(quantityInput, 2, 1);
            tableLayoutPanel2.Controls.Add(priceInput, 1, 1);
            tableLayoutPanel2.Controls.Add(countryOriginInput, 0, 1);
            tableLayoutPanel2.Controls.Add(brandInput, 2, 0);
            tableLayoutPanel2.Controls.Add(productTypeInput, 1, 0);
            tableLayoutPanel2.Controls.Add(productNameInput, 0, 0);
            tableLayoutPanel2.Controls.Add(dateTimePicker1, 0, 4);
            tableLayoutPanel2.Controls.Add(dateTimePicker2, 1, 4);
            tableLayoutPanel2.Controls.Add(statusInput, 2, 4);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 339);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 5;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.Size = new Size(340, 220);
            tableLayoutPanel2.TabIndex = 30;
            // 
            // flavorInput
            // 
            flavorInput.Dock = DockStyle.Fill;
            flavorInput.Location = new Point(229, 135);
            flavorInput.Name = "flavorInput";
            flavorInput.PlaceholderText = "Hương vị";
            flavorInput.Size = new Size(108, 23);
            flavorInput.TabIndex = 11;
            // 
            // weightInput
            // 
            weightInput.Dock = DockStyle.Fill;
            weightInput.Location = new Point(116, 135);
            weightInput.Name = "weightInput";
            weightInput.PlaceholderText = "Trọng lượng";
            weightInput.Size = new Size(107, 23);
            weightInput.TabIndex = 10;
            // 
            // benefitInput
            // 
            benefitInput.Dock = DockStyle.Fill;
            benefitInput.Location = new Point(3, 135);
            benefitInput.Name = "benefitInput";
            benefitInput.PlaceholderText = "Lợi ích";
            benefitInput.Size = new Size(107, 23);
            benefitInput.TabIndex = 9;
            // 
            // ingredientInput
            // 
            ingredientInput.Dock = DockStyle.Fill;
            ingredientInput.Location = new Point(229, 91);
            ingredientInput.Name = "ingredientInput";
            ingredientInput.PlaceholderText = "Thành phần";
            ingredientInput.Size = new Size(108, 23);
            ingredientInput.TabIndex = 8;
            // 
            // descriptionInput
            // 
            descriptionInput.Dock = DockStyle.Fill;
            descriptionInput.Location = new Point(116, 91);
            descriptionInput.Name = "descriptionInput";
            descriptionInput.PlaceholderText = "Mô tả";
            descriptionInput.Size = new Size(107, 23);
            descriptionInput.TabIndex = 7;
            // 
            // unitInput
            // 
            unitInput.Dock = DockStyle.Fill;
            unitInput.Location = new Point(3, 91);
            unitInput.Name = "unitInput";
            unitInput.PlaceholderText = "Đơn vị";
            unitInput.Size = new Size(107, 23);
            unitInput.TabIndex = 6;
            // 
            // quantityInput
            // 
            quantityInput.Dock = DockStyle.Fill;
            quantityInput.Location = new Point(229, 47);
            quantityInput.Name = "quantityInput";
            quantityInput.PlaceholderText = "Số lượng";
            quantityInput.Size = new Size(108, 23);
            quantityInput.TabIndex = 5;
            // 
            // priceInput
            // 
            priceInput.Dock = DockStyle.Fill;
            priceInput.Location = new Point(116, 47);
            priceInput.Name = "priceInput";
            priceInput.PlaceholderText = "Giá";
            priceInput.Size = new Size(107, 23);
            priceInput.TabIndex = 4;
            // 
            // countryOriginInput
            // 
            countryOriginInput.Dock = DockStyle.Fill;
            countryOriginInput.Location = new Point(3, 47);
            countryOriginInput.Name = "countryOriginInput";
            countryOriginInput.PlaceholderText = "Nơi sản xuất";
            countryOriginInput.Size = new Size(107, 23);
            countryOriginInput.TabIndex = 3;
            // 
            // brandInput
            // 
            brandInput.Dock = DockStyle.Fill;
            brandInput.Location = new Point(229, 3);
            brandInput.Name = "brandInput";
            brandInput.PlaceholderText = "Thương hiệu";
            brandInput.Size = new Size(108, 23);
            brandInput.TabIndex = 2;
            // 
            // productTypeInput
            // 
            productTypeInput.Dock = DockStyle.Fill;
            productTypeInput.Location = new Point(116, 3);
            productTypeInput.Name = "productTypeInput";
            productTypeInput.PlaceholderText = "Mã loại sản phẩm";
            productTypeInput.Size = new Size(107, 23);
            productTypeInput.TabIndex = 1;
            // 
            // productNameInput
            // 
            productNameInput.Dock = DockStyle.Fill;
            productNameInput.Location = new Point(3, 3);
            productNameInput.Name = "productNameInput";
            productNameInput.PlaceholderText = "Tên";
            productNameInput.Size = new Size(107, 23);
            productNameInput.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(3, 179);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(107, 23);
            dateTimePicker1.TabIndex = 17;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(116, 179);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(107, 23);
            dateTimePicker2.TabIndex = 18;
            // 
            // statusInput
            // 
            statusInput.FormattingEnabled = true;
            statusInput.Items.AddRange(new object[] { "Available", "Unavailable" });
            statusInput.Location = new Point(229, 179);
            statusInput.Name = "statusInput";
            statusInput.Size = new Size(107, 23);
            statusInput.TabIndex = 16;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.9999962F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0000076F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanel3.Controls.Add(supplierAddressInput, 1, 2);
            tableLayoutPanel3.Controls.Add(supplierPhoneInput, 1, 1);
            tableLayoutPanel3.Controls.Add(label3, 0, 0);
            tableLayoutPanel3.Controls.Add(label4, 0, 1);
            tableLayoutPanel3.Controls.Add(label5, 0, 2);
            tableLayoutPanel3.Controls.Add(supplierNameInput, 1, 0);
            tableLayoutPanel3.Controls.Add(label6, 0, 3);
            tableLayoutPanel3.Controls.Add(supplierEmailInput, 1, 3);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 115);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 4;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.Size = new Size(340, 106);
            tableLayoutPanel3.TabIndex = 31;
            // 
            // supplierAddressInput
            // 
            supplierAddressInput.Dock = DockStyle.Fill;
            supplierAddressInput.Location = new Point(167, 55);
            supplierAddressInput.Name = "supplierAddressInput";
            supplierAddressInput.Size = new Size(159, 23);
            supplierAddressInput.TabIndex = 28;
            // 
            // supplierPhoneInput
            // 
            supplierPhoneInput.Dock = DockStyle.Fill;
            supplierPhoneInput.Location = new Point(167, 29);
            supplierPhoneInput.Name = "supplierPhoneInput";
            supplierPhoneInput.Size = new Size(159, 23);
            supplierPhoneInput.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(158, 26);
            label3.TabIndex = 0;
            label3.Text = "Tên";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 26);
            label4.Name = "label4";
            label4.Size = new Size(158, 26);
            label4.TabIndex = 1;
            label4.Text = "SDT";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 52);
            label5.Name = "label5";
            label5.Size = new Size(158, 26);
            label5.TabIndex = 2;
            label5.Text = "Địa chỉ";
            // 
            // supplierNameInput
            // 
            supplierNameInput.Dock = DockStyle.Fill;
            supplierNameInput.Location = new Point(167, 3);
            supplierNameInput.Name = "supplierNameInput";
            supplierNameInput.Size = new Size(159, 23);
            supplierNameInput.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(3, 78);
            label6.Name = "label6";
            label6.Size = new Size(158, 28);
            label6.TabIndex = 29;
            label6.Text = "Email";
            // 
            // supplierEmailInput
            // 
            supplierEmailInput.Dock = DockStyle.Fill;
            supplierEmailInput.Location = new Point(167, 81);
            supplierEmailInput.Name = "supplierEmailInput";
            supplierEmailInput.Size = new Size(159, 23);
            supplierEmailInput.TabIndex = 30;
            // 
            // SuppliersPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1037, 562);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(button4);
            Controls.Add(textBox1);
            MaximizeBox = false;
            Name = "SuppliersPanel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += SuppliersPanel_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void SuppliersPanel_Load(object sender, EventArgs e)
        {
            
        }

        #endregion
        private Label label1;
        private TextBox textBox1;
        private Button button4;
        private ListView listView1;
        private Button button1;
        private Button button2;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Label label2;
        private Button button3;
        private Button button5;
        private Button button6;
        private Button button7;
        private TableLayoutPanel tableLayoutPanel1;
        private ListView listView2;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader16;
        private ColumnHeader columnHeader17;
        private ColumnHeader columnHeader18;
        private ColumnHeader columnHeader19;
        private ColumnHeader columnHeader20;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox textBox15;
        private TextBox textBox14;
        private TextBox flavorInput;
        private TextBox weightInput;
        private TextBox benefitInput;
        private TextBox ingredientInput;
        private TextBox descriptionInput;
        private TextBox unitInput;
        private TextBox quantityInput;
        private TextBox priceInput;
        private TextBox countryOriginInput;
        private TextBox brandInput;
        private TextBox productTypeInput;
        private TextBox productNameInput;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox supplierAddressInput;
        private TextBox supplierPhoneInput;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox supplierNameInput;
        private ColumnHeader columnHeader21;
        private Label label6;
        private TextBox supplierEmailInput;
        private ComboBox statusInput;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
    }
}