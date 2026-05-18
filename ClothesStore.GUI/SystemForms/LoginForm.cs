using ClothesStore.BUS;
using ClothesStore.DAL.Enums;
using ClothesStore.DTO.UserDto;
using ClothesStore.GUI.StaffForms;
using ClothesStore.GUI.SystemForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClothesStore.GUI
{
    public partial class LoginForm : Form
    {
        AuthService AuthService;

        public LoginForm()
        {
            InitializeComponent();
            AuthService = new AuthService();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            UserLoginRequest userLoginRequest = new UserLoginRequest
            {
                Username = username,
                Password = pass
            };

            try
            {
                var userInDb = AuthService.getUserByUsername(username); 

                if (userInDb == null)
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (userInDb.IsActive == false)
                {
                    MessageBox.Show("Tài khoản của bạn đã bị khóa. Vui lòng liên hệ Admin!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var loggedInUser = AuthService.logIn(userLoginRequest);

                if (loggedInUser != null)
                {
                    this.Hide();
                    GlobalSession.CurrentUser = loggedInUser;
                    UserRole role = (UserRole)loggedInUser.Role;

                    switch (role)
                    {
                        case UserRole.Admin:
                            new AdminMainForm().ShowDialog();
                            break;
                        case UserRole.SaleStaff:
                            new SaleMainForm().ShowDialog();
                            break;
                        case UserRole.WarehouseStaff:
                            new WarehouseMainForm().ShowDialog();
                            break;
                        default:
                            MessageBox.Show("Vai trò không hợp lệ!");
                            this.Show();
                            return;
                    }
                    if (GlobalSession.CurrentUser == null)
                    {
                        txtPassword.Clear();
                        this.Show();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối hệ thống: " + ex.Message);
            }
        }
        private void llbChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePasswordForm changePassForm = new ChangePasswordForm();
            changePassForm.ShowDialog();
        }
    }
}
