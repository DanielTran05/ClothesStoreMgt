using ClothesStore.DAL.Context;
using ClothesStore.DAL.Enums;
using ClothesStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClothesStore.DAL.Repository
{
    public class OrderRepository
    {
        private readonly ClothesStoreContext _context = new ClothesStoreContext();

        public List<object> GetAllOrders()
        {
            // Truy vấn lấy dữ liệu đơn hàng kèm thông tin liên quan
            var query = from o in _context.Orders
                        join c in _context.Users on o.CustomerId equals c.UserId into customers
                        from c in customers.DefaultIfEmpty()
                        join s in _context.ShippingProviders on o.ShippingProviderId equals s.ShippingProviderId into shippings
                        from s in shippings.DefaultIfEmpty()
                        select new
                        {
                            o.OrderId,
                            o.OrderDate,
                            o.OrderStatus,
                            o.ReceiverName,
                            o.ReceiverPhone,
                            ShippingName = s != null ? s.Name : "Chưa chọn",
                            o.TotalMoney
                        };

            return query.ToList<object>();
        }

        public List<object> SearchOrders(string keyword)
        {
            // Chuyển keyword về chữ thường để tìm kiếm không phân biệt hoa thường (tùy cấu hình DB)
            string key = keyword.ToLower();

            var query = from o in _context.Orders
                        join u in _context.Users on o.CustomerId equals u.UserId into userGroup
                        from user in userGroup.DefaultIfEmpty()
                            // Điều kiện lọc: Tìm theo Tên khách hàng HOẶC Mã đơn hàng
                        where (user != null && user.FullName.ToLower().Contains(key))
                              || o.OrderId.ToString().Contains(key)
                        select new
                        {
                            o.OrderId,
                            o.OrderDate,
                            o.OrderStatus,
                            o.TotalMoney,
                            o.ReceiverName
                        };

            return query.ToList<object>();
        }

        public bool Add(Order order)
        {
            try
            {
                // Mặc định các trường Guid sẽ là null nếu không gán
                _context.Orders.Add(order);
                return _context.SaveChanges() > 0;
            }
            catch { return false; }
        }
        public bool AddOrderWithInvoice(Order order, string paymentMethod)
        {
            // Sử dụng Transaction để đảm bảo an toàn dữ liệu
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // 1. Thêm đơn hàng trước
                    _context.Orders.Add(order);
                    _context.SaveChanges(); // Lưu để lấy được OrderId vừa tự sinh

                    // 2. Tạo Hóa đơn đi kèm với Status = 2
                    Invoice newInvoice = new Invoice
                    {
                        OrderId = order.OrderId,
                        Amount = order.TotalMoney ?? 0,
                        Status = 2, // Mặc định là 2 theo ý bạn
                        PaymentMethod = paymentMethod // Hoặc lấy từ GUI
                    };

                    _context.Invoices.Add(newInvoice);
                    _context.SaveChanges();

                    // Hoàn tất mọi thay đổi
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    // Nếu có lỗi, hủy bỏ toàn bộ quá trình (không tạo order, không tạo invoice)
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool UpdateOrderAndInvoice(Order order, string paymentMethod)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // 1. Tìm và cập nhật Order
                    var dbOrder = _context.Orders.Find(order.OrderId);
                    if (dbOrder == null) return false;

                    dbOrder.ReceiverName = order.ReceiverName;
                    dbOrder.ReceiverPhone = order.ReceiverPhone;
                    dbOrder.ShippingAddress = order.ShippingAddress;
                    dbOrder.TotalMoney = order.TotalMoney;
                    dbOrder.ShippingProviderId = order.ShippingProviderId;

                    // 2. Tìm và cập nhật Invoice liên quan
                    var dbInvoice = _context.Invoices.FirstOrDefault(i => i.OrderId == order.OrderId);
                    if (dbInvoice != null)
                    {
                        dbInvoice.PaymentMethod = paymentMethod;
                        dbInvoice.Amount = order.TotalMoney ?? 0;
                    }

                    _context.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool Delete(int orderId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // 1. Tìm và xóa Hóa đơn liên quan trước
                    var invoice = _context.Invoices.FirstOrDefault(i => i.OrderId == orderId);
                    if (invoice != null)
                    {
                        _context.Invoices.Remove(invoice);
                    }

                    // 2. Tìm và xóa Đơn hàng
                    var order = _context.Orders.Find(orderId);
                    if (order != null)
                    {
                        _context.Orders.Remove(order);
                    }

                    _context.SaveChanges();
                    transaction.Commit(); // Hoàn tất xóa cả hai
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback(); // Nếu lỗi (vướng bảng khác nữa) thì hủy lệnh
                    return false;
                }
            }
        }
    }
}
