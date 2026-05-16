using ClothesStore.BUS;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ClothesStore.GUI.StaffForms
{
    public partial class SupplierForm : Form
    {
        SupplierService service = new SupplierService();

        private int selectedId = -1;
        private DataTable supplierTable;

        // Label lỗi
        private Label errorName;
        private Label errorPhone;

        public SupplierForm()
        {
            InitializeComponent();

            SetupUI();
            SetupSearchControls();
            SetupRealtimeValidation();
            LoadData();
        }

        // ================= UI =================
        private void SetupUI()
        {
            dgvSuppliers.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvSuppliers.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvSuppliers.MultiSelect = false;
            dgvSuppliers.AllowUserToAddRows = false;
            dgvSuppliers.RowHeadersVisible = false;

            dgvSuppliers.BorderStyle = BorderStyle.None;
            dgvSuppliers.BackgroundColor = Color.White;

            dgvSuppliers.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvSuppliers.EnableHeadersVisualStyles = false;

            dgvSuppliers.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(52, 152, 219);

            dgvSuppliers.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvSuppliers.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Bold);

            dgvSuppliers.ColumnHeadersHeight = 40;

            dgvSuppliers.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dgvSuppliers.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(41, 128, 185);

            dgvSuppliers.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvSuppliers.RowTemplate.Height = 35;

            // ADD
            btnAdd.BackColor =
                Color.FromArgb(46, 204, 113);

            btnAdd.ForeColor = Color.White;

            btnAdd.FlatStyle = FlatStyle.Flat;

            btnAdd.FlatAppearance.BorderSize = 0;

            btnAdd.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            // UPDATE
            btnUpdate.BackColor =
                Color.FromArgb(241, 196, 15);

            btnUpdate.ForeColor = Color.White;

            btnUpdate.FlatStyle = FlatStyle.Flat;

            btnUpdate.FlatAppearance.BorderSize = 0;

            btnUpdate.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            // DELETE
            btnDelete.BackColor =
                Color.FromArgb(231, 76, 60);

            btnDelete.ForeColor = Color.White;

            btnDelete.FlatStyle = FlatStyle.Flat;

            btnDelete.FlatAppearance.BorderSize = 0;

            btnDelete.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            // LOAD
            btnLoad.BackColor =
                Color.FromArgb(52, 73, 94);

            btnLoad.ForeColor = Color.White;

            btnLoad.FlatStyle = FlatStyle.Flat;

            btnLoad.FlatAppearance.BorderSize = 0;

            btnLoad.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            // LABEL
            lblSearch.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            lblSearch.ForeColor =
                Color.FromArgb(52, 73, 94);

            lbName.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            lbName.ForeColor =
                Color.FromArgb(52, 73, 94);

            lbPhone.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            lbPhone.ForeColor =
                Color.FromArgb(52, 73, 94);

            // SEARCH
            txtSearch.Font =
                new Font("Segoe UI", 10);

            txtSearch.BorderStyle =
                BorderStyle.FixedSingle;

            cboSearchType.Font =
                new Font("Segoe UI", 10);

            cboSearchType.DropDownStyle =
                ComboBoxStyle.DropDownList;
        }

        // ================= SEARCH =================
        private void SetupSearchControls()
        {
            cboSearchType.Items.Add("Tên nhà cung cấp");
            cboSearchType.Items.Add("Số điện thoại");

            cboSearchType.SelectedIndex = 0;

            cboSearchType.SelectedIndexChanged +=
                CboSearchType_SelectedIndexChanged;
        }

        private void CboSearchType_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            TxtSearch_TextChanged(sender, e);
        }

        private void TxtSearch_TextChanged(
            object sender,
            EventArgs e)
        {
            if (supplierTable == null)
                return;

            string keyword =
                txtSearch.Text.Trim().Replace("'", "''");

            DataView dv =
                supplierTable.DefaultView;

            switch (cboSearchType.SelectedIndex)
            {
                case 0:
                    dv.RowFilter =
                        $"SupplierName LIKE '%{keyword}%'";
                    break;

                case 1:
                    dv.RowFilter =
                        $"PhoneNumber LIKE '%{keyword}%'";
                    break;
            }

            dgvSuppliers.DataSource = dv;
        }

        // ================= LOAD =================
        private void LoadData()
        {
            supplierTable = service.GetAll();

            dgvSuppliers.DataSource = supplierTable;
        }

        // ================= VALIDATION =================
        private void SetupRealtimeValidation()
        {
            // ERROR NAME
            errorName = new Label();

            errorName.ForeColor = Color.Red;

            errorName.Font =
                new Font("Segoe UI", 8);

            errorName.AutoSize = true;

            errorName.Location =
                new Point(
                    txtName.Left,
                    txtName.Bottom + 5);

            // ERROR PHONE
            errorPhone = new Label();

            errorPhone.ForeColor = Color.Red;

            errorPhone.Font =
                new Font("Segoe UI", 8);

            errorPhone.AutoSize = true;

            // tăng khoảng cách để không đè nhau
            errorPhone.Location =
                new Point(
                    txtPhone.Left,
                    txtPhone.Bottom + 20);

            Controls.Add(errorName);
            Controls.Add(errorPhone);

            txtName.TextChanged +=
                TxtName_TextChanged;

            txtPhone.TextChanged +=
                TxtPhone_TextChanged;
        }

        // ================= NAME VALIDATE =================
        private void TxtName_TextChanged(
            object sender,
            EventArgs e)
        {
            string name =
                txtName.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                txtName.BackColor =
                    Color.MistyRose;

                errorName.Text =
                    "Tên không được để trống";

                return;
            }

            if (!char.IsLetter(name[0]))
            {
                txtName.BackColor =
                    Color.MistyRose;

                errorName.Text =
                    "Tên không được bắt đầu bằng số/ký tự đặc biệt";

                return;
            }

            txtName.BackColor =
                Color.White;

            errorName.Text = "";
        }

        // ================= PHONE VALIDATE =================
        private void TxtPhone_TextChanged(
            object sender,
            EventArgs e)
        {
            string phone =
                txtPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(phone))
            {
                txtPhone.BackColor =
                    Color.MistyRose;

                errorPhone.Text =
                    "SĐT không được để trống";

                return;
            }

            if (!phone.All(char.IsDigit))
            {
                txtPhone.BackColor =
                    Color.MistyRose;

                errorPhone.Text =
                    "SĐT chỉ được nhập số";

                return;
            }

            if (phone.Length < 10 ||
                phone.Length > 11)
            {
                txtPhone.BackColor =
                    Color.MistyRose;

                errorPhone.Text =
                    "SĐT phải từ 10–11 số";

                return;
            }

            txtPhone.BackColor =
                Color.White;

            errorPhone.Text = "";
        }

        // ================= CHECK VALID =================
        private bool IsValidData()
        {
            return
                string.IsNullOrEmpty(errorName.Text)
                &&
                string.IsNullOrEmpty(errorPhone.Text)
                &&
                !string.IsNullOrWhiteSpace(txtName.Text)
                &&
                !string.IsNullOrWhiteSpace(txtPhone.Text);
        }

        // ================= DATAGRIDVIEW =================
        private void dgvSuppliers_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
                dgvSuppliers.Rows[e.RowIndex];

            if (row.Cells["SupplierID"].Value == null
                ||
                row.Cells["SupplierID"].Value == DBNull.Value)
                return;

            selectedId =
                Convert.ToInt32(
                    row.Cells["SupplierID"].Value);

            txtName.Text =
                row.Cells["SupplierName"]
                .Value?.ToString() ?? "";

            txtPhone.Text =
                row.Cells["PhoneNumber"]
                .Value?.ToString() ?? "";
        }

        // ================= ADD =================
        private void btnAdd_Click(
            object sender,
            EventArgs e)
        {
            if (!IsValidData())
            {
                MessageBox.Show(
                    "Vui lòng nhập đúng thông tin!");

                return;
            }

            service.Add(
                txtName.Text.Trim(),
                txtPhone.Text.Trim());

            MessageBox.Show(
                "Thêm thành công!");

            LoadData();

            ClearForm();
        }

        // ================= UPDATE =================
        private void btnUpdate_Click(
            object sender,
            EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn nhà cung cấp!");

                return;
            }

            if (!IsValidData())
            {
                MessageBox.Show(
                    "Vui lòng nhập đúng thông tin!");

                return;
            }

            service.Update(
                selectedId,
                txtName.Text.Trim(),
                txtPhone.Text.Trim());

            MessageBox.Show(
                "Cập nhật thành công!");

            LoadData();

            ClearForm();
        }

        // ================= DELETE =================
        private void btnDelete_Click(
            object sender,
            EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn nhà cung cấp!");

                return;
            }

            service.Delete(selectedId);

            MessageBox.Show(
                "Xóa thành công!");

            LoadData();

            ClearForm();
        }

        // ================= LOAD BUTTON =================
        private void btnLoad_Click(
            object sender,
            EventArgs e)
        {
            LoadData();
        }

        // ================= CLEAR =================
        private void ClearForm()
        {
            selectedId = -1;

            txtName.Clear();
            txtPhone.Clear();

            txtName.BackColor = Color.White;
            txtPhone.BackColor = Color.White;

            errorName.Text = "";
            errorPhone.Text = "";

            dgvSuppliers.ClearSelection();
        }
    }
}