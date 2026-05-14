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
        private Form _parentForm;
        public ucOrderManagement(Form parent)
        {
            InitializeComponent();
            _parentForm = parent;
            LoadOrderData();
            LoadStatusToComboBox();
            dtpFromDate.Value = DateTime.Now.AddMonths(-2);
            dtpToDate.Value = DateTime.Now;
            ExecuteAutoFilter();
        }
        public void LoadOrderData()
        {
            try
            {
                var orders = _orderService.GetOrders();

                dgvOrders.DataSource = null;
                dgvOrders.DataSource = orders;


                if (dgvOrders.Columns.Count > 0)
                {
                    dgvOrders.Columns["OrderId"].HeaderText = "Mã Đơn";
                    dgvOrders.Columns["OrderDate"].HeaderText = "Ngày Đặt";

                    if (dgvOrders.Columns["State"] != null)
                        dgvOrders.Columns["State"].Visible = false;

                    if (dgvOrders.Columns["StatusName"] != null)
                        dgvOrders.Columns["StatusName"].HeaderText = "Trạng Thái";

                    dgvOrders.Columns["TotalMoney"].HeaderText = "Tổng Tiền";

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
        }

        private void LoadPaymentMethodComboBox()
        {
        }

        private void txtSearchOrder_TextChanged(object sender, EventArgs e)
        {
            ExecuteAutoFilter();
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            Form mainForm = this.FindForm();

            CreateOrderForm form = new CreateOrderForm();

            form.FormClosed += (s, args) => mainForm.Show();

            mainForm.Hide();
            form.Show();
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells["OrderId"].Value);

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa đơn hàng #{orderId}?\n\n" +
                "Tất cả dữ liệu liên quan (OrderDetails, Invoice) sẽ bị xóa\n" +
                "và tồn kho sẽ được hoàn trả.",
                "XÁC NHẬN XÓA ĐƠN HÀNG",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                string result = _orderService.RemoveOrder(orderId);

                MessageBox.Show(result,
                                "Kết quả",
                                MessageBoxButtons.OK,
                                result.Contains("thành công") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result.Contains("thành công"))
                {
                    LoadOrderData();
                }
            }
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string statusName = dgvOrders.CurrentRow.Cells["StatusName"].Value?.ToString() ?? "";

            if (statusName != "Pending")
            {
                MessageBox.Show("Chỉ cho phép sửa đơn hàng ở trạng thái **Pending**!",
                    "Không cho phép", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells["OrderId"].Value);

            using (EditOrderForm editForm = new EditOrderForm(orderId))
            {
                DialogResult result = editForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoadOrderData(); 
                }
            }
        }

        private void InvoiceHistory_Click(object sender, EventArgs e)
        {
            Form mainForm = this.FindForm();

            InvoiceHistoryForm form = new InvoiceHistoryForm(mainForm);

            mainForm.Hide(); 
            form.Show();     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                this.Parent.Controls.Remove(this);
            }

            this.Dispose();
        }

        private void LoadStatusToComboBox()
        {
            cboFilterStatus.Items.Clear();
            cboFilterStatus.Items.Add("-- Tất cả trạng thái --");
            cboFilterStatus.Items.Add("Pending");
            cboFilterStatus.Items.Add("Paid");
            cboFilterStatus.Items.Add("Shipping");
            cboFilterStatus.Items.Add("Completed");
            cboFilterStatus.Items.Add("Canceled");
            cboFilterStatus.Items.Add("Returned");
            cboFilterStatus.SelectedIndex = 0;
        }

        private void viewOrderDetail_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow != null)
            {
                int selectedOrderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells["OrderId"].Value);
                OrderDetailForm detailForm = new OrderDetailForm(selectedOrderId);
                detailForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để xem chi tiết!", "Thông báo");
            }
        }
        private void ExecuteAutoFilter()
        {
            int? statusInDb = null;

            if (cboFilterStatus.SelectedIndex > 0)
            {
                statusInDb = cboFilterStatus.SelectedIndex - 1;
            }

            var result = _orderService.GetOrdersFiltered(
                dtpFromDate.Value,
                dtpToDate.Value,
                statusInDb,
                txtSearchOrder.Text.Trim()
            );

            dgvOrders.DataSource = null;
            dgvOrders.DataSource = result;

            if (dgvOrders.Columns.Count > 0)
            {
                if (dgvOrders.Columns["State"] != null) dgvOrders.Columns["State"].Visible = false;

                if (dgvOrders.Columns["TotalMoney"] != null)
                    dgvOrders.Columns["TotalMoney"].DefaultCellStyle.Format = "N0";

                if (dgvOrders.Columns["OrderDate"] != null)
                    dgvOrders.Columns["OrderDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            ExecuteAutoFilter();
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            ExecuteAutoFilter();
        }

        private void cboFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExecuteAutoFilter();
        }


    }
}
