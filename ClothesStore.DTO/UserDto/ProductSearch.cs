using System;
using System.Collections.Generic;
using System.Text;

namespace ClothesStore.DTO.UserDto
{
    public class ProductSearch
    {
        public string ProductName { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public int AmountInStock { get; set; }
        public string Status { get; set; }
    }
}
