using ClothesStore.DAL.Context;
using ClothesStore.DAL.Enums;
using ClothesStore.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq; // Bắt buộc phải có để chạy OrderBy và AsEnumerable
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
                            o.ReceiverName,
                            o.ReceiverPhone,
                            ShippingName = s != null ? s.Name : "Chưa chọn",
                            o.TotalMoney
                        };

            return query.OrderBy(o => o.OrderDate)
                        .AsEnumerable()
                        .Select(o => new
                        {
                            o.OrderId,
                            o.OrderDate,
                            State = o.State,
                            StatusName = GetStatusName(o.State),
                            o.ReceiverName,
                            o.ReceiverPhone,
                            o.ShippingName,
                            o.TotalMoney
                        }).ToList<object>();
        }

        private static string GetStatusName(int? status)
        {
            if (status == null) return "Unknown";

            int enumValue = status.Value + 1;

            if (Enum.IsDefined(typeof(OrderStatusEnum), enumValue))
            {
                return ((OrderStatusEnum)enumValue).ToString();
            }

            return "Unknown";
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
                            o.TotalMoney,
                            o.ReceiverName
                        };

            // Đồng bộ đọc trạng thái qua hàm Enum chung và đổi sang sắp xếp tăng dần OrderBy
            return query.OrderBy(o => o.OrderDate)
                        .AsEnumerable()
                        .Select(o => new
                        {
                            o.OrderId,
                            o.OrderDate,
                            State = o.State,
                            StatusName = GetStatusName(o.State),
                            o.TotalMoney,
                            o.ReceiverName
                        }).ToList<object>();
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
                    Console.WriteLine($"[INFO] Bắt đầu hủy đơn hàng ID = {orderId}");

                    var orderDetails = _context.OrderDetails
                        .Where(od => od.OrderId == orderId)
                        .ToList();

                    // ==================== 1. HOÀN TRẢ TỒN KHO ====================
                    foreach (var detail in orderDetails)
                    {
                        _context.Database.ExecuteSqlRaw(
                            "UPDATE ProductVariants SET AmountInStock = ISNULL(AmountInStock, 0) + {0} WHERE VariantId = {1}",
                            detail.Quantity, detail.VariantId);

                        _context.Database.ExecuteSqlRaw(
                            "UPDATE WarehouseReceiptDetails SET Quantity = ISNULL(Quantity, 0) + {0} WHERE VariantId = {1}",
                            detail.Quantity, detail.VariantId);
                    }

                    // ==================== 2. CẬP NHẬT TRẠNG THÁI VÀ XÓA LỊCH SỬ KHO ====================

                    _context.Database.ExecuteSqlRaw("DELETE FROM InventoryTransactions WHERE OrderId = {0}", orderId);

                    int dbCanceledStatus = (int)OrderStatusEnum.Canceled - 1;

                    _context.Database.ExecuteSqlRaw(
                        "UPDATE Orders SET OrderStatus = {0} WHERE OrderId = {1}",
                        dbCanceledStatus,
                        orderId
                    );

                    _context.Database.ExecuteSqlRaw("UPDATE Invoices SET Status = 2 WHERE OrderId = {0}", orderId);

                    transaction.Commit();

                    Console.WriteLine($"[SUCCESS] Đã hủy đơn hàng và hóa đơn {orderId} thành công!");
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("=== LỖI Hủy Đơn Hàng ===");
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

            var rawData = query.Select(o => new {
                o.OrderId,
                o.OrderDate,
                o.OrderStatus,
                o.ReceiverName,
                o.ReceiverPhone,
                o.TotalMoney
            });

            // Đổi OrderByDescending sang OrderBy (Tăng dần), đồng bộ đọc trạng thái qua Enum
            return rawData.OrderBy(o => o.OrderDate)
                          .AsEnumerable()
                          .Select(o => new {
                              o.OrderId,
                              o.OrderDate,
                              State = o.OrderStatus,
                              StatusName = GetStatusName(o.OrderStatus),
                              o.ReceiverName,
                              o.ReceiverPhone,
                              o.TotalMoney
                          }).ToList<object>();
        }
        public bool CreateFullOrder(Order order, Invoice invoice)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // 1. Lưu Order 
                    _context.Orders.Add(order);
                    _context.SaveChanges();

                    // 2. Lưu Invoice 
                    invoice.OrderId = order.OrderId;
                    _context.Invoices.Add(invoice);

                    // 3. Cập nhật số lượng tại các bảng liên quan và GHI NHẬN LỊCH SỬ
                    foreach (var detail in order.OrderDetails)
                    {
                        var variant = _context.ProductVariants.Find(detail.VariantId);
                        if (variant != null)
                        {
                            variant.AmountInStock -= detail.Quantity;
                        }

                        var receiptDetail = _context.WarehouseReceiptDetails
                            .FirstOrDefault(rd => rd.VariantId == detail.VariantId);
                        if (receiptDetail != null)
                        {
                            receiptDetail.Quantity -= detail.Quantity;
                        }

                        _context.Database.ExecuteSqlRaw(
                            @"INSERT INTO InventoryTransactions (VariantID, TransactionType, QuantityChange, OrderID, CreatedAt)
                      VALUES ({0}, {1}, {2}, {3}, {4})",
                            detail.VariantId ?? 0,
                            "SALE",
                            -detail.Quantity,
                            order.OrderId,
                            DateTime.Now
                        );
                    }

                    _context.SaveChanges();

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("=== LỖI DB KHI TẠO ĐƠN HÀNG ===");
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        // 🔥 ĐÃ KHÔI PHỤC LẠI HÀM NÀY CHO BẠN:
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
                    dbOrder.OrderStatus = order.OrderStatus;

                    var oldDetails = _context.OrderDetails
                        .Where(d => d.OrderId == order.OrderId)
                        .ToList();

                    foreach (var oldItem in oldDetails)
                    {
                        _context.Database.ExecuteSqlRaw(
                            @"UPDATE ProductVariants SET AmountInStock = AmountInStock + {0} WHERE VariantId = {1}",
                            oldItem.Quantity,
                            oldItem.VariantId
                        );
                    }

                    _context.Database.ExecuteSqlRaw("DELETE FROM InventoryTransactions WHERE OrderId = {0}", order.OrderId);

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
                            @"UPDATE ProductVariants SET AmountInStock = AmountInStock - {0} WHERE VariantId = {1}",
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

                        _context.Database.ExecuteSqlRaw(
                            @"INSERT INTO InventoryTransactions (VariantID, TransactionType, QuantityChange, OrderID, CreatedAt)
                      VALUES ({0}, {1}, {2}, {3}, {4})",
                            newItem.VariantId ?? 0,
                            "SALE",
                            -newItem.Quantity,
                            order.OrderId,
                            DateTime.Now
                        );
                    }

                    _context.Database.ExecuteSqlRaw(
                        @"UPDATE Invoices SET PaymentMethod = {0}, Amount = {1} WHERE OrderId = {2}",
                        paymentMethod,
                        order.TotalMoney ?? 0,
                        order.OrderId
                    );

                    _context.SaveChanges();

                    transaction.Commit();

                    Console.WriteLine($"[SUCCESS] Cập nhật Order {order.OrderId} thành công!");
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
        public bool Return(int orderId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Console.WriteLine($"[INFO] Bắt đầu xử lý trả đơn hàng ID = {orderId}");

                    // Lấy chi tiết sản phẩm của đơn hàng để làm thủ tục hoàn trả kho
                    var orderDetails = _context.OrderDetails
                        .Where(od => od.OrderId == orderId)
                        .ToList();

                    // ==================== 1. HOÀN TRẢ TỒN KHO ====================
                    foreach (var detail in orderDetails)
                    {
                        // Cộng lại số lượng vào bảng ProductVariants
                        _context.Database.ExecuteSqlRaw(
                            "UPDATE ProductVariants SET AmountInStock = ISNULL(AmountInStock, 0) + {0} WHERE VariantId = {1}",
                            detail.Quantity, detail.VariantId);

                        // Cộng lại số lượng vào bảng WarehouseReceiptDetails
                        _context.Database.ExecuteSqlRaw(
                            "UPDATE WarehouseReceiptDetails SET Quantity = ISNULL(Quantity, 0) + {0} WHERE VariantId = {1}",
                            detail.Quantity, detail.VariantId);
                    }

                    // ==================== 2. CẬP NHẬT TRẠNG THÁI & NHẬT KÝ KHO ====================

                    // Gỡ bỏ bản ghi xuất kho SALE cũ của đơn này vì hàng đã được trả lại vị trí cũ
                    _context.Database.ExecuteSqlRaw("DELETE FROM InventoryTransactions WHERE OrderId = {0}", orderId);

                    // 🔥 XỬ LÝ LỆCH PHA INDEX: 
                    // Trạng thái Returned trong Enum là số 6 => Lưu xuống Database trừ đi 1 đơn vị sẽ thành số 5
                    int dbReturnedStatus = (int)OrderStatusEnum.Returned - 1;

                    // Cập nhật Orders thành trạng thái Returned (Số 5 trong DB)
                    _context.Database.ExecuteSqlRaw(
                        "UPDATE Orders SET OrderStatus = {0} WHERE OrderId = {1}",
                        dbReturnedStatus,
                        orderId
                    );

                    // Cập nhật hóa đơn Invoices sang trạng thái Hủy/Hoàn tiền (Số 2 giống đơn hủy của bạn)
                    _context.Database.ExecuteSqlRaw("UPDATE Invoices SET Status = 2 WHERE OrderId = {0}", orderId);

                    transaction.Commit();
                    Console.WriteLine($"[SUCCESS] Đã xử lý trả đơn hàng {orderId} thành công!");
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("=== LỖI Trả Đơn Hàng (Return) ===");
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }
    }
}