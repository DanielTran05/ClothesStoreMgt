using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClothesStore.DAL.Models;

public partial class InventoryTransaction
{
    [Key]
    public int TransactionId { get; set; }

    public int VariantId { get; set; }

    public string TransactionType { get; set; } = null!;

    public int QuantityChange { get; set; }

    public int? OrderId { get; set; }

    public int? ReceiptId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Order? Order { get; set; }

    public virtual WarehouseReceipt? Receipt { get; set; }

    public virtual ProductVariant Variant { get; set; } = null!;
}
