# CLOTHESSTOREMGT - HỆ THỐNG QUẢN LÝ CỬA HÀNG QUẦN ÁO

Dự án phần mềm quản lý cửa hàng bán quần áo tích hợp thanh toán tự động, được xây dựng dựa trên mô hình Client-Server với API và giao diện quản trị nội bộ

## Tech Stack
* **Ngôn ngữ:** C# (.NET Core / .NET 10)
* **HQT CSDL:** SQL Server
* Lập trình phía Máy chủ (T-SQL):** Tích hợp Stored Procedures, User-defined Functions (UDF), Views, Triggers và kiểm soát Transactions[cite: 16, 18, 19, 20, 21].
* ORM & Truy xuất dữ liệu:** * Entity Framework Core (Quản lý thực thể)
  * ADO.NET (kết nối, truy vấn phức tạp)
  * LINQ to Objects / LINQ to SQL
* Giao diện (Presentation Layer):** Windows Forms (WinForms) cho Admin
* Web:** ASP.NET Core Web API (cung cấp Endpoints, tuong tac JSON)
* **Tích hợp bên thứ 3:** Thanh toán MoMo

## Architecture
* `ClothesStore.API` & `ClothesStore.GUI`: Lớp Giao diện/Dịch vụ (Presentation Layer)
* `ClothesStore.BUS`: Business Logic Layer xử lý logic và tính hợp lệ của dữ liệu
* `ClothesStore.DAL`: Data Access Layer giao tiếp trực tiếp với SQL Server[cite: 27].
* `ClothesStore.DTO`: Data Transfer Objects đóng gói dữ liệu truyền tải giữa các tầng

## Set up Environment

### 1: Khởi tạo Database
1. Mở SQL Server Management Studio (SSMS).
2. Chạy file script `ClothesStoreMgt_dbSqlScript.sql` đính kèm ở thư mục gốc để tự động tạo CSDL `clothesstoremgt`

### 2: Connection String config
Cập nhật tên `Server` khớp với SQL Server trên máy tính:
* **Tầng API:** vào project `ClothesStore.API` $\rightarrow$ Mở `appsettings.json` $\rightarrow$ Thay đổi giá trị: `"Server=[ten-server-tren-may];Database=clothesstoremgt;..."`
* **Tầng GUI:** vào project `ClothesStore.GUI` $\rightarrow$ Mở `App.config` $\rightarrow$ Thay đổi giá trị tương tự ở thẻ `<connectionStrings>`.

### 3: Dependencies
Proj su dụng NuGet. Mở Solution bằng Visual Studio, các thư viện sẽ tự động được tải về. Nếu gặp lỗi thiếu thư viện khi Build, hãy mở Terminal/Package Manager Console và chạy lệnh:
```bash
dotnet restore

### 4: Run
Run Server API: set ClothesStore.API làm Startup Project và nhấn F5.
Để mở ứng dụng Quản lý (Admin - winform): set ClothesStore.GUI làm Startup Project và nhấn F5.