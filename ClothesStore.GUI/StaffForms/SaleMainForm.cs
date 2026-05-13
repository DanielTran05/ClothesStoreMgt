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
            ucOrderManagement ucOrder = new ucOrderManagement();

            // 2. Thiết lập hiển thị tràn đầy vùng pnlMain
            ucOrder.Dock = DockStyle.Fill;

            // 3. Xóa các Control cũ đang hiển thị trong pnlMain
            this.Controls.Clear();

            // 4. Thêm UserControl vào Form hiện tại
            this.Controls.Add(ucOrder);
            ucOrder.BringToFront();
        }
    }
}
