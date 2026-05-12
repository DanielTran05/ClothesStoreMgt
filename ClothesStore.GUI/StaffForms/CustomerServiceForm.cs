using ClothesStore.BUS;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ClothesStore.GUI.StaffForms
{
    public partial class CustomerServiceForm : Form
    {
        private CustomerService service =
            new CustomerService();

        private int selectedId = -1;

        public CustomerServiceForm()
        {
            InitializeComponent();

            SetupUI();
            SetupFilter();

            LoadData();
        }

        private void SetupUI()
        {
            dgvCustomerService.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvCustomerService.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvCustomerService.MultiSelect = false;

            dgvCustomerService.AllowUserToAddRows = false;

            dgvCustomerService.RowHeadersVisible = false;

            dgvCustomerService.BorderStyle =
                BorderStyle.None;

            dgvCustomerService.BackgroundColor =
                Color.White;

            dgvCustomerService.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvCustomerService.EnableHeadersVisualStyles =
                false;

            dgvCustomerService.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(52, 152, 219);

            dgvCustomerService.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvCustomerService.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Bold);

            dgvCustomerService.ColumnHeadersHeight = 40;

            dgvCustomerService.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dgvCustomerService.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(41, 128, 185);

            dgvCustomerService.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvCustomerService.RowTemplate.Height = 35;

            btnAdd.BackColor =
                Color.FromArgb(52, 152, 219);

            btnAdd.ForeColor =
                Color.White;

            btnAdd.FlatStyle =
                FlatStyle.Flat;

            btnAdd.FlatAppearance.BorderSize = 0;

            btnHandle.BackColor =
                Color.FromArgb(241, 196, 15);

            btnHandle.ForeColor =
                Color.White;

            btnHandle.FlatStyle =
                FlatStyle.Flat;

            btnHandle.FlatAppearance.BorderSize = 0;

            btnSolve.BackColor =
                Color.FromArgb(46, 204, 113);

            btnSolve.ForeColor =
                Color.White;

            btnSolve.FlatStyle =
                FlatStyle.Flat;

            btnSolve.FlatAppearance.BorderSize = 0;

            btnReject.BackColor =
                Color.FromArgb(231, 76, 60);

            btnReject.ForeColor =
                Color.White;

            btnReject.FlatStyle =
                FlatStyle.Flat;

            btnReject.FlatAppearance.BorderSize = 0;

            btnLoad.BackColor =
                Color.FromArgb(52, 73, 94);

            btnLoad.ForeColor =
                Color.White;

            btnLoad.FlatStyle =
                FlatStyle.Flat;

            btnLoad.FlatAppearance.BorderSize = 0;

            btnFilter.BackColor =
                Color.FromArgb(155, 89, 182);

            btnFilter.ForeColor =
                Color.White;

            btnFilter.FlatStyle =
                FlatStyle.Flat;

            btnFilter.FlatAppearance.BorderSize = 0;
        }

        private void SetupFilter()
        {
            cbStatus.Items.Clear();

            cbStatus.Items.Add("Tất cả");
            cbStatus.Items.Add("New");
            cbStatus.Items.Add("Processing");
            cbStatus.Items.Add("Solved");
            cbStatus.Items.Add("Rejected");

            cbStatus.SelectedIndex = 0;
        }

        private void LoadData()
        {
            DataTable dt =
                service.GetAll();

            if (!dt.Columns.Contains("StatusText"))
            {
                dt.Columns.Add(
                    "StatusText",
                    typeof(string));
            }

            foreach (DataRow row in dt.Rows)
            {
                int status =
                    Convert.ToInt32(
                        row["Status"]);

                if (status == 0)
                {
                    row["StatusText"] =
                        "New";
                }
                else if (status == 1)
                {
                    row["StatusText"] =
                        "Processing";
                }
                else if (status == 2)
                {
                    row["StatusText"] =
                        "Solved";
                }
                else if (status == 3)
                {
                    row["StatusText"] =
                        "Rejected";
                }
            }

            DataView dv =
                dt.DefaultView;

            string filter = "";

            if (cbStatus.SelectedIndex > 0)
            {
                int status =
                    cbStatus.SelectedIndex - 1;

                filter =
                    $"Status = {status}";
            }

            dv.RowFilter = filter;

            dgvCustomerService.DataSource =
                dv;

            dgvCustomerService.Columns["CustomerServiceID"]
                .HeaderText =
                "Mã Khiếu Nại";

            dgvCustomerService.Columns["CustomerID"]
                .HeaderText =
                "Mã Khách Hàng";

            dgvCustomerService.Columns["Reason"]
                .HeaderText =
                "Lý Do";

            dgvCustomerService.Columns["Date"]
                .HeaderText =
                "Ngày Gửi";

            dgvCustomerService.Columns["EmployeeResponse"]
                .HeaderText =
                "Phản Hồi";

            dgvCustomerService.Columns["ResponseDate"]
                .HeaderText =
                "Ngày Phản Hồi";

            dgvCustomerService.Columns["StatusText"]
                .HeaderText =
                "Trạng Thái";

            dgvCustomerService.Columns["Status"]
                .Visible = false;
        }

        private void btnAdd_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                    txtCustomerId.Text) ||

                string.IsNullOrWhiteSpace(
                    txtReason.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ thông tin!");

                return;
            }

            service.Add(
                Guid.Parse(
                    txtCustomerId.Text),

                txtReason.Text
            );

            MessageBox.Show(
                "Gửi khiếu nại thành công!");

            LoadData();

            txtCustomerId.Clear();
            txtReason.Clear();
        }

        private void dgvCustomerService_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            selectedId =
                Convert.ToInt32(
                    dgvCustomerService
                    .Rows[e.RowIndex]
                    .Cells["CustomerServiceID"]
                    .Value);

            if (dgvCustomerService
                .Rows[e.RowIndex]
                .Cells["EmployeeResponse"]
                .Value != DBNull.Value)
            {
                txtResponse.Text =
                    dgvCustomerService
                    .Rows[e.RowIndex]
                    .Cells["EmployeeResponse"]
                    .Value
                    .ToString();
            }
            else
            {
                txtResponse.Clear();
            }
        }

        private void btnHandle_Click(
            object sender,
            EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn khiếu nại!");

                return;
            }

            service.Handle(
                selectedId,
                GlobalSession
                .CurrentUser
                .UserId
            );

            MessageBox.Show(
                "Đã chuyển sang Processing!");

            LoadData();
        }

        private void btnSolve_Click(
            object sender,
            EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn khiếu nại!");

                return;
            }

            if (string.IsNullOrWhiteSpace(
                    txtResponse.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập phản hồi!");

                return;
            }

            service.Solve(
                selectedId,
                txtResponse.Text,
                GlobalSession
                .CurrentUser
                .UserId
            );

            MessageBox.Show(
                "Đã giải quyết khiếu nại!");

            txtResponse.Clear();

            LoadData();
        }

        private void btnReject_Click(
            object sender,
            EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn khiếu nại!");

                return;
            }

            service.Reject(
                selectedId,
                GlobalSession.CurrentUser.UserId
            );

            MessageBox.Show(
                "Đã từ chối khiếu nại!");

            LoadData();
        }

        private void btnLoad_Click(
            object sender,
            EventArgs e)
        {
            LoadData();
        }

        private void btnFilter_Click(
            object sender,
            EventArgs e)
        {
            LoadData();
        }

        private void cbStatus_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            LoadData();
        }
    }
}