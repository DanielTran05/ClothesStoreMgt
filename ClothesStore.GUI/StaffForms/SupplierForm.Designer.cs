namespace ClothesStore.GUI.StaffForms
{
    partial class SupplierForm
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
            dgvSuppliers = new DataGridView();
            txtName = new TextBox();
            txtPhone = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnLoad = new Button();
            lbPhone = new Label();
            lbName = new Label();
            txtSearch = new TextBox();
            lblSearch = new Label();
            cboSearchType = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).BeginInit();
            SuspendLayout();
            // 
            // dgvSuppliers
            // 
            dgvSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSuppliers.Location = new Point(12, 77);
            dgvSuppliers.Name = "dgvSuppliers";
            dgvSuppliers.RowHeadersWidth = 51;
            dgvSuppliers.Size = new Size(1408, 491);
            dgvSuppliers.TabIndex = 0;
            dgvSuppliers.CellClick += dgvSuppliers_CellClick;
            // 
            // txtName
            // 
            txtName.Location = new Point(70, 614);
            txtName.Name = "txtName";
            txtName.Size = new Size(278, 27);
            txtName.TabIndex = 1;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(430, 614);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(167, 27);
            txtPhone.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(1023, 592);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 50);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(1126, 591);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 50);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(1226, 591);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 50);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Cancel";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(1326, 591);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 50);
            btnLoad.TabIndex = 2;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // lbPhone
            // 
            lbPhone.Location = new Point(368, 617);
            lbPhone.Name = "lbPhone";
            lbPhone.Size = new Size(59, 25);
            lbPhone.TabIndex = 3;
            lbPhone.Text = "Phone:";
            // 
            // lbName
            // 
            lbName.Location = new Point(11, 617);
            lbName.Name = "lbName";
            lbName.Size = new Size(62, 25);
            lbName.TabIndex = 3;
            lbName.Text = "Name:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(343, 44);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(125, 27);
            txtSearch.TabIndex = 4;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.Location = new Point(270, 47);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(78, 25);
            lblSearch.TabIndex = 3;
            lblSearch.Text = "Search:";
            // 
            // cboSearchType
            // 
            cboSearchType.FormattingEnabled = true;
            cboSearchType.Location = new Point(85, 44);
            cboSearchType.Name = "cboSearchType";
            cboSearchType.Size = new Size(151, 28);
            cboSearchType.TabIndex = 5;
            // 
            // label1
            // 
            label1.Location = new Point(12, 46);
            label1.Name = "label1";
            label1.Size = new Size(67, 25);
            label1.TabIndex = 6;
            label1.Text = "Filter by:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F);
            label2.Location = new Point(528, 9);
            label2.Name = "label2";
            label2.Size = new Size(400, 46);
            label2.TabIndex = 7;
            label2.Text = "SUPPLIER MANAGEMENT";
            // 
            // SupplierForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1432, 677);
            Controls.Add(label1);
            Controls.Add(cboSearchType);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(lbName);
            Controls.Add(lbPhone);
            Controls.Add(btnLoad);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(txtPhone);
            Controls.Add(txtName);
            Controls.Add(dgvSuppliers);
            Name = "SupplierForm";
            Text = "SupplierForm";
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvSuppliers;
        private TextBox txtName;
        private TextBox txtPhone;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnLoad;
        private Label lbPhone;
        private Label lbName;
        private TextBox txtSearch;
        private Label lblSearch;
        private ComboBox cboSearchType;
        private Label label1;
        private Label label2;
    }
}