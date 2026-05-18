using ClothesStore.DAL.Context;
using ClothesStore.DAL.Models;
using ClothesStore.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ClothesStore.DAL.Repository
{
    public class InvoiceRepository
    {
        private readonly ClothesStoreContext _context = new ClothesStoreContext();

        public List<object> GetAllInvoices()
        {
            var query = from i in _context.Invoices
                        join o in _context.Orders on i.OrderId equals o.OrderId
                        join u in _context.Users on o.CustomerId equals u.UserId into userGroup
                        from u in userGroup.DefaultIfEmpty()
                        select new
                        {
                            i.InvoiceId,
                            i.OrderId,
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
            int dbPaid = (int)InvoiceStatus.Paid - 1;

            return _context.Invoices
                           .OrderByDescending(i => i.PaymentDate)
                           .Select(i => new {
                               i.InvoiceId,
                               i.OrderId,
                               i.Amount,
                               i.PaymentMethod,
                               i.PaymentDate,
                               i.Status,
                               StatusName = i.Status == dbPaid ? "Đã thanh toán" : "Chờ xử lý"
                           })
                           .ToList<object>();
        }

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
            var query = _context.Invoices.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(i => i.OrderId.ToString().Contains(keyword)
                                      || i.InvoiceId.ToString().Contains(keyword));
            }

            if (fromDate.HasValue)
            {
                query = query.Where(i => i.PaymentDate >= fromDate.Value.Date);
            }

            if (toDate.HasValue)
            {
                var nextDay = toDate.Value.Date.AddDays(1);
                query = query.Where(i => i.PaymentDate < nextDay);
            }

            if (status.HasValue)
            {
                query = query.Where(i => i.Status == status.Value);
            }

            int dbPaid = (int)InvoiceStatus.Paid - 1;

            return query.Select(i => new
            {
                i.InvoiceId,
                i.OrderId,
                i.Amount,
                i.PaymentDate,
                i.PaymentMethod,
                i.Status,
                StatusName = i.Status == dbPaid ? "Đã thanh toán" : "Chờ xử lý"
            })
            .OrderByDescending(i => i.PaymentDate)
            .ToList<object>();
        }

        public bool UpdateInvoiceStatusByOrder(int orderId, int status)
        {
            try
            {
                var invoice = _context.Invoices.FirstOrDefault(i => i.OrderId == orderId);

                if (invoice != null)
                {
                    invoice.Status = status;
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

            if (fromDate.HasValue)
            {
                DateTime start = fromDate.Value.Date;
                query = query.Where(i => i.PaymentDate >= start);
            }

            if (toDate.HasValue)
            {
                DateTime endLimit = toDate.Value.Date.AddDays(1);
                query = query.Where(i => i.PaymentDate < endLimit);
            }

            if (status.HasValue)
            {
                query = query.Where(i => i.Status == status.Value);
            }

            int totalRecords = query.Count();

            int dbPending = (int)InvoiceStatus.Pending - 1;
            int dbPaid = (int)InvoiceStatus.Paid - 1;
            int dbCancelled = (int)InvoiceStatus.Cancelled - 1;

            var data = query.OrderByDescending(i => i.PaymentDate)
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .Select(i => new {
                                i.InvoiceId,
                                i.OrderId,
                                i.Amount,
                                i.PaymentMethod,
                                i.PaymentDate,
                                StatusName = i.Status == dbPending ? "Pending" :
                                             i.Status == dbPaid ? "Paid" :
                                             i.Status == dbCancelled ? "Cancelled" : "Unknown"
                            })
                            .ToList<object>();

            return (data, totalRecords);
        }

        public (List<object> Data, int TotalRecords) GetInvoicePaged(int pageNumber, int pageSize = 20)
        {
            var query = _context.Invoices.AsQueryable();

            int totalRecords = query.Count();

            int dbPending = (int)InvoiceStatus.Pending - 1;
            int dbPaid = (int)InvoiceStatus.Paid - 1;
            int dbCancelled = (int)InvoiceStatus.Cancelled - 1;

            var data = query.OrderByDescending(i => i.PaymentDate)
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .Select(i => new {
                                i.InvoiceId,
                                i.OrderId,
                                i.Amount,
                                i.PaymentMethod,
                                i.PaymentDate,
                                StatusName = i.Status == dbPending ? "Pending" :
                                             i.Status == dbPaid ? "Paid" :
                                             i.Status == dbCancelled ? "Cancelled" : "Unknown"
                            })
                            .ToList<object>();

            return (data, totalRecords);
        }
    }
}