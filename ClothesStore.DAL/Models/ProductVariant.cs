using System;
using System.Collections.Generic;

namespace ClothesStore.DAL.Models;

public partial class ProductVariant
{
    public int VariantId { get; set; }

    public int? ProductId { get; set; }

    public int? ColorId { get; set; }

    public int? SizeId { get; set; }

    public string? Sku { get; set; }

    public decimal Price { get; set; }

    public int? AmountInStock { get; set; }

    public string? Img { get; set; }

    public virtual Color? Color { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Product? Product { get; set; }

    public virtual Size? Size { get; set; }

    public virtual ICollection<WarehouseReceiptDetail> WarehouseReceiptDetails { get; set; } = new List<WarehouseReceiptDetail>();
}
