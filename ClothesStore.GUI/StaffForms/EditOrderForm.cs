using ClothesStore.BUS;
using ClothesStore.DAL.Enums;
using ClothesStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ClothesStore.GUI.StaffForms
{
    public partial class EditOrderForm : Form
    {
        private WarehouseService service = new WarehouseService();
        private DataTable inventoryTable;
        private ProductVariantService _variantService = new ProductVariantService();
        private OrderService _orderService = new OrderService();
        private ShippingService _shippingService = new ShippingService();
        private InvoiceService _invoiceService = new InvoiceService();
        private int _orderId;

        public EditOrderForm(int orderId)
        {
            InitializeComponent();
            _orderId = orderId;

            SetupUI();
            SetupSearchControls();
            LoadInventory();
            LoadPaymentMethods();
            LoadShippingMethods();
            LoadOrderDetails();
        }

        private void LoadOrderDetails()
        {
            try
            {
                var order = _orderService.GetOrderById(_orderId);
                if (order == null)
                {
                    MessageBox.Show($"Không tìm thấy đơn hàng mã {_orderId}!", "Lỗi");
                    return;
                }

                txtCustomerName.Text = order.ReceiverName ?? "Khách vãng lai";
                txtAddress.Text = order.ShippingAddress ?? "";

                if (order.ShippingProviderId.HasValue)
                    cboShipping.SelectedValue = order.ShippingProviderId.Value;

                var invoice = order.Invoices?.FirstOrDefault();
                if (invoice != null && !string.IsNullOrWhiteSpace(invoice.PaymentMethod))
                {
                    string dbPayment = invoice.PaymentMethod.Trim();
                    string[] currentMethods = cboPayment.DataSource as string[];

                    if (currentMethods != null)
                    {
                        int index = Array.FindIndex(currentMethods, x => x.Equals(dbPayment, StringComparison.OrdinalIgnoreCase));
                        if (index != -1)
                        {
                            cboPayment.SelectedIndex = index;
                        }
                        else
                        {
                            var newList = new List<string>(currentMethods);
                            newList.Add(dbPayment);
                            cboPayment.DataSource = null;
                            cboPayment.DataSource = newList;
                            cboPayment.SelectedIndex = newList.Count - 1;
                        }
                    }
                }
                else if (cboPayment.Items.Count > 0)
                {
                    cboPayment.SelectedIndex = 0;
                }

                dgvOrderDetails.Rows.Clear();
                if (order.OrderDetails == null || order.OrderDetails.Count == 0)
                {
                    lbTotalPrice.Text = "0 VNĐ";
                    return;
                }

                foreach (var detail in order.OrderDetails)
                {
                    string productName = detail.Variant?.Product?.ProductName ?? "Không xác định";
                    string sku = detail.Variant?.Sku ?? "";
                    decimal price = detail.PriceAtPurchase;
                    int quantity = detail.Quantity;

                    dgvOrderDetails.Rows.Add(productName, sku, quantity, price.ToString("N0"));
                }

                UpdateTotalPrice();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết đơn hàng:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditOrderForm_Load(object sender, EventArgs e)
        {
            SetupUI();
            LoadOrderDetails();
        }

        private void SetupUI()
        {
            dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventory.MultiSelect = false;
            dgvInventory.AllowUserToAddRows = false;
            dgvInventory.RowHeadersVisible = false;
            dgvInventory.BorderStyle = BorderStyle.None;
            dgvInventory.BackgroundColor = System.Drawing.Color.White;
            dgvInventory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvInventory.EnableHeadersVisualStyles = false;

            dgvInventory.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            dgvInventory.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvInventory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvInventory.ColumnHeadersHeight = 40;

            dgvInventory.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvInventory.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            dgvInventory.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            dgvInventory.RowTemplate.Height = 35;

            lblSearch.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSearch.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);

            txtSearch.Font = new Font("Segoe UI", 10);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;

            cboSearchType.Font = new Font("Segoe UI", 10);
            cboSearchType.DropDownStyle = ComboBoxStyle.DropDownList;

            dgvOrderDetails.Columns.Clear();
            dgvOrderDetails.Columns.Add("ProductName", "Tên Sản Phẩm");
            dgvOrderDetails.Columns.Add("SKU", "SKU");
            dgvOrderDetails.Columns.Add("Quantity", "Số Lượng");
            dgvOrderDetails.Columns.Add("Price", "Đơn Giá");

            dgvOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrderDetails.ReadOnly = true;
            dgvOrderDetails.AllowUserToAddRows = false;

            dgvOrderDetails.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrderDetails.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOrderDetails.Columns["Price"].DefaultCellStyle.Format = "N0";
        }

        private void SetupSearchControls()
        {
            cboSearchType.Items.Add("Tên sản phẩm");
            cboSearchType.Items.Add("SKU");
            cboSearchType.Items.Add("ProductID");
            cboSearchType.SelectedIndex = 0;
            cboSearchType.SelectedIndexChanged += cboSearchType_SelectedIndexChanged;
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

        private void cboSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch_TextChanged(sender, e);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
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

        private void LoadShippingMethods()
        {
            try
            {
                var shippers = _shippingService.GetShippers();
                cboShipping.DataSource = shippers;
                cboShipping.DisplayMember = "Name";
                cboShipping.ValueMember = "ShippingProviderId";

                if (cboShipping.Items.Count > 0)
                    cboShipping.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải phương thức vận chuyển: " + ex.Message);
            }
        }

        private void LoadPaymentMethods()
        {
            try
            {
                cboPayment.DataSource = null;
                cboPayment.Items.Clear();

                string[] methods = Enum.GetNames(typeof(PaymentMethod));

                if (methods.Length > 0)
                {
                    cboPayment.DataSource = methods;
                    cboPayment.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải phương thức thanh toán: " + ex.Message);
            }
        }

        private decimal CalculateTotalFromGrid()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvOrderDetails.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["Price"].Value != null && row.Cells["Quantity"].Value != null)
                {
                    decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    total += price * quantity;
                }
            }
            return total;
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvInventory.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm từ bảng kho bên trái!", "Thông báo");
                return;
            }

            int quantityToAdd = (int)count.Value;
            if (quantityToAdd <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!", "Cảnh báo");
                return;
            }

            DataGridViewRow selectedRow = dgvInventory.CurrentRow;
            int variantId = Convert.ToInt32(selectedRow.Cells["ProductID"].Value);
            string productName = selectedRow.Cells["ProductName"].Value?.ToString() ?? "Không xác định";
            string sku = selectedRow.Cells["SKU"]?.Value?.ToString() ?? "";
            decimal price = Convert.ToDecimal(selectedRow.Cells["Price"].Value);
            int stock = Convert.ToInt32(selectedRow.Cells["AmountInStock"].Value);

            if (quantityToAdd > stock)
            {
                MessageBox.Show($"Không đủ hàng! Kho chỉ còn {stock} sản phẩm.", "Cảnh báo");
                return;
            }

            bool existed = false;
            foreach (DataGridViewRow row in dgvOrderDetails.Rows)
            {
                if (row.Cells["SKU"].Value?.ToString() == sku)
                {
                    int currentQty = Convert.ToInt32(row.Cells["Quantity"].Value);
                    if (currentQty + quantityToAdd > stock)
                    {
                        MessageBox.Show("Tổng số lượng vượt quá tồn kho!", "Cảnh báo");
                        return;
                    }
                    row.Cells["Quantity"].Value = currentQty + quantityToAdd;
                    existed = true;
                    break;
                }
            }

            if (!existed)
            {
                dgvOrderDetails.Rows.Add(productName, sku, quantityToAdd, price.ToString("N0"));
            }

            UpdateTotalPrice();
            count.Value = 1;
        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            if (dgvOrderDetails.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần bớt!", "Thông báo");
                return;
            }

            int currentQty = Convert.ToInt32(dgvOrderDetails.CurrentRow.Cells["Quantity"].Value);
            int removeQty = (int)count.Value;

            if (removeQty >= currentQty)
                dgvOrderDetails.Rows.Remove(dgvOrderDetails.CurrentRow);
            else
                dgvOrderDetails.CurrentRow.Cells["Quantity"].Value = currentQty - removeQty;

            UpdateTotalPrice();
        }

        private void UpdateTotalPrice()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvOrderDetails.Rows)
            {
                if (row.IsNewRow) continue;
                decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                int qty = Convert.ToInt32(row.Cells["Quantity"].Value);
                total += price * qty;
            }
            lbTotalPrice.Text = total.ToString("N0") + " VNĐ";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã lưu thay đổi đơn hàng!", "Thành công");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCustomerName.Text) || string.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Tên người nhận và Địa chỉ!", "Cảnh báo");
                    return;
                }

                var order = _orderService.GetOrderById(_orderId);
                if (order == null)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng!", "Lỗi");
                    return;
                }

                if (order.OrderStatus != 0) 
                {
                    MessageBox.Show("Chỉ đơn hàng ở trạng thái Pending mới được sửa!", "Không cho phép");
                    return;
                }

                order.ReceiverName = txtCustomerName.Text.Trim();
                order.ShippingAddress = txtAddress.Text.Trim();
                order.ShippingProviderId = cboShipping.SelectedValue as int? ?? order.ShippingProviderId;
                order.TotalMoney = CalculateTotalFromGrid();

                order.OrderDetails.Clear();

                foreach (DataGridViewRow row in dgvOrderDetails.Rows)
                {
                    if (row.IsNewRow) continue;

                    string sku = row.Cells["SKU"].Value?.ToString() ?? "";
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    decimal price = Convert.ToDecimal(row.Cells["Price"].Value);

                    var variant = _variantService.GetVariantBySKU(sku);
                    if (variant == null)
                    {
                        MessageBox.Show($"Không tìm thấy sản phẩm có SKU: {sku}", "Lỗi");
                        return;
                    }

                    order.OrderDetails.Add(new OrderDetail
                    {
                        VariantId = variant.VariantID,
                        Quantity = quantity,
                        PriceAtPurchase = price
                    });
                }

                if (order.OrderDetails.Count == 0)
                {
                    MessageBox.Show("Đơn hàng phải có ít nhất 1 sản phẩm!", "Cảnh báo");
                    return;
                }

                string paymentMethod = cboPayment.Text.Trim();
                string shippingMethod = cboShipping.Text.Trim();

                if (paymentMethod.Equals("CASH", StringComparison.OrdinalIgnoreCase) &&
                    shippingMethod.Equals("Direct", StringComparison.OrdinalIgnoreCase))
                {
                    order.OrderStatus = 1;
                }
                else
                {
                    order.OrderStatus = 2;
                }

                bool success = _orderService.UpdateFullOrder(order, paymentMethod);

                if (success)
                {
                    MessageBox.Show("Cập nhật đơn hàng thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu đơn hàng:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}