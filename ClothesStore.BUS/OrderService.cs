using ClothesStore.DAL.Models;
using ClothesStore.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClothesStore.BUS
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepo = new OrderRepository();

        public List<object> GetOrders()
        {
            return _orderRepo.GetAllOrders();
        }

        public List<object> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return _orderRepo.GetAllOrders();
            }
            return _orderRepo.SearchOrders(keyword);
        }

        public string CreateOrder(Order order, string paymentMethod)
        {
            if (string.IsNullOrWhiteSpace(paymentMethod)) return "Vui lòng chọn phương thức thanh toán!";

            bool success = _orderRepo.AddOrderWithInvoice(order, paymentMethod);

            return success ? "Thêm thành công!" : "Lỗi hệ thống!";
        }

        public string UpdateOrder(Order order, string paymentMethod)
        {
            if (order.OrderId <= 0) return "Mã đơn hàng không hợp lệ!";

            bool result = _orderRepo.UpdateOrderAndInvoice(order, paymentMethod);

            return result ? "Cập nhật đơn hàng thành công!" : "Cập nhật thất bại!";
        }

        public string RemoveOrder(int id)
        {
            bool result = _orderRepo.Delete(id);
            if (result)
                return "Xóa đơn hàng thành công!";
            else
                return "Không thể xóa đơn hàng này (Đơn hàng không tồn tại hoặc đã có dữ liệu liên quan)!";
        }
        public List<object> GetOrdersFiltered(DateTime from, DateTime to, int? status, string key)
        {
            return _orderRepo.GetOrdersFiltered(from, to, status, key);
        }
        public bool ConfirmOrder(Order order, string paymentMethod)
        {
            Invoice invoice = new Invoice
            {
                Amount = order.TotalMoney ?? 0,
                PaymentDate = DateTime.Now,
                PaymentMethod = paymentMethod,
                Status = 2 
            };

            return _orderRepo.CreateFullOrder(order, invoice);
        }
        public Order GetOrderById(int orderId)
        {
            return _orderRepo.GetOrderById(orderId);
        }
        public bool UpdateFullOrder(Order order, string paymentMethod)
        {
            return _orderRepo.UpdateFullOrder(order, paymentMethod);
        }
    }
}
