using ClothesStore.DAL;
using System;
using System.Windows.Forms;
using System.Configuration;
using ClothesStore.BUS;
using ClothesStore.DTO;

namespace ClothesStore.GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            CategoryBUS bus = new CategoryBUS(connString);

            CateDTO newCategory = new CateDTO
            {
                CateName = txtCategoryName.Text,
                Description = txtCategoryDesc.Text
            };

            bool isSuccess = bus.AddNewCategory(newCategory);

            if (isSuccess)
            {
                MessageBox.Show("Đã thêm danh mục mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCategoryName.Clear();
                txtCategoryDesc.Clear();
            }
            else
            {
                MessageBox.Show("Thêm thất bại! Vui lòng nhập Tên danh mục.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
