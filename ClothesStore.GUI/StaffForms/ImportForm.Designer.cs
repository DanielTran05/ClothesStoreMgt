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
            ((System.ComponentModel.ISupportInitialize)dgvDetail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            SuspendLayout();
            // 
            // cbSupplier
            // 
            cbSupplier.FormattingEnabled = true;
            cbSupplier.Location = new Point(637, 12);
            cbSupplier.Name = "cbSupplier";
            cbSupplier.Size = new Size(151, 28);
            cbSupplier.TabIndex = 0;
            // 
            // btnCreateReceipt
            // 
            btnCreateReceipt.Location = new Point(449, 6);
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
            dgvDetail.Location = new Point(12, 124);
            dgvDetail.Name = "dgvDetail";
            dgvDetail.RowHeadersWidth = 51;
            dgvDetail.Size = new Size(776, 230);
            dgvDetail.TabIndex = 2;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(449, 55);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(125, 27);
            txtQuantity.TabIndex = 3;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(663, 55);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(125, 27);
            txtPrice.TabIndex = 3;
            // 
            // btnAddDetail
            // 
            btnAddDetail.Location = new Point(694, 625);
            btnAddDetail.Name = "btnAddDetail";
            btnAddDetail.Size = new Size(94, 69);
            btnAddDetail.TabIndex = 4;
            btnAddDetail.Text = "Add detail";
            btnAddDetail.UseVisualStyleBackColor = true;
            btnAddDetail.Click += btnAddDetail_Click;
            // 
            // lbPrice
            // 
            lbPrice.Location = new Point(582, 55);
            lbPrice.Name = "lbPrice";
            lbPrice.Size = new Size(75, 27);
            lbPrice.TabIndex = 5;
            lbPrice.Text = "Price:";
            // 
            // lbQuantity
            // 
            lbQuantity.Location = new Point(368, 55);
            lbQuantity.Name = "lbQuantity";
            lbQuantity.Size = new Size(75, 27);
            lbQuantity.TabIndex = 5;
            lbQuantity.Text = "Quantity:";
            // 
            // cbVariant
            // 
            cbVariant.FormattingEnabled = true;
            cbVariant.Location = new Point(211, 55);
            cbVariant.Name = "cbVariant";
            cbVariant.Size = new Size(151, 28);
            cbVariant.TabIndex = 6;
            // 
            // dgvHistory
            // 
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistory.Location = new Point(12, 389);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.RowHeadersWidth = 51;
            dgvHistory.Size = new Size(776, 230);
            dgvHistory.TabIndex = 2;
            // 
            // lblHistory
            // 
            lblHistory.AutoSize = true;
            lblHistory.Location = new Point(12, 366);
            lblHistory.Name = "lblHistory";
            lblHistory.Size = new Size(59, 20);
            lblHistory.TabIndex = 7;
            lblHistory.Text = "History:";
            // 
            // dtImportDate
            // 
            dtImportDate.Location = new Point(12, 10);
            dtImportDate.Name = "dtImportDate";
            dtImportDate.Size = new Size(262, 27);
            dtImportDate.TabIndex = 8;
            dtImportDate.ValueChanged += dtImportDate_ValueChanged;
            // 
            // lblVariant
            // 
            lblVariant.AutoSize = true;
            lblVariant.Location = new Point(147, 58);
            lblVariant.Name = "lblVariant";
            lblVariant.Size = new Size(58, 20);
            lblVariant.TabIndex = 9;
            lblVariant.Text = "Varient:";
            // 
            // cbFilterType
            // 
            cbFilterType.FormattingEnabled = true;
            cbFilterType.Location = new Point(211, 90);
            cbFilterType.Name = "cbFilterType";
            cbFilterType.Size = new Size(151, 28);
            cbFilterType.TabIndex = 6;
            cbFilterType.SelectedIndexChanged += cbFilterType_SelectedIndexChanged;
            // 
            // lblFilterType
            // 
            lblFilterType.Location = new Point(118, 90);
            lblFilterType.Name = "lblFilterType";
            lblFilterType.Size = new Size(87, 27);
            lblFilterType.TabIndex = 5;
            lblFilterType.Text = "Filter Type:";
            // 
            // ImportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 706);
            Controls.Add(lblVariant);
            Controls.Add(dtImportDate);
            Controls.Add(lblHistory);
            Controls.Add(cbFilterType);
            Controls.Add(cbVariant);
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
    }
}