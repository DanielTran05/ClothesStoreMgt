namespace ClothesStore.GUI.StaffForms
{
    partial class EditOrderForm
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
            panel3 = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            cboSearchType = new ComboBox();
            dgvInventory = new DataGridView();
            btnBack = new Button();
            panel4 = new Panel();
            cboPayment = new ComboBox();
            cboShipping = new ComboBox();
            txtAddress = new TextBox();
            txtCustomerName = new TextBox();
            dgvOrderDetails = new DataGridView();
            btnAddToCart = new Button();
            btnRemoveFromCart = new Button();
            count = new NumericUpDown();
            lbTotalPrice = new Label();
            label2 = new Label();
            button3 = new Button();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).BeginInit();
            ((System.ComponentModel.ISupportInitialize)count).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.Controls.Add(lblSearch);
            panel3.Controls.Add(txtSearch);
            panel3.Controls.Add(cboSearchType);
            panel3.Controls.Add(dgvInventory);
            panel3.Location = new Point(2, 178);
            panel3.Name = "panel3";
            panel3.Size = new Size(818, 436);
            panel3.TabIndex = 4;
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
            txtSearch.TextChanged += txtSearch_TextChanged;
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
            dgvInventory.Size = new Size(812, 372);
            dgvInventory.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 617);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 5;
            btnBack.Text = "Quay lại";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(cboPayment);
            panel4.Controls.Add(cboShipping);
            panel4.Controls.Add(txtAddress);
            panel4.Controls.Add(txtCustomerName);
            panel4.Location = new Point(2, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(818, 125);
            panel4.TabIndex = 6;
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
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(52, 20);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.PlaceholderText = "Họ tên";
            txtCustomerName.Size = new Size(229, 27);
            txtCustomerName.TabIndex = 0;
            // 
            // dgvOrderDetails
            // 
            dgvOrderDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderDetails.Location = new Point(826, 81);
            dgvOrderDetails.Name = "dgvOrderDetails";
            dgvOrderDetails.RowHeadersWidth = 51;
            dgvOrderDetails.Size = new Size(601, 565);
            dgvOrderDetails.TabIndex = 7;
            // 
            // btnAddToCart
            // 
            btnAddToCart.AutoSize = true;
            btnAddToCart.Location = new Point(30, 134);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(124, 30);
            btnAddToCart.TabIndex = 8;
            btnAddToCart.Text = "Thêm sản phẩm";
            btnAddToCart.UseVisualStyleBackColor = true;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // btnRemoveFromCart
            // 
            btnRemoveFromCart.AutoSize = true;
            btnRemoveFromCart.Location = new Point(202, 135);
            btnRemoveFromCart.Name = "btnRemoveFromCart";
            btnRemoveFromCart.Size = new Size(110, 30);
            btnRemoveFromCart.TabIndex = 9;
            btnRemoveFromCart.Text = "Bớt sản phẩm";
            btnRemoveFromCart.UseVisualStyleBackColor = true;
            btnRemoveFromCart.Click += btnRemoveFromCart_Click;
            // 
            // count
            // 
            count.Location = new Point(400, 138);
            count.Name = "count";
            count.Size = new Size(150, 27);
            count.TabIndex = 10;
            // 
            // lbTotalPrice
            // 
            lbTotalPrice.AutoSize = true;
            lbTotalPrice.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTotalPrice.ForeColor = Color.Red;
            lbTotalPrice.Location = new Point(1048, 23);
            lbTotalPrice.Name = "lbTotalPrice";
            lbTotalPrice.Size = new Size(0, 27);
            lbTotalPrice.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(875, 23);
            label2.Name = "label2";
            label2.Size = new Size(137, 27);
            label2.TabIndex = 11;
            label2.Text = "Total Price:";
            // 
            // button3
            // 
            button3.Location = new Point(1326, 4);
            button3.Name = "button3";
            button3.Size = new Size(94, 71);
            button3.TabIndex = 13;
            button3.Text = "Confirm to edit";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // EditOrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1432, 653);
            Controls.Add(button3);
            Controls.Add(lbTotalPrice);
            Controls.Add(label2);
            Controls.Add(count);
            Controls.Add(btnRemoveFromCart);
            Controls.Add(btnAddToCart);
            Controls.Add(dgvOrderDetails);
            Controls.Add(panel4);
            Controls.Add(btnBack);
            Controls.Add(panel3);
            Name = "EditOrderForm";
            Text = "EditOrderForm";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).EndInit();
            ((System.ComponentModel.ISupportInitialize)count).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel3;
        private Label lblSearch;
        private TextBox txtSearch;
        private ComboBox cboSearchType;
        private DataGridView dgvInventory;
        private Button btnBack;
        private Panel panel4;
        private ComboBox cboPayment;
        private ComboBox cboShipping;
        private TextBox txtAddress;
        private TextBox txtCustomerName;
        private DataGridView dgvOrderDetails;
        private Button btnAddToCart;
        private Button btnRemoveFromCart;
        private NumericUpDown count;
        private Label lbTotalPrice;
        private Label label2;
        private Button button3;
    }
}