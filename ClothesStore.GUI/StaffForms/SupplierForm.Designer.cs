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
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).BeginInit();
            SuspendLayout();
            // 
            // dgvSuppliers
            // 
            dgvSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSuppliers.Location = new Point(12, 45);
            dgvSuppliers.Name = "dgvSuppliers";
            dgvSuppliers.RowHeadersWidth = 51;
            dgvSuppliers.Size = new Size(776, 188);
            dgvSuppliers.TabIndex = 0;
            dgvSuppliers.CellClick += dgvSuppliers_CellClick;
            // 
            // txtName
            // 
            txtName.Location = new Point(463, 12);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 1;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(663, 12);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(125, 27);
            txtPhone.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(394, 261);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 50);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(494, 261);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 50);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(594, 261);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 50);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(694, 261);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 50);
            btnLoad.TabIndex = 2;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // lbPhone
            // 
            lbPhone.Location = new Point(595, 15);
            lbPhone.Name = "lbPhone";
            lbPhone.Size = new Size(62, 25);
            lbPhone.TabIndex = 3;
            lbPhone.Text = "Phone:";
            // 
            // lbName
            // 
            lbName.Location = new Point(395, 14);
            lbName.Name = "lbName";
            lbName.Size = new Size(62, 25);
            lbName.TabIndex = 3;
            lbName.Text = "Name:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(264, 9);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(125, 27);
            txtSearch.TabIndex = 4;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.Location = new Point(180, 11);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(78, 25);
            lblSearch.TabIndex = 3;
            lblSearch.Text = "Search:";
            // 
            // cboSearchType
            // 
            cboSearchType.FormattingEnabled = true;
            cboSearchType.Location = new Point(12, 8);
            cboSearchType.Name = "cboSearchType";
            cboSearchType.Size = new Size(151, 28);
            cboSearchType.TabIndex = 5;
            // 
            // SupplierForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 325);
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
    }
}