using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClothesStore.BUS; 
using ClothesStore.DTO.UserDto; 

namespace ClothesStore.GUI
{
    public partial class ucUserManagement : UserControl
    {
        private readonly UserService _userService;
        private bool _isEditMode = false;
        private Guid _selectedUserId;
        public ucUserManagement()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void ucUserManagement_Load(object sender, EventArgs e)
        {
            pnlInputSide.Visible = false;
            pnlToolBar.SendToBack();
            pnlInputSide.SendToBack();
            dgvUsers.BringToFront();
            LoadUserData();
            Dictionary<int, string> roles = new Dictionary<int, string>
    {
        { 1, "Quản trị viên" },
        { 2, "Nhân viên bán hàng" },
        { 3, "Thủ kho" }
    };
            cbRole.DataSource = new BindingSource(roles, null);
            cbRole.DisplayMember = "Value";
            cbRole.ValueMember = "Key";
        }

        private void LoadUserData()
        {
            try
            {
                var data = _userService.GetAllEmployees();
                if (data == null) return;
                dgvUsers.DataSource = data;
                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dgvUsers.ScrollBars = ScrollBars.Both;
                foreach (DataGridViewColumn col in dgvUsers.Columns)
                {
                    string prop = (col.DataPropertyName ?? col.Name).ToLower();
                    if (prop == "userid" || prop == "password" || prop == "passwordhash" || prop == "address")
                    {
                        col.Visible = false;
                    }
                    else if (prop == "username") col.HeaderText = "Tên đăng nhập";
                    else if (prop == "fullname") col.HeaderText = "Họ và tên";
                    else if (prop == "email") col.HeaderText = "Email";
                    else if (prop == "phonenumber") col.HeaderText = "Số điện thoại";
                    else if (prop == "role") col.HeaderText = "Vai trò";
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
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
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
            lblTitle.Text = "THÊM NHÂN VIÊN MỚI";
        }

        public void ShowUpdatePanel()
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên trong bảng!");
                return;
            }

            _isEditMode = true;
            var selectedUser = (ReadUserDTO)dgvUsers.SelectedRows[0].DataBoundItem;
            _selectedUserId = selectedUser.UserID;

            txtUsername.Text = selectedUser.Username;
            txtFullName.Text = selectedUser.FullName;
            txtEmail.Text = selectedUser.Email;
            txtPhone.Text = selectedUser.PhoneNumber;
            cbRole.SelectedValue = selectedUser.Role;

            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            pnlInputSide.Visible = true;
            dgvUsers.BringToFront();
            lblTitle.Text = "CẬP NHẬT THÔNG TIN";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string errors = ValidateInputs(!_isEditMode);
            if (!string.IsNullOrEmpty(errors))
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin:\n\n" + errors,
                    "Thông tin không hợp lệ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return; 
            }
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
                        Role = (int)cbRole.SelectedValue,
                        IsActive = true
                    };
                    _userService.CreateEmployee(request);
                    MessageBox.Show("Thêm nhân viên thành công!");
                }
                else
                {
                    var request = new UpdateUserRequest
                    {
                        UserID = _selectedUserId,
                        FullName = txtFullName.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        PhoneNumber = txtPhone.Text.Trim(),
                        Role = (int)cbRole.SelectedValue
                    };
                    _userService.UpdateEmployee(request);
                    MessageBox.Show("Cập nhật thành công!");
                }

                pnlInputSide.Visible = false;
                LoadUserData();
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
                MessageBox.Show("Vui lòng chọn một nhân viên trong danh sách!");
                return;
            }
            var selectedUser = (ReadUserDTO)dgvUsers.SelectedRows[0].DataBoundItem;

            bool newStatus = !(bool)selectedUser.IsActive;
            string actionText = newStatus ? "MỞ KHÓA" : "KHÓA";
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn {actionText} tài khoản '{selectedUser.Username}'?",
                "Xác nhận thay đổi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _userService.ToggleUserStatus(selectedUser.UserID, newStatus);

                    MessageBox.Show($"Đã {actionText} nhân viên thành công!");

                    LoadUserData();
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
                MessageBox.Show("Vui lòng chọn nhân viên cần reset mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedUser = (ReadUserDTO)dgvUsers.SelectedRows[0].DataBoundItem;

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn đưa mật khẩu của tài khoản '{selectedUser.Username}' về mặc định (123456)?",
                "Xác nhận Reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _userService.ResetUserPassword(selectedUser.UserID, "123456");

                    MessageBox.Show($"Reset mật khẩu thành công!\nNhân viên {selectedUser.Username} có thể đăng nhập bằng mật khẩu: 123456",
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
                LoadUserData();
            }
            else
            {
                var data = _userService.GetAllEmployees();
                if (data == null) return;
                var filteredList = data.Where(u => u.Username.ToLower().Contains(keyword)).ToList();
                dgvUsers.DataSource = filteredList;
            }
        }
        private string ValidateInputs(bool isAddMode)
        {
            var sb = new System.Text.StringBuilder();
            string fullName = txtFullName.Text.Trim();
            if (string.IsNullOrEmpty(fullName))
                sb.AppendLine("• Họ và tên không được để trống.");
            else if (fullName.Length < 2 || fullName.Length > 100)
                sb.AppendLine("• Họ và tên phải từ 2 đến 100 ký tự.");

            string email = txtEmail.Text.Trim();
            if (!string.IsNullOrEmpty(email))
            {
                var emailRegex = new System.Text.RegularExpressions.Regex(
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                if (!emailRegex.IsMatch(email))
                    sb.AppendLine("• Email không đúng định dạng (vd: abc@gmail.com).");
            }

            string phone = txtPhone.Text.Trim();
            if (!string.IsNullOrEmpty(phone))
            {
                var phoneRegex = new System.Text.RegularExpressions.Regex(
                    @"^(0[3|5|7|8|9])[0-9]{8}$");
                if (!phoneRegex.IsMatch(phone))
                    sb.AppendLine("• Số điện thoại không đúng định dạng.\n  (Phải là 10 số, bắt đầu bằng 03x/05x/07x/08x/09x)");
            }

            if (isAddMode)
            {
                string username = txtUsername.Text.Trim();
                if (string.IsNullOrEmpty(username))
                    sb.AppendLine("• Tên đăng nhập không được để trống.");
                else if (username.Length < 4 || username.Length > 50)
                    sb.AppendLine("• Tên đăng nhập phải từ 4 đến 50 ký tự.");
                else if (!System.Text.RegularExpressions.Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"))
                    sb.AppendLine("• Tên đăng nhập chỉ được chứa chữ cái, số và dấu gạch dưới.");

                string password = txtPassword.Text;
                if (string.IsNullOrEmpty(password))
                    sb.AppendLine("• Mật khẩu không được để trống.");
                else if (password.Length < 6)
                    sb.AppendLine("• Mật khẩu phải có ít nhất 6 ký tự.");
            }

            return sb.ToString();
        }
    }
}