using ClothesStore.BUS;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ClothesStore.GUI.StaffForms
{
    public partial class CustomerServiceForm : Form
    {
        private CustomerService service = new CustomerService();
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
            dgvCustomerService.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomerService.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomerService.MultiSelect = false;
            dgvCustomerService.AllowUserToAddRows = false;
            dgvCustomerService.RowHeadersVisible = false;
            dgvCustomerService.BorderStyle = BorderStyle.None;
            dgvCustomerService.BackgroundColor = Color.White;

            dgvCustomerService.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCustomerService.EnableHeadersVisualStyles = false;

            dgvCustomerService.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(52, 152, 219);
            dgvCustomerService.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCustomerService.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Bold);

            dgvCustomerService.ColumnHeadersHeight = 40;

            dgvCustomerService.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dgvCustomerService.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(41, 128, 185);

            dgvCustomerService.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvCustomerService.RowTemplate.Height = 35;

            btnHandle.BackColor = Color.FromArgb(241, 196, 15);
            btnReject.BackColor = Color.FromArgb(231, 76, 60);
            btnLoad.BackColor = Color.FromArgb(52, 73, 94);

            btnHandle.ForeColor = Color.White;
            btnReject.ForeColor = Color.White;
            btnLoad.ForeColor = Color.White;
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
            DataTable dt = service.GetAll();
            if (dt == null) return;

            if (!dt.Columns.Contains("StatusText"))
                dt.Columns.Add("StatusText", typeof(string));

            foreach (DataRow row in dt.Rows)
            {
                int status = Convert.ToInt32(row["Status"]);

                row["StatusText"] =
                    status == 0 ? "New" :
                    status == 1 ? "Processing" :
                    status == 2 ? "Solved" :
                    "Rejected";
            }

            DataView dv = dt.DefaultView;

            if (cbStatus.SelectedIndex > 0)
                dv.RowFilter = $"Status = {cbStatus.SelectedIndex - 1}";
            else
                dv.RowFilter = "";

            dgvCustomerService.DataSource = dv;

            SetHeader("CustomerServiceID", "Mã Khiếu Nại");

            SetHeader("CustomerID", "Mã KH");
            SetHeader("CustomerName", "Tên Khách Hàng");

            SetHeader("EmployeeID", "Mã NV");
            SetHeader("EmployeeName", "Tên Nhân Viên");

            SetHeader("Reason", "Lý Do");
            SetHeader("Date", "Ngày Gửi");

            SetHeader("EmployeeResponse", "Phản Hồi");
            SetHeader("ResponseDate", "Ngày Phản Hồi");

            SetHeader("StatusText", "Trạng Thái");

            HideColumn("Status");
        }

        private void SetHeader(string col, string text)
        {
            if (dgvCustomerService.Columns.Contains(col))
                dgvCustomerService.Columns[col].HeaderText = text;
        }

        private void HideColumn(string col)
        {
            if (dgvCustomerService.Columns.Contains(col))
                dgvCustomerService.Columns[col].Visible = false;
        }

        private void dgvCustomerService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            selectedId = Convert.ToInt32(
                dgvCustomerService.Rows[e.RowIndex]
                .Cells["CustomerServiceID"].Value
            );
        }

        //private void btnHandle_Click(object sender, EventArgs e)
        //{
        //    if (selectedId == -1)
        //    {
        //        MessageBox.Show("Vui lòng chọn khiếu nại!");
        //        return;
        //    }

        //    int status = Convert.ToInt32(
        //        dgvCustomerService.CurrentRow.Cells["Status"].Value
        //    );

        //    // NEW -> PROCESSING
        //    if (status == 0)
        //    {
        //        service.Handle(
        //            selectedId,
        //            GlobalSession.CurrentUser.UserId
        //        );

        //        MessageBox.Show("Processing...");
        //        LoadData();
        //        return;
        //    }

        //    // PROCESSING -> SOLVED
        //    if (status == 1)
        //    {
        //        using (var frm = new ResponseForm())
        //        {
        //            if (frm.ShowDialog() == DialogResult.OK)
        //            {
        //                service.Solve(
        //                    selectedId,
        //                    frm.ResponseText,
        //                    GlobalSession.CurrentUser.UserId
        //                );

        //                MessageBox.Show("Solved!");
        //                LoadData();
        //            }
        //        }

        //        return;
        //    }

        //    MessageBox.Show("Trạng thái không hợp lệ!");
        //}

        private void btnHandle_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Vui lòng chọn khiếu nại!");
                return;
            }

            int status = Convert.ToInt32(
                dgvCustomerService.CurrentRow.Cells["Status"].Value
            );

            if (status == 2 || status == 3)
            {
                MessageBox.Show("Không thể xử lý!");
                return;
            }

            bool wasNew = (status == 0);

            // NEW -> PROCESSING
            if (wasNew)
            {
                service.Handle(
                    selectedId,
                    GlobalSession.CurrentUser.UserId
                );

                LoadData();
            }

            using (var frm = new ResponseForm())
            {
                DialogResult result = frm.ShowDialog();

                // SOLVED
                if (result == DialogResult.OK)
                {
                    service.Solve(
                        selectedId,
                        frm.ResponseText,
                        GlobalSession.CurrentUser.UserId
                    );

                    MessageBox.Show("Solved!");
                }

                // CANCEL -> quay lại NEW
                else if (result == DialogResult.Cancel)
                {
                    // chỉ reset nếu ban đầu là NEW
                    if (wasNew)
                    {
                        service.Reset(selectedId);
                    }
                }

                // Retry = Đang xử lý
                // giữ nguyên PROCESSING
                else if (result == DialogResult.Retry)
                {
                    MessageBox.Show("Đã lưu trạng thái Processing!");
                }

                LoadData();
            }
        }
        private void btnReject_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Vui lòng chọn khiếu nại!");
                return;
            }

            int status = Convert.ToInt32(
                dgvCustomerService.CurrentRow.Cells["Status"].Value
            );

            if (status == 2 || status == 3)
            {
                MessageBox.Show("Không thể reject!");
                return;
            }

            service.Reject(selectedId, GlobalSession.CurrentUser.UserId);

            MessageBox.Show("Rejected!");
            LoadData();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}