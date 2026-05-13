namespace ClothesStore.GUI.StaffForms
{
    partial class StatisticTodayForm
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
            lblTitle = new Label();
            lblTotal = new Label();
            dgvStatistic = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvStatistic).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(241, 36);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Doanh thu hôm nay";
            // 
            // lblTotal
            // 
            lblTotal.BackColor = SystemColors.ControlLight;
            lblTotal.Location = new Point(259, 17);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(235, 25);
            lblTotal.TabIndex = 1;
            // 
            // dgvStatistic
            // 
            dgvStatistic.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStatistic.Location = new Point(12, 48);
            dgvStatistic.Name = "dgvStatistic";
            dgvStatistic.RowHeadersWidth = 51;
            dgvStatistic.Size = new Size(482, 169);
            dgvStatistic.TabIndex = 2;
            // 
            // StatisticForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 229);
            Controls.Add(dgvStatistic);
            Controls.Add(lblTotal);
            Controls.Add(lblTitle);
            Name = "StatisticForm";
            Text = "StatisticForm";
            ((System.ComponentModel.ISupportInitialize)dgvStatistic).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Label lblTotal;
        private DataGridView dgvStatistic;
    }
}