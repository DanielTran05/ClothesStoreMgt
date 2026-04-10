using ClothesStore.DAL;
using ClothesStore.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClothesStore.BUS
{
    public class CategoryBUS
    {
        private readonly CategoryDAL _categoryDAL;

        public CategoryBUS(string connectionString)
        {
            _categoryDAL = new CategoryDAL(connectionString);
        }

        public bool AddNewCategory(CateDTO category)
        {
            if (string.IsNullOrWhiteSpace(category.CateName))
            {
                return false;
            }

            return _categoryDAL.AddCategory(category);
        }
    }
}
