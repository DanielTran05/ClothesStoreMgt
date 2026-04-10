using System;
using System.Collections.Generic;

namespace ClothesStore.DAL.Models;

public partial class User
{
    public Guid UserId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public int Role { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<CustomerService> CustomerServiceCustomers { get; set; } = new List<CustomerService>();

    public virtual ICollection<CustomerService> CustomerServiceEmployees { get; set; } = new List<CustomerService>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<WarehouseReceipt> WarehouseReceipts { get; set; } = new List<WarehouseReceipt>();
}
