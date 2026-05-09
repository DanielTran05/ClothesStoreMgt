using System;
using System.Collections.Generic;
using System.Text;

namespace ClothesStore.DTO.ProductDto
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
    }
}
