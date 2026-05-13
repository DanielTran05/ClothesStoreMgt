using ClothesStore.BUS;
using ClothesStore.DAL.Enums;
using ClothesStore.DAL.Models;
using ClothesStore.GUI.StaffForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClothesStore.GUI
{
    public partial class ucOrderManagement : UserControl
    {
        private readonly OrderService _orderService = new OrderService();
        private readonly ShippingService _shippingService = new ShippingService();
        private readonly InvoiceService _invoiceService = new InvoiceService();
        public ucOrderManagement()
        {
            InitializeComponent();
            LoadOrderData();
            LoadShippingComboBox();
            LoadPaymentMethodComboBox();
        }
        public void LoadOrderData()
        {
            try
            {
                // Lấy dữ liệu từ BUS
                var orders = _orderService.GetOrders();

                // Gán vào DataGridView
                dgvOrders.DataSource = null; // Reset để cập nhật mới
                dgvOrders.DataSource = orders;

                // Định dạng tiêu đề cột (Header)
                if (dgvOrders.Columns.Count > 0)
                {
                    dgvOrders.Columns["OrderId"].HeaderText = "Mã Đơn";
                    dgvOrders.Columns["OrderDate"].HeaderText = "Ngày Đặt";
                    dgvOrders.Columns["OrderStatus"].HeaderText = "Trạng Thái";
                    dgvOrders.Columns["TotalMoney"].HeaderText = "Tổng Tiền";

                    // Định dạng tiền tệ cho cột Tổng Tiền
                    dgvOrders.Columns["TotalMoney"].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải đơn hàng: " + ex.Message, "Thông báo");
            }
        }
        private void LoadShippingComboBox()
        {
            try
            {
                // 1. Lấy danh sách từ BUS
                var shippers = _shippingService.GetShippers();

                // 2. Thiết lập ComboBox (ví dụ tên là cboShipping)
                cboShipping.DataSource = shippers;

                // Hiển thị tên nhà vận chuyển
                cboShipping.DisplayMember = "Name";

                // Giá trị lưu trữ là ID để gán vào bảng Orders
                cboShipping.ValueMember = "ShippingProviderId";

                // 3. (Tùy chọn) Để ComboBox không chọn sẵn mục nào khi mới load
                cboShipping.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách vận chuyển: " + ex.Message);
            }
        }

        private void LoadPaymentMethodComboBox()
        {
            try
            {
                List<string> methods = _invoiceService.GetPaymentMethods();

                cboPaymentMethod.DataSource = methods;

                cboPaymentMethod.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void txtSearchOrder_TextChanged(object sender, EventArgs e)
        {
            dgvOrders.DataSource = _orderService.Search(txtSearchOrder.Text);
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn đơn vị vận chuyển chưa
            if (cboShipping.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đơn vị vận chuyển!");
                return;
            }

            if (cboPaymentMethod.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán!");
                return;
            }

            Order newOrder = new Order
            {
                OrderStatus = 2,
                OrderDate = DateTime.Now,
                ReceiverName = txtReceiverName.Text,
                ReceiverPhone = txtReceiverPhone.Text,
                TotalMoney = Decimal.Parse(txtTotalMoney.Text.Trim()),

                // Lấy ID từ ComboBox đã được liên kết với bảng ShippingProviders
                ShippingProviderId = (int)cboShipping.SelectedValue
            };

            string paymentMethod = cboPaymentMethod.SelectedItem.ToString();
            // Gọi hàm SaveOrder mà chúng ta đã tích hợp tạo Invoice (Status = 2)
            string result = _orderService.CreateOrder(newOrder, paymentMethod);
            MessageBox.Show(result);
            LoadOrderData();
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow != null)
            {
                // 2. Lấy giá trị ID của dòng đang chọn (OrderID hoặc ProductID)
                // Lưu ý: "OrderId" phải là tên cột (Name) bạn đã đặt trong DataGridView
                int idToDelete = Convert.ToInt32(dgvOrders.CurrentRow.Cells["OrderId"].Value);

                // 3. Hiển thị hộp thoại xác nhận để tránh xóa nhầm
                DialogResult confirm = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa mục có mã {idToDelete} không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    // 4. Gọi Service để thực hiện xóa trong CSDL
                    string result = _orderService.RemoveOrder(idToDelete);

                    // 5. Thông báo kết quả và tải lại dữ liệu lên Grid
                    MessageBox.Show(result);
                    if (result.Contains("thành công"))
                    {
                        LoadOrderData(); // Hàm tải lại dữ liệu bạn đã viết ở trên
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trong danh sách trước khi xóa!");
            }
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow != null)
            {
                int currentState = Convert.ToInt32(dgvOrders.CurrentRow.Cells["OrderStatus"].Value);

                // Kiểm tra nếu trạng thái là 2 (Đã thanh toán/Hoàn thành)
                if (currentState == 2)
                {
                    MessageBox.Show("Đơn hàng đã thanh toán không thể sửa đổi!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // 1. Lấy ID từ dòng đang chọn
                int orderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells["OrderId"].Value);

                // 2. Kiểm tra dữ liệu đầu vào cơ bản
                if (cboShipping.SelectedValue == null || cboPaymentMethod.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ đơn vị vận chuyển và phương thức thanh toán!");
                    return;
                }

                // 3. Đóng gói dữ liệu vào đối tượng Order
                Order updatedOrder = new Order
                {
                    OrderId = orderId,
                    ReceiverName = txtReceiverName.Text.Trim(),
                    ReceiverPhone = txtReceiverPhone.Text.Trim(),
                    ShippingAddress = txtAddress.Text.Trim(),
                    TotalMoney = Decimal.Parse(txtTotalMoney.Text.Trim()),
                    ShippingProviderId = (int)cboShipping.SelectedValue
                    // OrderStatus giữ nguyên hoặc lấy từ UI nếu có
                };

                string paymentMethod = cboPaymentMethod.SelectedItem.ToString();

                // 4. Hỏi xác nhận cập nhật
                if (MessageBox.Show($"Bạn có muốn cập nhật đơn hàng {orderId}?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // 5. Gọi Service xử lý (Lưu ý: Service cần hàm UpdateOrder nhận thêm paymentMethod)
                    string message = _orderService.UpdateOrder(updatedOrder, paymentMethod);
                    MessageBox.Show(message);

                    if (message.Contains("thành công"))
                    {
                        LoadOrderData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để cập nhật!");
            }
        }

        private void InvoiceHistory_Click(object sender, EventArgs e)
        {
            InvoiceHistoryForm form = new InvoiceHistoryForm();
            this.Hide();
            form.Show();
        }
    }
}
