using System;
using System.Collections.Generic;

namespace ClothesStore.DAL.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public Guid? CustomerId { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? OrderStatus { get; set; }

    public string? ShippingAddress { get; set; }

    public string? ReceiverName { get; set; }

    public string? ReceiverPhone { get; set; }

    public decimal? TotalMoney { get; set; }

    public int? ShippingProviderId { get; set; }

    public virtual User? Customer { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ShippingProvider? ShippingProvider { get; set; }
}
