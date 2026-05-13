using ClothesStore.BUS;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClothesStore.GUI.StaffForms
{
    public partial class ProductSearchForm : Form
    {
        private ProductService service = new ProductService();
        private readonly ProductService _productService = new ProductService();

        public ProductSearchForm()
        {
            InitializeComponent();
            SetupUI();
            LoadProductData();
        }

        private void SetupUI()
        {
            dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResult.MultiSelect = false;
            dgvResult.AllowUserToAddRows = false;
            dgvResult.RowHeadersVisible = false;
            dgvResult.BorderStyle = BorderStyle.None;
            dgvResult.BackgroundColor = Color.White;
            dgvResult.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvResult.EnableHeadersVisualStyles = false;

            dgvResult.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            dgvResult.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvResult.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvResult.ColumnHeadersHeight = 40;

            dgvResult.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvResult.DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dgvResult.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvResult.RowTemplate.Height = 35;

            btnSearch.BackColor = Color.FromArgb(46, 204, 113);
            btnSearch.ForeColor = Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnSearch.Cursor = Cursors.Hand;

            txtSearch.Font = new Font("Segoe UI", 11);
        }

        private void LoadProductData()
        {
            try
            {
                // 1. Lấy danh sách từ BUS
                var products = _productService.GetAllProducts();

                // 2. Gán vào DataGridView (ví dụ tên là dgvProducts)
                dgvResult.DataSource = null; // Xóa dữ liệu cũ để tránh lỗi binding
                dgvResult.DataSource = products;

                // 3. Định dạng lại tiêu đề cột (HeaderText) cho đẹp
                if (dgvResult.Columns.Count > 0)
                {
                    dgvResult.Columns["ProductID"].HeaderText = "Mã SP";
                    dgvResult.Columns["ProductName"].HeaderText = "Tên Sản Phẩm";
                    dgvResult.Columns["Description"].HeaderText = "Mô tả";
                    dgvResult.Columns["CategoryID"].HeaderText = "Mã Loại";
                    // Ẩn các cột không cần thiết nếu muốn
                    // dgvProducts.Columns["Description"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sản phẩm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvResult.DataSource = service.SearchProductForStaff(txtSearch.Text);

            if (dgvResult.Columns["ProductName"] != null)
                dgvResult.Columns["ProductName"].HeaderText = "Tên Sản Phẩm";

            if (dgvResult.Columns["CategoryName"] != null)
                dgvResult.Columns["CategoryName"].HeaderText = "Loại";

            if (dgvResult.Columns["Price"] != null)
            {
                dgvResult.Columns["Price"].HeaderText = "Đơn Giá";
                dgvResult.Columns["Price"].DefaultCellStyle.Format = "N0";
            }
        }
    }
}