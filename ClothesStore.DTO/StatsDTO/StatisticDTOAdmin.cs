using System;
using System.Collections.Generic;
using System.Text;

namespace ClothesStore.DTO.StatisticDTO
{

    public class RevenueProfitDTO
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Revenue { get; set; }
        public decimal Profit { get; set; }
    }

    public class CategoryDTO
    {
        public int? CategoryID { get; set; } 
        public string CategoryName { get; set; }
        public int TotalVariants { get; set; }
    }

    public class ProductDTO
    {
        public int? ProductID { get; set; } 
        public string ProductName { get; set; }
        public int TotalQty { get; set; }
    }

    public class OrderStatusDTO
    {
        public string StatusName { get; set; }
        public int OrderCount { get; set; }
    }

    public class EmployeeDTO
    {
        public Guid? EmployeeID { get; set; } 
        public string FullName { get; set; }
        public int OrderCount { get; set; }
    }

    public class SupplierDTO
    {
        public int? SupplierID { get; set; } 
        public string SupplierName { get; set; }
        public int ImportCount { get; set; }
    }

    public class LowStockDTO
    {
        public int? VariantID { get; set; } 
        public string ProductName { get; set; }
        public string SKU { get; set; }
        public int AmountInStock { get; set; }
    }
}
