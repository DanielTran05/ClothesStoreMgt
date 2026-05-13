namespace ClothesStore.GUI
{
    partial class ucOrderManagement
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            InvoiceHistory = new Button();
            label2 = new Label();
            txtSearchOrder = new TextBox();
            panel2 = new Panel();
            txtTotalMoney = new TextBox();
            cboPaymentMethod = new ComboBox();
            cboShipping = new ComboBox();
            txtReceiverPhone = new TextBox();
            txtReceiverName = new TextBox();
            txtAddress = new TextBox();
            label1 = new Label();
            panel4 = new Panel();
            btnCancelOrder = new Button();
            btnUpdateOrder = new Button();
            btnCreateOrder = new Button();
            panel5 = new Panel();
            dgvOrders = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 192, 128);
            panel1.Controls.Add(InvoiceHistory);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtSearchOrder);
            panel1.Location = new Point(3, 85);
            panel1.Name = "panel1";
            panel1.Size = new Size(1154, 42);
            panel1.TabIndex = 0;
            // 
            // InvoiceHistory
            // 
            InvoiceHistory.Location = new Point(1031, 7);
            InvoiceHistory.Name = "InvoiceHistory";
            InvoiceHistory.Size = new Size(94, 29);
            InvoiceHistory.TabIndex = 3;
            InvoiceHistory.Text = "Xem lịch sử";
            InvoiceHistory.UseVisualStyleBackColor = true;
            InvoiceHistory.Click += InvoiceHistory_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 10);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 2;
            label2.Text = "Tìm kiếm:";
            // 
            // txtSearchOrder
            // 
            txtSearchOrder.Location = new Point(91, 7);
            txtSearchOrder.Name = "txtSearchOrder";
            txtSearchOrder.Size = new Size(281, 27);
            txtSearchOrder.TabIndex = 1;
            txtSearchOrder.TextChanged += txtSearchOrder_TextChanged;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 192, 128);
            panel2.Controls.Add(txtTotalMoney);
            panel2.Controls.Add(cboPaymentMethod);
            panel2.Controls.Add(cboShipping);
            panel2.Controls.Add(txtReceiverPhone);
            panel2.Controls.Add(txtReceiverName);
            panel2.Controls.Add(txtAddress);
            panel2.Controls.Add(label1);
            panel2.ForeColor = SystemColors.ControlText;
            panel2.Location = new Point(1163, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(287, 694);
            panel2.TabIndex = 1;
            // 
            // txtTotalMoney
            // 
            txtTotalMoney.Location = new Point(20, 163);
            txtTotalMoney.Name = "txtTotalMoney";
            txtTotalMoney.PlaceholderText = "Tổng tiền";
            txtTotalMoney.Size = new Size(239, 27);
            txtTotalMoney.TabIndex = 2;
            // 
            // cboPaymentMethod
            // 
            cboPaymentMethod.FormattingEnabled = true;
            cboPaymentMethod.Location = new Point(20, 231);
            cboPaymentMethod.Name = "cboPaymentMethod";
            cboPaymentMethod.Size = new Size(239, 28);
            cboPaymentMethod.TabIndex = 3;
            // 
            // cboShipping
            // 
            cboShipping.FormattingEnabled = true;
            cboShipping.Location = new Point(20, 197);
            cboShipping.Name = "cboShipping";
            cboShipping.Size = new Size(239, 28);
            cboShipping.TabIndex = 3;
            // 
            // txtReceiverPhone
            // 
            txtReceiverPhone.Location = new Point(20, 130);
            txtReceiverPhone.Name = "txtReceiverPhone";
            txtReceiverPhone.PlaceholderText = "Số điện thoại";
            txtReceiverPhone.Size = new Size(239, 27);
            txtReceiverPhone.TabIndex = 2;
            // 
            // txtReceiverName
            // 
            txtReceiverName.Location = new Point(20, 97);
            txtReceiverName.Name = "txtReceiverName";
            txtReceiverName.PlaceholderText = "Tên người nhận";
            txtReceiverName.Size = new Size(239, 27);
            txtReceiverName.TabIndex = 2;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(20, 64);
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "Địa chỉ";
            txtAddress.Size = new Size(239, 27);
            txtAddress.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 8);
            label1.Name = "label1";
            label1.Size = new Size(204, 27);
            label1.TabIndex = 1;
            label1.Text = "Thông tin chi tiết";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(255, 192, 128);
            panel4.Controls.Add(btnCancelOrder);
            panel4.Controls.Add(btnUpdateOrder);
            panel4.Controls.Add(btnCreateOrder);
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(1154, 74);
            panel4.TabIndex = 3;
            // 
            // btnCancelOrder
            // 
            btnCancelOrder.Location = new Point(421, 3);
            btnCancelOrder.Name = "btnCancelOrder";
            btnCancelOrder.Size = new Size(103, 64);
            btnCancelOrder.TabIndex = 0;
            btnCancelOrder.Text = "Xóa";
            btnCancelOrder.UseVisualStyleBackColor = true;
            btnCancelOrder.Click += btnCancelOrder_Click;
            // 
            // btnUpdateOrder
            // 
            btnUpdateOrder.Location = new Point(227, 3);
            btnUpdateOrder.Name = "btnUpdateOrder";
            btnUpdateOrder.Size = new Size(103, 64);
            btnUpdateOrder.TabIndex = 0;
            btnUpdateOrder.Text = "Sửa";
            btnUpdateOrder.UseVisualStyleBackColor = true;
            btnUpdateOrder.Click += btnUpdateOrder_Click;
            // 
            // btnCreateOrder
            // 
            btnCreateOrder.Location = new Point(38, 3);
            btnCreateOrder.Name = "btnCreateOrder";
            btnCreateOrder.Size = new Size(103, 64);
            btnCreateOrder.TabIndex = 0;
            btnCreateOrder.Text = "Thêm";
            btnCreateOrder.UseVisualStyleBackColor = true;
            btnCreateOrder.Click += btnCreateOrder_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(dgvOrders);
            panel5.Location = new Point(3, 142);
            panel5.Name = "panel5";
            panel5.Size = new Size(1154, 555);
            panel5.TabIndex = 4;
            // 
            // dgvOrders
            // 
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(3, 3);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.RowHeadersWidth = 51;
            dgvOrders.Size = new Size(1148, 508);
            dgvOrders.TabIndex = 0;
            // 
            // ucOrderManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ucOrderManagement";
            Size = new Size(1450, 700);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private TextBox txtSearchOrder;
        private Label label1;
        private TextBox txtTotalMoney;
        private Panel panel4;
        private Button btnCancelOrder;
        private Button btnUpdateOrder;
        private Button btnCreateOrder;
        private Panel panel5;
        private DataGridView dgvOrders;
        private ComboBox cboShipping;
        private TextBox txtReceiverPhone;
        private TextBox txtReceiverName;
        private TextBox txtAddress;
        private Label label2;
        private ComboBox cboPaymentMethod;
        private Button InvoiceHistory;
    }
}
