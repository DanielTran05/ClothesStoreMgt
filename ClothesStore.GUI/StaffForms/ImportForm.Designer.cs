namespace ClothesStore.GUI.StaffForms
{
    partial class ImportForm
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
            cbSupplier = new ComboBox();
            btnCreateReceipt = new Button();
            dgvDetail = new DataGridView();
            txtQuantity = new TextBox();
            txtPrice = new TextBox();
            btnAddDetail = new Button();
            lbPrice = new Label();
            lbQuantity = new Label();
            cbVariant = new ComboBox();
            dgvHistory = new DataGridView();
            lblHistory = new Label();
            dtImportDate = new DateTimePicker();
            lblVariant = new Label();
            cbFilterType = new ComboBox();
            lblFilterType = new Label();
            lblDate = new Label();
            lblSupplier = new Label();
            txtSearch = new TextBox();
            lblSearch = new Label();
            btnViewDetail = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDetail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            SuspendLayout();
            // 
            // cbSupplier
            // 
            cbSupplier.FormattingEnabled = true;
            cbSupplier.Location = new Point(86, 22);
            cbSupplier.Name = "cbSupplier";
            cbSupplier.Size = new Size(269, 28);
            cbSupplier.TabIndex = 0;
            // 
            // btnCreateReceipt
            // 
            btnCreateReceipt.Location = new Point(1264, 338);
            btnCreateReceipt.Name = "btnCreateReceipt";
            btnCreateReceipt.Size = new Size(156, 38);
            btnCreateReceipt.TabIndex = 1;
            btnCreateReceipt.Text = "Create Receipt";
            btnCreateReceipt.UseVisualStyleBackColor = true;
            btnCreateReceipt.Click += btnCreateReceipt_Click;
            // 
            // dgvDetail
            // 
            dgvDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetail.Location = new Point(12, 102);
            dgvDetail.Name = "dgvDetail";
            dgvDetail.RowHeadersWidth = 51;
            dgvDetail.Size = new Size(1408, 230);
            dgvDetail.TabIndex = 2;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(340, 60);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(125, 27);
            txtQuantity.TabIndex = 3;
            txtQuantity.KeyPress += txtQuantity_KeyPress;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(553, 59);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(140, 27);
            txtPrice.TabIndex = 3;
            txtPrice.KeyPress += txtPrice_KeyPress;
            // 
            // btnAddDetail
            // 
            btnAddDetail.Location = new Point(703, 56);
            btnAddDetail.Name = "btnAddDetail";
            btnAddDetail.Size = new Size(94, 28);
            btnAddDetail.TabIndex = 4;
            btnAddDetail.Text = "Add detail";
            btnAddDetail.UseVisualStyleBackColor = true;
            btnAddDetail.Click += btnAddDetail_Click;
            // 
            // lbPrice
            // 
            lbPrice.Location = new Point(489, 60);
            lbPrice.Name = "lbPrice";
            lbPrice.Size = new Size(49, 27);
            lbPrice.TabIndex = 5;
            lbPrice.Text = "Price:";
            // 
            // lbQuantity
            // 
            lbQuantity.Location = new Point(246, 59);
            lbQuantity.Name = "lbQuantity";
            lbQuantity.Size = new Size(88, 27);
            lbQuantity.TabIndex = 5;
            lbQuantity.Text = "Quantity:";
            // 
            // cbVariant
            // 
            cbVariant.FormattingEnabled = true;
            cbVariant.Location = new Point(77, 59);
            cbVariant.Name = "cbVariant";
            cbVariant.Size = new Size(151, 28);
            cbVariant.TabIndex = 6;
            // 
            // dgvHistory
            // 
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistory.Location = new Point(12, 414);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.RowHeadersWidth = 51;
            dgvHistory.Size = new Size(1408, 230);
            dgvHistory.TabIndex = 2;
            // 
            // lblHistory
            // 
            lblHistory.AutoSize = true;
            lblHistory.Location = new Point(12, 383);
            lblHistory.Name = "lblHistory";
            lblHistory.Size = new Size(59, 20);
            lblHistory.TabIndex = 7;
            lblHistory.Text = "History:";
            // 
            // dtImportDate
            // 
            dtImportDate.Location = new Point(603, 386);
            dtImportDate.Name = "dtImportDate";
            dtImportDate.Size = new Size(262, 27);
            dtImportDate.TabIndex = 8;
            dtImportDate.ValueChanged += dtImportDate_ValueChanged;
            // 
            // lblVariant
            // 
            lblVariant.AutoSize = true;
            lblVariant.Location = new Point(13, 62);
            lblVariant.Name = "lblVariant";
            lblVariant.Size = new Size(58, 20);
            lblVariant.TabIndex = 9;
            lblVariant.Text = "Varient:";
            // 
            // cbFilterType
            // 
            cbFilterType.FormattingEnabled = true;
            cbFilterType.Location = new Point(147, 383);
            cbFilterType.Name = "cbFilterType";
            cbFilterType.Size = new Size(151, 28);
            cbFilterType.TabIndex = 6;
            cbFilterType.SelectedIndexChanged += cbFilterType_SelectedIndexChanged;
            // 
            // lblFilterType
            // 
            lblFilterType.Location = new Point(77, 385);
            lblFilterType.Name = "lblFilterType";
            lblFilterType.Size = new Size(87, 27);
            lblFilterType.TabIndex = 5;
            lblFilterType.Text = "Filter by:";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(553, 391);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(44, 20);
            lblDate.TabIndex = 10;
            lblDate.Text = "Date:";
            // 
            // lblSupplier
            // 
            lblSupplier.AutoSize = true;
            lblSupplier.Location = new Point(15, 25);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(67, 20);
            lblSupplier.TabIndex = 11;
            lblSupplier.Text = "Supplier:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(413, 385);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(125, 27);
            txtSearch.TabIndex = 12;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.Location = new Point(340, 385);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(67, 27);
            lblSearch.TabIndex = 5;
            lblSearch.Text = "Search:";
            // 
            // btnViewDetail
            // 
            btnViewDetail.Location = new Point(1252, 650);
            btnViewDetail.Name = "btnViewDetail";
            btnViewDetail.Size = new Size(168, 43);
            btnViewDetail.TabIndex = 13;
            btnViewDetail.Text = "View Detail";
            btnViewDetail.UseVisualStyleBackColor = true;
            btnViewDetail.Click += btnViewDetail_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20F);
            label3.Location = new Point(1102, 22);
            label3.Name = "label3";
            label3.Size = new Size(318, 46);
            label3.TabIndex = 12;
            label3.Text = "IMPORT PRODUCTS";
            // 
            // ImportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1432, 699);
            Controls.Add(btnViewDetail);
            Controls.Add(txtSearch);
            Controls.Add(lblSupplier);
            Controls.Add(lblDate);
            Controls.Add(lblVariant);
            Controls.Add(dtImportDate);
            Controls.Add(lblHistory);
            Controls.Add(cbFilterType);
            Controls.Add(cbVariant);
            Controls.Add(lblSearch);
            Controls.Add(lblFilterType);
            Controls.Add(lbQuantity);
            Controls.Add(lbPrice);
            Controls.Add(btnAddDetail);
            Controls.Add(txtPrice);
            Controls.Add(txtQuantity);
            Controls.Add(dgvHistory);
            Controls.Add(dgvDetail);
            Controls.Add(btnCreateReceipt);
            Controls.Add(cbSupplier);
            Name = "ImportForm";
            Text = "ImportForm";
            ((System.ComponentModel.ISupportInitialize)dgvDetail).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbSupplier;
        private Button btnCreateReceipt;
        private DataGridView dgvDetail;
        private TextBox txtQuantity;
        private TextBox txtPrice;
        private Button btnAddDetail;
        private Label lbPrice;
        private Label lbQuantity;
        private ComboBox cbVariant;
        private DataGridView dgvHistory;
        private Label lblHistory;
        private DateTimePicker dtImportDate;
        private Label lblVariant;
        private ComboBox cbFilterType;
        private Label lblFilterType;
        private Label lblDate;
        private Label lblSupplier;
        private TextBox txtSearch;
        private Label lblSearch;
        private Button btnViewDetail;
    }
}