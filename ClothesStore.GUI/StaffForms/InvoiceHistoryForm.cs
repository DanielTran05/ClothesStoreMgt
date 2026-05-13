using ClothesStore.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClothesStore.GUI.StaffForms
{
    public partial class InvoiceHistoryForm : Form
    {
        private readonly InvoiceService _invoiceService = new InvoiceService();

        int currentPage = 1;
        int totalPages = 1;
        public InvoiceHistoryForm()
        {
            InitializeComponent();
            LoadStatusSimple();
            LoadHistory();
        }
        private void LoadHistory()
        {
            try
            {
                // Gọi Service lấy dữ liệu trang hiện tại
                var result = _invoiceService.GetInvoicesByPage(currentPage);

                // Đổ dữ liệu vào Grid
                dgvInvoices.DataSource = null;
                dgvInvoices.DataSource = result.Data;

                // Cập nhật biến tổng số trang
                totalPages = result.TotalPages;

                // Hiển thị thông tin lên nhãn (Ví dụ: lblPageInfo)
                lblPageInfo.Text = $"Trang {currentPage} / {totalPages}";

                // Điều khiển trạng thái nút bấm
                btnPrev.Enabled = currentPage > 1;
                btnNext.Enabled = currentPage < totalPages;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi phân trang: " + ex.Message);
            }
        }

        private void ExecuteFilter()
        {
            // Lấy ngày thuần túy (.Date)
            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDate = dtpTo.Value.Date;

            int? status = null;
            if (cboStatus.SelectedIndex > 0)
            {
                status = cboStatus.SelectedIndex; // 1: Pending, 2: Paid, 3: Cancelled
            }

            // Gọi Service
            var result = _invoiceService.GetHistory(fromDate, toDate, status, currentPage);

            dgvInvoices.DataSource = null;
            dgvInvoices.DataSource = result.Data;

            // Cập nhật nhãn trang
            totalPages = result.TotalPages;
            lblPageInfo.Text = $"Trang {currentPage} / {totalPages}";
        }

        private void LoadStatusSimple()
        {
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Tất cả trạng thái"); // Index 0 -> null (Tất cả)
            cboStatus.Items.Add("Pending");           // Index 1 -> Số 1
            cboStatus.Items.Add("Paid");              // Index 2 -> Số 2
            cboStatus.Items.Add("Cancelled");         // Index 3 -> Số 3

            cboStatus.SelectedIndex = 0; // Mặc định chọn cái đầu tiên
        }

        private void ResetAndLoad()
        {
            currentPage = 1; // Luôn về trang đầu khi tiêu chí lọc thay đổi
            ExecuteFilter();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                ExecuteFilter(); // Phải gọi ExecuteFilter để giữ bộ lọc ngày/status
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                ExecuteFilter(); // Phải gọi ExecuteFilter để giữ bộ lọc ngày/status
            }
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            ExecuteFilter(); // Hoặc LoadHistory() tùy theo tên hàm bạn đặt
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            ExecuteFilter();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem ComboBox có dữ liệu chưa để tránh chạy bậy khi đang khởi tạo
            if (cboStatus.SelectedIndex == -1) return;

            // Mỗi khi tiêu chí lọc thay đổi (ví dụ đổi từ Paid sang Cancelled)
            // chúng ta PHẢI quay về trang 1 để xem dữ liệu mới nhất
            currentPage = 1;

            // Gọi hàm lọc mà bạn đã chuẩn bị
            ExecuteFilter();
        }
    }
}
