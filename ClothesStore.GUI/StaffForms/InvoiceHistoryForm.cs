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
            LoadHistory();
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
                    status = cboStatus.SelectedIndex;
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


        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetAndLoad();
        }

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

        private void btnFiller_Click(object sender, EventArgs e)
        {
            ResetAndLoad();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now.AddMonths(-1);
            dtpTo.Value = DateTime.Now;

            if (cboStatus.Items.Count > 0)
            {
                cboStatus.SelectedIndex = 0;
            }

            currentPage = 1;

            LoadHistory();
        }
    }
}