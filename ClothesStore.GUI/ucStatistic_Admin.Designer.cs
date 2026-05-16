namespace ClothesStore.GUI
{
    partial class ucStatistic_Admin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            DataGridViewCellStyle gridHeaderStyle = new DataGridViewCellStyle();
            flowLayoutPanel2 = new FlowLayoutPanel();
            pnlRevenue = new Panel();
            lblRevenueValue = new Label();
            label9 = new Label();
            pnlProfit = new Panel();
            lblProfitValue = new Label();
            label4 = new Label();
            pnlSuccessOrders = new Panel();
            lblSuccessOrdersValue = new Label();
            label11 = new Label();
            pnlLowStock = new Panel();
            lblLowStockValue = new Label();
            label13 = new Label();
            flowLayoutPanel3 = new FlowLayoutPanel();
            label12 = new Label();
            dtpFrom = new DateTimePicker();
            label14 = new Label();
            dtpTo = new DateTimePicker();
            btnFilterRevenue = new Button();
            pnlScrollArea = new Panel();
            tlpDashboard = new TableLayoutPanel();
            panel5 = new Panel();
            chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartOrderStatus = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel1 = new Panel();
            dgvTopProducts = new DataGridView();
            panel4 = new Panel();
            cboTopType = new ComboBox();
            label6 = new Label();
            chartCategory = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel2 = new Panel();
            dgvTopStaff = new DataGridView();
            label8 = new Label();
            panel3 = new Panel();
            dgvTopSuppliers = new DataGridView();
            label10 = new Label();
            // Grid Header Style Chung
            gridHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridHeaderStyle.BackColor = Color.FromArgb(24, 119, 242);
            gridHeaderStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gridHeaderStyle.ForeColor = Color.White;
            gridHeaderStyle.SelectionBackColor = SystemColors.Highlight;
            gridHeaderStyle.SelectionForeColor = SystemColors.HighlightText;
            gridHeaderStyle.WrapMode = DataGridViewTriState.True;
            flowLayoutPanel2.SuspendLayout();
            pnlRevenue.SuspendLayout();
            pnlProfit.SuspendLayout();
            pnlSuccessOrders.SuspendLayout();
            pnlLowStock.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            pnlScrollArea.SuspendLayout();
            tlpDashboard.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartRevenue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartOrderStatus).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopProducts).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartCategory).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopStaff).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopSuppliers).BeginInit();
            SuspendLayout();
            // flowLayoutPanel2 (Chứa KPI)
            flowLayoutPanel2.BackColor = Color.White;
            flowLayoutPanel2.Controls.Add(pnlRevenue);
            flowLayoutPanel2.Controls.Add(pnlProfit);
            flowLayoutPanel2.Controls.Add(pnlSuccessOrders);
            flowLayoutPanel2.Controls.Add(pnlLowStock);
            flowLayoutPanel2.Dock = DockStyle.Top;
            flowLayoutPanel2.Location = new Point(0, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1645, 120);
            flowLayoutPanel2.TabIndex = 1;
            // pnlRevenue
            pnlRevenue.BackColor = Color.FromArgb(236, 252, 241);
            pnlRevenue.Controls.Add(lblRevenueValue);
            pnlRevenue.Controls.Add(label9);
            pnlRevenue.Location = new Point(20, 10);
            pnlRevenue.Margin = new Padding(20, 10, 10, 10);
            pnlRevenue.Name = "pnlRevenue";
            pnlRevenue.Size = new Size(260, 100);
            pnlRevenue.TabIndex = 3;
            // lblRevenueValue
            lblRevenueValue.AutoSize = true;
            lblRevenueValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRevenueValue.ForeColor = Color.FromArgb(40, 167, 69);
            lblRevenueValue.Location = new Point(10, 50);
            lblRevenueValue.Name = "lblRevenueValue";
            lblRevenueValue.Size = new Size(130, 28);
            lblRevenueValue.Text = "Số doanh thu";
            // label9
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label9.Location = new Point(10, 10);
            label9.Name = "label9";
            label9.Size = new Size(240, 30);
            label9.Text = "TỔNG DOANH THU";
            // pnlProfit
            pnlProfit.BackColor = Color.FromArgb(230, 242, 255);
            pnlProfit.Controls.Add(lblProfitValue);
            pnlProfit.Controls.Add(label4);
            pnlProfit.Location = new Point(300, 10);
            pnlProfit.Margin = new Padding(10);
            pnlProfit.Name = "pnlProfit";
            pnlProfit.Size = new Size(260, 100);
            pnlProfit.TabIndex = 0;
            // lblProfitValue
            lblProfitValue.AutoSize = true;
            lblProfitValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblProfitValue.ForeColor = Color.FromArgb(0, 123, 255);
            lblProfitValue.Location = new Point(10, 50);
            lblProfitValue.Name = "lblProfitValue";
            lblProfitValue.Size = new Size(121, 28);
            lblProfitValue.Text = "Số lợi nhuận";
            // label4
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(10, 10);
            label4.Name = "label4";
            label4.Size = new Size(240, 30);
            label4.Text = "TỔNG LỢI NHUẬN";
            // pnlSuccessOrders
            pnlSuccessOrders.BackColor = Color.FromArgb(253, 245, 230);
            pnlSuccessOrders.Controls.Add(lblSuccessOrdersValue);
            pnlSuccessOrders.Controls.Add(label11);
            pnlSuccessOrders.Location = new Point(580, 10);
            pnlSuccessOrders.Margin = new Padding(10);
            pnlSuccessOrders.Name = "pnlSuccessOrders";
            pnlSuccessOrders.Size = new Size(260, 100);
            pnlSuccessOrders.TabIndex = 3;
            // lblSuccessOrdersValue
            lblSuccessOrdersValue.AutoSize = true;
            lblSuccessOrdersValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSuccessOrdersValue.ForeColor = Color.FromArgb(253, 126, 20);
            lblSuccessOrdersValue.Location = new Point(10, 50);
            lblSuccessOrdersValue.Name = "lblSuccessOrdersValue";
            lblSuccessOrdersValue.Size = new Size(124, 28);
            lblSuccessOrdersValue.Text = "Số đơn hàng";
            // label11
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label11.Location = new Point(10, 10);
            label11.Name = "label11";
            label11.Size = new Size(240, 30);
            label11.Text = "ĐƠN THÀNH CÔNG";
            // pnlLowStock
            pnlLowStock.BackColor = Color.FromArgb(255, 235, 238);
            pnlLowStock.Controls.Add(lblLowStockValue);
            pnlLowStock.Controls.Add(label13);
            pnlLowStock.Location = new Point(860, 10);
            pnlLowStock.Margin = new Padding(10);
            pnlLowStock.Name = "pnlLowStock";
            pnlLowStock.Size = new Size(260, 100);
            pnlLowStock.TabIndex = 3;
            // lblLowStockValue
            lblLowStockValue.AutoSize = true;
            lblLowStockValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblLowStockValue.ForeColor = Color.FromArgb(220, 53, 69);
            lblLowStockValue.Location = new Point(10, 50);
            lblLowStockValue.Name = "lblLowStockValue";
            lblLowStockValue.Size = new Size(152, 28);
            lblLowStockValue.Text = "Số hàng sắp hết";
            // label13
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label13.Location = new Point(10, 10);
            label13.Name = "label13";
            label13.Size = new Size(240, 30);
            label13.Text = "SẮP HẾT KHO";
            // flowLayoutPanel3 (Thanh Lọc Đã Tách Ra Ngoài)
            flowLayoutPanel3.BackColor = Color.FromArgb(240, 244, 248);
            flowLayoutPanel3.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel3.Controls.Add(label12);
            flowLayoutPanel3.Controls.Add(dtpFrom);
            flowLayoutPanel3.Controls.Add(label14);
            flowLayoutPanel3.Controls.Add(dtpTo);
            flowLayoutPanel3.Controls.Add(btnFilterRevenue);
            flowLayoutPanel3.Dock = DockStyle.Top;
            flowLayoutPanel3.Location = new Point(0, 120);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Padding = new Padding(12);
            flowLayoutPanel3.Size = new Size(1645, 65);
            flowLayoutPanel3.TabIndex = 2;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label12.Location = new Point(15, 18);
            label12.Text = "Từ tháng:";
            dtpFrom.CustomFormat = "MM/yyyy";
            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.Location = new Point(100, 15);
            dtpFrom.Size = new Size(120, 30);
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label14.Location = new Point(230, 18);
            label14.Text = "Đến tháng:";
            dtpTo.CustomFormat = "MM/yyyy";
            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.Location = new Point(320, 15);
            dtpTo.Size = new Size(120, 30);
            btnFilterRevenue.Location = new Point(450, 13);
            btnFilterRevenue.Size = new Size(120, 32);
            btnFilterRevenue.Text = "Bắt đầu lọc";
            btnFilterRevenue.Click += btnFilterRevenue_Click;
            // pnlScrollArea
            pnlScrollArea.AutoScroll = true;
            pnlScrollArea.Controls.Add(tlpDashboard);
            pnlScrollArea.Dock = DockStyle.Fill;
            pnlScrollArea.Location = new Point(0, 185);
            pnlScrollArea.Name = "pnlScrollArea";
            pnlScrollArea.Padding = new Padding(12);
            pnlScrollArea.Size = new Size(1645, 703);
            pnlScrollArea.TabIndex = 3;
            // tlpDashboard
            tlpDashboard.ColumnCount = 2;
            tlpDashboard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpDashboard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpDashboard.Controls.Add(panel5, 0, 0);
            tlpDashboard.Controls.Add(chartOrderStatus, 1, 0);
            tlpDashboard.Controls.Add(panel1, 0, 1);
            tlpDashboard.Controls.Add(chartCategory, 1, 1);
            tlpDashboard.Controls.Add(panel2, 0, 2);
            tlpDashboard.Controls.Add(panel3, 1, 2);
            tlpDashboard.Dock = DockStyle.Top;
            tlpDashboard.Location = new Point(12, 12);
            tlpDashboard.Name = "tlpDashboard";
            tlpDashboard.RowCount = 3;
            tlpDashboard.RowStyles.Add(new RowStyle(SizeType.Absolute, 450F));
            tlpDashboard.RowStyles.Add(new RowStyle(SizeType.Absolute, 400F));
            tlpDashboard.RowStyles.Add(new RowStyle(SizeType.Absolute, 400F));
            tlpDashboard.Size = new Size(1595, 1250);
            // panel5 (Chứa Chart Doanh Thu)
            panel5.Controls.Add(chartRevenue);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(10, 10);
            panel5.Margin = new Padding(10);
            panel5.Name = "panel5";
            panel5.Size = new Size(777, 430);
            // chartRevenue
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.LabelStyle.Format = "0.## 'Tr'";
            chartArea1.Name = "ChartArea1";
            chartRevenue.ChartAreas.Add(chartArea1);
            chartRevenue.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            chartRevenue.Legends.Add(legend1);
            chartRevenue.Name = "chartRevenue";
            series3.ChartArea = "ChartArea1";
            series3.Color = Color.LightSeaGreen;
            series3.Legend = "Legend1";
            series3.Name = "Doanh thu";
            series3.LabelFormat = "0.## 'Tr'";
            series4.ChartArea = "ChartArea1";
            series4.Color = Color.Blue;
            series4.Legend = "Legend1";
            series4.Name = "Lợi nhuận";
            series4.LabelFormat = "0.## 'Tr'";
            chartRevenue.Series.Add(series3);
            chartRevenue.Series.Add(series4);
            title3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            title3.Text = "THỐNG KÊ DOANH THU & LỢI NHUẬN";
            chartRevenue.Titles.Add(title3);
            // chartOrderStatus
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.Name = "ChartArea1";
            chartOrderStatus.ChartAreas.Add(chartArea2);
            chartOrderStatus.Dock = DockStyle.Fill;
            legend2.Name = "Legend1";
            chartOrderStatus.Legends.Add(legend2);
            chartOrderStatus.Location = new Point(807, 10);
            chartOrderStatus.Margin = new Padding(10);
            chartOrderStatus.Name = "chartOrderStatus";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Số lượng đơn";
            chartOrderStatus.Series.Add(series1);
            title1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            title1.Text = "BIỂU ĐỒ TRẠNG THÁI ĐƠN HÀNG";
            chartOrderStatus.Titles.Add(title1);
            // panel1 (Chứa DGV Sản phẩm)
            panel1.BackColor = Color.White;
            panel1.Controls.Add(dgvTopProducts);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(label6);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(10, 460);
            panel1.Margin = new Padding(10);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            // label6
            label6.AutoSize = true;
            label6.Dock = DockStyle.Top;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.Text = "TOP NHỮNG SẢN PHẨM BÁN CHẠY/Ế";
            // panel4 (Chứa Combo Box)
            panel4.Controls.Add(cboTopType);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(10, 30);
            panel4.Size = new Size(777, 50);
            cboTopType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTopType.Location = new Point(10, 10);
            cboTopType.Size = new Size(250, 30);
            cboTopType.SelectedIndexChanged += cboTopType_SelectedIndexChanged;
            // dgvTopProducts (Modern Style)
            dgvTopProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTopProducts.BackgroundColor = Color.White;
            dgvTopProducts.BorderStyle = BorderStyle.None;
            dgvTopProducts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTopProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTopProducts.ColumnHeadersDefaultCellStyle = gridHeaderStyle;
            dgvTopProducts.ColumnHeadersHeight = 40;
            dgvTopProducts.Dock = DockStyle.Fill;
            dgvTopProducts.EnableHeadersVisualStyles = false;
            dgvTopProducts.Location = new Point(10, 80);
            dgvTopProducts.Name = "dgvTopProducts";
            dgvTopProducts.RowHeadersVisible = false;
            dgvTopProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // chartCategory (Pie Chart Format)
            chartArea3.Name = "ChartArea1";
            chartCategory.ChartAreas.Add(chartArea3);
            chartCategory.Dock = DockStyle.Fill;
            legend3.Name = "Legend1";
            chartCategory.Legends.Add(legend3);
            chartCategory.Location = new Point(807, 460);
            chartCategory.Margin = new Padding(10);
            chartCategory.Name = "chartCategory";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Label = "#PERCENT{P0}";
            series2.LegendText = "#VALX";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartCategory.Series.Add(series2);
            title2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            title2.Text = "Tỷ lệ Sản phẩm theo Danh mục";
            chartCategory.Titles.Add(title2);
            // panel2 (DGV Nhân viên)
            panel2.BackColor = Color.White;
            panel2.Controls.Add(dgvTopStaff);
            panel2.Controls.Add(label8);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(10, 860);
            panel2.Margin = new Padding(10);
            panel2.Padding = new Padding(10);
            label8.AutoSize = true;
            label8.Dock = DockStyle.Top;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label8.Text = "TOP NHỮNG NHÂN VIÊN XUẤT SẮC";
            dgvTopStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTopStaff.BackgroundColor = Color.White;
            dgvTopStaff.BorderStyle = BorderStyle.None;
            dgvTopStaff.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTopStaff.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTopStaff.ColumnHeadersDefaultCellStyle = gridHeaderStyle;
            dgvTopStaff.ColumnHeadersHeight = 40;
            dgvTopStaff.Dock = DockStyle.Fill;
            dgvTopStaff.EnableHeadersVisualStyles = false;
            dgvTopStaff.Location = new Point(10, 30);
            dgvTopStaff.Name = "dgvTopStaff";
            dgvTopStaff.RowHeadersVisible = false;
            dgvTopStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // panel3 (DGV NCC)
            panel3.BackColor = Color.White;
            panel3.Controls.Add(dgvTopSuppliers);
            panel3.Controls.Add(label10);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(807, 860);
            panel3.Margin = new Padding(10);
            panel3.Padding = new Padding(10);
            label10.AutoSize = true;
            label10.Dock = DockStyle.Top;
            label10.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label10.Text = "TOP NHỮNG NHÀ CUNG CẤP TIỀM NĂNG";
            dgvTopSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTopSuppliers.BackgroundColor = Color.White;
            dgvTopSuppliers.BorderStyle = BorderStyle.None;
            dgvTopSuppliers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTopSuppliers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTopSuppliers.ColumnHeadersDefaultCellStyle = gridHeaderStyle;
            dgvTopSuppliers.ColumnHeadersHeight = 40;
            dgvTopSuppliers.Dock = DockStyle.Fill;
            dgvTopSuppliers.EnableHeadersVisualStyles = false;
            dgvTopSuppliers.Location = new Point(10, 30);
            dgvTopSuppliers.Name = "dgvTopSuppliers";
            dgvTopSuppliers.RowHeadersVisible = false;
            dgvTopSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // ucStatistic_Admin
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlScrollArea);
            Controls.Add(flowLayoutPanel3);
            Controls.Add(flowLayoutPanel2);
            Name = "ucStatistic_Admin";
            Size = new Size(1645, 888);
            Load += ucStatistic_Load;
            flowLayoutPanel2.ResumeLayout(false);
            pnlRevenue.ResumeLayout(false);
            pnlRevenue.PerformLayout();
            pnlProfit.ResumeLayout(false);
            pnlProfit.PerformLayout();
            pnlSuccessOrders.ResumeLayout(false);
            pnlSuccessOrders.PerformLayout();
            pnlLowStock.ResumeLayout(false);
            pnlLowStock.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            pnlScrollArea.ResumeLayout(false);
            tlpDashboard.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartRevenue).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartOrderStatus).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopProducts).EndInit();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartCategory).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopStaff).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopSuppliers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel pnlRevenue;
        private System.Windows.Forms.Label lblRevenueValue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlProfit;
        private System.Windows.Forms.Label lblProfitValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlSuccessOrders;
        private System.Windows.Forms.Label lblSuccessOrdersValue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pnlLowStock;
        private System.Windows.Forms.Label lblLowStockValue;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pnlScrollArea;
        private System.Windows.Forms.TableLayoutPanel tlpDashboard;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOrderStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvTopProducts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCategory;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvTopSuppliers;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvTopStaff;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cboTopType;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnFilterRevenue;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
    }
}