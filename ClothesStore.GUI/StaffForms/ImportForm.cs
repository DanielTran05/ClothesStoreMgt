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

            dtImportDate.Value =
                DateTime.Today;

            SetupUI();

            SetupGrid();

            LoadSupplier();

            LoadVariant();

            LoadImportHistory();

        }

        // ================= UI =================
        private void SetupUI()
        {
            BackColor =
                Color.White;

            StartPosition =
                FormStartPosition.CenterScreen;

            FormBorderStyle =
                FormBorderStyle.FixedSingle;

            MaximizeBox =
                false;

            SetupDataGridView(dgvDetail);

            SetupDataGridView(dgvHistory);

            // KHÓA GRID HISTORY
            dgvHistory.ReadOnly =
                true;

            dgvHistory.AllowUserToDeleteRows =
                false;

            dgvHistory.AllowUserToResizeRows =
                false;

            dgvHistory.EditMode =
                DataGridViewEditMode.EditProgrammatically;

            // KHÓA GRID DETAIL
            dgvDetail.ReadOnly =
                true;

            dgvDetail.AllowUserToDeleteRows =
                false;

            dgvDetail.AllowUserToResizeRows =
                false;

            dgvDetail.EditMode =
                DataGridViewEditMode.EditProgrammatically;

            // BUTTON CREATE
            btnCreateReceipt.BackColor =
                Color.FromArgb(46, 204, 113);

            btnCreateReceipt.ForeColor =
                Color.White;

            btnCreateReceipt.FlatStyle =
                FlatStyle.Flat;

            btnCreateReceipt.FlatAppearance.BorderSize =
                0;

            btnCreateReceipt.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            // BUTTON ADD
            btnAddDetail.BackColor =
                Color.FromArgb(52, 152, 219);

            btnAddDetail.ForeColor =
                Color.White;

            btnAddDetail.FlatStyle =
                FlatStyle.Flat;

            btnAddDetail.FlatAppearance.BorderSize =
                0;

            btnAddDetail.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            // BUTTON VIEW DETAIL
            btnViewDetail.BackColor =
                Color.FromArgb(155, 89, 182);

            btnViewDetail.ForeColor =
                Color.White;

            btnViewDetail.FlatStyle =
                FlatStyle.Flat;

            btnViewDetail.FlatAppearance.BorderSize =
                0;

            btnViewDetail.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            // COMBOBOX
            cbSupplier.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cbVariant.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cbFilterType.DropDownStyle =
                ComboBoxStyle.DropDownList;

            // TEXTBOX
            txtSearch.Enabled =
                false;

            txtSearch.BackColor =
                Color.Gainsboro;

            // DATE
            dtImportDate.Format =
                DateTimePickerFormat.Custom;

            dtImportDate.CustomFormat =
                "dd/MM/yyyy";

            // FILTER
            cbFilterType.Items.Clear();

            cbFilterType.Items.Add(
                "Theo ngày nhập");

            cbFilterType.Items.Add(
                "Theo công ty");

            cbFilterType.SelectedIndex =
                0;
        }

        // ================= DATAGRIDVIEW =================
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

            dgv.ColumnHeadersHeight =
                40;

            dgv.RowTemplate.Height =
                35;
        }

        // ================= GRID =================
        private void SetupGrid()
        {
            detailsTable.Columns.Add(
                "VariantID");

            detailsTable.Columns.Add(
                "Product");

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

        // ================= DETAIL COLUMN =================
        private void SetupDetailColumn()
        {
            if (dgvDetail.Columns["VariantID"] != null)
            {
                dgvDetail.Columns["VariantID"]
                    .Visible = false;
            }
        }

        // ================= LOAD SUPPLIER =================
        private void LoadSupplier()
        {
            DataTable dt =
                supplierService.GetAll();

            cbSupplier.DataSource =
                dt;

            cbSupplier.DisplayMember =
                "SupplierName";

            cbSupplier.ValueMember =
                "SupplierID";

            cbSupplier.SelectedIndex =
                -1;
        }

        // ================= LOAD VARIANT =================
        private void LoadVariant()
        {
            DataTable dt =
                productService
                .SearchProductForStaff("");

            cbVariant.DataSource =
                dt;

            cbVariant.DisplayMember =
                "SKU";

            cbVariant.ValueMember =
                "VariantID";

            cbVariant.SelectedIndex =
                -1;
        }

        // ================= LOAD HISTORY =================
        private void LoadImportHistory()
        {
            dgvHistory.DataSource =
                warehouseService
                .GetImportHistory();

            SetupHistoryColumn();

            FilterHistory();
        }

        // ================= HISTORY COLUMN =================
        private void SetupHistoryColumn()
        {
            if (dgvHistory.Columns["SupplierID"] != null)
            {
                dgvHistory.Columns["SupplierID"]
                    .Visible = false;
            }

            if (dgvHistory.Columns["EmployeeID"] != null)
            {
                dgvHistory.Columns["EmployeeID"]
                    .Visible = false;
            }

            if (dgvHistory.Columns["Status"] != null)
            {
                dgvHistory.Columns["Status"]
                    .Visible = false;
            }

            if (dgvHistory.Columns["StatusText"] != null)
            {
                dgvHistory.Columns["StatusText"]
                    .HeaderText =
                    "Trạng Thái";
            }
        }

        // ================= ADD DETAIL =================
        private void btnAddDetail_Click(
            object? sender,
            EventArgs e)
        {
            if (cbVariant.SelectedValue == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm!");

                return;
            }

            if (!int.TryParse(
                txtQuantity.Text,
                out int quantity))
            {
                MessageBox.Show(
                    "Số lượng không hợp lệ!");

                return;
            }

            if (!decimal.TryParse(
                txtPrice.Text,
                out decimal price))
            {
                MessageBox.Show(
                    "Giá nhập không hợp lệ!");

                return;
            }

            DataRowView row =
                (DataRowView)
                cbVariant.SelectedItem!;

            string product =
                row["ProductName"]
                .ToString()
                + " - "
                + row["SKU"]
                .ToString();

            decimal total =
                quantity * price;

            detailsTable.Rows.Add(
                cbVariant.SelectedValue,
                product,
                quantity,
                price,
                total
            );

            txtQuantity.Clear();

            txtPrice.Clear();

            cbVariant.SelectedIndex =
                -1;
        }

        // ================= CREATE RECEIPT =================
        private void btnCreateReceipt_Click(object? sender, EventArgs e)
        {
            // 1. Chốt chặn bảo vệ Session: Tránh lỗi NullReferenceException
            if (GlobalSession.CurrentUser == null)
            {
                MessageBox.Show("Phiên đăng nhập đã hết hạn hoặc không tìm thấy thông tin nhân viên. Vui lòng đăng nhập lại!", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Có thể gọi lệnh đẩy về màn hình Login ở đây
                return;
            }

            if (cbSupplier.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn công ty!");
                return;
            }

            if (detailsTable.Rows.Count == 0) // Lưu ý: Nếu lấy từ DataGridView thì phải check dgvDetail.Rows
            {
                MessageBox.Show("Chưa có sản phẩm!");
                return;
            }

            // 2. Tính tổng tiền
            decimal totalAmount = 0;
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                if (!row.IsNewRow)
                {
                    int qty = Convert.ToInt32(row.Cells["Quantity"].Value);
                    decimal price = Convert.ToDecimal(row.Cells["ImportPrice"].Value);
                    totalAmount += (qty * price);
                }
            }

            try
            {
                // 3. Đã đảo lại thứ tự tham số cho khớp với WarehouseService (SupplierId, EmployeeId, TotalAmount)
                int receiptId = warehouseService.CreateReceipt(
                    Convert.ToInt32(cbSupplier.SelectedValue),
                    GlobalSession.CurrentUser.UserId,
                    totalAmount
                );

                foreach (DataRow row in detailsTable.Rows)
                {
                    warehouseService.AddReceiptDetail(
                        receiptId,
                        Convert.ToInt32(row["VariantID"]),
                        Convert.ToInt32(row["Quantity"]),
                        Convert.ToDecimal(row["ImportPrice"])
                    );

                    // Ghi nhận lịch sử giao dịch (Nhập kho)
                    warehouseService.AddInventoryTransaction(
                        Convert.ToInt32(row["VariantID"]),
                        "IMPORT",
                        Convert.ToInt32(row["Quantity"]),
                        receiptId
                    );
                }

                MessageBox.Show("Tạo phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                detailsTable.Clear();
                LoadImportHistory();

                if (dgvHistory.Rows.Count > 0)
                {
                    dgvHistory.ClearSelection();
                    dgvHistory.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình lưu dữ liệu: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= VIEW DETAIL =================
        private void btnViewDetail_Click(
            object? sender,
            EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn phiếu!");

                return;
            }

            DataGridViewRow row =
                dgvHistory.SelectedRows[0];

            int receiptId =
                Convert.ToInt32(
                    row.Cells["ReceiptID"]
                    .Value);

            ReceiptDetailForm form =
                new ReceiptDetailForm(
                    receiptId);

            form.ShowDialog();
        }

        // ================= FILTER TYPE =================
        private void cbFilterType_SelectedIndexChanged(
            object? sender,
            EventArgs e)
        {
            bool isDateFilter =
                cbFilterType.SelectedIndex == 0;

            dtImportDate.Enabled =
                isDateFilter;

            txtSearch.Enabled =
                !isDateFilter;

            txtSearch.BackColor =
                isDateFilter
                ? Color.Gainsboro
                : Color.White;

            FilterHistory();
        }

        // ================= FILTER =================
        private void FilterHistory()
        {
            DataTable dt =
                warehouseService
                .GetImportHistory();

            if (cbFilterType.SelectedIndex == 0)
            {
                DateTime selectedDate =
                    dtImportDate.Value.Date;

                DataRow[] rows =
                    dt.Select(
                        $"ImportDate >= '#{selectedDate:MM/dd/yyyy}#' " +
                        $"AND ImportDate < '#{selectedDate.AddDays(1):MM/dd/yyyy}#'"
                    );

                dgvHistory.DataSource =
                    rows.Length > 0
                    ? rows.CopyToDataTable()
                    : dt.Clone();
            }
            else
            {
                string keyword =
                    txtSearch.Text.Trim();

                if (string.IsNullOrWhiteSpace(keyword))
                {
                    dgvHistory.DataSource =
                        dt;
                }
                else
                {
                    keyword =
                        keyword.Replace("'", "''");

                    DataRow[] rows =
                        dt.Select(
                            $"SupplierName LIKE '%{keyword}%'"
                        );

                    dgvHistory.DataSource =
                        rows.Length > 0
                        ? rows.CopyToDataTable()
                        : dt.Clone();
                }
            }

            SetupHistoryColumn();
        }

        // ================= SEARCH =================
        private void txtSearch_TextChanged(
            object? sender,
            EventArgs e)
        {
            FilterHistory();
        }

        // ================= DATE =================
        private void dtImportDate_ValueChanged(
            object? sender,
            EventArgs e)
        {
            FilterHistory();
        }

        // ================= KEY PRESS =================
        private void txtQuantity_KeyPress(
            object? sender,
            KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress(
            object? sender,
            KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (sender is TextBox txt
                && e.KeyChar == '.'
                && txt.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}