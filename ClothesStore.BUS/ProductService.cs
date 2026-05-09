using System;
using System.Collections.Generic;
using System.Data;
using ClothesStore.DAL.Repository;
using ClothesStore.DTO;
using ClothesStore.DTO.ProductDto;

namespace ClothesStore.BUS
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public DataTable SearchProductForStaff(string keyword)
        {
            return _productRepository.SearchStaff(keyword);
        }

        public List<ProductDTO> GetAllProducts()
            => _productRepository.GetAllProducts();

        public void CreateProduct(ProductDTO product)
        {
            if (string.IsNullOrWhiteSpace(product.ProductName))
                throw new Exception("Tên sản phẩm không được để trống!");

            if (product.CategoryID <= 0)
                throw new Exception("Vui lòng chọn Loại sản phẩm cho áo/quần này!");

            product.ProductName = product.ProductName.Trim();

            _productRepository.CreateProduct(product);
        }

        public void UpdateProduct(ProductDTO product)
        {
            if (string.IsNullOrWhiteSpace(product.ProductName))
                throw new Exception("Tên sản phẩm không được để trống!");

            if (product.CategoryID <= 0)
                throw new Exception("Vui lòng chọn Loại sản phẩm!");

            product.ProductName = product.ProductName.Trim();

            _productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(int id)
            => _productRepository.DeleteProduct(id);
    }
}