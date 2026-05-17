namespace ClothesStore.GUI.StaffForms
{
    partial class CustomerServiceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up resources.
        /// </summary>
        protected override void Dispose(
            bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dgvCustomerService = new DataGridView();
            btnLoad = new Button();
            btnHandle = new Button();
            btnReject = new Button();
            dtpFilterDate = new DateTimePicker();
            cbStatus = new ComboBox();
            lblAllreportsforms = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCustomerService).BeginInit();
            SuspendLayout();
            // 
            // dgvCustomerService
            // 
            dgvCustomerService.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomerService.Location = new Point(12, 120);
            dgvCustomerService.Name = "dgvCustomerService";
            dgvCustomerService.RowHeadersWidth = 51;
            dgvCustomerService.Size = new Size(1408, 470);
            dgvCustomerService.TabIndex = 4;
            dgvCustomerService.CellClick += dgvCustomerService_CellClick;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(1320, 596);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(100, 45);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnHandle
            // 
            btnHandle.Location = new Point(1108, 596);
            btnHandle.Name = "btnHandle";
            btnHandle.Size = new Size(100, 45);
            btnHandle.TabIndex = 2;
            btnHandle.Text = "Handle";
            btnHandle.UseVisualStyleBackColor = true;
            btnHandle.Click += btnHandle_Click;
            // 
            // btnReject
            // 
            btnReject.Location = new Point(1214, 596);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(100, 45);
            btnReject.TabIndex = 1;
            btnReject.Text = "Reject";
            btnReject.UseVisualStyleBackColor = true;
            btnReject.Click += btnReject_Click;
            // 
            // dtpFilterDate
            // 
            dtpFilterDate.Location = new Point(1200, 87);
            dtpFilterDate.Name = "dtpFilterDate";
            dtpFilterDate.Size = new Size(220, 27);
            dtpFilterDate.TabIndex = 8;
            // 
            // cbStatus
            // 
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(110, 55);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(150, 28);
            cbStatus.TabIndex = 7;
            cbStatus.SelectedIndexChanged += cbStatus_SelectedIndexChanged;
            // 
            // lblAllreportsforms
            // 
            lblAllreportsforms.AutoSize = true;
            lblAllreportsforms.Location = new Point(12, 97);
            lblAllreportsforms.Name = "lblAllreportsforms";
            lblAllreportsforms.Size = new Size(120, 20);
            lblAllreportsforms.TabIndex = 13;
            lblAllreportsforms.Text = "All reports forms";
            // 
            // label2
            // 
            //label2.AutoSize = true;
            //label2.Font = new Font("Segoe UI", 20F);
            //label2.Location = new Point(1096, 9);
            //label2.Name = "label2";
            //label2.Size = new Size(324, 46);
            //label2.TabIndex = 14;
            //label2.Text = "CUSTOMER SERVICE";
            //// 
            //// label3
            //// 
            //label3.AutoSize = true;
            //label3.Location = new Point(12, 55);
            //label3.Name = "label3";
            //label3.Size = new Size(65, 20);
            //label3.TabIndex = 15;
            //label3.Text = "Filter by:";
            //label3.Click += label3_Click;
            // 
            // CustomerServiceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1432, 653);
            Controls.Add(lblAllreportsforms);
            Controls.Add(btnLoad);
            Controls.Add(btnReject);
            Controls.Add(btnHandle);
            Controls.Add(dgvCustomerService);
            Controls.Add(cbStatus);
            Controls.Add(dtpFilterDate);
            Name = "CustomerServiceForm";
            Text = "CustomerServiceForm";
            ((System.ComponentModel.ISupportInitialize)dgvCustomerService).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCustomerService;

        private Button btnLoad;
        private Button btnHandle;
        private Button btnReject;

        private DateTimePicker dtpFilterDate;

        private ComboBox cbStatus;
        private Label lblAllreportsforms;
    }
}