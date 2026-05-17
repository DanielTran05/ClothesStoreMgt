namespace ClothesStore.GUI.StaffForms
{
    partial class CreateOrderForm
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
            panel1 = new Panel();
            checkPhone = new Button();
            Phone = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            dgvCart = new DataGridView();
            CreateOrder = new Button();
            panel3 = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            cboSearchType = new ComboBox();
            dgvInventory = new DataGridView();
            panel4 = new Panel();
            cboPayment = new ComboBox();
            cboShipping = new ComboBox();
            txtAddress = new TextBox();
            txtReceiverName = new TextBox();
            btnAddToCart = new Button();
            count = new NumericUpDown();
            label2 = new Label();
            lbTotalPrice = new Label();
            back = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)count).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(checkPhone);
            panel1.Controls.Add(Phone);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(474, 40);
            panel1.TabIndex = 0;
            // 
            // checkPhone
            // 
            checkPhone.Location = new Point(348, 8);
            checkPhone.Name = "checkPhone";
            checkPhone.Size = new Size(103, 29);
            checkPhone.TabIndex = 2;
            checkPhone.Text = "Kiểm tra";
            checkPhone.UseVisualStyleBackColor = true;
            checkPhone.Click += checkPhone_Click;
            // 
            // Phone
            // 
            Phone.Location = new Point(154, 8);
            Phone.Name = "Phone";
            Phone.Size = new Size(163, 27);
            Phone.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 8);
            label1.Name = "label1";
            label1.Size = new Size(138, 20);
            label1.TabIndex = 0;
            label1.Text = "Nhập số điện thoại:";
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvCart);
            panel2.Location = new Point(826, 67);
            panel2.Name = "panel2";
            panel2.Size = new Size(607, 580);
            panel2.TabIndex = 1;
            // 
            // dgvCart
            // 
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(3, 3);
            dgvCart.Name = "dgvCart";
            dgvCart.RowHeadersWidth = 51;
            dgvCart.Size = new Size(601, 574);
            dgvCart.TabIndex = 0;
            // 
            // CreateOrder
            // 
            CreateOrder.AutoEllipsis = true;
            CreateOrder.Location = new Point(1323, 2);
            CreateOrder.Name = "CreateOrder";
            CreateOrder.Size = new Size(110, 59);
            CreateOrder.TabIndex = 2;
            CreateOrder.Text = "Xác nhận tạo đơn hàng";
            CreateOrder.UseVisualStyleBackColor = true;
            CreateOrder.Click += CreateOrder_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblSearch);
            panel3.Controls.Add(txtSearch);
            panel3.Controls.Add(cboSearchType);
            panel3.Controls.Add(dgvInventory);
            panel3.Location = new Point(2, 179);
            panel3.Name = "panel3";
            panel3.Size = new Size(818, 435);
            panel3.TabIndex = 3;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(443, 18);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(56, 20);
            lblSearch.TabIndex = 3;
            lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(523, 11);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(161, 27);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            // 
            // cboSearchType
            // 
            cboSearchType.FormattingEnabled = true;
            cboSearchType.Location = new Point(166, 12);
            cboSearchType.Name = "cboSearchType";
            cboSearchType.Size = new Size(151, 28);
            cboSearchType.TabIndex = 1;
            cboSearchType.SelectedIndexChanged += cboSearchType_SelectedIndexChanged;
            // 
            // dgvInventory
            // 
            dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventory.Location = new Point(0, 61);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.RowHeadersWidth = 51;
            dgvInventory.Size = new Size(812, 371);
            dgvInventory.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(cboPayment);
            panel4.Controls.Add(cboShipping);
            panel4.Controls.Add(txtAddress);
            panel4.Controls.Add(txtReceiverName);
            panel4.Location = new Point(2, 48);
            panel4.Name = "panel4";
            panel4.Size = new Size(818, 125);
            panel4.TabIndex = 4;
            // 
            // cboPayment
            // 
            cboPayment.FormattingEnabled = true;
            cboPayment.Location = new Point(412, 68);
            cboPayment.Name = "cboPayment";
            cboPayment.Size = new Size(232, 28);
            cboPayment.TabIndex = 1;
            // 
            // cboShipping
            // 
            cboShipping.FormattingEnabled = true;
            cboShipping.Location = new Point(412, 19);
            cboShipping.Name = "cboShipping";
            cboShipping.Size = new Size(232, 28);
            cboShipping.TabIndex = 1;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(52, 68);
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "Địa chỉ";
            txtAddress.Size = new Size(229, 27);
            txtAddress.TabIndex = 0;
            // 
            // txtReceiverName
            // 
            txtReceiverName.Location = new Point(52, 20);
            txtReceiverName.Name = "txtReceiverName";
            txtReceiverName.PlaceholderText = "Họ tên";
            txtReceiverName.Size = new Size(229, 27);
            txtReceiverName.TabIndex = 0;
            // 
            // btnAddToCart
            // 
            btnAddToCart.Location = new Point(555, 10);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(142, 29);
            btnAddToCart.TabIndex = 5;
            btnAddToCart.Text = "Thêm sản phẩm";
            btnAddToCart.UseVisualStyleBackColor = true;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // count
            // 
            count.Location = new Point(721, 11);
            count.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            count.Name = "count";
            count.Size = new Size(150, 27);
            count.TabIndex = 6;
            count.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(914, 23);
            label2.Name = "label2";
            label2.Size = new Size(126, 27);
            label2.TabIndex = 7;
            label2.Text = "Tổng tiền:";
            // 
            // lbTotalPrice
            // 
            lbTotalPrice.AutoSize = true;
            lbTotalPrice.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTotalPrice.ForeColor = Color.Red;
            lbTotalPrice.Location = new Point(1056, 23);
            lbTotalPrice.Name = "lbTotalPrice";
            lbTotalPrice.Size = new Size(0, 27);
            lbTotalPrice.TabIndex = 8;
            // 
            // back
            // 
            back.Location = new Point(12, 617);
            back.Name = "back";
            back.Size = new Size(94, 29);
            back.TabIndex = 9;
            back.Text = "Quay lại";
            back.UseVisualStyleBackColor = true;
            back.Click += back_Click;
            // 
            // CreateOrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1432, 653);
            Controls.Add(back);
            Controls.Add(lbTotalPrice);
            Controls.Add(label2);
            Controls.Add(count);
            Controls.Add(btnAddToCart);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(CreateOrder);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "CreateOrderForm";
            Text = "CreateOrderForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)count).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button checkPhone;
        private TextBox Phone;
        private Label label1;
        private Panel panel2;
        private Button CreateOrder;
        private Panel panel3;
        private ComboBox cboSearchType;
        private DataGridView dgvInventory;
        private Panel panel4;
        private ComboBox cboPayment;
        private ComboBox cboShipping;
        private TextBox txtAddress;
        private TextBox txtReceiverName;
        private Button btnAddToCart;
        private DataGridView dgvCart;
        private TextBox txtSearch;
        private Label lblSearch;
        private NumericUpDown count;
        private Label label2;
        private Label lbTotalPrice;
        private Button back;
    }
}