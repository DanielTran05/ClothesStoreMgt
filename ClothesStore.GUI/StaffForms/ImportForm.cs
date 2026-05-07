using ClothesStore.BUS;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ClothesStore.GUI.StaffForms
{
    public partial class ImportForm : Form
    {
        private WarehouseService warehouseService = new WarehouseService();
        private SupplierService supplierService = new SupplierService();

        private DataTable detailsTable = new DataTable();

        private int currentReceiptId = -1;

        public ImportForm()
        {
            InitializeComponent();

            LoadSupplier();
            SetupGrid();
            SetupUI();
        }

        private void SetupUI()
        {
            BackColor = Color.White;
            StartPosition = FormStartPosition.CenterScreen;

            dgvDetail.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvDetail.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvDetail.MultiSelect = false;

            dgvDetail.AllowUserToAddRows = false;

            dgvDetail.RowHeadersVisible = false;

            dgvDetail.BorderStyle = BorderStyle.None;

            dgvDetail.BackgroundColor = Color.White;

            dgvDetail.EnableHeadersVisualStyles = false;

            dgvDetail.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvDetail.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(52, 152, 219);

            dgvDetail.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvDetail.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvDetail.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dgvDetail.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(41, 128, 185);

            dgvDetail.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvDetail.RowTemplate.Height = 32;

            dgvDetail.ColumnHeadersHeight = 38;

            btnCreateReceipt.BackColor =
                Color.FromArgb(46, 204, 113);

            btnCreateReceipt.ForeColor = Color.White;

            btnCreateReceipt.FlatStyle = FlatStyle.Flat;

            btnCreateReceipt.FlatAppearance.BorderSize = 0;

            btnAddDetail.BackColor =
                Color.FromArgb(52, 152, 219);

            btnAddDetail.ForeColor = Color.White;

            btnAddDetail.FlatStyle = FlatStyle.Flat;

            btnAddDetail.FlatAppearance.BorderSize = 0;
        }

        private void LoadSupplier()
        {
            DataTable dt = supplierService.GetAll();

            cbSupplier.DataSource = dt;
            cbSupplier.DisplayMember = "SupplierName";
            cbSupplier.ValueMember = "SupplierID";
        }

        private void SetupGrid()
        {
            detailsTable.Columns.Add("VariantID");
            detailsTable.Columns.Add("Quantity");
            detailsTable.Columns.Add("ImportPrice");
            detailsTable.Columns.Add("Total");

            dgvDetail.DataSource = detailsTable;
        }

        private void btnCreateReceipt_Click(object sender, EventArgs e)
        {
            if (cbSupplier.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!");
                return;
            }

            currentReceiptId = warehouseService.CreateReceipt(
                Convert.ToInt32(cbSupplier.SelectedValue),
                GlobalSession.CurrentUser.UserId
            );

            MessageBox.Show("Tạo phiếu nhập thành công!");
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (currentReceiptId == -1)
            {
                MessageBox.Show("Vui lòng tạo phiếu trước!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtVariantId.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            int variantId = Convert.ToInt32(txtVariantId.Text);
            int quantity = Convert.ToInt32(txtQuantity.Text);
            decimal price = Convert.ToDecimal(txtPrice.Text);

            warehouseService.AddReceiptDetail(
                currentReceiptId,
                variantId,
                quantity,
                price
            );

            decimal total = quantity * price;

            detailsTable.Rows.Add(
                variantId,
                quantity,
                price,
                total
            );

            MessageBox.Show("Đã thêm sản phẩm!");

            txtVariantId.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();
        }
    }
}