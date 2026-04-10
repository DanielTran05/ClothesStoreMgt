using ClothesStore.DAL.Models;
using ClothesStore.DAL.Context;
using ClothesStore.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClothesStore.DAL
{
    public class CategoryDAL
    {
        private readonly string _connectionString;

        public CategoryDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool AddCategory(CateDTO categoryDto)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<ClothesStoreContext>();
                optionsBuilder.UseSqlServer(_connectionString);

                using (var context = new ClothesStoreContext(optionsBuilder.Options))
                {
                    // DTO → entity cua EF
                    var newCategory = new Category
                    {
                        CategoryName = categoryDto.CateName,
                        Description = categoryDto.Description
                    };

                    context.Categories.Add(newCategory);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
