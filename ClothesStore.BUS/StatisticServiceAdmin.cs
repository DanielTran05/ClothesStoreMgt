using ClothesStore.DAL.Repository;
using ClothesStore.DTO.StatisticDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClothesStore.BUS
{
    public class StatisticServiceAdmin
    {
        private readonly StatisticRepositoryAdmin _repo = new StatisticRepositoryAdmin();

        public async Task<List<RevenueProfitDTO>> GetRevenueProfit(DateTime from, DateTime to) => await _repo.GetRevenueProfit(from, to);
        public async Task<List<CategoryDTO>> GetProductCountByCategory(DateTime from, DateTime to) => await _repo.GetProductCountByCategory(from, to);
        public async Task<List<ProductDTO>> GetTop5Products(DateTime from, DateTime to, bool isBestSeller) => await _repo.GetTop5Products(from, to, isBestSeller);
        public async Task<List<OrderStatusDTO>> GetOrderStatus(DateTime from, DateTime to) => await _repo.GetOrderStatus(from, to);
        public async Task<List<EmployeeDTO>> GetTopEmployees(DateTime from, DateTime to) => await _repo.GetTopEmployees(from, to);
        public async Task<List<SupplierDTO>> GetTopSuppliers() => await _repo.GetTopSuppliers();
        public async Task<List<LowStockDTO>> GetLowStockProducts(int threshold = 10) => await _repo.GetLowStockProducts(threshold);
    }
}