using ClothesStore.BUS;
using System.Data;
using System.Runtime.InteropServices.Marshalling;

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

            LoadSupplier();

            LoadVariant();

            SetupGrid();

            SetupUI();
        }

        private void SetupUI()
        {
            BackColor =
                Color.White;

            StartPosition =
                FormStartPosition.CenterScreen;

            dgvDetail.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvDetail.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvDetail.MultiSelect =
                false;

            dgvDetail.AllowUserToAddRows =
                false;

            dgvDetail.RowHeadersVisible =
                false;

            dgvDetail.BorderStyle =
                BorderStyle.None;

            dgvDetail.BackgroundColor =
                Color.White;

            dgvDetail.EnableHeadersVisualStyles =
                false;

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

            dgvDetail.RowTemplate.Height =
                32;

            dgvDetail.ColumnHeadersHeight =
                38;

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

            cbSupplier.Font =
                new Font("Segoe UI", 10);

            cbVariant.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cbVariant.Font =
                new Font("Segoe UI", 10);
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
                productService.SearchProductForStaff("");

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
            else
            {
                MessageBox.Show(
                    "Không có dữ liệu sản phẩm!");
            }
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
        }

        private void btnAddDetail_Click(
            object sender,
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

            MessageBox.Show(
                "Đã thêm vào danh sách nhập!");

            txtQuantity.Clear();

            txtPrice.Clear();

            cbVariant.SelectedIndex =
                -1;
        }

        private void btnCreateReceipt_Click(
            object sender,
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
                warehouseService.CreateReceipt(
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
        }
    }
}