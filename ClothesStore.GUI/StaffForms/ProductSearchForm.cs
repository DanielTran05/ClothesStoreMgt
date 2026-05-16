using ClothesStore.BUS;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ClothesStore.GUI.StaffForms
{
    public partial class ProductSearchForm : Form
    {
        private ProductService service = new ProductService();

        private DataTable fullTable = new DataTable();
        private DataTable currentTable = new DataTable();

        private int currentPage = 1;
        private int pageSize = 20;
        private int totalPage = 1;

        public ProductSearchForm()
        {
            InitializeComponent();

            SetupUI();
            SetupSearchControls();
            LoadData();
        }

        private void SetupUI()
        {
            dgvResult.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvResult.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvResult.MultiSelect = false;

            dgvResult.AllowUserToAddRows = false;

            dgvResult.RowHeadersVisible = false;

            dgvResult.BorderStyle = BorderStyle.None;

            dgvResult.BackgroundColor = Color.White;

            dgvResult.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvResult.EnableHeadersVisualStyles = false;

            dgvResult.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(52, 152, 219);

            dgvResult.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvResult.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Bold);

            dgvResult.ColumnHeadersHeight = 40;

            dgvResult.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dgvResult.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(41, 128, 185);

            dgvResult.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvResult.RowTemplate.Height = 35;

            btnSearch.BackColor =
                Color.FromArgb(46, 204, 113);

            btnSearch.ForeColor = Color.White;

            btnSearch.FlatStyle = FlatStyle.Flat;

            btnSearch.FlatAppearance.BorderSize = 0;

            btnSearch.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            btnPrev.BackColor =
                Color.FromArgb(52, 152, 219);

            btnPrev.ForeColor = Color.White;

            btnPrev.FlatStyle = FlatStyle.Flat;

            btnPrev.FlatAppearance.BorderSize = 0;

            btnNext.BackColor =
                Color.FromArgb(52, 152, 219);

            btnNext.ForeColor = Color.White;

            btnNext.FlatStyle = FlatStyle.Flat;

            btnNext.FlatAppearance.BorderSize = 0;

            txtSearch.Font =
                new Font("Segoe UI", 11);

            cboSearchType.Font =
                new Font("Segoe UI", 10);

            cboSearchType.DropDownStyle =
                ComboBoxStyle.DropDownList;
        }

        private void SetupSearchControls()
        {
            cboSearchType.Items.Add("Tên sản phẩm");
            cboSearchType.Items.Add("SKU");
            cboSearchType.Items.Add("ProductID");

            cboSearchType.SelectedIndex = 0;
            cboSearchType.SelectedIndexChanged += SearchChanged;
        }

        private void LoadData()
        {
            fullTable =
                service.SearchProductForStaff("");

            ApplyFilter();
        }

        private void SearchChanged(
            object sender,
            EventArgs e)
        {
            currentPage = 1;

            ApplyFilter();
        }

        private void btnSearch_Click(
            object sender,
            EventArgs e)
        {
            currentPage = 1;

            ApplyFilter();
        }

        private void ApplyFilter()
        {
            if (fullTable == null)
                return;

            string keyword =
                txtSearch.Text
                .Trim()
                .Replace("'", "''");

            DataView dv =
                fullTable.DefaultView;

            switch (cboSearchType.SelectedIndex)
            {
                case 0:
                    dv.RowFilter =
                        $"ProductName LIKE '%{keyword}%'";
                    break;

                case 1:
                    dv.RowFilter =
                        $"SKU LIKE '%{keyword}%'";
                    break;

                case 2:
                    dv.RowFilter =
                        $"Convert(ProductID, 'System.String') LIKE '%{keyword}%'";
                    break;
            }

            currentTable = dv.ToTable();

            LoadPage();
        }

        private void LoadPage()
        {
            if (currentTable.Rows.Count == 0)
            {
                dgvResult.DataSource = null;

                lblPage.Text = "0 / 0";

                return;
            }

            totalPage =
                (int)Math.Ceiling(
                    currentTable.Rows.Count
                    / (double)pageSize);

            if (currentPage > totalPage)
                currentPage = totalPage;

            DataTable pageTable =
                currentTable.Clone();

            var rows =
                currentTable.AsEnumerable()
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize);

            foreach (var row in rows)
            {
                pageTable.ImportRow(row);
            }

            dgvResult.DataSource = pageTable;

            lblPage.Text =
                $"{currentPage} / {totalPage}";

            SetupColumnName();
        }

        private void SetupColumnName()
        {
            if (dgvResult.Columns["ProductName"] != null)
            {
                dgvResult.Columns["ProductName"]
                    .HeaderText = "Tên Sản Phẩm";
            }

            if (dgvResult.Columns["CategoryName"] != null)
            {
                dgvResult.Columns["CategoryName"]
                    .HeaderText = "Loại";
            }

            if (dgvResult.Columns["SKU"] != null)
            {
                dgvResult.Columns["SKU"]
                    .HeaderText = "SKU";
            }

            if (dgvResult.Columns["ProductID"] != null)
            {
                dgvResult.Columns["ProductID"]
                    .HeaderText = "Mã Sản Phẩm";
            }

            if (dgvResult.Columns["Price"] != null)
            {
                dgvResult.Columns["Price"]
                    .HeaderText = "Đơn Giá";

                dgvResult.Columns["Price"]
                    .DefaultCellStyle.Format = "N0";
            }
        }

        private void btnPrev_Click(
            object sender,
            EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;

                LoadPage();
            }
        }

        private void btnNext_Click(
            object sender,
            EventArgs e)
        {
            if (currentPage < totalPage)
            {
                currentPage++;

                LoadPage();
            }
        }
    }
}