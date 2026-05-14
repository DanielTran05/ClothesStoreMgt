using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClothesStore.GUI.StaffForms
{
    public partial class SaleMainForm : Form
    {
        public SaleMainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductSearchForm search = new ProductSearchForm();
            this.Hide();
            search.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ucOrderManagement ucOrder = new ucOrderManagement(this);

            ucOrder.Dock = DockStyle.Fill;

            this.Controls.Add(ucOrder);

            ucOrder.BringToFront();
        }
    }
}
