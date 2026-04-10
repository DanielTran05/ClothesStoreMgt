using System;
using System.Collections.Generic;
using System.Text;

namespace ClothesStore.DAL.Enums
{
    public enum OrderStatusEnum
    {
        Pending = 0,    // Vua tao don, khach quet QR
        Paid = 1,       // Reponse momo thanh cong, alter ve trang thai nay
        Shipping = 2,   // Giao cho dvvc
        Completed = 3,  // Giao hang thanh cong
        Canceled = 4    // Huy hoac thanh toan Momo that bai
    }
}
