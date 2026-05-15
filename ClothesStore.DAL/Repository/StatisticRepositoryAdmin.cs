using Microsoft.Data.SqlClient;
using System.Data;
using Helper;
using ClothesStore.DTO.StatisticDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClothesStore.DAL.Repository
{
    public class StatisticRepositoryAdmin
    {
        public async Task<List<RevenueProfitDTO>> GetRevenueProfit(DateTime from, DateTime to)
        {
            var list = new List<RevenueProfitDTO>();
            using var conn = DbHelper.GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand("GetRevenueAndProfit", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@FromDate", from);
            cmd.Parameters.AddWithValue("@ToDate", to);

            using var dr = await cmd.ExecuteReaderAsync();
            while (await dr.ReadAsync())
            {
                list.Add(new RevenueProfitDTO
                {
                    Month = dr["Month"] != DBNull.Value ? Convert.ToInt32(dr["Month"]) : 0,
                    Year = dr["Year"] != DBNull.Value ? Convert.ToInt32(dr["Year"]) : 0,
                    Revenue = dr["Revenue"] != DBNull.Value ? Convert.ToDecimal(dr["Revenue"]) : 0,
                    Profit = dr["Profit"] != DBNull.Value ? Convert.ToDecimal(dr["Profit"]) : 0
                });
            }
            return list;
        }

        public async Task<List<CategoryDTO>> GetProductCountByCategory(DateTime from, DateTime to)
        {
            var list = new List<CategoryDTO>();
            using var conn = DbHelper.GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand("GetProductCountByCategory", conn)
            { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@FromDate", from);
            cmd.Parameters.AddWithValue("@ToDate", to);
            using var dr = await cmd.ExecuteReaderAsync();
            while (await dr.ReadAsync())
            {
                list.Add(new CategoryDTO
                {
                    CategoryName = dr["CategoryName"].ToString(),
                    TotalVariants = dr["TotalVariants"] != DBNull.Value
                        ? Convert.ToInt32(dr["TotalVariants"]) : 0
                });
            }
            return list;
        }

        public async Task<List<ProductDTO>> GetTop5Products(DateTime from, DateTime to, bool isBestSeller)
        {
            var list = new List<ProductDTO>();
            using var conn = DbHelper.GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand("GetTop5Products", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@FromDate", from);
            cmd.Parameters.AddWithValue("@ToDate", to);
            cmd.Parameters.AddWithValue("@IsBestSeller", isBestSeller);

            using var dr = await cmd.ExecuteReaderAsync();
            while (await dr.ReadAsync())
            {
                list.Add(new ProductDTO
                {
                    ProductID = dr["ProductID"] != DBNull.Value ? Convert.ToInt32(dr["ProductID"]) : 0,
                    ProductName = dr["ProductName"].ToString(),
                    TotalQty = dr["TotalQty"] != DBNull.Value ? Convert.ToInt32(dr["TotalQty"]) : 0
                });
            }
            return list;
        }

        public async Task<List<OrderStatusDTO>> GetOrderStatus(DateTime from, DateTime to)
        {
            var list = new List<OrderStatusDTO>();
            using var conn = DbHelper.GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand("GetOrderStatus", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@FromDate", from);
            cmd.Parameters.AddWithValue("@ToDate", to);

            using var dr = await cmd.ExecuteReaderAsync();
            while (await dr.ReadAsync())
            {
                list.Add(new OrderStatusDTO
                {
                    StatusName = dr["StatusName"].ToString(),
                    OrderCount = dr["OrderCount"] != DBNull.Value ? Convert.ToInt32(dr["OrderCount"]) : 0
                });
            }
            return list;
        }

        public async Task<List<EmployeeDTO>> GetTopEmployees(DateTime from, DateTime to)
        {
            var list = new List<EmployeeDTO>();
            using var conn = DbHelper.GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand("GetTopEmployees", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@FromDate", from);
            cmd.Parameters.AddWithValue("@ToDate", to);

            using var dr = await cmd.ExecuteReaderAsync();
            while (await dr.ReadAsync())
            {
                list.Add(new EmployeeDTO
                {
                    EmployeeID = dr["UserID"] != DBNull.Value ? (Guid)dr["UserID"] : Guid.Empty,
                    FullName = dr["FullName"].ToString(),
                    OrderCount = dr["OrderCount"] != DBNull.Value ? Convert.ToInt32(dr["OrderCount"]) : 0
                });
            }
            return list;
        }

        public async Task<List<SupplierDTO>> GetTopSuppliers()
        {
            var list = new List<SupplierDTO>();
            using var conn = DbHelper.GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand("GetTopSuppliers", conn) { CommandType = CommandType.StoredProcedure };

            using var dr = await cmd.ExecuteReaderAsync();
            while (await dr.ReadAsync())
            {
                list.Add(new SupplierDTO
                {
                    SupplierID = dr["SupplierID"] != DBNull.Value ? Convert.ToInt32(dr["SupplierID"]) : 0,
                    SupplierName = dr["SupplierName"].ToString(),
                    ImportCount = dr["ImportCount"] != DBNull.Value ? Convert.ToInt32(dr["ImportCount"]) : 0
                });
            }
            return list;
        }

        public async Task<List<LowStockDTO>> GetLowStockProducts(int threshold)
        {
            var list = new List<LowStockDTO>();
            using var conn = DbHelper.GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand("GetLowStockProducts", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Threshold", threshold);

            using var dr = await cmd.ExecuteReaderAsync();
            while (await dr.ReadAsync())
            {
                list.Add(new LowStockDTO
                {
                    VariantID = dr["VariantID"] != DBNull.Value ? Convert.ToInt32(dr["VariantID"]) : 0,
                    ProductName = dr["ProductName"].ToString(),
                    SKU = dr["SKU"].ToString(),
                    AmountInStock = dr["AmountInStock"] != DBNull.Value ? Convert.ToInt32(dr["AmountInStock"]) : 0
                });
            }
            return list;
        }
    }
}