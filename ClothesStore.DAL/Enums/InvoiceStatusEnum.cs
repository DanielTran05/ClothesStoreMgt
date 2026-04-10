using System;
using System.Collections.Generic;
using System.Text;

namespace ClothesStore.DAL.Enums
{
    public enum InvoiceStatusEnum
    {
        Unpaid = 0,
        Paid = 1,
        Refunded = 2,
        Failed = 3
    }
}
