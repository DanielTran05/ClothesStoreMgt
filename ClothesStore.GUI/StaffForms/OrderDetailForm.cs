using ClothesStore.DAL.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClothesStore.GUI.StaffForms
{
    public partial class OrderDetailForm : Form
    {
        private int _orderId;
        private OrderRepository _repo = new OrderRepository();

        public OrderDetailForm(int orderId)
        {
            InitializeComponent();
            _orderId = orderId;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = $"Chi tiết đơn hàng #{_orderId}";
        }

        private void OrderDetailForm_Load(object sender, EventArgs e)
        {
            try
            {
                var details = _repo.GetOrderDetailsWithInfo(_orderId);

                dgvOrderDetail.DataSource = null;
                dgvOrderDetail.DataSource = details;

                if (dgvOrderDetail.Columns.Count > 0)
                {
                    if (dgvOrderDetail.Columns["SKU"] != null)
                    {
                        dgvOrderDetail.Columns["SKU"].HeaderText = "Mã SKU";
                        dgvOrderDetail.Columns["SKU"].DisplayIndex = 0;
                    }

                    if (dgvOrderDetail.Columns["ProductName"] != null)
                        dgvOrderDetail.Columns["ProductName"].HeaderText = "Tên Sản Phẩm";

                    if (dgvOrderDetail.Columns["Quantity"] != null)
                    {
                        dgvOrderDetail.Columns["Quantity"].HeaderText = "Số Lượng";
                        dgvOrderDetail.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    if (dgvOrderDetail.Columns["Price"] != null)
                    {
                        dgvOrderDetail.Columns["Price"].HeaderText = "Giá Mua";
                        dgvOrderDetail.Columns["Price"].DefaultCellStyle.Format = "N0";
                        dgvOrderDetail.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    if (dgvOrderDetail.Columns["SubTotal"] != null)
                    {
                        dgvOrderDetail.Columns["SubTotal"].HeaderText = "Thành Tiền";
                        dgvOrderDetail.Columns["SubTotal"].DefaultCellStyle.Format = "N0";
                        dgvOrderDetail.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    string[] hiddenColumns = { "VariantId", "OrderDetailId", "OrderId" };
                    foreach (var colName in hiddenColumns)
                    {
                        if (dgvOrderDetail.Columns[colName] != null)
                            dgvOrderDetail.Columns[colName].Visible = false;
                    }

                    if (dgvOrderDetail.Columns["ProductName"] != null)
                        dgvOrderDetail.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
