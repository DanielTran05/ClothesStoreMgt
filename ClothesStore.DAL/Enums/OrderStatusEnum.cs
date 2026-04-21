using System;
using System.Collections.Generic;
using System.Text;

namespace ClothesStore.DAL.Enums
{
    public enum OrderStatusEnum
    {
        Pending = 1,       // cho thanh toan
        Paid = 2,          // da thanh toan
        Shipping = 3,      // dang giao
        Completed = 4,     // thanh cong
        Canceled = 5,      // da huy
        Returned = 6       // tra hang
    }
}
