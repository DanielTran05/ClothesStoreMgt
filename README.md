# CLOTHESSTOREMGT - HỆ THỐNG QUẢN LÝ CỬA HÀNG QUẦN ÁO

Dự án phần mềm quản lý cửa hàng bán quần áo thong quan giao diện quản trị nội bộ.

## Tech Stack
* **Ngôn ngữ:** C# (.NET Core / .NET 10)
* **HQT CSDL:** SQL Server
* **Lập trình phía Máy chủ (T-SQL):** Stored Procedures, User-defined Functions (UDF), Views, Triggers và kiểm soát Transactions.
* **ORM & Truy xuất dữ liệu:**
  * Entity Framework Core
  * ADO.NET
  * LINQ to Objects / LINQ to SQL
* **Giao diện (Presentation Layer):** Windows Forms (WinForms) cho Admin

## Architecture
* `ClothesStore.GUI`: Lớp Giao diện
* `ClothesStore.BUS`: Business Logic Layer xử lý logic và tính hợp lệ của dữ liệu
* `ClothesStore.DAL`: Data Access Layer giao tiếp trực tiếp với SQL Server
* `ClothesStore.DTO`: Data Transfer Objects đóng gói dữ liệu truyền tải giữa các tầng
* `ClothesStore.HELPER`: Các hàm tiện tích

## Set up Environment

### 1: Khởi tạo Database
1. Mở SQL Server Management Studio (SSMS).
2. Chạy file script `ClothesStoreMgt_dbSqlScript.sql` đính kèm ở thư mục gốc để tự động tạo CSDL `clothesstoremgt`

### 2: Connection String config
Cập nhật tên `Server` khớp với SQL Server trên máy tính:
* **Tầng GUI:** vào project `ClothesStore.GUI` -> Mở `App.config` -> Thay đổi giá trị tương tự ở thẻ `<connectionStrings>`
* connectionString="Server=ten-server-tren-may;Database=clothesstoremgt;Trusted_Connection=True;TrustServerCertificate=True;

### 3: Dependencies
Proj sử dụng NuGet. Mở Solution bằng Visual Studio, các thư viện sẽ tự động được tải về. Nếu gặp lỗi thiếu thư viện khi Build, hãy mở Terminal/Package Manager Console và chạy lệnh:
```bash
dotnet restore
```

### 4: Run
Set ClothesStore.GUI làm Startup Project và nhấn Build → Run proj

### 5: Quy trình làm
1. Clone proj → Set up env
2. Khi làm thì chia branch làm trong branch khác → làm xong thì commit → rồi push vào branch mình đang làm → lên git tạo Pull request → chờ xác nhận từ owner (không được tự ý merge)