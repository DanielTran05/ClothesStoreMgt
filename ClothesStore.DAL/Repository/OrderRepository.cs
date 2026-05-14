using ClothesStore.DAL.Context;
using ClothesStore.DAL.Enums;
using ClothesStore.DAL.Models;
using Microsoft.EntityFrameworkCore;
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
            var query = from o in _context.Orders
                        join c in _context.Users on o.CustomerId equals c.UserId into customers
                        from c in customers.DefaultIfEmpty()
                        join s in _context.ShippingProviders on o.ShippingProviderId equals s.ShippingProviderId into shippings
                        from s in shippings.DefaultIfEmpty()
                        select new
                        {
                            o.OrderId,
                            o.OrderDate,
                            State = o.OrderStatus,
                            StatusName = GetStatusName(o.OrderStatus),   // Gọi static method
                            o.ReceiverName,
                            o.ReceiverPhone,
                            ShippingName = s != null ? s.Name : "Chưa chọn",
                            o.TotalMoney
                        };

            return query.ToList<object>();
        }

        // Hàm xử lý trạng thái an toàn
        private static string GetStatusName(int? status)
        {
            if (status == null) return "Unknown";

            return status switch
            {
                0 => "Pending",
                1 => "Pending",
                2 => "Paid",
                3 => "Shipping",
                4 => "Completed",
                5 => "Canceled",
                6 => "Returned",
                _ => "Unknown"
            };
        }

        public List<object> SearchOrders(string keyword)
        {
            string key = keyword.ToLower();

            var query = from o in _context.Orders
                        join u in _context.Users on o.CustomerId equals u.UserId into userGroup
                        from user in userGroup.DefaultIfEmpty()
                        where (user != null && user.FullName.ToLower().Contains(key))
                              || o.OrderId.ToString().Contains(key)
                        select new
                        {
                            o.OrderId,
                            o.OrderDate,
                            State = o.OrderStatus,
                            StatusName = o.OrderStatus == 1 ? "Pending" :
                                         o.OrderStatus == 2 ? "Paid" :
                                         o.OrderStatus == 3 ? "Shipping" :
                                         o.OrderStatus == 4 ? "Completed" :
                                         o.OrderStatus == 5 ? "Canceled" :
                                         o.OrderStatus == 6 ? "Returned" : "Unknown",
                            o.TotalMoney,
                            o.ReceiverName
                        };

            return query.ToList<object>();
        }

        public bool Add(Order order)
        {
            try
            {
                _context.Orders.Add(order);
                return _context.SaveChanges() > 0;
            }
            catch { return false; }
        }
        public bool AddOrderWithInvoice(Order order, string paymentMethod)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Orders.Add(order);
                    _context.SaveChanges(); 

                    Invoice newInvoice = new Invoice
                    {
                        OrderId = order.OrderId,
                        Amount = order.TotalMoney ?? 0,
                        Status = 2,
                        PaymentMethod = paymentMethod 
                    };

                    _context.Invoices.Add(newInvoice);
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

        public bool UpdateOrderAndInvoice(Order order, string paymentMethod)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var dbOrder = _context.Orders.Find(order.OrderId);
                    if (dbOrder == null) return false;

                    dbOrder.ReceiverName = order.ReceiverName;
                    dbOrder.ReceiverPhone = order.ReceiverPhone;
                    dbOrder.ShippingAddress = order.ShippingAddress;
                    dbOrder.TotalMoney = order.TotalMoney;
                    dbOrder.ShippingProviderId = order.ShippingProviderId;

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
            Console.WriteLine($"[INFO] Bắt đầu xóa đơn hàng ID = {orderId}");

            // Lấy chi tiết đơn hàng để hoàn trả kho
            var orderDetails = _context.OrderDetails
                .Where(od => od.OrderId == orderId)
                .ToList();

            // ==================== 1. HOÀN TRẢ TỒN KHO ====================
            foreach (var detail in orderDetails)
            {
                // Hoàn trả ProductVariants
                _context.Database.ExecuteSqlRaw(
                    "UPDATE ProductVariants SET AmountInStock = ISNULL(AmountInStock, 0) + {0} WHERE VariantId = {1}",
                    detail.Quantity, detail.VariantId);

                // Hoàn trả WarehouseReceiptDetails
                _context.Database.ExecuteSqlRaw(
                    "UPDATE WarehouseReceiptDetails SET Quantity = ISNULL(Quantity, 0) + {0} WHERE VariantId = {1}",
                    detail.Quantity, detail.VariantId);
            }

            // ==================== 2. XÓA DỮ LIỆU LIÊN QUAN ====================
            _context.Database.ExecuteSqlRaw("DELETE FROM Invoices WHERE OrderId = {0}", orderId);
            _context.Database.ExecuteSqlRaw("DELETE FROM OrderDetails WHERE OrderId = {0}", orderId);
            _context.Database.ExecuteSqlRaw("DELETE FROM Orders WHERE OrderId = {0}", orderId);

            transaction.Commit();

            Console.WriteLine($"[SUCCESS] Đã xóa thành công đơn hàng {orderId}");
            return true;
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Console.WriteLine("=== LỖI Delete Order ===");
            Console.WriteLine(ex.ToString());
            return false;
        }
    }
}
        public List<object> GetOrderDetailsWithInfo(int orderId)
        {
            var query = from od in _context.OrderDetails
                        join v in _context.ProductVariants on od.VariantId equals v.VariantId
                        join p in _context.Products on v.ProductId equals p.ProductId

                        where od.OrderId == orderId
                        select new
                        {
                            SKU = v.Sku,
                            ProductName = p.ProductName,
                            Quantity = od.Quantity,
                            Price = od.PriceAtPurchase,
                            SubTotal = od.Quantity * od.PriceAtPurchase
                        };

            return query.ToList<object>();
        }
        public List<object> GetOrdersFiltered(DateTime fromDate, DateTime toDate, int? status, string keyword)
        {
            var query = _context.Orders.AsQueryable();

            DateTime start = fromDate.Date;
            DateTime end = toDate.Date.AddDays(1);
            query = query.Where(o => o.OrderDate >= start && o.OrderDate < end);

            if (status.HasValue)
            {
                query = query.Where(o => o.OrderStatus == status.Value);
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                string key = keyword.ToLower();
                query = query.Where(o => o.OrderId.ToString().Contains(key) ||
                                         o.ReceiverName.ToLower().Contains(key));
            }

            return query.Select(o => new {
                o.OrderId,
                o.OrderDate,
                State = o.OrderStatus, 
                StatusName = o.OrderStatus == 0 ? "Pending" :
                             o.OrderStatus == 1 ? "Paid" :
                             o.OrderStatus == 2 ? "Shipping" :
                             o.OrderStatus == 3 ? "Completed" :
                             o.OrderStatus == 4 ? "Canceled" : 
                             o.OrderStatus == 5 ? "Returned" : "Unknown",
                o.ReceiverName,
                o.ReceiverPhone,
                o.TotalMoney
            })
            .OrderByDescending(o => o.OrderDate)
            .ToList<object>();
        }
        public bool CreateFullOrder(Order order, Invoice invoice)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // 1. Lưu Order (Các trường ReceiverName, ReceiverPhone, ShippingAddress phải có giá trị từ GUI)
                    _context.Orders.Add(order);
                    _context.SaveChanges();

                    // 2. Lưu Invoice (Gán ID của Order vừa tạo)
                    invoice.OrderId = order.OrderId;
                    _context.Invoices.Add(invoice);

                    // 3. Cập nhật số lượng tại các bảng liên quan
                    foreach (var detail in order.OrderDetails)
                    {
                        // Trừ kho tại bảng ProductVariants (để hiển thị lên GUI)
                        var variant = _context.ProductVariants.Find(detail.VariantId);
                        if (variant != null)
                        {
                            variant.AmountInStock -= detail.Quantity;
                        }

                        // Trừ số lượng thực tế tại bảng WarehouseReceiptDetails (như image_2ad0fa.jpg)
                        var receiptDetail = _context.WarehouseReceiptDetails
                            .FirstOrDefault(rd => rd.VariantId == detail.VariantId);
                        if (receiptDetail != null)
                        {
                            receiptDetail.Quantity -= detail.Quantity;
                        }
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
        public Order? GetOrderById(int orderId)
        {
            return _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Variant)
                        .ThenInclude(v => v.Product)
                .Include(o => o.Invoices)           
                .FirstOrDefault(o => o.OrderId == orderId);
        }
        public bool UpdateFullOrder(Order order, string paymentMethod)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.ChangeTracker.Clear();
                    Console.WriteLine($"[INFO] Bắt đầu cập nhật OrderId = {order.OrderId}");

                    var dbOrder = _context.Orders
                        .FirstOrDefault(o => o.OrderId == order.OrderId);

                    if (dbOrder == null)
                    {
                        Console.WriteLine("[ERROR] Không tìm thấy đơn hàng");
                        return false;
                    }

                    dbOrder.ReceiverName = order.ReceiverName;
                    dbOrder.ReceiverPhone = order.ReceiverPhone;
                    dbOrder.ShippingAddress = order.ShippingAddress;
                    dbOrder.ShippingProviderId = order.ShippingProviderId;
                    dbOrder.TotalMoney = order.TotalMoney;


                    var oldDetails = _context.OrderDetails
                        .Where(d => d.OrderId == order.OrderId)
                        .ToList();

                    foreach (var oldItem in oldDetails)
                    {
                        _context.Database.ExecuteSqlRaw(
                            @"UPDATE ProductVariants
                      SET AmountInStock = AmountInStock + {0}
                      WHERE VariantId = {1}",
                            oldItem.Quantity,
                            oldItem.VariantId
                        );
                    }

                    _context.OrderDetails.RemoveRange(oldDetails);

                    _context.SaveChanges();
                    _context.ChangeTracker.Clear();

                    var cleanDetails = order.OrderDetails
                        .Select(x => new OrderDetail
                        {
                            OrderId = order.OrderId,
                            VariantId = x.VariantId,
                            Quantity = x.Quantity,
                            PriceAtPurchase = x.PriceAtPurchase
                        })
                        .ToList();

                    foreach (var newItem in cleanDetails)
                    {
                        var stock = _context.ProductVariants
                            .Where(v => v.VariantId == newItem.VariantId)
                            .Select(v => v.AmountInStock)
                            .FirstOrDefault();

                        if (stock == null || stock < newItem.Quantity)
                        {
                            throw new Exception(
                                $"Sản phẩm VariantId = {newItem.VariantId} không đủ tồn kho!"
                            );
                        }
                        _context.Database.ExecuteSqlRaw(
                            @"UPDATE ProductVariants
                      SET AmountInStock = AmountInStock - {0}
                      WHERE VariantId = {1}",
                            newItem.Quantity,
                            newItem.VariantId
                        );
                        _context.OrderDetails.Add(new OrderDetail
                        {
                            OrderId = newItem.OrderId,
                            VariantId = newItem.VariantId,
                            Quantity = newItem.Quantity,
                            PriceAtPurchase = newItem.PriceAtPurchase
                        });
                    }

                    _context.Database.ExecuteSqlRaw(
                        @"UPDATE Invoices
                  SET PaymentMethod = {0},
                      Amount = {1}
                  WHERE OrderId = {2}",
                        paymentMethod,
                        order.TotalMoney ?? 0,
                        order.OrderId
                    );

                    _context.SaveChanges();


                    transaction.Commit();

                    Console.WriteLine(
                        $"[SUCCESS] Cập nhật Order {order.OrderId} thành công!"
                    );

                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    Console.WriteLine("=== LỖI UpdateFullOrder ===");
                    Console.WriteLine(ex.ToString());

                    return false;
                }
            }
        }
    }
}
