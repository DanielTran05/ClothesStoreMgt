using ClothesStore.BUS;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ClothesStore.GUI.StaffForms
{
    public partial class SupplierForm : Form
    {
        SupplierService service = new SupplierService();

        private int selectedId = -1;
        private DataTable supplierTable;

        public SupplierForm()
        {
            InitializeComponent();

            SetupUI();
            SetupSearchControls();
            LoadData();
        }

        private void SetupUI()
        {
            dgvSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSuppliers.MultiSelect = false;
            dgvSuppliers.AllowUserToAddRows = false;
            dgvSuppliers.RowHeadersVisible = false;
            dgvSuppliers.BorderStyle = BorderStyle.None;
            dgvSuppliers.BackgroundColor = Color.White;
            dgvSuppliers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvSuppliers.EnableHeadersVisualStyles = false;

            dgvSuppliers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            dgvSuppliers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSuppliers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvSuppliers.ColumnHeadersHeight = 40;

            dgvSuppliers.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvSuppliers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dgvSuppliers.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvSuppliers.RowTemplate.Height = 35;

            btnAdd.BackColor = Color.FromArgb(46, 204, 113);
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;

            btnUpdate.BackColor = Color.FromArgb(241, 196, 15);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.FlatAppearance.BorderSize = 0;

            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;

            btnLoad.BackColor = Color.FromArgb(52, 73, 94);
            btnLoad.ForeColor = Color.White;
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.FlatAppearance.BorderSize = 0;

            btnAdd.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnUpdate.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnDelete.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnLoad.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            lblSearch.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSearch.ForeColor = Color.FromArgb(52, 73, 94);

            lbName.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lbName.ForeColor = Color.FromArgb(52, 73, 94);

            lbPhone.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lbPhone.ForeColor = Color.FromArgb(52, 73, 94);

            txtSearch.Font = new Font("Segoe UI", 10);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;

            cboSearchType.Font = new Font("Segoe UI", 10);
            cboSearchType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void SetupSearchControls()
        {
            cboSearchType.Items.Add("Tên nhà cung cấp");
            cboSearchType.Items.Add("Số điện thoại");

            cboSearchType.SelectedIndex = 0;

            cboSearchType.SelectedIndexChanged += CboSearchType_SelectedIndexChanged;
        }

        void LoadData()
        {
            supplierTable = service.GetAll();
            dgvSuppliers.DataSource = supplierTable;
        }

        private void CboSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtSearch_TextChanged(sender, e);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (supplierTable == null) return;

            string keyword = txtSearch.Text.Trim().Replace("'", "''");

            DataView dv = supplierTable.DefaultView;

            switch (cboSearchType.SelectedIndex)
            {
                case 0:
                    dv.RowFilter = $"SupplierName LIKE '%{keyword}%'";
                    break;

                case 1:
                    dv.RowFilter = $"PhoneNumber LIKE '%{keyword}%'";
                    break;
            }

            dgvSuppliers.DataSource = null;
            dgvSuppliers.DataSource = dv;
        }

        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvSuppliers.Rows[e.RowIndex];

            if (row.Cells["SupplierID"].Value == null ||
                row.Cells["SupplierID"].Value == DBNull.Value)
                return;

            selectedId = Convert.ToInt32(row.Cells["SupplierID"].Value);

            txtName.Text = row.Cells["SupplierName"].Value?.ToString() ?? "";
            txtPhone.Text = row.Cells["PhoneNumber"].Value?.ToString() ?? "";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            service.Add(txtName.Text, txtPhone.Text);

            MessageBox.Show("Thêm thành công!");

            LoadData();
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!");
                return;
            }

            service.Update(selectedId, txtName.Text, txtPhone.Text);

            MessageBox.Show("Cập nhật thành công!");

            LoadData();
            ClearForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!");
                return;
            }

            service.Delete(selectedId);

            MessageBox.Show("Xóa thành công!");

            LoadData();
            ClearForm();
        }

        private void ClearForm()
        {
            selectedId = -1;

            txtName.Clear();
            txtPhone.Clear();

            dgvSuppliers.ClearSelection();
        }
    }
}