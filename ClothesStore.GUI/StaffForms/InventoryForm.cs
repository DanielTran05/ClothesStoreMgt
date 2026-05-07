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

        public InventoryForm()
        {
            InitializeComponent();
            SetupUI();
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
        }

        private void LoadInventory()
        {
            dgvInventory.DataSource = service.GetInventory();

            if (dgvInventory.Columns["ProductName"] != null)
                dgvInventory.Columns["ProductName"].HeaderText = "Tên Sản Phẩm";

            if (dgvInventory.Columns["AmountInStock"] != null)
                dgvInventory.Columns["AmountInStock"].HeaderText = "Số Lượng Tồn";

            if (dgvInventory.Columns["Price"] != null)
            {
                dgvInventory.Columns["Price"].HeaderText = "Đơn Giá";
                dgvInventory.Columns["Price"].DefaultCellStyle.Format = "N0"; 
            }
        }
    }
}