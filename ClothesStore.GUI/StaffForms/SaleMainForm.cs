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
    }
}
