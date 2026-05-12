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
            lblCustomerId = new Label();
            lblReason = new Label();
            txtCustomerId = new TextBox();
            txtReason = new TextBox();
            dgvCustomerService = new DataGridView();
            btnLoad = new Button();
            btnHandle = new Button();
            btnAdd = new Button();
            btnReject = new Button();
            dtpFilterDate = new DateTimePicker();
            cbStatus = new ComboBox();
            lblResponse = new Label();
            txtResponse = new TextBox();
            btnSolve = new Button();
            btnFilter = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCustomerService).BeginInit();
            SuspendLayout();
            // 
            // lblCustomerId
            // 
            lblCustomerId.AutoSize = true;
            lblCustomerId.Location = new Point(12, 12);
            lblCustomerId.Name = "lblCustomerId";
            lblCustomerId.Size = new Size(92, 20);
            lblCustomerId.TabIndex = 12;
            lblCustomerId.Text = "Customer Id:";
            // 
            // lblReason
            // 
            lblReason.AutoSize = true;
            lblReason.Location = new Point(250, 12);
            lblReason.Name = "lblReason";
            lblReason.Size = new Size(60, 20);
            lblReason.TabIndex = 10;
            lblReason.Text = "Reason:";
            // 
            // txtCustomerId
            // 
            txtCustomerId.Location = new Point(110, 9);
            txtCustomerId.Name = "txtCustomerId";
            txtCustomerId.Size = new Size(120, 27);
            txtCustomerId.TabIndex = 11;
            // 
            // txtReason
            // 
            txtReason.Location = new Point(320, 9);
            txtReason.Name = "txtReason";
            txtReason.Size = new Size(180, 27);
            txtReason.TabIndex = 9;
            // 
            // dgvCustomerService
            // 
            dgvCustomerService.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomerService.Location = new Point(12, 120);
            dgvCustomerService.Name = "dgvCustomerService";
            dgvCustomerService.RowHeadersWidth = 51;
            dgvCustomerService.Size = new Size(860, 280);
            dgvCustomerService.TabIndex = 4;
            dgvCustomerService.CellClick += dgvCustomerService_CellClick;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(772, 424);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(100, 45);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnHandle
            // 
            btnHandle.Location = new Point(560, 424);
            btnHandle.Name = "btnHandle";
            btnHandle.Size = new Size(100, 45);
            btnHandle.TabIndex = 2;
            btnHandle.Text = "Handle";
            btnHandle.UseVisualStyleBackColor = true;
            btnHandle.Click += btnHandle_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(454, 424);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 45);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnReject
            // 
            btnReject.Location = new Point(666, 424);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(100, 45);
            btnReject.TabIndex = 1;
            btnReject.Text = "Reject";
            btnReject.UseVisualStyleBackColor = true;
            btnReject.Click += btnReject_Click;
            // 
            // dtpFilterDate
            // 
            dtpFilterDate.Location = new Point(520, 9);
            dtpFilterDate.Name = "dtpFilterDate";
            dtpFilterDate.Size = new Size(220, 27);
            dtpFilterDate.TabIndex = 8;
            // 
            // cbStatus
            // 
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(12, 50);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(150, 28);
            cbStatus.TabIndex = 7;
            cbStatus.SelectedIndexChanged += cbStatus_SelectedIndexChanged;
            // 
            // lblResponse
            // 
            lblResponse.AutoSize = true;
            lblResponse.Location = new Point(180, 54);
            lblResponse.Name = "lblResponse";
            lblResponse.Size = new Size(75, 20);
            lblResponse.TabIndex = 6;
            lblResponse.Text = "Response:";
            // 
            // txtResponse
            // 
            txtResponse.Location = new Point(265, 50);
            txtResponse.Multiline = true;
            txtResponse.Name = "txtResponse";
            txtResponse.Size = new Size(235, 28);
            txtResponse.TabIndex = 5;
            // 
            // btnSolve
            // 
            btnSolve.Location = new Point(354, 424);
            btnSolve.Name = "btnSolve";
            btnSolve.Size = new Size(94, 45);
            btnSolve.TabIndex = 13;
            btnSolve.Text = "Solve";
            btnSolve.UseVisualStyleBackColor = true;
            btnSolve.Click += btnSolve_Click;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(254, 424);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(94, 45);
            btnFilter.TabIndex = 14;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // CustomerServiceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 481);
            Controls.Add(btnFilter);
            Controls.Add(btnSolve);
            Controls.Add(btnLoad);
            Controls.Add(btnReject);
            Controls.Add(btnHandle);
            Controls.Add(btnAdd);
            Controls.Add(dgvCustomerService);
            Controls.Add(txtResponse);
            Controls.Add(lblResponse);
            Controls.Add(cbStatus);
            Controls.Add(dtpFilterDate);
            Controls.Add(txtReason);
            Controls.Add(lblReason);
            Controls.Add(txtCustomerId);
            Controls.Add(lblCustomerId);
            Name = "CustomerServiceForm";
            Text = "CustomerServiceForm";
            ((System.ComponentModel.ISupportInitialize)dgvCustomerService).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCustomerId;
        private Label lblReason;

        private TextBox txtCustomerId;
        private TextBox txtReason;

        private DataGridView dgvCustomerService;

        private Button btnLoad;
        private Button btnHandle;
        private Button btnAdd;
        private Button btnReject;

        private DateTimePicker dtpFilterDate;

        private ComboBox cbStatus;

        private Label lblResponse;

        private TextBox txtResponse;
        private Button btnSolve;
        private Button btnFilter;
    }
}