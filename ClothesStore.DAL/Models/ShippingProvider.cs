using System;
using System.Collections.Generic;

namespace ClothesStore.DAL.Models;

public partial class ShippingProvider
{
    public int ShippingProviderId { get; set; }

    public string Name { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
