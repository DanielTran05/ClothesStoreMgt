using ClothesStore.BUS;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ClothesStore.GUI.StaffForms
{
    public partial class StatisticForm : Form
    {
        private WarehouseService service = new WarehouseService();

        public StatisticForm()
        {
            InitializeComponent();

            SetupUI();
            LoadTodaySales();
            LoadStatisticTable();
        }

        private void SetupUI()
        {
            dgvStatistic.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvStatistic.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvStatistic.MultiSelect = false;

            dgvStatistic.AllowUserToAddRows = false;

            dgvStatistic.RowHeadersVisible = false;

            dgvStatistic.BorderStyle = BorderStyle.None;

            dgvStatistic.BackgroundColor = Color.White;

            dgvStatistic.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvStatistic.EnableHeadersVisualStyles = false;

            dgvStatistic.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(52, 152, 219);

            dgvStatistic.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvStatistic.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Bold);

            dgvStatistic.ColumnHeadersHeight = 40;

            dgvStatistic.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dgvStatistic.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(41, 128, 185);

            dgvStatistic.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvStatistic.RowTemplate.Height = 35;
        }

        private void LoadTodaySales()
        {
            lblTotal.Text =
                service.GetTodaySales().ToString("N0") + " VNĐ";
        }

        private void LoadStatisticTable()
        {
            DataTable dt = service.GetTodayStatistic();

            dgvStatistic.DataSource = dt;

            if (dgvStatistic.Columns["ProductName"] != null)
                dgvStatistic.Columns["ProductName"].HeaderText =
                    "Tên Sản Phẩm";

            if (dgvStatistic.Columns["SoldQuantity"] != null)
                dgvStatistic.Columns["SoldQuantity"].HeaderText =
                    "Đã Bán";

            if (dgvStatistic.Columns["ImportedQuantity"] != null)
                dgvStatistic.Columns["ImportedQuantity"].HeaderText =
                    "Đã Nhập";
        }
    }
}