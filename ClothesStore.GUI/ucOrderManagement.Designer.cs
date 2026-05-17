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
            cboFilterStatus = new ComboBox();
            dtpToDate = new DateTimePicker();
            dtpFromDate = new DateTimePicker();
            InvoiceHistory = new Button();
            label2 = new Label();
            txtSearchOrder = new TextBox();
            panel4 = new Panel();
            viewOrderDetail = new Button();
            btnCancelOrder = new Button();
            btnUpdateOrder = new Button();
            btnCreateOrder = new Button();
            panel5 = new Panel();
            button1 = new Button();
            dgvOrders = new DataGridView();
            btnReturn = new Button();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 192, 128);
            panel1.Controls.Add(cboFilterStatus);
            panel1.Controls.Add(dtpToDate);
            panel1.Controls.Add(dtpFromDate);
            panel1.Controls.Add(InvoiceHistory);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtSearchOrder);
            panel1.Location = new Point(3, 85);
            panel1.Name = "panel1";
            panel1.Size = new Size(1444, 42);
            panel1.TabIndex = 0;
            // 
            // cboFilterStatus
            // 
            cboFilterStatus.FormattingEnabled = true;
            cboFilterStatus.Location = new Point(881, 6);
            cboFilterStatus.Name = "cboFilterStatus";
            cboFilterStatus.Size = new Size(151, 28);
            cboFilterStatus.TabIndex = 5;
            cboFilterStatus.SelectedIndexChanged += cboFilterStatus_SelectedIndexChanged;
            // 
            // dtpToDate
            // 
            dtpToDate.Location = new Point(596, 7);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(250, 27);
            dtpToDate.TabIndex = 4;
            dtpToDate.ValueChanged += dtpToDate_ValueChanged;
            // 
            // dtpFromDate
            // 
            dtpFromDate.Location = new Point(314, 7);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(250, 27);
            dtpFromDate.TabIndex = 4;
            dtpFromDate.ValueChanged += dtpFromDate_ValueChanged;
            // 
            // InvoiceHistory
            // 
            InvoiceHistory.Location = new Point(1347, 7);
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
            txtSearchOrder.Size = new Size(199, 27);
            txtSearchOrder.TabIndex = 1;
            txtSearchOrder.TextChanged += txtSearchOrder_TextChanged;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(255, 192, 128);
            panel4.Controls.Add(btnReturn);
            panel4.Controls.Add(viewOrderDetail);
            panel4.Controls.Add(btnCancelOrder);
            panel4.Controls.Add(btnUpdateOrder);
            panel4.Controls.Add(btnCreateOrder);
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(1444, 74);
            panel4.TabIndex = 3;
            // 
            // viewOrderDetail
            // 
            viewOrderDetail.Location = new Point(596, 3);
            viewOrderDetail.Name = "viewOrderDetail";
            viewOrderDetail.Size = new Size(109, 64);
            viewOrderDetail.TabIndex = 1;
            viewOrderDetail.Text = "Chi tiết đơn hàng";
            viewOrderDetail.UseVisualStyleBackColor = true;
            viewOrderDetail.Click += viewOrderDetail_Click;
            // 
            // btnCancelOrder
            // 
            btnCancelOrder.Location = new Point(421, 3);
            btnCancelOrder.Name = "btnCancelOrder";
            btnCancelOrder.Size = new Size(103, 64);
            btnCancelOrder.TabIndex = 0;
            btnCancelOrder.Text = "Hủy";
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
            panel5.Controls.Add(button1);
            panel5.Controls.Add(dgvOrders);
            panel5.Location = new Point(3, 142);
            panel5.Name = "panel5";
            panel5.Size = new Size(1444, 555);
            panel5.TabIndex = 4;
            // 
            // button1
            // 
            button1.BackColor = Color.Yellow;
            button1.Location = new Point(0, 466);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "Quay lại";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dgvOrders
            // 
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(3, 3);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.RowHeadersWidth = 51;
            dgvOrders.Size = new Size(1438, 457);
            dgvOrders.TabIndex = 0;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(750, 6);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(96, 61);
            btnReturn.TabIndex = 2;
            btnReturn.Text = "Trả";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // ucOrderManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Name = "ucOrderManagement";
            Size = new Size(1450, 700);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtSearchOrder;
        private Panel panel4;
        private Button btnCancelOrder;
        private Button btnUpdateOrder;
        private Button btnCreateOrder;
        private Panel panel5;
        private DataGridView dgvOrders;
        private Label label2;
        private Button InvoiceHistory;
        private Button button1;
        private Button viewOrderDetail;
        private ComboBox cboFilterStatus;
        private DateTimePicker dtpToDate;
        private DateTimePicker dtpFromDate;
        private Button btnReturn;
    }
}
