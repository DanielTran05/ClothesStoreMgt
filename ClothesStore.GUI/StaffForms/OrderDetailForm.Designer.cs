namespace ClothesStore.GUI.StaffForms
{
    partial class OrderDetailForm
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
            dgvOrderDetail = new DataGridView();
            close = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetail).BeginInit();
            SuspendLayout();
            // 
            // dgvOrderDetail
            // 
            dgvOrderDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderDetail.Location = new Point(2, 3);
            dgvOrderDetail.Name = "dgvOrderDetail";
            dgvOrderDetail.RowHeadersWidth = 51;
            dgvOrderDetail.Size = new Size(1428, 596);
            dgvOrderDetail.TabIndex = 0;
            // 
            // close
            // 
            close.Location = new Point(12, 612);
            close.Name = "close";
            close.Size = new Size(94, 29);
            close.TabIndex = 1;
            close.Text = "Đóng";
            close.UseVisualStyleBackColor = true;
            close.Click += close_Click;
            // 
            // OrderDetailForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1432, 653);
            Controls.Add(close);
            Controls.Add(dgvOrderDetail);
            Name = "OrderDetailForm";
            Text = "OrderDetailForm";
            Load += OrderDetailForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetail).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvOrderDetail;
        private Button close;
    }
}