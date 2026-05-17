using System;
using System.Collections.Generic;
using System.Text;

namespace ClothesStore.DAL.Enums
{
    public enum InvoiceStatus
    {
        Pending = 1,        // cho thanh toan
        Paid = 2,           // da thanh toan
        Cancelled = 3,      // hoa don bi huy, them nut huy don
    }
}
