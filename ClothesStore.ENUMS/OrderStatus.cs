using System;
using System.Collections.Generic;
using System.Text;

namespace ClothesStore.ENUMS
{
    public enum OrderStatus
    {
         Pending = 1,       // cho thanh toan
         Paid = 2,          // da thanh toan
         Shipping = 3,      // dang giao
         Completed = 4,     // thanh cong
         Canceled = 5,      // da huy
         Returned = 6       // tra hang
    }

    public enum WarehouseStatus
    {
         Draft = 1,     // ban nhap
         Completed = 2, // da nhap kho
         Canceled = 3   // huy phieu
    }

    public enum UserRole
    {
        Admin = 1,
        SaleStaff = 2,
        WarehouseStaff = 3,
        Customer = 4,
        Guess = 5
    }

    public enum UserStatus
    {
        active = 1,
        ban = 0
    }
}
