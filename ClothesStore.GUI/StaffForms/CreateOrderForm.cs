using ClothesStore.DAL.Models;
using ClothesStore.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClothesStore.GUI.StaffForms
{
    public partial class CreateOrderForm : Form
    {
        private readonly ClothesStore.BUS.CustomerService _customerService = new ClothesStore.BUS.CustomerService();
        private readonly InvoiceService _invoiceService = new InvoiceService();
        private readonly ShippingService _shippingService = new ShippingService();
        private WarehouseService service = new WarehouseService();
        private OrderService _orderService = new OrderService();
        private DataTable inventoryTable;
        private Form _parentForm;

        public CreateOrderForm()
        {
            InitializeComponent();
            txtReceiverName.Enabled = false;
            txtAddress.Enabled = false;

            cboShipping.Enabled = false;
            cboPayment.Enabled = false;
            LoadPaymentMethods();
            LoadShippingMethods();
            SetupUI();
            LoadInventory();
            SetupSearchControls();
            SetupCartDataGridView();
        }

        private void checkPhone_Click(object sender, EventArgs e)
        {
            string phone = Phone.Text.Trim();

            if (string.IsNullOrEmpty(phone) || phone.Length != 10 || !phone.StartsWith("0") || !phone.All(char.IsDigit))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại hợp lệ (bao gồm đúng 10 chữ số và bắt đầu bằng số 0)!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User customer = _customerService.GetCustomerByPhone(phone);

            cboShipping.Enabled = true;
            cboPayment.Enabled = true;

            if (customer != null)
            {
                object rawOrder = _orderService.GetOrdersByCustomer(customer.UserId);

                if (rawOrder != null)
                {
                    string receiverName = rawOrder.GetType().GetProperty("ReceiverName")?.GetValue(rawOrder, null)?.ToString() ?? "";
                    string shippingAddress = rawOrder.GetType().GetProperty("ShippingAddress")?.GetValue(rawOrder, null)?.ToString() ?? "";
                    string shippingName = rawOrder.GetType().GetProperty("ShippingName")?.GetValue(rawOrder, null)?.ToString() ?? "Chưa chọn";

                    txtReceiverName.Text = receiverName;
                    txtAddress.Text = shippingAddress;

                    if (shippingName != "Chưa chọn")
                    {
                        cboShipping.Text = shippingName;
                    }

                    if (cboPayment.Items.Count > 0) cboPayment.SelectedIndex = 0;

                    txtReceiverName.ReadOnly = true;
                    txtAddress.ReadOnly = true;

                    MessageBox.Show("Đã tìm thấy thông tin và lịch sử giao hàng của khách hàng cũ.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tài khoản thành viên tồn tại nhưng chưa có đơn hàng cũ! Vui lòng nhập thông tin nhận hàng.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ResetInputFields(true);
                }
            }
            else
            {
                MessageBox.Show("Khách hàng mới hoàn toàn! Vui lòng nhập họ tên và địa chỉ để tạo đơn.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetInputFields(false);
            }
            checkPhone.Enabled = false;
        }

        private void ResetInputFields(bool isUserExists)
        {
            txtReceiverName.Clear();
            txtAddress.Clear();

            txtReceiverName.ReadOnly = false;
            txtAddress.ReadOnly = false;
            txtReceiverName.Enabled = true;
            txtAddress.Enabled = true;

            if (cboShipping.Items.Count > 0) cboShipping.SelectedIndex = 0;
            if (cboPayment.Items.Count > 0) cboPayment.SelectedIndex = 0;
        }

        private void LoadPaymentMethods()
        {
            try
            {
                List<string> methods = _invoiceService.GetPaymentMethods();

                cboPayment.DataSource = null;
                cboPayment.Items.Clear();

                if (methods != null && methods.Count > 0)
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

        private void LoadShippingMethods()
        {
            try
            {
                var shippers = _shippingService.GetShippers();
                cboShipping.DataSource = shippers;
                cboShipping.DisplayMember = "Name";
                cboShipping.ValueMember = "ShippingProviderId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải phương thức vận chuyển: " + ex.Message);
            }
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
        }

        private void SetupSearchControls()
        {
            cboSearchType.Items.Add("Tên sản phẩm");
            cboSearchType.Items.Add("SKU");
            cboSearchType.Items.Add("ProductID");
            cboSearchType.SelectedIndex = 0;
            cboSearchType.SelectedIndexChanged += cboSearchType_SelectedIndexChanged;
        }

        private void SetupCartDataGridView()
        {
            dgvCart.Columns.Clear();
            dgvCart.Columns.Add("ProductName", "Tên Sản Phẩm");
            dgvCart.Columns.Add("Price", "Đơn Giá");
            dgvCart.Columns.Add("Quantity", "Số Lượng");

            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "VariantID";
            colId.HeaderText = "Mã Biến Thể";
            dgvCart.Columns.Add(colId);
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
            TxtSearch_TextChanged(sender, e);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (inventoryTable == null) return;

            string keyword = txtSearch.Text.Trim().Replace("'", "''");
            DataView dv = inventoryTable.DefaultView;

            switch (cboSearchType.SelectedIndex)
            {
                case 0: dv.RowFilter = $"ProductName LIKE '%{keyword}%'"; break;
                case 1: dv.RowFilter = $"SKU LIKE '%{keyword}%'"; break;
                case 2: dv.RowFilter = $"Convert(ProductID, 'System.String') LIKE '%{keyword}%'"; break;
            }

            dgvInventory.DataSource = null;
            dgvInventory.DataSource = dv;
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvInventory.CurrentRow == null) return;

            var selectedRow = dgvInventory.CurrentRow;
            var variantId = selectedRow.Cells["ProductID"].Value;
            string name = selectedRow.Cells["ProductName"].Value.ToString();
            decimal price = Convert.ToDecimal(selectedRow.Cells["Price"].Value);
            int stock = Convert.ToInt32(selectedRow.Cells["AmountInStock"].Value);

            int quantityToAdd = (int)count.Value;

            if (quantityToAdd > stock)
            {
                MessageBox.Show($"Không đủ hàng! Kho còn: {stock}");
                return;
            }

            bool isExisted = false;
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells["VariantID"].Value != null && row.Cells["VariantID"].Value.Equals(variantId))
                {
                    int currentQty = Convert.ToInt32(row.Cells["Quantity"].Value);
                    if (currentQty + quantityToAdd > stock)
                    {
                        MessageBox.Show("Tổng số lượng vượt quá tồn kho!");
                        return;
                    }
                    row.Cells["Quantity"].Value = currentQty + quantityToAdd;
                    isExisted = true;
                    break;
                }
            }

            if (!isExisted)
            {
                dgvCart.Rows.Add(name, price, quantityToAdd, variantId);
            }

            UpdateLabelTotalPrice();
            count.Value = 1;
        }

        private void UpdateLabelTotalPrice()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (!row.IsNewRow && row.Cells["Price"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["Price"].Value) * Convert.ToInt32(row.Cells["Quantity"].Value);
                }
            }
            lbTotalPrice.Text = total.ToString("N0") + " VNĐ";
        }

        private void CreateOrder_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống! Vui lòng thêm sản phẩm.", "Cảnh báo");
                return;
            }

            try
            {
                if (string.IsNullOrWhiteSpace(txtReceiverName.Text) || string.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Họ tên và Địa chỉ nhận hàng!", "Cảnh báo");
                    return;
                }

                string phone = Phone.Text.Trim();
                User customer = _customerService.GetCustomerByPhone(phone);

                decimal totalMoney = 0;
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (!row.IsNewRow && row.Cells["Price"].Value != null)
                    {
                        totalMoney += Convert.ToDecimal(row.Cells["Price"].Value) * Convert.ToInt32(row.Cells["Quantity"].Value);
                    }
                }

                string paymentMethod = cboPayment.Text.Trim();
                string shippingMethod = cboShipping.Text.Trim();
                int statusId = 2;

                if (paymentMethod.Equals("CASH", StringComparison.OrdinalIgnoreCase) &&
                    shippingMethod.Equals("Direct", StringComparison.OrdinalIgnoreCase))
                {
                    statusId = 1;
                }

                Order newOrder = new Order
                {
                    OrderDate = DateTime.Now,
                    ReceiverName = txtReceiverName.Text.Trim(),
                    ReceiverPhone = phone,
                    ShippingAddress = txtAddress.Text.Trim(),
                    ShippingProviderId = Convert.ToInt32(cboShipping.SelectedValue),
                    OrderStatus = statusId,
                    TotalMoney = totalMoney,

                    CustomerId = customer != null ? customer.UserId : (Guid?)null
                };

                newOrder.OrderDetails = new List<OrderDetail>();
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (!row.IsNewRow && row.Cells["VariantID"].Value != null)
                    {
                        newOrder.OrderDetails.Add(new OrderDetail
                        {
                            VariantId = Convert.ToInt32(row.Cells["VariantID"].Value),
                            Quantity = Convert.ToInt32(row.Cells["Quantity"].Value),
                            PriceAtPurchase = Convert.ToDecimal(row.Cells["Price"].Value)
                        });
                    }
                }

                if (_orderService.ConfirmOrder(newOrder, paymentMethod))
                {
                    MessageBox.Show("Tạo đơn hàng và cập nhật kho thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvCart.Rows.Clear();
                    lbTotalPrice.Text = "0 VNĐ";
                    txtReceiverName.Clear();
                    txtAddress.Clear();
                    Phone.Clear();
                    LoadInventory();
                }
                else
                {
                    MessageBox.Show("Lưu đơn hàng thất bại, vui lòng kiểm tra lại!", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                string error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show("Lỗi hệ thống chi tiết:\n" + error, "Lỗi Nghiêm Trọng",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            if (_parentForm != null)
            {
                _parentForm.Show();
            }

            this.Close();
        }
    }
}