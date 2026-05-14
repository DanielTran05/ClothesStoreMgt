using ClothesStore.DAL.Context;
using Helper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ClothesStore.DAL.Repository
{
    public class WarehouseRepository
    {
        private readonly ClothesStoreContext _context = new ClothesStoreContext();

        public int CreateReceipt(int supplierId, Guid employeeId)
        {
            using var conn = DbHelper.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_CreateReceipt", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SupplierId", supplierId);
            cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void AddReceiptDetail(int receiptId, int variantId, int qty, decimal price)
        {
            using var conn = DbHelper.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_AddReceiptDetail", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ReceiptId", receiptId);
            cmd.Parameters.AddWithValue("@VariantId", variantId);
            cmd.Parameters.AddWithValue("@Quantity", qty);
            cmd.Parameters.AddWithValue("@Price", price);

            cmd.ExecuteNonQuery();
        }

        public DataTable GetInventory()
        {
            using var conn = DbHelper.GetConnection();

            SqlDataAdapter da = new SqlDataAdapter("sp_GetInventory", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public decimal GetTodaySales()
        {
            using var conn = DbHelper.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_TodaySales", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            var result = cmd.ExecuteScalar();
            return result == DBNull.Value ? 0 : Convert.ToDecimal(result);
        }

        public void AddInventoryTransaction(int variantId, string transactionType, int quantityChange, int receiptId)
        {
            using var conn = DbHelper.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand(
                "sp_AddInventoryTransaction",
                conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@VariantID", variantId);
            cmd.Parameters.AddWithValue("@TransactionType", transactionType);
            cmd.Parameters.AddWithValue("@QuantityChange", quantityChange);
            cmd.Parameters.AddWithValue("@ReceiptID", receiptId);

            cmd.ExecuteNonQuery();
        }

        public DataTable GetTodayStatistic()
        {
            using var conn = DbHelper.GetConnection();

            SqlDataAdapter da =
                new SqlDataAdapter("sp_TodayStatistic", conn);

            da.SelectCommand.CommandType =
                CommandType.StoredProcedure;

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }

        public bool UpdateWarehouseStock(int variantId, int quantitySold)
        {
            try
            {
                var stockDetail = _context.WarehouseReceiptDetails
                                          .FirstOrDefault(wd => wd.VariantId == variantId);

                if (stockDetail != null)
                {
                    stockDetail.Quantity -= quantitySold;

                    return _context.SaveChanges() > 0;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}