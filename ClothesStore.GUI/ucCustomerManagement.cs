using System;
using System.Collections.Generic;
using System.Linq; 
using System.Windows.Forms;
using ClothesStore.BUS;
using ClothesStore.DTO.UserDto;

namespace ClothesStore.GUI
{
    public partial class ucCustomerManagement : UserControl
    {
        private readonly UserService _userService;
        private bool _isEditMode = false;
        private Guid _selectedUserId;

        private List<ReadUserDTO> _allCustomers = new List<ReadUserDTO>();

        public ucCustomerManagement()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void ucCustomerManagement_Load(object sender, EventArgs e)
        {
            pnlInputSide.Visible = false;
            pnlToolBar.SendToBack();
            pnlInputSide.SendToBack();
            dgvUsers.BringToFront();

            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            try
            {
                _allCustomers = _userService.GetAllCustomers();
                if (_allCustomers == null) return;

                dgvUsers.DataSource = _allCustomers;
                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dgvUsers.ScrollBars = ScrollBars.Both;

                foreach (DataGridViewColumn col in dgvUsers.Columns)
                {
                    string prop = (col.DataPropertyName ?? col.Name).ToLower();
                    if (prop == "userid" || prop == "password" || prop == "passwordhash" || prop == "address" || prop == "role")
                    {
                        col.Visible = false;
                    }
                    else if (prop == "username") col.HeaderText = "Tên đăng nhập";
                    else if (prop == "fullname") col.HeaderText = "Họ và tên";
                    else if (prop == "email") col.HeaderText = "Email";
                    else if (prop == "phonenumber") col.HeaderText = "Số điện thoại";
                    else if (prop == "isactive") col.HeaderText = "Trạng thái";
                    else if (prop == "createdat")
                    {
                        col.HeaderText = "Ngày tạo";
                        col.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    }
                }
                if (dgvUsers.Columns.Contains("Email"))
                {
                    dgvUsers.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu khách hàng: " + ex.Message);
            }
        }

        public void ShowAddPanel()
        {
            _isEditMode = false;
            pnlInputSide.Visible = true;
            dgvUsers.BringToFront();
            txtUsername.Clear();
            txtPassword.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            lblTitle.Text = "THÊM KHÁCH HÀNG MỚI";
        }

        public void ShowUpdatePanel()
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng trong bảng!");
                return;
            }

            _isEditMode = true;
            var selectedUser = (ReadUserDTO)dgvUsers.SelectedRows[0].DataBoundItem;
            _selectedUserId = selectedUser.UserID;

            txtUsername.Text = selectedUser.Username;
            txtFullName.Text = selectedUser.FullName;
            txtEmail.Text = selectedUser.Email;
            txtPhone.Text = selectedUser.PhoneNumber;

            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            pnlInputSide.Visible = true;
            dgvUsers.BringToFront();
            lblTitle.Text = "CẬP NHẬT KHÁCH HÀNG";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_isEditMode)
                {
                    var request = new CreateUserRequest
                    {
                        Username = txtUsername.Text.Trim(),
                        Password = txtPassword.Text,
                        FullName = txtFullName.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        PhoneNumber = txtPhone.Text.Trim(),
                        Role = 4, 
                        IsActive = true
                    };
                    _userService.CreateEmployee(request);
                    MessageBox.Show("Thêm Khách hàng thành công!");
                }
                else
                {
                    var request = new UpdateUserRequest
                    {
                        UserID = _selectedUserId,
                        FullName = txtFullName.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        PhoneNumber = txtPhone.Text.Trim(),
                        Role = 4
                    };
                    _userService.UpdateEmployee(request);
                    MessageBox.Show("Cập nhật thành công!");
                }

                pnlInputSide.Visible = false;
                LoadCustomerData();
                txtSearch.Text = ""; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlInputSide.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowAddPanel();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ShowUpdatePanel();
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng trong danh sách!");
                return;
            }
            var selectedUser = (ReadUserDTO)dgvUsers.SelectedRows[0].DataBoundItem;

            bool newStatus = !(bool)selectedUser.IsActive;
            string actionText = newStatus ? "MỞ KHÓA" : "KHÓA";
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn {actionText} tài khoản khách hàng '{selectedUser.Username}'?",
                "Xác nhận thay đổi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _userService.ToggleUserStatus(selectedUser.UserID, newStatus);
                    MessageBox.Show($"Đã {actionText} khách hàng thành công!");
                    LoadCustomerData();
                    txtSearch.Text = ""; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thực hiện: " + ex.Message);
                }
            }
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần reset mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedUser = (ReadUserDTO)dgvUsers.SelectedRows[0].DataBoundItem;

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn đưa mật khẩu của khách hàng '{selectedUser.Username}' về mặc định (123456)?",
                "Xác nhận Reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _userService.ResetUserPassword(selectedUser.UserID, "123456");

                    MessageBox.Show($"Reset mật khẩu thành công!\nKhách hàng {selectedUser.Username} có thể đăng nhập bằng mật khẩu: 123456",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi reset mật khẩu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                dgvUsers.DataSource = _allCustomers;
            }
            else
            {
                var filteredList = _allCustomers.Where(c =>
                    (c.Username != null && c.Username.ToLower().Contains(keyword)) ||
                    (c.FullName != null && c.FullName.ToLower().Contains(keyword)) ||
                    (c.PhoneNumber != null && c.PhoneNumber.ToLower().Contains(keyword)) ||
                    (c.Email != null && c.Email.ToLower().Contains(keyword))
                ).ToList();

                dgvUsers.DataSource = filteredList;
            }
        }
    }
}