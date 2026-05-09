using ClothesStore.BUS;
using System;
using System.Windows.Forms;

namespace ClothesStore.GUI.StaffForms
{
    public partial class StatisticForm : Form
    {
        private WarehouseService service = new WarehouseService();

        public StatisticForm()
        {
            InitializeComponent();
            LoadTodaySales();
        }

        private void LoadTodaySales()
        {
            lblTotal.Text = service.GetTodaySales().ToString();
        }
    }
}