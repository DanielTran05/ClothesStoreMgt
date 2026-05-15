namespace ClothesStore.GUI.StaffForms
{
    partial class ProductSearchForm
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
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvResult = new DataGridView();
            cboSearchType = new ComboBox();
            btnNext = new Button();
            btnPrev = new Button();
            lblPage = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvResult).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(526, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(262, 27);
            txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(413, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvResult
            // 
            dgvResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResult.Location = new Point(12, 67);
            dgvResult.Name = "dgvResult";
            dgvResult.RowHeadersWidth = 51;
            dgvResult.Size = new Size(776, 230);
            dgvResult.TabIndex = 2;
            // 
            // cboSearchType
            // 
            cboSearchType.FormattingEnabled = true;
            cboSearchType.Location = new Point(256, 13);
            cboSearchType.Name = "cboSearchType";
            cboSearchType.Size = new Size(151, 28);
            cboSearchType.TabIndex = 3;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(657, 306);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(94, 47);
            btnNext.TabIndex = 4;
            btnNext.Text = ">>";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(557, 306);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(94, 47);
            btnPrev.TabIndex = 4;
            btnPrev.Text = "<<";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // lblPage
            // 
            lblPage.AutoSize = true;
            lblPage.Location = new Point(757, 333);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(31, 20);
            lblPage.TabIndex = 5;
            lblPage.Text = "1/1";
            // 
            // ProductSearchForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 362);
            Controls.Add(lblPage);
            Controls.Add(btnPrev);
            Controls.Add(btnNext);
            Controls.Add(cboSearchType);
            Controls.Add(dgvResult);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Name = "ProductSearchForm";
            Text = "ProductSearchForm";
            ((System.ComponentModel.ISupportInitialize)dgvResult).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvResult;
        private ComboBox cboSearchType;
        private Button btnNext;
        private Button btnPrev;
        private Label lblPage;
    }
}