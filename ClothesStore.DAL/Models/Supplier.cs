using System;
using System.Collections.Generic;

namespace ClothesStore.DAL.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public virtual ICollection<WarehouseReceipt> WarehouseReceipts { get; set; } = new List<WarehouseReceipt>();
}
