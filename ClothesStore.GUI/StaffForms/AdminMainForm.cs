using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClothesStore.GUI
{
    public partial class AdminMainForm : BaseForm
    {
        public AdminMainForm()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            base.HandleLogout();
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            ucUserManagement uc = new ucUserManagement();
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btnQuanLyDanhMuc_Click(object sender, EventArgs e)
        {
            ucCategoryManagement ucCategory = new ucCategoryManagement();
            ucCategory.Dock = DockStyle.Fill;

            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(ucCategory);
            ucCategory.BringToFront();
        }

        private void btnQuanLySanPham_Click(object sender, EventArgs e)
        {
            ucProductManagement ucProduct = new ucProductManagement();
            ucProduct.Dock = DockStyle.Fill;

            pnlMain.Controls.Clear();

            pnlMain.Controls.Add(ucProduct);

            ucProduct.BringToFront();
        }

        private void btnCustomerManagement_Click(object sender, EventArgs e)
        {
            ucCustomerManagement ucCustomer = new ucCustomerManagement();
            ucCustomer.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(ucCustomer);
            ucCustomer.BringToFront();
        }
    }
}
