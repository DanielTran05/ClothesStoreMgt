using ClothesStore.BUS;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; 
using ClothesStore.DTO.StatisticDTO;

namespace ClothesStore.GUI
{
    public partial class ucStatistic_Admin : UserControl
    {
        private readonly StatisticServiceAdmin _statisticService = new StatisticServiceAdmin();

        public ucStatistic_Admin()
        {
            InitializeComponent();
            chartRevenue.FormatNumber += chartRevenue_FormatNumber;
        }
        private void chartRevenue_FormatNumber(object sender, FormatNumberEventArgs e)
        {
            if (e.ElementType == ChartElementType.AxisLabels)
            {
                e.LocalizedValue = FormatMoneySmart((decimal)e.Value);
            }
        }

        private async void ucStatistic_Load(object sender, EventArgs e)
        {
            if (cboTopType.Items.Count == 0)
            {
                cboTopType.Items.Add("Top Sản Phẩm Bán Chạy");
                cboTopType.Items.Add("Top Sản Phẩm Bán Ế");
            }
            cboTopType.SelectedIndex = 0;
            await LoadAllStatistics();
        }

        private async void btnFilterRevenue_Click(object sender, EventArgs e)
        {
            if (dtpFrom.Value > dtpTo.Value)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!");
                return;
            }
            await LoadAllStatistics();
        }

        private async void cboTopType_SelectedIndexChanged(object sender, EventArgs e) => await LoadTopProducts();

        private string FormatMoneySmart(decimal amount)
        {
            bool isNegative = amount < 0;
            decimal absAmount = Math.Abs(amount);
            string result = "";

            if (absAmount >= 1000000000)
                result = (absAmount / 1000000000m).ToString("0.#") + "B";
            else if (absAmount >= 1000000)
                result = (absAmount / 1000000m).ToString("0.#") + "M";
            else if (absAmount >= 1000)
                result = (absAmount / 1000m).ToString("0.#") + "K";
            else
                result = absAmount.ToString("0.#");

            return isNegative ? "-" + result : result;
        }

        private async Task LoadAllStatistics()
        {
            try
            {
                DateTime fromDate = new DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, 1);
                int daysInToMonth = DateTime.DaysInMonth(dtpTo.Value.Year, dtpTo.Value.Month);
                DateTime toDate = new DateTime(dtpTo.Value.Year, dtpTo.Value.Month, daysInToMonth);

                var taskRevenue = _statisticService.GetRevenueProfit(fromDate, toDate);
                var taskCategory = _statisticService.GetProductCountByCategory(fromDate, toDate);
                var taskStatus = _statisticService.GetOrderStatus(fromDate, toDate);
                var taskStaff = _statisticService.GetTopEmployees(fromDate, toDate);
                var taskSupplier = _statisticService.GetTopSuppliers();
                var taskLowStock = _statisticService.GetLowStockProducts(10);

                await Task.WhenAll(taskRevenue, taskCategory, taskStatus, taskStaff, taskSupplier, taskLowStock);

                chartRevenue.Series["Doanh thu"].Points.Clear();
                chartRevenue.Series["Lợi nhuận"].Points.Clear();
                chartRevenue.Series["Doanh thu"].IsXValueIndexed = true;
                chartRevenue.Series["Lợi nhuận"].IsXValueIndexed = true;
                chartRevenue.Series["Doanh thu"].IsValueShownAsLabel = true;
                chartRevenue.Series["Lợi nhuận"].IsValueShownAsLabel = true;

                chartRevenue.Series["Doanh thu"]["PointWidth"] = "0.85";
                chartRevenue.Series["Lợi nhuận"]["PointWidth"] = "0.85";
                chartRevenue.Series["Doanh thu"].LabelFormat = "";
                chartRevenue.Series["Lợi nhuận"].LabelFormat = "";
                chartRevenue.ChartAreas[0].AxisY.LabelStyle.Format = "";
                chartRevenue.ChartAreas[0].AxisY.Title = "";
                chartRevenue.ChartAreas[0].AxisX.Title = "Thời gian (Tháng/Năm)";

                decimal totalRev = 0, totalProf = 0;
                foreach (var item in await taskRevenue)
                {
                    string xAxisLabel = $"{item.Month:D2}/{item.Year}";
                    int idxRev = chartRevenue.Series["Doanh thu"].Points.AddXY(xAxisLabel, item.Revenue);
                    int idxProf = chartRevenue.Series["Lợi nhuận"].Points.AddXY(xAxisLabel, item.Profit);
                    chartRevenue.Series["Doanh thu"].Points[idxRev].Label = FormatMoneySmart(item.Revenue);
                    chartRevenue.Series["Lợi nhuận"].Points[idxProf].Label = FormatMoneySmart(item.Profit);

                    totalRev += item.Revenue;
                    totalProf += item.Profit;
                }
                lblRevenueValue.Text = string.Format("{0:N0} đ", totalRev);
                lblProfitValue.Text = string.Format("{0:N0} đ", totalProf);

                var statusData = await taskStatus;
                lblSuccessOrdersValue.Text = (statusData.FirstOrDefault(x => x.StatusName == "Thành công")?.OrderCount.ToString() ?? "0") + " Đơn hàng";
                lblLowStockValue.Text = (await taskLowStock).Count.ToString() + " Sản phẩm";

                chartOrderStatus.Series[0].IsXValueIndexed = true;
                chartOrderStatus.Series[0].Points.Clear();
                chartOrderStatus.Series[0].IsValueShownAsLabel = true;

                foreach (var item in statusData)
                {
                    int pointIndex = chartOrderStatus.Series[0].Points.AddXY(item.StatusName, item.OrderCount);
                    var currentPoint = chartOrderStatus.Series[0].Points[pointIndex];
                    switch (item.StatusName)
                    {
                        case "Chờ duyệt":
                            currentPoint.Color = Color.Orange; 
                            break;
                        case "Đã thanh toán":
                            currentPoint.Color = Color.DeepSkyBlue; 
                            break;
                        case "Đang giao":
                            currentPoint.Color = Color.MediumPurple; 
                            break;
                        case "Thành công":
                            currentPoint.Color = Color.MediumSeaGreen; 
                            break;
                        case "Đã hủy":
                            currentPoint.Color = Color.Crimson; 
                            break;
                        case "Trả hàng":
                            currentPoint.Color = Color.SlateGray; 
                            break;
                        default:
                            currentPoint.Color = Color.DarkGray; 
                            break;
                    }
                }
                chartCategory.Series[0].Points.Clear();
                chartCategory.Series[0].IsValueShownAsLabel = true;
                foreach (var item in await taskCategory)
                {
                    if (item.TotalVariants > 0)
                    {
                        int pIndex = chartCategory.Series[0].Points.AddXY(item.CategoryName, item.TotalVariants);
                        chartCategory.Series[0].Points[pIndex].LegendText = item.CategoryName;
                        chartCategory.Series[0].Points[pIndex].Label = "#PERCENT{P0}";
                    }
                }
                dgvTopStaff.DataSource = await taskStaff;
                FormatStaffGrid();

                dgvTopSuppliers.DataSource = await taskSupplier;
                FormatSupplierGrid();

                await LoadTopProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadTopProducts()
        {
            try
            {
                bool isBestSeller = (cboTopType.SelectedIndex == 0);
                var data = await _statisticService.GetTop5Products(dtpFrom.Value, dtpTo.Value, isBestSeller);
                dgvTopProducts.DataSource = data;
                FormatProductGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy Top Sản Phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatProductGrid()
        {
            if (dgvTopProducts.Columns["ProductID"] != null)
            {
                dgvTopProducts.Columns["ProductID"].Visible = true;
                dgvTopProducts.Columns["ProductID"].HeaderText = "Mã SP";
                dgvTopProducts.Columns["ProductID"].FillWeight = 20;
            }
            if (dgvTopProducts.Columns["ProductName"] != null) dgvTopProducts.Columns["ProductName"].HeaderText = "Tên Sản Phẩm";
            if (dgvTopProducts.Columns["TotalQty"] != null)
            {
                dgvTopProducts.Columns["TotalQty"].HeaderText = "Số Lượng";
                dgvTopProducts.Columns["TotalQty"].FillWeight = 30;
            }
        }

        private void FormatStaffGrid()
        {
            if (dgvTopStaff.Columns["EmployeeID"] != null) dgvTopStaff.Columns["EmployeeID"].Visible = false;
            if (dgvTopStaff.Columns["FullName"] != null) dgvTopStaff.Columns["FullName"].HeaderText = "Tên Nhân Viên";
            if (dgvTopStaff.Columns["OrderCount"] != null)
            {
                dgvTopStaff.Columns["OrderCount"].HeaderText = "Số Đơn Chốt";
                dgvTopStaff.Columns["OrderCount"].FillWeight = 40;
            }
        }

        private void FormatSupplierGrid()
        {
            if (dgvTopSuppliers.Columns["SupplierID"] != null)
            {
                dgvTopSuppliers.Columns["SupplierID"].Visible = true;
                dgvTopSuppliers.Columns["SupplierID"].HeaderText = "Mã NCC";
                dgvTopSuppliers.Columns["SupplierID"].FillWeight = 20;
            }
            if (dgvTopSuppliers.Columns["SupplierName"] != null) dgvTopSuppliers.Columns["SupplierName"].HeaderText = "Nhà Cung Cấp";
            if (dgvTopSuppliers.Columns["ImportCount"] != null)
            {
                dgvTopSuppliers.Columns["ImportCount"].HeaderText = "Số Lần Nhập";
                dgvTopSuppliers.Columns["ImportCount"].FillWeight = 30;
            }
        }
    }
}