using System;
using System.Collections.Generic;

namespace ClothesStore.DAL.Models;

public partial class WarehouseReceipt
{
    public int ReceiptId { get; set; }

    public int? SupplierId { get; set; }

    public Guid? EmployeeId { get; set; }

    public DateTime? ImportDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public int? Status { get; set; }

    public virtual User? Employee { get; set; }

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();

    public virtual Supplier? Supplier { get; set; }

    public virtual ICollection<WarehouseReceiptDetail> WarehouseReceiptDetails { get; set; } = new List<WarehouseReceiptDetail>();
}
