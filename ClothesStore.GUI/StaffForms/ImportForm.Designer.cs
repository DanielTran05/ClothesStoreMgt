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
            ((System.ComponentModel.ISupportInitialize)dgvDetail).BeginInit();
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
            txtQuantity.Location = new Point(250, 83);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(125, 27);
            txtQuantity.TabIndex = 3;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(449, 82);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(125, 27);
            txtPrice.TabIndex = 3;
            // 
            // btnAddDetail
            // 
            btnAddDetail.Location = new Point(694, 369);
            btnAddDetail.Name = "btnAddDetail";
            btnAddDetail.Size = new Size(94, 69);
            btnAddDetail.TabIndex = 4;
            btnAddDetail.Text = "Add detail";
            btnAddDetail.UseVisualStyleBackColor = true;
            btnAddDetail.Click += btnAddDetail_Click;
            // 
            // lbPrice
            // 
            lbPrice.Location = new Point(396, 83);
            lbPrice.Name = "lbPrice";
            lbPrice.Size = new Size(75, 27);
            lbPrice.TabIndex = 5;
            lbPrice.Text = "Price:";
            // 
            // lbQuantity
            // 
            lbQuantity.Location = new Point(169, 82);
            lbQuantity.Name = "lbQuantity";
            lbQuantity.Size = new Size(75, 27);
            lbQuantity.TabIndex = 5;
            lbQuantity.Text = "Quantity:";
            // 
            // cbVariant
            // 
            cbVariant.FormattingEnabled = true;
            cbVariant.Location = new Point(12, 82);
            cbVariant.Name = "cbVariant";
            cbVariant.Size = new Size(151, 28);
            cbVariant.TabIndex = 6;
            // 
            // ImportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cbVariant);
            Controls.Add(lbQuantity);
            Controls.Add(lbPrice);
            Controls.Add(btnAddDetail);
            Controls.Add(txtPrice);
            Controls.Add(txtQuantity);
            Controls.Add(dgvDetail);
            Controls.Add(btnCreateReceipt);
            Controls.Add(cbSupplier);
            Name = "ImportForm";
            Text = "ImportForm";
            ((System.ComponentModel.ISupportInitialize)dgvDetail).EndInit();
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
    }
}