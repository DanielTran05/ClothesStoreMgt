using System.Data;
using ClothesStore.DAL.Repository;

namespace ClothesStore.BUS
{
    public class WarehouseService
    {
        private WarehouseRepository repo =
            new WarehouseRepository();

        public int CreateReceipt(
            int supplierId,
            Guid employeeId)
        {
            return repo.CreateReceipt(
                supplierId,
                employeeId);
        }

        public void AddReceiptDetail(
            int receiptId,
            int variantId,
            int qty,
            decimal price)
        {
            repo.AddReceiptDetail(
                receiptId,
                variantId,
                qty,
                price);
        }

        public DataTable GetInventory()
        {
            return repo.GetInventory();
        }

        public decimal GetTodaySales()
        {
            return repo.GetTodaySales();
        }

        public DataTable GetTodayStatistic()
        {
            return repo.GetTodayStatistic();
        }

        public void AddInventoryTransaction(
            int variantId,
            string transactionType,
            int quantityChange,
            int receiptId)
        {
            repo.AddInventoryTransaction(
                variantId,
                transactionType,
                quantityChange,
                receiptId);
        }
        public DataTable GetImportHistory(string filterType)
        {
            return repo.GetImportHistory(
                filterType);
        }
    }
}