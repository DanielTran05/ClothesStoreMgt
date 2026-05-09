namespace ClothesStore.GUI.StaffForms
{
    partial class CustomerServiceForm
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
            lblCustomerId = new Label();
            lblReason = new Label();
            txtCustomerId = new TextBox();
            txtReason = new TextBox();
            dgvCustomerService = new DataGridView();
            btnLoad = new Button();
            btnHandle = new Button();
            btnAdd = new Button();
            btnReject = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCustomerService).BeginInit();
            SuspendLayout();
            // 
            // lblCustomerId
            // 
            lblCustomerId.AutoSize = true;
            lblCustomerId.Location = new Point(12, 9);
            lblCustomerId.Name = "lblCustomerId";
            lblCustomerId.Size = new Size(92, 20);
            lblCustomerId.TabIndex = 0;
            lblCustomerId.Text = "Customer Id:";
            // 
            // lblReason
            // 
            lblReason.AutoSize = true;
            lblReason.Location = new Point(250, 9);
            lblReason.Name = "lblReason";
            lblReason.Size = new Size(60, 20);
            lblReason.TabIndex = 0;
            lblReason.Text = "Reason:";
            // 
            // txtCustomerId
            // 
            txtCustomerId.Location = new Point(110, 6);
            txtCustomerId.Name = "txtCustomerId";
            txtCustomerId.Size = new Size(125, 27);
            txtCustomerId.TabIndex = 1;
            // 
            // txtReason
            // 
            txtReason.Location = new Point(328, 6);
            txtReason.Name = "txtReason";
            txtReason.Size = new Size(125, 27);
            txtReason.TabIndex = 1;
            // 
            // dgvCustomerService
            // 
            dgvCustomerService.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomerService.Location = new Point(12, 39);
            dgvCustomerService.Name = "dgvCustomerService";
            dgvCustomerService.RowHeadersWidth = 51;
            dgvCustomerService.Size = new Size(697, 260);
            dgvCustomerService.TabIndex = 2;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(515, 305);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 55);
            btnLoad.TabIndex = 3;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnHandle
            // 
            btnHandle.Location = new Point(415, 305);
            btnHandle.Name = "btnHandle";
            btnHandle.Size = new Size(94, 55);
            btnHandle.TabIndex = 3;
            btnHandle.Text = "Handle";
            btnHandle.UseVisualStyleBackColor = true;
            btnHandle.Click += btnHandle_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(315, 305);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 55);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnReject
            // 
            btnReject.Location = new Point(615, 305);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(94, 55);
            btnReject.TabIndex = 3;
            btnReject.Text = "Reject";
            btnReject.UseVisualStyleBackColor = true;
            btnReject.Click += btnReject_Click;
            // 
            // CustomerServiceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(721, 372);
            Controls.Add(btnAdd);
            Controls.Add(btnHandle);
            Controls.Add(btnReject);
            Controls.Add(btnLoad);
            Controls.Add(dgvCustomerService);
            Controls.Add(txtReason);
            Controls.Add(txtCustomerId);
            Controls.Add(lblReason);
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
    }
}