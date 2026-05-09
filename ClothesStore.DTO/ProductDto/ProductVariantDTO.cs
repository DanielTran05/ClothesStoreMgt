using System;
using System.Collections.Generic;
using System.Text;

namespace ClothesStore.DTO.ProductDto
{
    public class ProductVariantDTO
    {
        public int VariantID { get; set; }
        public int ProductID { get; set; }
        public int ColorID { get; set; }
        public int SizeID { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public int AmountInStock { get; set; }
        public string Img { get; set; }

        public string ColorName { get; set; }
        public string SizeName { get; set; }
    }
}
