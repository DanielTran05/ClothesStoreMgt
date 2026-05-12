using ClothesStore.BUS;
using ClothesStore.DTO.MasterDataDto;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClothesStore.GUI
{
    public partial class ucCategoryManagement : UserControl
    {
        private readonly CategoryService _categoryService;
        private readonly ColorService _colorService;
        private readonly SizeService _sizeService;
        private List<CategoryDTO> _allCategories = new List<CategoryDTO>();
        private List<ColorDTO> _allColors = new List<ColorDTO>();
        private List<SizeDTO> _allSizes = new List<SizeDTO>();
        private bool isAddMode = false;
        private int _selectedId = -1;

        public ucCategoryManagement()
        {
            InitializeComponent();
            _categoryService = new CategoryService();
            _colorService = new ColorService();
            _sizeService = new SizeService();

            this.Load -= ucCategoryManagement_Load;
            this.Load += ucCategoryManagement_Load;

            tab.SelectedIndexChanged -= tab_SelectedIndexChanged;
            tab.SelectedIndexChanged += tab_SelectedIndexChanged;

            btnAdd.Click -= btnAdd_Click;
            btnAdd.Click += btnAdd_Click;

            btnUpdate.Click -= btnUpdate_Click;
            btnUpdate.Click += btnUpdate_Click;

            btnDelete.Click -= btnDelete_Click;
            btnDelete.Click += btnDelete_Click;

            btnSave.Click -= btnSave_Click;
            btnSave.Click += btnSave_Click;

            dgvCategories.CellClick -= dgvCategories_CellClick;
            dgvCategories.CellClick += dgvCategories_CellClick;

            dgvColors.CellClick -= dgvColors_CellClick;
            dgvColors.CellClick += dgvColors_CellClick;

            dgvSize.CellClick -= dgvSize_CellClick;
            dgvSize.CellClick += dgvSize_CellClick;
        }

        private void ucCategoryManagement_Load(object sender, EventArgs e)
        {
            pnlInputSide.Visible = false;
            pnlToolBar.SendToBack();
            pnlInputSide.SendToBack();
            tab.BringToFront();
            LoadAllData();
            UpdateUIContext();
        }

        private void LoadAllData()
        {
            try
            {
                _allCategories = _categoryService.GetAllCategories();
                _allColors = _colorService.GetAllColors();
                _allSizes = _sizeService.GetAllSizes();

                dgvCategories.DataSource = _allCategories;
                dgvColors.DataSource = _allColors;
                dgvSize.DataSource = _allSizes;

                FormatGrid(dgvCategories);
                FormatGrid(dgvColors);
                FormatGrid(dgvSize);
                tab.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGrid(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv.ScrollBars = ScrollBars.Both;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                string prop = (col.DataPropertyName ?? col.Name).ToLower();

                if (prop == "categoryid" || prop == "colorid" || prop == "sizeid")
                {
                    col.Visible = false;
                }
                else if (prop == "categoryname")
                {
                    col.HeaderText = "Tên Loại Sản Phẩm";
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else if (prop == "description") col.HeaderText = "Mô Tả";
                else if (prop == "colorname") col.HeaderText = "Tên Màu";
                else if (prop == "sizename") col.HeaderText = "Tên Kích Cỡ";
            }
        }

        private void tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlInputSide.Visible = false;
            if (txtSearch != null) txtSearch.Text = "";
            UpdateUIContext();
        }

        private void UpdateUIContext()
        {
            if (tab.SelectedTab.Name == "tabCategories")
            {
                if (lblTitle != null) lblTitle.Text = "QUẢN LÝ LOẠI SẢN PHẨM";
                txtDescription.Visible = true;
            }
            else if (tab.SelectedTab.Name == "tabColors")
            {
                if (lblTitle != null) lblTitle.Text = "QUẢN LÝ MÀU SẮC";
                txtDescription.Visible = false;
            }
            else if (tab.SelectedTab.Name == "tabSize")
            {
                if (lblTitle != null) lblTitle.Text = "QUẢN LÝ KÍCH CỠ";
                txtDescription.Visible = false;
            }

            txtName.Text = "";
            txtDescription.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAddMode = true;
            txtName.Text = "";
            txtDescription.Text = "";
            pnlInputSide.Visible = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedId == -1)
            {
                MessageBox.Show("Vui lòng chọn một dòng dưới lưới để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            isAddMode = false;
            pnlInputSide.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isAddMode && _selectedId == -1)
                {
                    MessageBox.Show("Vui lòng chọn một dòng dưới lưới để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (tab.SelectedTab.Name == "tabCategories")
                {
                    if (isAddMode)
                        _categoryService.CreateCategory(new CategoryDTO { CategoryName = txtName.Text, Description = txtDescription.Text });
                    else
                        _categoryService.UpdateCategory(new CategoryDTO { CategoryID = _selectedId, CategoryName = txtName.Text, Description = txtDescription.Text });
                }
                else if (tab.SelectedTab.Name == "tabColors")
                {
                    if (isAddMode)
                        _colorService.CreateColor(new ColorDTO { ColorName = txtName.Text });
                    else
                        _colorService.UpdateColor(new ColorDTO { ColorID = _selectedId, ColorName = txtName.Text });
                }
                else if (tab.SelectedTab.Name == "tabSize")
                {
                    if (isAddMode)
                        _sizeService.CreateSize(new SizeDTO { SizeName = txtName.Text });
                    else
                        _sizeService.UpdateSize(new SizeDTO { SizeID = _selectedId, SizeName = txtName.Text });
                }

                MessageBox.Show("Lưu dữ liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAllData();
                pnlInputSide.Visible = false;
                _selectedId = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCategories.Rows[e.RowIndex];
                _selectedId = Convert.ToInt32(row.Cells["CategoryID"].Value);
                txtName.Text = row.Cells["CategoryName"].Value.ToString();
                txtDescription.Text = row.Cells["Description"].Value?.ToString();
            }
        }

        private void dgvColors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvColors.Rows[e.RowIndex];
                _selectedId = Convert.ToInt32(row.Cells["ColorID"].Value);
                txtName.Text = row.Cells["ColorName"].Value.ToString();
            }
        }

        private void dgvSize_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSize.Rows[e.RowIndex];
                _selectedId = Convert.ToInt32(row.Cells["SizeID"].Value);
                txtName.Text = row.Cells["SizeName"].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedId == -1)
            {
                MessageBox.Show("Vui lòng chọn dữ liệu cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn xóa dữ liệu này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    if (tab.SelectedTab.Name == "tabCategories") _categoryService.DeleteCategory(_selectedId);
                    else if (tab.SelectedTab.Name == "tabColors") _colorService.DeleteColor(_selectedId);
                    else if (tab.SelectedTab.Name == "tabSize") _sizeService.DeleteSize(_selectedId);

                    MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllData();
                    pnlInputSide.Visible = false;
                    _selectedId = -1;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        MessageBox.Show("Không thể xóa! Dữ liệu này đang được sử dụng ở Sản Phẩm/Biến Thể.", "Cảnh báo toàn vẹn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            if (tab.SelectedTab.Name == "tabCategories")
            {
                dgvCategories.DataSource = string.IsNullOrEmpty(keyword)
                    ? _allCategories
                    : _allCategories.Where(x => x.CategoryName.ToLower().Contains(keyword)).ToList();
            }
            else if (tab.SelectedTab.Name == "tabColors")
            {
                dgvColors.DataSource = string.IsNullOrEmpty(keyword)
                    ? _allColors
                    : _allColors.Where(x => x.ColorName.ToLower().Contains(keyword)).ToList();
            }
            else if (tab.SelectedTab.Name == "tabSize")
            {
                dgvSize.DataSource = string.IsNullOrEmpty(keyword)
                    ? _allSizes
                    : _allSizes.Where(x => x.SizeName.ToLower().Contains(keyword)).ToList();
            }
        }
    }
}