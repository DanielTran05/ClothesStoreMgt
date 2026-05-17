using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClothesStore.GUI.StaffForms
{
    public partial class SaleMainForm : BaseForm
    {
        public SaleMainForm()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            base.HandleLogout();
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            new ProductSearchForm().ShowDialog();
        }

        private void btnCustomerService_Click(object sender, EventArgs e)
        {
            new CustomerServiceForm().ShowDialog();
        }

        private void btnSaleManagament_Click(object sender, EventArgs e)
        {
            ucOrderManagement ucOrder = new ucOrderManagement(this);

            ucOrder.Dock = DockStyle.Fill;

            this.Controls.Add(ucOrder);

            ucOrder.BringToFront();
        }
    }
}
