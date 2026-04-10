using System;
using System.Collections.Generic;

namespace ClothesStore.DAL.Models;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public int OrderId { get; set; }

    public decimal Amount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? PaymentMethod { get; set; }

    public string? TransactionId { get; set; }

    public int Status { get; set; }

    public virtual Order Order { get; set; } = null!;
}
