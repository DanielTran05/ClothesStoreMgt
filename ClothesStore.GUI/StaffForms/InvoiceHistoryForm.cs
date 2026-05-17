using ClothesStore.BUS;
using System;
using System.Windows.Forms;

namespace ClothesStore.GUI.StaffForms
{
    public partial class InvoiceHistoryForm : Form
    {
        private readonly InvoiceService _invoiceService = new InvoiceService();
        private Form _parentForm;

        private int currentPage = 1;
        private int totalPages = 1;

        public InvoiceHistoryForm(Form parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
                
            LoadStatusSimple();
            LoadHistory();   // Load trang 1 ban đầu
        }

        private void LoadHistory()
        {
            try
            {
                var result = _invoiceService.GetInvoicesByPage(currentPage);

                dgvInvoices.DataSource = result.Data;
                totalPages = result.TotalPages;

                UpdatePaginationUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử: " + ex.Message);
            }
        }

        private void ExecuteFilter()
        {
            try
            {
                DateTime fromDate = dtpFrom.Value.Date;
                DateTime toDate = dtpTo.Value.Date;

                int? status = null;
                if (cboStatus.SelectedIndex > 0)
                {
                    status = cboStatus.SelectedIndex;   // tùy theo mapping của bạn
                }

                var result = _invoiceService.GetHistory(fromDate, toDate, status, currentPage);

                dgvInvoices.DataSource = result.Data;
                totalPages = result.TotalPages;

                UpdatePaginationUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lọc dữ liệu: " + ex.Message);
            }
        }

        // Cập nhật giao diện phân trang (quan trọng)
        private void UpdatePaginationUI()
        {
            lblPageInfo.Text = $"Trang {currentPage} / {totalPages}";

            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
        }

        private void ResetAndLoad()
        {
            currentPage = 1;
            ExecuteFilter();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                ExecuteFilter();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                ExecuteFilter();
            }
        }

        // Các event filter
        private void dtpFrom_ValueChanged(object sender, EventArgs e) => ResetAndLoad();
        private void dtpTo_ValueChanged(object sender, EventArgs e) => ResetAndLoad();
        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e) => ResetAndLoad();

        private void LoadStatusSimple()
        {
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Tất cả trạng thái");
            cboStatus.Items.Add("Pending");
            cboStatus.Items.Add("Paid");
            cboStatus.Items.Add("Cancelled");
            cboStatus.SelectedIndex = 0;
        }

        private void back_Click(object sender, EventArgs e)
        {
            _parentForm?.Show();
            this.Close();
        }
    }
}