using ClothesStore.BUS;
using ClothesStore.DTO.UserDto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClothesStore.GUI.SystemForms
{
    public partial class ChangePasswordForm : Form
    {
        private readonly UserService _userService;
        private readonly AuthService _authService;
        public ChangePasswordForm()
        {
            InitializeComponent();

            _authService = new AuthService();
            _userService = new UserService();

            txtPassword.UseSystemPasswordChar = true;
            txtNewPassword.UseSystemPasswordChar = true;
            txtRewriteNewPassword.UseSystemPasswordChar = true;
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string oldPass = txtPassword.Text.Trim();
            string newPass = txtNewPassword.Text.Trim();
            string rewritePass = txtRewriteNewPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(oldPass) ||
                string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(rewritePass))
            {
                MessageBox.Show("Vui lòng điền đầy đủ tất cả các trường!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass != rewritePass)
            {
                MessageBox.Show("Mật khẩu mới và Nhập lại mật khẩu không khớp nhau!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                UserLoginRequest loginReq = new UserLoginRequest
                {
                    Username = username,
                    Password = oldPass
                };

                var validUser = _authService.logIn(loginReq);

                if (validUser != null)
                {
                    _userService.ResetUserPassword(validUser.UserId, newPass);

                    MessageBox.Show("Đổi mật khẩu thành công! Hãy sử dụng mật khẩu mới cho lần đăng nhập tiếp theo.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sai Tên đăng nhập hoặc Mật khẩu cũ! Vui lòng kiểm tra lại.", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
