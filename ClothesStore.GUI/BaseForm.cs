using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClothesStore.GUI
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }
        protected void HandleLogout()
        {
            var result = MessageBox.Show("Are you sure to logout", "Confirm",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                GlobalSession.Clear();

                this.Hide();

                LoginForm login = new LoginForm();
                login.Show();

                this.Close();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           Application.Exit();
        }
    }
}
