using System;
using System.Collections.Generic;

namespace ClothesStore.DAL.Models;

public partial class WarehouseReceiptDetail
{
    public int ReceiptDetailId { get; set; }

    public int? ReceiptId { get; set; }

    public int? VariantId { get; set; }

    public int Quantity { get; set; }

    public decimal ImportPrice { get; set; }

    public virtual WarehouseReceipt? Receipt { get; set; }

    public virtual ProductVariant? Variant { get; set; }
}
