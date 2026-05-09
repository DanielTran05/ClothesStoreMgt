using ClothesStore.BUS;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ClothesStore.GUI.StaffForms
{
    public partial class InventoryForm : Form
    {
        private WarehouseService service = new WarehouseService();
        private DataTable inventoryTable;

        public InventoryForm()
        {
            InitializeComponent();
            SetupUI();
            SetupSearchControls();
            LoadInventory();
        }

        private void SetupUI()
        {
            dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventory.MultiSelect = false;
            dgvInventory.AllowUserToAddRows = false;
            dgvInventory.RowHeadersVisible = false;
            dgvInventory.BorderStyle = BorderStyle.None;
            dgvInventory.BackgroundColor = Color.White;
            dgvInventory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvInventory.EnableHeadersVisualStyles = false;

            dgvInventory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            dgvInventory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvInventory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvInventory.ColumnHeadersHeight = 40;

            dgvInventory.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvInventory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dgvInventory.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvInventory.RowTemplate.Height = 35;

            lblSearch.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSearch.ForeColor = Color.FromArgb(52, 73, 94);

            txtSearch.Font = new Font("Segoe UI", 10);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;

            cboSearchType.Font = new Font("Segoe UI", 10);
            cboSearchType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void SetupSearchControls()
        {
            cboSearchType.Items.Add("Tên sản phẩm");
            cboSearchType.Items.Add("SKU");
            cboSearchType.Items.Add("ProductID");

            cboSearchType.SelectedIndex = 0;

            cboSearchType.SelectedIndexChanged += CboSearchType_SelectedIndexChanged;
        }

        private void LoadInventory()
        {
            inventoryTable = service.GetInventory();

            dgvInventory.DataSource = inventoryTable;

            if (dgvInventory.Columns["ProductName"] != null)
                dgvInventory.Columns["ProductName"].HeaderText = "Tên Sản Phẩm";

            if (dgvInventory.Columns["AmountInStock"] != null)
                dgvInventory.Columns["AmountInStock"].HeaderText = "Số Lượng Tồn";

            if (dgvInventory.Columns["Price"] != null)
            {
                dgvInventory.Columns["Price"].HeaderText = "Đơn Giá";
                dgvInventory.Columns["Price"].DefaultCellStyle.Format = "N0";
            }

            if (dgvInventory.Columns["SKU"] != null)
                dgvInventory.Columns["SKU"].HeaderText = "SKU";

            if (dgvInventory.Columns["ProductID"] != null)
                dgvInventory.Columns["ProductID"].HeaderText = "Mã Sản Phẩm";
        }

        private void CboSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtSearch_TextChanged(sender, e);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (inventoryTable == null) return;

            string keyword = txtSearch.Text.Trim().Replace("'", "''");

            DataView dv = inventoryTable.DefaultView;

            switch (cboSearchType.SelectedIndex)
            {
                case 0:
                    dv.RowFilter = $"ProductName LIKE '%{keyword}%'";
                    break;

                case 1:
                    dv.RowFilter = $"SKU LIKE '%{keyword}%'";
                    break;

                case 2:
                    dv.RowFilter = $"Convert(ProductID, 'System.String') LIKE '%{keyword}%'";
                    break;
            }

            dgvInventory.DataSource = null;
            dgvInventory.DataSource = dv;
        }
    }
}