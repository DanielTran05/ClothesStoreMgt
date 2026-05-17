namespace ClothesStore.GUI.StaffForms
{
    partial class ReceiptDetailForm
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
            dgvReceiptDetail = new DataGridView();
            lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReceiptDetail).BeginInit();
            SuspendLayout();
            // 
            // dgvReceiptDetail
            // 
            dgvReceiptDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReceiptDetail.Location = new Point(12, 62);
            dgvReceiptDetail.Name = "dgvReceiptDetail";
            dgvReceiptDetail.RowHeadersWidth = 51;
            dgvReceiptDetail.Size = new Size(985, 188);
            dgvReceiptDetail.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(454, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(154, 20);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "CHI TIẾT PHIẾU NHẬP";
            // 
            // ReceiptDetailForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1009, 264);
            Controls.Add(lblTitle);
            Controls.Add(dgvReceiptDetail);
            Name = "ReceiptDetailForm";
            Text = "ReceiptDetailForm";
            ((System.ComponentModel.ISupportInitialize)dgvReceiptDetail).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvReceiptDetail;
        private Label lblTitle;
    }
}