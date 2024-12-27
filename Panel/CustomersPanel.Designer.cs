namespace SieuThiMini.Panel
{
    partial class CustomersPanel
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
            btnReset = new Button();
            btnUnlock = new Button();
            btnLock = new Button();
            btnDel = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            ViewKH = new DataGridView();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            txtSĐT = new TextBox();
            txtName = new TextBox();
            txtId = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)ViewKH).BeginInit();
            SuspendLayout();
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            btnReset.Location = new Point(362, 381);
            btnReset.Margin = new Padding(3, 4, 3, 4);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(111, 55);
            btnReset.TabIndex = 25;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnUnlock
            // 
            btnUnlock.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            btnUnlock.Location = new Point(362, 319);
            btnUnlock.Margin = new Padding(3, 4, 3, 4);
            btnUnlock.Name = "btnUnlock";
            btnUnlock.Size = new Size(111, 55);
            btnUnlock.TabIndex = 24;
            btnUnlock.Text = "UnLock";
            btnUnlock.UseVisualStyleBackColor = true;
            btnUnlock.Click += btnUnlock_Click;
            // 
            // btnLock
            // 
            btnLock.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            btnLock.Location = new Point(362, 256);
            btnLock.Margin = new Padding(3, 4, 3, 4);
            btnLock.Name = "btnLock";
            btnLock.Size = new Size(111, 55);
            btnLock.TabIndex = 23;
            btnLock.Text = "Lock";
            btnLock.UseVisualStyleBackColor = true;
            btnLock.Click += btnLock_Click;
            // 
            // btnDel
            // 
            btnDel.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            btnDel.Location = new Point(362, 193);
            btnDel.Margin = new Padding(3, 4, 3, 4);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(111, 55);
            btnDel.TabIndex = 22;
            btnDel.Text = "Xóa";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            btnEdit.Location = new Point(362, 131);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(111, 55);
            btnEdit.TabIndex = 21;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.Location = new Point(362, 68);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(111, 55);
            btnAdd.TabIndex = 20;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // ViewKH
            // 
            ViewKH.AllowUserToDeleteRows = false;
            ViewKH.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ViewKH.Location = new Point(24, 469);
            ViewKH.Margin = new Padding(3, 4, 3, 4);
            ViewKH.Name = "ViewKH";
            ViewKH.ReadOnly = true;
            ViewKH.RowHeadersWidth = 51;
            ViewKH.RowTemplate.Height = 25;
            ViewKH.Size = new Size(449, 200);
            ViewKH.TabIndex = 19;
            ViewKH.CellContentClick += ViewKH_CellContentClick;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(145, 291);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(196, 41);
            txtPassword.TabIndex = 17;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(145, 237);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(196, 41);
            txtEmail.TabIndex = 18;
            // 
            // txtSĐT
            // 
            txtSĐT.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            txtSĐT.Location = new Point(145, 184);
            txtSĐT.Margin = new Padding(3, 4, 3, 4);
            txtSĐT.Name = "txtSĐT";
            txtSĐT.Size = new Size(196, 41);
            txtSĐT.TabIndex = 16;
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            txtName.Location = new Point(145, 131);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.Size = new Size(196, 41);
            txtName.TabIndex = 15;
            // 
            // txtId
            // 
            txtId.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            txtId.Location = new Point(145, 77);
            txtId.Margin = new Padding(3, 4, 3, 4);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(196, 41);
            txtId.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(24, 192);
            label6.Name = "label6";
            label6.Size = new Size(59, 35);
            label6.TabIndex = 10;
            label6.Text = "SĐT";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(24, 299);
            label5.Name = "label5";
            label5.Size = new Size(120, 35);
            label5.TabIndex = 9;
            label5.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(24, 245);
            label4.Name = "label4";
            label4.Size = new Size(75, 35);
            label4.TabIndex = 8;
            label4.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(24, 139);
            label3.Name = "label3";
            label3.Size = new Size(93, 35);
            label3.TabIndex = 7;
            label3.Text = "Tên KH";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(24, 85);
            label2.Name = "label2";
            label2.Size = new Size(90, 35);
            label2.TabIndex = 12;
            label2.Text = "Mã KH";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(24, 25);
            label1.Name = "label1";
            label1.Size = new Size(361, 35);
            label1.TabIndex = 6;
            label1.Text = "Quản lý thông tin khách hàng";
            // 
            // CustomersPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 705);
            Controls.Add(btnReset);
            Controls.Add(btnUnlock);
            Controls.Add(btnLock);
            Controls.Add(btnDel);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(ViewKH);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(txtSĐT);
            Controls.Add(txtName);
            Controls.Add(txtId);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CustomersPanel";
            Text = "CustomersPanel";
            Load += CustomersPanel_Load;
            ((System.ComponentModel.ISupportInitialize)ViewKH).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnReset;
        private Button btnUnlock;
        private Button btnLock;
        private Button btnDel;
        private Button btnEdit;
        private Button btnAdd;
        private DataGridView ViewKH;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private TextBox txtSĐT;
        private TextBox txtName;
        private TextBox txtId;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}