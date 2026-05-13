using ClothesStore.DAL.Context;
using ClothesStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ClothesStore.DAL.Repository
{
    public class InvoiceRepository
    {
        private readonly ClothesStoreContext _context = new ClothesStoreContext();

        // Lấy danh sách hóa đơn (EF Core sử dụng LINQ để Join)
        public List<object> GetAllInvoices()
        {
            var query = from i in _context.Invoices
                        // Join với Orders (thường luôn có OrderId nên join thường cũng được)
                        join o in _context.Orders on i.OrderId equals o.OrderId

                        // LEFT JOIN với Users để lấy tên khách hàng (nếu có)
                        join u in _context.Users on o.CustomerId equals u.UserId into userGroup
                        from u in userGroup.DefaultIfEmpty()

                        select new
                        {
                            i.InvoiceId,
                            i.OrderId,
                            // Nếu u null thì hiện "Khách lẻ", không làm mất dòng dữ liệu
                            CustomerName = u != null ? u.FullName : "Khách lẻ",
                            i.Amount,
                            i.PaymentDate,
                            i.PaymentMethod,
                            i.Status
                        };
            return query.ToList<object>();
        }

        public List<object> GetAllInvoicesRaw()
        {
            // Lấy toàn bộ danh sách, không lọc, sắp xếp theo ngày mới nhất
            return _context.Invoices
                           .OrderByDescending(i => i.PaymentDate)
                           .Select(i => new {
                               i.InvoiceId,
                               i.OrderId,
                               i.Amount,
                               i.PaymentMethod,
                               i.PaymentDate,
                               i.Status,
                               StatusName = i.Status == 2 ? "Đã thanh toán" : "Chờ xử lý"
                           })
                           .ToList<object>();
        }

        // Cập nhật trạng thái hóa đơn
        public bool UpdateInvoiceStatus(int invoiceId, int status)
        {
            var invoice = _context.Invoices.Find(invoiceId);
            if (invoice != null)
            {
                invoice.Status = status;
                return _context.SaveChanges() > 0;
            }
            return false;
        }
        public List<object> SearchInvoices(string keyword, DateTime? fromDate, DateTime? toDate, int? status)
        {
            // Chỉ lấy từ bảng Invoices (có thể Join thêm Orders nếu cần lấy thông tin đơn hàng)
            var query = _context.Invoices.AsQueryable();

            // 1. Lọc theo từ khóa (Mã đơn hàng hoặc Mã hóa đơn)
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(i => i.OrderId.ToString().Contains(keyword)
                                      || i.InvoiceId.ToString().Contains(keyword));
            }

            // 2. Lọc theo ngày bắt đầu
            if (fromDate.HasValue)
            {
                query = query.Where(i => i.PaymentDate >= fromDate.Value.Date);
            }

            // 3. Lọc theo ngày kết thúc (Lấy hết dữ liệu trong ngày đó)
            if (toDate.HasValue)
            {
                var nextDay = toDate.Value.Date.AddDays(1);
                query = query.Where(i => i.PaymentDate < nextDay);
            }

            // 4. Lọc theo trạng thái
            if (status.HasValue)
            {
                query = query.Where(i => i.Status == status.Value);
            }

            // 5. Trả về kết quả
            return query.Select(i => new
            {
                i.InvoiceId,
                i.OrderId,
                i.Amount,
                i.PaymentDate,
                i.PaymentMethod,
                i.Status,
                StatusName = i.Status == 2 ? "Đã thanh toán" : "Chờ xử lý"
            })
            .OrderByDescending(i => i.PaymentDate)
            .ToList<object>();
        }

        public bool UpdateInvoiceStatusByOrder(int orderId, int status)
        {
            try
            {
                // Tìm hóa đơn liên kết với OrderID này
                var invoice = _context.Invoices.FirstOrDefault(i => i.OrderId == orderId);

                if (invoice != null)
                {
                    invoice.Status = status; // Cập nhật trạng thái thành 2
                    return _context.SaveChanges() > 0;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public List<string> GetExistingPaymentMethods()
        {
            // Lấy danh sách các giá trị PaymentMethod duy nhất từ bảng Invoices
            return _context.Invoices
                           .Select(i => i.PaymentMethod)
                           .Distinct()
                           .Where(m => !string.IsNullOrEmpty(m))
                           .ToList()!;
        }
        public (List<object> Data, int TotalRecords) GetInvoiceHistory(
    DateTime? fromDate,
    DateTime? toDate,
    int? status,
    int pageNumber = 1,
    int pageSize = 20)
        {
            var query = _context.Invoices.AsQueryable();

            // 1. Lọc theo ngày bắt đầu (00:00:00)
            if (fromDate.HasValue)
            {
                DateTime start = fromDate.Value.Date;
                query = query.Where(i => i.PaymentDate >= start);
            }

            // 2. Lọc theo ngày kết thúc (Phải lấy đến 23:59:59 của ngày đó)
            if (toDate.HasValue)
            {
                // Cách chuẩn nhất: Lấy mọi thứ nhỏ hơn ngày hôm sau
                DateTime endLimit = toDate.Value.Date.AddDays(1);
                query = query.Where(i => i.PaymentDate < endLimit);
            }

            // 3. Lọc theo trạng thái
            if (status.HasValue)
            {
                query = query.Where(i => i.Status == status.Value);
            }

            int totalRecords = query.Count();

            var data = query.OrderByDescending(i => i.PaymentDate)
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .Select(i => new {
                                i.InvoiceId,
                                i.OrderId,
                                i.Amount,
                                i.PaymentMethod,
                                i.PaymentDate,
                                StatusName = i.Status == 1 ? "Pending" :
                                             i.Status == 2 ? "Paid" : "Cancelled"
                            })
                            .ToList<object>();

            return (data, totalRecords);
        }

        public (List<object> Data, int TotalRecords) GetInvoicePaged(int pageNumber, int pageSize = 20)
        {
            var query = _context.Invoices.AsQueryable();

            // 1. Tính tổng số bản ghi
            int totalRecords = query.Count();

            // 2. Lấy dữ liệu và ép kiểu hiển thị cho Status
            var data = query.OrderByDescending(i => i.PaymentDate)
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .Select(i => new {
                                i.InvoiceId,
                                i.OrderId,
                                i.Amount,
                                i.PaymentMethod,
                                i.PaymentDate,
                                StatusName = i.Status == 1 ? "Pending" :
                                             i.Status == 2 ? "Paid" :
                                             i.Status == 3 ? "Cancelled" : "Unknown"
                            })
                            .ToList<object>();

            return (data, totalRecords);
        }
    }
}
