using System;
using System.Collections.Generic;
using System.Text;

namespace ClothesStore.DAL.Enums
{
    public enum WarehouseReceiptStatus
    {
        Draft = 0,      // Dang tao phieu, chua cap nhap so luong hang
        Completed = 1,  // Hoan tat -> kich hoat trigger/logic cap nhat AmountInStock
        Canceled = 2    // Huy phieu nhap hang
    }
}
