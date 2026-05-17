using ClothesStore.BUS;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ClothesStore.GUI.StaffForms
{
    public partial class ReceiptDetailForm : Form
    {
        private WarehouseService warehouseService =
            new WarehouseService();

        private int receiptId;

        public ReceiptDetailForm(
            int receiptId)
        {
            InitializeComponent();

            this.receiptId =
                receiptId;

            SetupUI();

            LoadDetail();
        }

        // ================= UI =================
        private void SetupUI()
        {
            BackColor =
                Color.White;

            StartPosition =
                FormStartPosition.CenterParent;

            Text =
                "Chi tiết phiếu nhập";

            Size =
                new Size(900, 500);

            lblTitle.Text =
                "CHI TIẾT PHIẾU NHẬP";

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    16,
                    FontStyle.Bold
                );

            lblTitle.ForeColor =
                Color.FromArgb(52, 73, 94);

            dgvReceiptDetail.Dock =
                DockStyle.Bottom;

            dgvReceiptDetail.Height =
                380;

            SetupDataGridView(
                dgvReceiptDetail
            );
        }

        private void SetupDataGridView(
            DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgv.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgv.MultiSelect =
                false;

            dgv.AllowUserToAddRows =
                false;

            dgv.RowHeadersVisible =
                false;

            dgv.BorderStyle =
                BorderStyle.None;

            dgv.BackgroundColor =
                Color.White;

            dgv.EnableHeadersVisualStyles =
                false;

            dgv.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgv.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(52, 152, 219);

            dgv.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            dgv.ColumnHeadersHeight =
                40;

            dgv.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10
                );

            dgv.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(41, 128, 185);

            dgv.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgv.RowTemplate.Height =
                35;
        }

        private void LoadDetail()
        {
            dgvReceiptDetail.DataSource =
                warehouseService
                .GetReceiptDetails(
                    receiptId
                );

            SetupColumn();
        }

        private void SetupColumn()
        {
            if (dgvReceiptDetail.Columns["ReceiptDetailID"] != null)
            {
                dgvReceiptDetail.Columns["ReceiptDetailID"]
                    .HeaderText =
                    "Mã CT";
            }

            if (dgvReceiptDetail.Columns["SKU"] != null)
            {
                dgvReceiptDetail.Columns["SKU"]
                    .HeaderText =
                    "SKU";
            }

            if (dgvReceiptDetail.Columns["ProductName"] != null)
            {
                dgvReceiptDetail.Columns["ProductName"]
                    .HeaderText =
                    "Tên Sản Phẩm";
            }

            if (dgvReceiptDetail.Columns["Quantity"] != null)
            {
                dgvReceiptDetail.Columns["Quantity"]
                    .HeaderText =
                    "Số Lượng";
            }

            if (dgvReceiptDetail.Columns["ImportPrice"] != null)
            {
                dgvReceiptDetail.Columns["ImportPrice"]
                    .HeaderText =
                    "Đơn Giá";

                dgvReceiptDetail.Columns["ImportPrice"]
                    .DefaultCellStyle.Format =
                    "N0";
            }

            if (dgvReceiptDetail.Columns["Total"] != null)
            {
                dgvReceiptDetail.Columns["Total"]
                    .HeaderText =
                    "Thành Tiền";

                dgvReceiptDetail.Columns["Total"]
                    .DefaultCellStyle.Format =
                    "N0";
            }
        }
    }
}