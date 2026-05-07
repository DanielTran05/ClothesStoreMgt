using System.Data;
using ClothesStore.DAL.Repository;

namespace ClothesStore.BUS
{
    public class WarehouseService
    {
        private WarehouseRepository repo = new WarehouseRepository();

        public int CreateReceipt(int supplierId, Guid employeeId)
            => repo.CreateReceipt(supplierId, employeeId);

        public void AddReceiptDetail(int receiptId, int variantId, int qty, decimal price)
            => repo.AddReceiptDetail(receiptId, variantId, qty, price);

        public DataTable GetInventory()
            => repo.GetInventory();

        public decimal GetTodaySales()
            => repo.GetTodaySales();
    }
}