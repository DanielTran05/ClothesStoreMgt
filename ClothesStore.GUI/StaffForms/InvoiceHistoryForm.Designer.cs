namespace ClothesStore.GUI.StaffForms
{
    partial class InvoiceHistoryForm
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
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            cboStatus = new ComboBox();
            panel1 = new Panel();
            lblPageInfo = new Label();
            btnNext = new Button();
            btnPrev = new Button();
            dgvInvoices = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoices).BeginInit();
            SuspendLayout();
            // 
            // dtpFrom
            // 
            dtpFrom.Location = new Point(84, 45);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(250, 27);
            dtpFrom.TabIndex = 0;
            dtpFrom.ValueChanged += dtpFrom_ValueChanged;
            // 
            // dtpTo
            // 
            dtpTo.Location = new Point(388, 45);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(250, 27);
            dtpTo.TabIndex = 0;
            // 
            // cboStatus
            // 
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(697, 45);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(151, 28);
            cboStatus.TabIndex = 1;
            cboStatus.SelectedIndexChanged += cboStatus_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblPageInfo);
            panel1.Controls.Add(btnNext);
            panel1.Controls.Add(btnPrev);
            panel1.Controls.Add(dgvInvoices);
            panel1.Location = new Point(3, 111);
            panel1.Name = "panel1";
            panel1.Size = new Size(1425, 541);
            panel1.TabIndex = 2;
            // 
            // lblPageInfo
            // 
            lblPageInfo.AutoSize = true;
            lblPageInfo.Location = new Point(1227, 501);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(50, 20);
            lblPageInfo.TabIndex = 2;
            lblPageInfo.Text = "label1";
            // 
            // btnNext
            // 
            btnNext.Location = new Point(1323, 501);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(94, 29);
            btnNext.TabIndex = 1;
            btnNext.Text = ">>";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(1088, 501);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(94, 29);
            btnPrev.TabIndex = 1;
            btnPrev.Text = "<<";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // dgvInvoices
            // 
            dgvInvoices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInvoices.Location = new Point(3, 3);
            dgvInvoices.Name = "dgvInvoices";
            dgvInvoices.RowHeadersWidth = 51;
            dgvInvoices.Size = new Size(1419, 483);
            dgvInvoices.TabIndex = 0;
            // 
            // InvoiceHistoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1432, 653);
            Controls.Add(panel1);
            Controls.Add(cboStatus);
            Controls.Add(dtpTo);
            Controls.Add(dtpFrom);
            Name = "InvoiceHistoryForm";
            Text = "InvoiceHistory";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoices).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private ComboBox cboStatus;
        private Panel panel1;
        private Label lblPageInfo;
        private Button btnNext;
        private Button btnPrev;
        private DataGridView dgvInvoices;
    }
}