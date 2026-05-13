using ClothesStore.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ClothesStore.BUS
{
    public class InvoiceService
    {
        private readonly InvoiceRepository _invoiceRepo = new InvoiceRepository();

        public List<object> GetInvoices()
        {
            return _invoiceRepo.GetAllInvoices();
        }

        public List<object> GetAllInvoices()
        {
            return _invoiceRepo.GetAllInvoicesRaw();
        }
        public List<object> Search(string keyword, DateTime? start, DateTime? end, int? status)
        {
            return _invoiceRepo.SearchInvoices(keyword, start, end, status);
        }

        public (List<object> Data, int TotalPages) GetInvoicesByPage(int page)
        {
            int pageSize = 20;
            var result = _invoiceRepo.GetInvoicePaged(page, pageSize);

            // Tính tổng số trang (Ví dụ: 41 bản ghi -> 3 trang)
            int totalPages = (int)Math.Ceiling((double)result.TotalRecords / pageSize);

            return (result.Data, totalPages);
        }

        public string UpdateInvoiceStatus(int id, int status)
        {
            // Kiểm tra ràng buộc Status (0: Chờ thanh toán, 1: Đã thanh toán, 2: Hoàn tiền, 3: Hủy)
            if (status < 0 || status > 3)
                return "Trạng thái không hợp lệ!";

            bool success = _invoiceRepo.UpdateInvoiceStatus(id, status);
            return success ? "Cập nhật thành công!" : "Cập nhật thất bại hoặc hóa đơn không tồn tại.";
        }
        public List<string> GetPaymentMethods()
        {
            var methods = _invoiceRepo.GetExistingPaymentMethods();

            if (methods.Count == 0)
            {
                methods.Add("Tiền mặt");
                methods.Add("Chuyển khoản");
                methods.Add("Ví điện tử");
            }
            return methods;
        }

        public (List<object> Data, int TotalPages) GetHistory(DateTime? start, DateTime? end, int? status, int page)
        {
            int pageSize = 20;
            var result = _invoiceRepo.GetInvoiceHistory(start, end, status, page, pageSize);

            // Tính tổng số trang (ví dụ 41 records / 20 = 3 trang)
            int totalPages = (int)Math.Ceiling((double)result.TotalRecords / pageSize);

            return (result.Data, totalPages);
        }
    }
}
