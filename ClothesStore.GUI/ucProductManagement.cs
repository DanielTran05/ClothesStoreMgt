using ClothesStore.BUS;
using ClothesStore.DTO;
using ClothesStore.DTO.ProductDto;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ClothesStore.GUI
{
    public partial class ucProductManagement : UserControl
    {
        private readonly ProductService _productService;
        private readonly ProductVariantService _variantService;
        private readonly CategoryService _categoryService;
        private readonly ColorService _colorService;
        private readonly SizeService _sizeService;
        private string _currentBase64Image = "";
        private bool isAddModePro = false;
        private bool isAddModeVar = false;
        private int _selectedProductId = -1;
        private int _selectedVariantId = -1;

        private List<ProductDTO> _allProducts = new List<ProductDTO>();
        private List<ProductVariantDTO> _currentVariants = new List<ProductVariantDTO>();

        public ucProductManagement()
        {
            InitializeComponent();
            _productService = new ProductService();
            _variantService = new ProductVariantService();
            _categoryService = new CategoryService();
            _colorService = new ColorService();
            _sizeService = new SizeService();

            this.Load -= ucProductManagement_Load;
            this.Load += ucProductManagement_Load;

            dgvProducts.CellClick -= dgvProducts_CellClick;
            dgvProducts.CellClick += dgvProducts_CellClick;

            dgvVariants.CellClick -= dgvVariants_CellClick;
            dgvVariants.CellClick += dgvVariants_CellClick;

            btnAddPro.Click -= btnAddPro_Click;
            btnAddPro.Click += btnAddPro_Click;

            btnUpdatePro.Click -= btnUpdatePro_Click;
            btnUpdatePro.Click += btnUpdatePro_Click;

            btnAddProVar.Click -= btnAddProVar_Click;
            btnAddProVar.Click += btnAddProVar_Click;

            btnUpdateProVar.Click -= btnUpdateProVar_Click;
            btnUpdateProVar.Click += btnUpdateProVar_Click;

            btnSaveProduct.Click -= btnSaveProduct_Click;
            btnSaveProduct.Click += btnSaveProduct_Click;

            btnSaveVariant.Click -= btnSaveVariant_Click;
            btnSaveVariant.Click += btnSaveVariant_Click;

            btnUploadImg.Click -= btnUploadImg_Click;
            btnUploadImg.Click += btnUploadImg_Click;

            btnDeletePro.Click -= btnDeletePro_Click;
            btnDeletePro.Click += btnDeletePro_Click;

            btnDeleteProVar.Click -= btnDeleteProVar_Click;
            btnDeleteProVar.Click += btnDeleteProVar_Click;

            var searchPro = this.Controls.Find("txtSearchPro", true).FirstOrDefault();
            if (searchPro != null)
            {
                searchPro.TextChanged -= txtSearchPro_TextChanged;
                searchPro.TextChanged += txtSearchPro_TextChanged;
            }

            var searchVar = this.Controls.Find("txtSearchVar", true).FirstOrDefault();
            if (searchVar != null)
            {
                searchVar.TextChanged -= txtSearchVar_TextChanged;
                searchVar.TextChanged += txtSearchVar_TextChanged;
            }
        }

        private void ucProductManagement_Load(object sender, EventArgs e)
        {
            pnlInputSidePro.Visible = false;
            pnlInputSideProVar.Visible = false;
            LoadComboBoxes();
            LoadProducts();
        }

        private void LoadComboBoxes()
        {
            try
            {
                cboCategory.DataSource = _categoryService.GetAllCategories();
                cboCategory.DisplayMember = "CategoryName";
                cboCategory.ValueMember = "CategoryID";

                cboColor.DataSource = _colorService.GetAllColors();
                cboColor.DisplayMember = "ColorName";
                cboColor.ValueMember = "ColorID";

                cboSize.DataSource = _sizeService.GetAllSizes();
                cboSize.DisplayMember = "SizeName";
                cboSize.ValueMember = "SizeID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message);
            }
        }

        private void LoadProducts()
        {
            try
            {
                _allProducts = _productService.GetAllProducts();
                dgvProducts.DataSource = _allProducts;
                FormatProductGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message);
            }
        }

        private void FormatProductGrid()
        {
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn col in dgvProducts.Columns)
            {
                string prop = (col.DataPropertyName ?? col.Name).ToLower();
                if (prop == "productid" || prop == "categoryid") col.Visible = false;
                else if (prop == "productname") col.HeaderText = "Tên Sản Phẩm";
                else if (prop == "description") col.HeaderText = "Mô Tả";
                else if (prop == "categoryname") col.HeaderText = "Phân Loại";
            }
        }

        private void btnAddPro_Click(object sender, EventArgs e)
        {
            if (sender != btnAddPro) return;
            isAddModePro = true;
            txtName.Text = "";
            txtDescription.Text = "";
            pnlInputSidePro.Visible = true;
        }

        private void btnUpdatePro_Click(object sender, EventArgs e)
        {
            if (sender != btnUpdatePro) return;
            if (_selectedProductId == -1)
            {
                MessageBox.Show("Vui lòng chọn 1 sản phẩm để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            isAddModePro = false;
            pnlInputSidePro.Visible = true;
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];
                _selectedProductId = Convert.ToInt32(row.Cells["ProductID"].Value);
                txtName.Text = row.Cells["ProductName"].Value.ToString();
                txtDescription.Text = row.Cells["Description"].Value?.ToString();
                cboCategory.SelectedValue = row.Cells["CategoryID"].Value;
                LoadVariants(_selectedProductId);
            }
        }

        private void LoadVariants(int productId)
        {
            try
            {
                _currentVariants = _variantService.GetVariantsByProductID(productId);
                dgvVariants.DataSource = _currentVariants;
                FormatVariantGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải biến thể: " + ex.Message);
            }
        }

        private void FormatVariantGrid()
        {
            dgvVariants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            foreach (DataGridViewColumn col in dgvVariants.Columns)
            {
                string prop = (col.DataPropertyName ?? col.Name).ToLower();
                if (prop == "variantid" || prop == "productid" || prop == "colorid" || prop == "sizeid" || prop == "img")
                    col.Visible = false;
                else if (prop == "colorname") col.HeaderText = "Màu";
                else if (prop == "sizename") col.HeaderText = "Size";
                else if (prop == "sku") col.HeaderText = "Mã SKU";
                else if (prop == "price")
                {
                    col.HeaderText = "Giá bán";
                    col.DefaultCellStyle.Format = "N0";
                }
                else if (prop == "amountinstock") col.HeaderText = "Tồn kho";
            }
        }

        private void btnAddProVar_Click(object sender, EventArgs e)
        {
            if (sender != btnAddProVar) return;
            if (_selectedProductId == -1)
            {
                MessageBox.Show("Bạn phải chọn một Sản phẩm ở bảng trên trước khi thêm biến thể!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            isAddModeVar = true;
            txtSKU.Text = "";
            txtPrice.Text = "0";
            txtAmount.Text = "0";
            picVariantImage.Image = null;
            pnlInputSideProVar.Visible = true;
        }

        private void btnUpdateProVar_Click(object sender, EventArgs e)
        {
            if (sender != btnUpdateProVar) return;
            if (_selectedVariantId == -1)
            {
                MessageBox.Show("Vui lòng chọn 1 biến thể để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            isAddModeVar = false;
            pnlInputSideProVar.Visible = true;
        }

        private void dgvVariants_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvVariants.Rows[e.RowIndex];
                _selectedVariantId = Convert.ToInt32(row.Cells["VariantID"].Value);
                cboColor.SelectedValue = row.Cells["ColorID"].Value;
                cboSize.SelectedValue = row.Cells["SizeID"].Value;
                txtSKU.Text = row.Cells["SKU"].Value?.ToString();
                txtPrice.Text = row.Cells["Price"].Value.ToString();
                txtAmount.Text = row.Cells["AmountInStock"].Value.ToString();
                string base64Str = row.Cells["Img"].Value?.ToString();

                if (!string.IsNullOrEmpty(base64Str))
                {
                    try
                    {
                        byte[] imageBytes = Convert.FromBase64String(base64Str);
                        using (var ms = new System.IO.MemoryStream(imageBytes))
                        {
                            picVariantImage.Image = System.Drawing.Image.FromStream(ms);
                            picVariantImage.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        _currentBase64Image = base64Str;
                    }
                    catch
                    {
                        picVariantImage.Image = null;
                        _currentBase64Image = "";
                    }
                }
                else
                {
                    picVariantImage.Image = null;
                    _currentBase64Image = "";
                }
            }
        }

        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            if (sender != btnSaveProduct) return;
            try
            {
                var productDto = new ProductDTO
                {
                    ProductName = txtName.Text,
                    Description = txtDescription.Text,
                    CategoryID = cboCategory.SelectedValue != null ? Convert.ToInt32(cboCategory.SelectedValue) : 0
                };

                if (isAddModePro)
                {
                    _productService.CreateProduct(productDto);
                    MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (_selectedProductId == -1) throw new Exception("Vui lòng chọn sản phẩm cần sửa!");
                    productDto.ProductID = _selectedProductId;
                    _productService.UpdateProduct(productDto);
                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadProducts();
                pnlInputSidePro.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUploadImg_Click(object sender, EventArgs e)
        {
            if (sender != btnUploadImg) return;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                ofd.Title = "Chọn ảnh cho biến thể";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picVariantImage.Image = System.Drawing.Image.FromFile(ofd.FileName);
                    picVariantImage.SizeMode = PictureBoxSizeMode.Zoom;
                    byte[] imageArray = System.IO.File.ReadAllBytes(ofd.FileName);
                    _currentBase64Image = Convert.ToBase64String(imageArray);
                }
            }
        }

        private void btnSaveVariant_Click(object sender, EventArgs e)
        {
            if (sender != btnSaveVariant) return;
            try
            {
                if (_selectedProductId == -1)
                    throw new Exception("Vui lòng click chọn 1 sản phẩm ở bảng trên trước khi lưu biến thể!");

                var variantDto = new ProductVariantDTO
                {
                    ProductID = _selectedProductId,
                    ColorID = cboColor.SelectedValue != null ? Convert.ToInt32(cboColor.SelectedValue) : 0,
                    SizeID = cboSize.SelectedValue != null ? Convert.ToInt32(cboSize.SelectedValue) : 0,
                    SKU = txtSKU.Text,
                    Price = string.IsNullOrWhiteSpace(txtPrice.Text) ? 0 : Convert.ToDecimal(txtPrice.Text),
                    AmountInStock = string.IsNullOrWhiteSpace(txtAmount.Text) ? 0 : Convert.ToInt32(txtAmount.Text),
                    Img = _currentBase64Image
                };

                if (isAddModeVar)
                {
                    _variantService.CreateVariant(variantDto);
                    MessageBox.Show("Thêm biến thể thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (_selectedVariantId == -1) throw new Exception("Vui lòng chọn biến thể cần sửa!");
                    variantDto.VariantID = _selectedVariantId;
                    _variantService.UpdateVariant(variantDto);
                    MessageBox.Show("Cập nhật biến thể thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadVariants(_selectedProductId);
                pnlInputSideProVar.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeletePro_Click(object sender, EventArgs e)
        {
            if (sender != btnDeletePro) return;
            if (_selectedProductId == -1)
            {
                MessageBox.Show("Vui lòng click chọn một Sản phẩm ở lưới trên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var existingVariants = _variantService.GetVariantsByProductID(_selectedProductId);
            if (existingVariants != null && existingVariants.Count > 0)
            {
                MessageBox.Show("Không thể xóa! Sản phẩm này đang chứa Biến thể bên trong. Vui lòng xóa hết biến thể ở bảng dưới trước.", "Cảnh báo toàn vẹn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn xóa Sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                try
                {
                    _productService.DeleteProduct(_selectedProductId);
                    MessageBox.Show("Xóa Sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _selectedProductId = -1;
                    pnlInputSidePro.Visible = false;
                    LoadProducts();
                    dgvVariants.DataSource = null;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        MessageBox.Show("Không thể xóa! Sản phẩm này đang chứa Biến thể bên trong. Vui lòng xóa hết biến thể ở bảng dưới trước.", "Cảnh báo toàn vẹn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnDeleteProVar_Click(object sender, EventArgs e)
        {
            if (sender != btnDeleteProVar) return;
            if (_selectedVariantId == -1)
            {
                MessageBox.Show("Vui lòng click chọn một Biến thể ở lưới dưới để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn xóa Biến thể này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                try
                {
                    _variantService.DeleteVariant(_selectedVariantId);
                    MessageBox.Show("Xóa Biến thể thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _selectedVariantId = -1;
                    pnlInputSideProVar.Visible = false;
                    LoadVariants(_selectedProductId);
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        MessageBox.Show("Không thể xóa! Biến thể này đã phát sinh dữ liệu trong kho hoặc đã được bán ra.", "Cảnh báo toàn vẹn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtSearchPro_TextChanged(object sender, EventArgs e)
        {
            var txt = sender as Control;
            if (txt == null) return;

            string keyword = txt.Text.Trim().ToLower();
            dgvProducts.DataSource = string.IsNullOrEmpty(keyword)
                ? _allProducts
                : _allProducts.Where(p => p.ProductName.ToLower().Contains(keyword)).ToList();

            dgvVariants.DataSource = null;
            _currentVariants.Clear();
            _selectedProductId = -1;
            _selectedVariantId = -1;
            pnlInputSidePro.Visible = false;
            pnlInputSideProVar.Visible = false;
        }

        private void txtSearchVar_TextChanged(object sender, EventArgs e)
        {
            var txt = sender as Control;
            if (txt == null) return;

            if (_selectedProductId == -1)
            {
                if (!string.IsNullOrEmpty(txt.Text))
                {
                    MessageBox.Show("Vui lòng chọn một Sản phẩm ở bảng trên trước khi tìm kiếm biến thể!", "Cảnh báo thao tác", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt.Text = "";
                }
                return;
            }

            string keyword = txt.Text.Trim().ToLower();
            dgvVariants.DataSource = string.IsNullOrEmpty(keyword)
                ? _currentVariants
                : _currentVariants.Where(v =>
                    (v.SKU != null && v.SKU.ToLower().Contains(keyword)) ||
                    (v.ColorName != null && v.ColorName.ToLower().Contains(keyword)) ||
                    (v.SizeName != null && v.SizeName.ToLower().Contains(keyword))
                  ).ToList();
        }
    }
}