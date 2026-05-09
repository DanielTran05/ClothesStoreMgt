using ClothesStore.DAL.Repository;
using ClothesStore.DTO;
using ClothesStore.DTO.MasterDataDto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClothesStore.BUS
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryService()
        {
            _categoryRepository = new CategoryRepository();
        }

        public List<CategoryDTO> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public void CreateCategory(CategoryDTO category)
        {
            if (string.IsNullOrWhiteSpace(category.CategoryName))
            {
                throw new Exception("Tên danh mục không được để trống!");
            }

            category.CategoryName = category.CategoryName.Trim();
            if (!string.IsNullOrWhiteSpace(category.Description))
            {
                category.Description = category.Description.Trim();
            }

            var isExist = _categoryRepository.GetAllCategories()
                .Any(c => c.CategoryName.Equals(category.CategoryName, StringComparison.OrdinalIgnoreCase));

            if (isExist)
            {
                throw new Exception($"Danh mục mang tên '{category.CategoryName}' đã tồn tại trong hệ thống!");
            }

            _categoryRepository.CreateCategory(category);
        }

        public void UpdateCategory(CategoryDTO category)
        {
            if (string.IsNullOrWhiteSpace(category.CategoryName))
            {
                throw new Exception("Tên danh mục không được để trống!");
            }

            category.CategoryName = category.CategoryName.Trim();
            if (!string.IsNullOrWhiteSpace(category.Description))
            {
                category.Description = category.Description.Trim();
            }

            var isExist = _categoryRepository.GetAllCategories()
                .Any(c => c.CategoryName.Equals(category.CategoryName, StringComparison.OrdinalIgnoreCase)
                       && c.CategoryID != category.CategoryID);

            if (isExist)
            {
                throw new Exception($"Danh mục mang tên '{category.CategoryName}' đã tồn tại!");
            }

            _categoryRepository.UpdateCategory(category);
        }

        public void DeleteCategory(int categoryId)
        {
            _categoryRepository.DeleteCategory(categoryId);
        }
    }
}