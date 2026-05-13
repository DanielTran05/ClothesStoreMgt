using ClothesStore.BUS;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ClothesStore.GUI.StaffForms
{
    public partial class ImportForm : Form
    {
        private WarehouseService warehouseService =
            new WarehouseService();

        private SupplierService supplierService =
            new SupplierService();

        private ProductService productService =
            new ProductService();

        private DataTable detailsTable =
            new DataTable();

        public ImportForm()
        {
            InitializeComponent();

            SetupUI();

            SetupGrid();

            SetupFilter();

            LoadSupplier();

            LoadVariant();

            LoadImportHistory();
        }

        private void SetupUI()
        {
            BackColor =
                Color.White;

            StartPosition =
                FormStartPosition.CenterScreen;

            SetupDataGridView(dgvDetail);

            SetupDataGridView(dgvHistory);

            btnCreateReceipt.BackColor =
                Color.FromArgb(46, 204, 113);

            btnCreateReceipt.ForeColor =
                Color.White;

            btnCreateReceipt.FlatStyle =
                FlatStyle.Flat;

            btnCreateReceipt.FlatAppearance.BorderSize =
                0;

            btnAddDetail.BackColor =
                Color.FromArgb(52, 152, 219);

            btnAddDetail.ForeColor =
                Color.White;

            btnAddDetail.FlatStyle =
                FlatStyle.Flat;

            btnAddDetail.FlatAppearance.BorderSize =
                0;

            cbSupplier.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cbVariant.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cbFilterType.DropDownStyle =
                ComboBoxStyle.DropDownList;
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

            dgv.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(41, 128, 185);

            dgv.DefaultCellStyle.SelectionForeColor =
                Color.White;
        }

        private void SetupFilter()
        {
            cbFilterType.Items.Add(
                "Theo ngày nhập");

            cbFilterType.Items.Add(
                "Theo công ty");

            cbFilterType.SelectedIndex = 0;

            cbFilterType.SelectedIndexChanged +=
                cbFilterType_SelectedIndexChanged;

            dtImportDate.ValueChanged +=
                dtImportDate_ValueChanged;
        }

        private void SetupGrid()
        {
            detailsTable.Columns.Add(
                "VariantID");

            detailsTable.Columns.Add(
                "SKU");

            detailsTable.Columns.Add(
                "Quantity");

            detailsTable.Columns.Add(
                "ImportPrice");

            detailsTable.Columns.Add(
                "Total");

            dgvDetail.DataSource =
                detailsTable;

            SetupDetailColumn();
        }

        private void SetupDetailColumn()
        {
            if (dgvDetail.Columns["VariantID"] != null)
            {
                dgvDetail.Columns["VariantID"]
                    .Visible = false;
            }

            if (dgvDetail.Columns["SKU"] != null)
            {
                dgvDetail.Columns["SKU"]
                    .HeaderText =
                    "SKU";
            }

            if (dgvDetail.Columns["Quantity"] != null)
            {
                dgvDetail.Columns["Quantity"]
                    .HeaderText =
                    "Số Lượng";
            }

            if (dgvDetail.Columns["ImportPrice"] != null)
            {
                dgvDetail.Columns["ImportPrice"]
                    .HeaderText =
                    "Giá Nhập";

                dgvDetail.Columns["ImportPrice"]
                    .DefaultCellStyle.Format =
                    "N0";
            }

            if (dgvDetail.Columns["Total"] != null)
            {
                dgvDetail.Columns["Total"]
                    .HeaderText =
                    "Thành Tiền";

                dgvDetail.Columns["Total"]
                    .DefaultCellStyle.Format =
                    "N0";
            }
        }

        private void LoadSupplier()
        {
            DataTable dt =
                supplierService.GetAll();

            cbSupplier.DataSource =
                null;

            cbSupplier.DisplayMember =
                "SupplierName";

            cbSupplier.ValueMember =
                "SupplierID";

            cbSupplier.DataSource =
                dt;

            cbSupplier.SelectedIndex =
                -1;
        }

        private void LoadVariant()
        {
            DataTable dt =
                productService
                .SearchProductForStaff("");

            cbVariant.DataSource =
                null;

            if (dt != null &&
                dt.Rows.Count > 0)
            {
                cbVariant.DisplayMember =
                    "SKU";

                cbVariant.ValueMember =
                    "VariantID";

                cbVariant.DataSource =
                    dt;

                cbVariant.SelectedIndex =
                    -1;
            }
        }

        private void LoadImportHistory()
        {
            dgvHistory.DataSource =
                warehouseService
                .GetImportHistory("");

            SetupHistoryColumn();
        }

        private void SetupHistoryColumn()
        {
            if (dgvHistory.Columns["ReceiptID"] != null)
            {
                dgvHistory.Columns["ReceiptID"]
                    .HeaderText =
                    "Mã Phiếu";
            }

            if (dgvHistory.Columns["SupplierName"] != null)
            {
                dgvHistory.Columns["SupplierName"]
                    .HeaderText =
                    "Công Ty";
            }

            if (dgvHistory.Columns["ImportDate"] != null)
            {
                dgvHistory.Columns["ImportDate"]
                    .HeaderText =
                    "Ngày Nhập";
            }

            if (dgvHistory.Columns["ProductName"] != null)
            {
                dgvHistory.Columns["ProductName"]
                    .HeaderText =
                    "Sản Phẩm";
            }

            if (dgvHistory.Columns["SKU"] != null)
            {
                dgvHistory.Columns["SKU"]
                    .HeaderText =
                    "SKU";
            }

            if (dgvHistory.Columns["Quantity"] != null)
            {
                dgvHistory.Columns["Quantity"]
                    .HeaderText =
                    "Số Lượng";
            }

            if (dgvHistory.Columns["ImportPrice"] != null)
            {
                dgvHistory.Columns["ImportPrice"]
                    .HeaderText =
                    "Giá Nhập";

                dgvHistory.Columns["ImportPrice"]
                    .DefaultCellStyle.Format =
                    "N0";
            }

            if (dgvHistory.Columns["Total"] != null)
            {
                dgvHistory.Columns["Total"]
                    .HeaderText =
                    "Thành Tiền";

                dgvHistory.Columns["Total"]
                    .DefaultCellStyle.Format =
                    "N0";
            }
        }

        private void btnAddDetail_Click(
            object? sender,
            EventArgs e)
        {
            if (cbVariant.SelectedValue == null ||
                string.IsNullOrWhiteSpace(
                    txtQuantity.Text) ||
                string.IsNullOrWhiteSpace(
                    txtPrice.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ thông tin!");

                return;
            }

            int variantId =
                Convert.ToInt32(
                    cbVariant.SelectedValue);

            string sku =
                cbVariant.Text;

            int quantity =
                Convert.ToInt32(
                    txtQuantity.Text);

            decimal price =
                Convert.ToDecimal(
                    txtPrice.Text);

            decimal total =
                quantity * price;

            detailsTable.Rows.Add(
                variantId,
                sku,
                quantity,
                price,
                total
            );

            txtQuantity.Clear();

            txtPrice.Clear();

            cbVariant.SelectedIndex =
                -1;
        }

        private void btnCreateReceipt_Click(
            object? sender,
            EventArgs e)
        {
            if (cbSupplier.SelectedValue == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn nhà cung cấp!");

                return;
            }

            if (detailsTable.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng thêm sản phẩm nhập!");

                return;
            }

            int receiptId =
                warehouseService
                .CreateReceipt(
                    Convert.ToInt32(
                        cbSupplier.SelectedValue),

                    GlobalSession
                    .CurrentUser
                    .UserId
                );

            foreach (DataRow row
                in detailsTable.Rows)
            {
                int variantId =
                    Convert.ToInt32(
                        row["VariantID"]);

                int quantity =
                    Convert.ToInt32(
                        row["Quantity"]);

                decimal price =
                    Convert.ToDecimal(
                        row["ImportPrice"]);

                warehouseService
                    .AddReceiptDetail(
                        receiptId,
                        variantId,
                        quantity,
                        price
                    );

                warehouseService
                    .AddInventoryTransaction(
                        variantId,
                        "IMPORT",
                        quantity,
                        receiptId
                    );
            }

            MessageBox.Show(
                "Tạo phiếu nhập thành công!");

            detailsTable.Clear();

            cbSupplier.SelectedIndex =
                -1;

            LoadImportHistory();
        }

        private void cbFilterType_SelectedIndexChanged(
            object? sender,
            EventArgs e)
        {
            FilterHistory();
        }

        private void dtImportDate_ValueChanged(
            object? sender,
            EventArgs e)
        {
            if (cbFilterType.SelectedIndex == 0)
            {
                FilterHistory();
            }
        }

        private void FilterHistory()
        {
            string supplier = "";

            if (cbFilterType.SelectedIndex == 1)
            {
                supplier =
                    cbSupplier.Text?.Trim() ?? "";
            }

            DataTable dt =
                warehouseService
                .GetImportHistory(
                    supplier
                );

            DataView dv =
                dt.DefaultView;

            if (cbFilterType.SelectedIndex == 0)
            {
                string date =
                    dtImportDate.Value
                    .Date
                    .ToString("yyyy-MM-dd");

                dv.RowFilter =
                    $"Convert(ImportDate, 'System.String') LIKE '%{date}%'";
            }

            dgvHistory.DataSource =
                dv.ToTable();

            SetupHistoryColumn();
        }
    }
}