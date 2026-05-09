using ClothesStore.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClothesStore.GUI.StaffForms
{
    public partial class WarehouseMainForm : BaseForm
    {

        public WarehouseMainForm()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            base.HandleLogout();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            new ImportForm().ShowDialog();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            new SupplierForm().ShowDialog();

        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            new InventoryForm().ShowDialog();
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            new StatisticForm().Show();
        }
    }
}
