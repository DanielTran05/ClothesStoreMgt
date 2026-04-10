using System;
using System.Collections.Generic;

namespace ClothesStore.DAL.Models;

public partial class CustomerService
{
    public int CustomerServiceId { get; set; }

    public Guid? CustomerId { get; set; }

    public string? Reason { get; set; }

    public DateTime? Date { get; set; }

    public int? Status { get; set; }

    public Guid? EmployeeId { get; set; }

    public virtual User? Customer { get; set; }

    public virtual User? Employee { get; set; }
}
