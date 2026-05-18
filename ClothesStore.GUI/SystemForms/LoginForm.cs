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
                MessageBox.Show("Please fill all fields!");
                return;
            }

            UserLoginRequest userLoginRequest = new UserLoginRequest();
            userLoginRequest.Username = username;
            userLoginRequest.Password = pass;

            try
            {
                var loggedInUser = AuthService.logIn(userLoginRequest);

                GlobalSession.CurrentUser = loggedInUser;

                if (loggedInUser != null)
                {
                    if (loggedInUser.IsActive == false)
                    {
                        MessageBox.Show("Your account has been baned, pls contact with admin");
                        return;
                    }

                    this.Hide();

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
                            MessageBox.Show("Invalid role!");
                            this.Show();
                            break;
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
                    MessageBox.Show("Incorrect username and password!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("System connection error: " + ex.Message);
            }
        }

        private void llbChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePasswordForm changePassForm = new ChangePasswordForm();
            changePassForm.ShowDialog();
        }
    }
}
