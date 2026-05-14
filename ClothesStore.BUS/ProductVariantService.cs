using ClothesStore.DAL.Repository;
using ClothesStore.DTO;
using ClothesStore.DTO.ProductDto;
using System;
using System.Collections.Generic;

namespace ClothesStore.BUS
{
    public class ProductVariantService
    {
        private readonly ProductVariantRepository _variantRepository;


        public ProductVariantService()
        {
            _variantRepository = new ProductVariantRepository();
        }

        public List<ProductVariantDTO> GetVariantsByProductID(int productId)
        {
            return _variantRepository.GetVariantsByProductID(productId);
        }

        public void CreateVariant(ProductVariantDTO variant)
        {
            ValidateVariant(variant);
            _variantRepository.CreateVariant(variant);
        }

        public void UpdateVariant(ProductVariantDTO variant)
        {
            ValidateVariant(variant);
            _variantRepository.UpdateVariant(variant);
        }

        public void DeleteVariant(int id) => _variantRepository.DeleteVariant(id);

        private void ValidateVariant(ProductVariantDTO variant)
        {
            if (variant.ColorID <= 0)
                throw new Exception("Vui lòng chọn Màu sắc cho biến thể!");

            if (variant.SizeID <= 0)
                throw new Exception("Vui lòng chọn Kích cỡ cho biến thể!");

            if (variant.Price < 0)
                throw new Exception("Giá bán không được là số âm!");

            if (!string.IsNullOrWhiteSpace(variant.SKU))
                variant.SKU = variant.SKU.Trim();
        }
        public List<(string ProductName, decimal Price, int VariantID)> GetAllVariantsForGrid()
        {
            return _variantRepository.GetVariantDetailsForGrid();
        }
        public dynamic GetVariantById(int variantId)
        {
            return _variantRepository.GetVariantById(variantId);
        }
        public ProductVariantDTO GetVariantBySKU(string sku)
        {
            if (string.IsNullOrWhiteSpace(sku)) return null;
            return _variantRepository.GetVariantBySKU(sku);
        }
    }
}