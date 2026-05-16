USE [clothesstoremgt] 
GO

-- Làm sạch dữ liệu cũ trước khi mock để tránh rác database
SET NOCOUNT ON;

-- ==============================================================================
-- 0. DỌN DẸP DỮ LIỆU CŨ (Giữ lại admin, sale, kho, khach01 của bạn)
-- ==============================================================================
EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'

DELETE FROM [dbo].[CustomerService];
DELETE FROM [dbo].[InventoryTransactions];
DELETE FROM [dbo].[Invoices];
DELETE FROM [dbo].[OrderDetails];
DELETE FROM [dbo].[Orders];
DELETE FROM [dbo].[WarehouseReceiptDetails];
DELETE FROM [dbo].[WarehouseReceipts];
DELETE FROM [dbo].[ProductVariants];
DELETE FROM [dbo].[Products];
DELETE FROM [dbo].[Sizes];
DELETE FROM [dbo].[Colors];
DELETE FROM [dbo].[Categories];
DELETE FROM [dbo].[ShippingProviders];
DELETE FROM [dbo].[Suppliers];
DELETE FROM [dbo].[Users] WHERE Username NOT IN ('admin', 'sale', 'kho', 'khach01');

DBCC CHECKIDENT ('[dbo].[CustomerService]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[InventoryTransactions]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[Invoices]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[OrderDetails]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[Orders]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[WarehouseReceiptDetails]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[WarehouseReceipts]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[ProductVariants]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[Products]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[Sizes]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[Colors]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[Categories]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[ShippingProviders]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[Suppliers]', RESEED, 0);

EXEC sp_MSForEachTable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'
GO

-- ==============================================================================
-- 1. INSERT USERS (EMPLOYEES & CUSTOMERS)
-- ==============================================================================
INSERT INTO [dbo].[Users] (UserID, Username, PasswordHash, FullName, Email, PhoneNumber, Address, Role, IsActive, CreatedAt)
VALUES
-- Employees (Role = 2)
(NEWID(), 'employee01', '<COPY_HASH_TỪ_ADMIN>', N'Trần Nhân Viên 1', 'employee01@clothes.com', '0901111111', N'Quận 1, TP.HCM', 2, 1, GETDATE()),
(NEWID(), 'employee02', '<COPY_HASH_TỪ_ADMIN>', N'Nguyễn Nhân Viên 2', 'employee02@clothes.com', '0902222222', N'Quận 3, TP.HCM', 2, 1, GETDATE()),

-- Customers (Role = 3)
(NEWID(), 'khach02', '<COPY_HASH_TỪ_ADMIN>', N'Lê Khách Hàng 2', 'khach02@gmail.com', '0903333333', N'Gò Vấp, TP.HCM', 3, 1, GETDATE()),
(NEWID(), 'khach03', '<COPY_HASH_TỪ_ADMIN>', N'Phạm Khách Hàng 3', 'khach03@gmail.com', '0904444444', N'Bình Thạnh, TP.HCM', 3, 1, GETDATE());
GO

-- ==============================================================================
-- 2. INSERT CATEGORIES
-- ==============================================================================
INSERT INTO [dbo].[Categories] (CategoryName, Description)
VALUES
(N'Áo Thun', N'Các loại áo thun basic, polo tay ngắn, tay dài'),
(N'Quần Jean', N'Quần jean nam nữ, form rộng, form suông'),
(N'Áo Khoác', N'Áo khoác gió, áo khoác dù, hoodie');
GO

-- ==============================================================================
-- 3. INSERT THUỘC TÍNH (COLORS & SIZES)
-- ==============================================================================
INSERT INTO [dbo].[Colors] (ColorName) VALUES (N'Đen'), (N'Trắng'), (N'Xanh Navy'), (N'Be');
INSERT INTO [dbo].[Sizes] (SizeName) VALUES ('S'), ('M'), ('L'), ('XL'), ('Freesize');
GO

-- ==============================================================================
-- 4. INSERT PRODUCTS
-- ==============================================================================
DECLARE @CatAoThun INT = (SELECT TOP 1 CategoryID FROM Categories WHERE CategoryName = N'Áo Thun');
DECLARE @CatQuanJean INT = (SELECT TOP 1 CategoryID FROM Categories WHERE CategoryName = N'Quần Jean');

INSERT INTO [dbo].[Products] (ProductName, Description, CategoryID)
VALUES
(N'Áo thun nam Basic cổ tròn', N'Chất liệu cotton 100%, co giãn 4 chiều, thấm hút mồ hôi tốt.', @CatAoThun),
(N'Quần Jean nam ống suông', N'Vải denim cao cấp không phai màu, dáng suông hack chiều cao.', @CatQuanJean);
GO

-- ==============================================================================
-- 5. INSERT PRODUCT VARIANTS (BIẾN THỂ SẢN PHẨM)
-- ==============================================================================
DECLARE @ProAoThun INT = (SELECT TOP 1 ProductID FROM Products WHERE ProductName = N'Áo thun nam Basic cổ tròn');
DECLARE @ProQuanJean INT = (SELECT TOP 1 ProductID FROM Products WHERE ProductName = N'Quần Jean nam ống suông');

DECLARE @ColorDen INT = (SELECT TOP 1 ColorID FROM Colors WHERE ColorName = N'Đen');
DECLARE @ColorTrang INT = (SELECT TOP 1 ColorID FROM Colors WHERE ColorName = N'Trắng');
DECLARE @ColorXanh INT = (SELECT TOP 1 ColorID FROM Colors WHERE ColorName = N'Xanh Navy');

DECLARE @SizeM INT = (SELECT TOP 1 SizeID FROM Sizes WHERE SizeName = 'M');
DECLARE @SizeL INT = (SELECT TOP 1 SizeID FROM Sizes WHERE SizeName = 'L');
DECLARE @SizeXL INT = (SELECT TOP 1 SizeID FROM Sizes WHERE SizeName = 'XL');

INSERT INTO [dbo].[ProductVariants] (ProductID, ColorID, SizeID, SKU, Price, AmountInStock, Img)
VALUES
(@ProAoThun, @ColorDen, @SizeM, 'AT-BASIC-DEN-M', 150000, 100, 'url_img_aothun_den.jpg'),
(@ProAoThun, @ColorDen, @SizeL, 'AT-BASIC-DEN-L', 150000, 80, 'url_img_aothun_den.jpg'),
(@ProAoThun, @ColorTrang, @SizeM, 'AT-BASIC-TRANG-M', 150000, 120, 'url_img_aothun_trang.jpg'),
(@ProAoThun, @ColorTrang, @SizeL, 'AT-BASIC-TRANG-L', 150000, 50, 'url_img_aothun_trang.jpg'),
(@ProQuanJean, @ColorXanh, @SizeL, 'QJ-SUONG-XANH-L', 350000, 45, 'url_img_quanjean_xanh.jpg'),
(@ProQuanJean, @ColorXanh, @SizeXL, 'QJ-SUONG-XANH-XL', 350000, 30, 'url_img_quanjean_xanh.jpg');
GO

USE [clothesstoremgt]
GO

DECLARE @Emp1 UNIQUEIDENTIFIER = (SELECT TOP 1 UserID FROM Users WHERE Username = 'employee01');
DECLARE @Cus1 UNIQUEIDENTIFIER = (SELECT TOP 1 UserID FROM Users WHERE Username = 'khach02');
DECLARE @Cus2 UNIQUEIDENTIFIER = (SELECT TOP 1 UserID FROM Users WHERE Username = 'khach03');

DECLARE @VarATDenM INT = (SELECT TOP 1 VariantID FROM ProductVariants WHERE SKU = 'AT-BASIC-DEN-M');
DECLARE @VarQJXanhL INT = (SELECT TOP 1 VariantID FROM ProductVariants WHERE SKU = 'QJ-SUONG-XANH-L');

-- ==============================================================================
-- 6. INSERT NHÀ CUNG CẤP & ĐƠN VỊ VẬN CHUYỂN
-- ==============================================================================
INSERT INTO [dbo].[Suppliers] (SupplierName, PhoneNumber) 
VALUES (N'Xưởng May Toàn Thắng', '0988777666');
DECLARE @SupToanThang INT = SCOPE_IDENTITY();

INSERT INTO [dbo].[ShippingProviders] (Name, PhoneNumber, Address, IsActive) 
VALUES (N'Giao Hàng Tiết Kiệm', '19001234', N'Hà Nội', 1);
DECLARE @ShipGHTK INT = SCOPE_IDENTITY();

-- ==============================================================================
-- 7. INSERT KẾT QUẢ NHẬP KHO
-- ==============================================================================
INSERT INTO [dbo].[WarehouseReceipts] (SupplierID, EmployeeID, ImportDate, TotalAmount, Status)
VALUES (@SupToanThang, @Emp1, GETDATE() - 10, 18000000, 1);
DECLARE @Receipt1 INT = SCOPE_IDENTITY();

INSERT INTO [dbo].[WarehouseReceiptDetails] (ReceiptID, VariantID, Quantity, ImportPrice)
VALUES 
(@Receipt1, @VarATDenM, 100, 80000), 
(@Receipt1, @VarQJXanhL, 50, 200000);

INSERT INTO [dbo].[InventoryTransactions] (VariantID, TransactionType, QuantityChange, ReceiptID, CreatedAt)
VALUES 
(@VarATDenM, 'IN', 100, @Receipt1, GETDATE() - 10),
(@VarQJXanhL, 'IN', 50, @Receipt1, GETDATE() - 10);

-- ==============================================================================
-- 8. INSERT ĐƠN HÀNG ĐỂ BẮT ĐẦU ĐỒNG BỘ (Sửa khớp mã Enum mới: 4 = Thành công)
-- ==============================================================================
-- ĐƠN HÀNG 1: Đã hoàn thành (Sửa trạng thái cũ từ 3 thành 4)
INSERT INTO [dbo].[Orders] (CustomerID, OrderDate, OrderStatus, ShippingAddress, ReceiverName, ReceiverPhone, TotalMoney, ShippingProviderID, EmployeeID)
VALUES (@Cus1, GETDATE() - 2, 4, N'Gò Vấp, TP.HCM', N'Lê Khách Hàng 2', '0903333333', 500000, @ShipGHTK, @Emp1); 
DECLARE @Order1 INT = SCOPE_IDENTITY();

INSERT INTO [dbo].[OrderDetails] (OrderID, VariantID, Quantity, PriceAtPurchase)
VALUES 
(@Order1, @VarATDenM, 1, 150000),
(@Order1, @VarQJXanhL, 1, 350000);

INSERT INTO [dbo].[Invoices] (OrderID, Amount, PaymentDate, PaymentMethod, TransactionID, Status)
VALUES (@Order1, 500000, GETDATE() - 2, 'VNPay', 'VNP123456789', 3);

INSERT INTO [dbo].[InventoryTransactions] (VariantID, TransactionType, QuantityChange, OrderID, CreatedAt)
VALUES 
(@VarATDenM, 'OUT', -1, @Order1, GETDATE() - 2),
(@VarQJXanhL, 'OUT', -1, @Order1, GETDATE() - 2);

-- ĐƠN HÀNG 2: Đang chờ xử lý (Sửa trạng thái từ số 0 thành số 1 = Chờ duyệt)
INSERT INTO [dbo].[Orders] (CustomerID, OrderDate, OrderStatus, ShippingAddress, ReceiverName, ReceiverPhone, TotalMoney, ShippingProviderID, EmployeeID)
VALUES (@Cus2, GETDATE(), 1, N'Bình Thạnh, TP.HCM', N'Phạm Khách Hàng 3', '0904444444', 300000, @ShipGHTK, NULL); 
DECLARE @Order2 INT = SCOPE_IDENTITY();

INSERT INTO [dbo].[OrderDetails] (OrderID, VariantID, Quantity, PriceAtPurchase)
VALUES (@Order2, @VarATDenM, 2, 150000);

INSERT INTO [dbo].[Invoices] (OrderID, Amount, PaymentDate, PaymentMethod, TransactionID, Status)
VALUES (@Order2, 300000, NULL, 'COD', NULL, 0);
GO

USE [clothesstoremgt]
GO

SET NOCOUNT ON;

DECLARE @EmpID UNIQUEIDENTIFIER = (SELECT TOP 1 UserID FROM Users WHERE Role = 2 ORDER BY NEWID());
DECLARE @ShipID INT = (SELECT TOP 1 ShippingProviderID FROM ShippingProviders ORDER BY NEWID());
DECLARE @SupID INT = (SELECT TOP 1 SupplierID FROM Suppliers ORDER BY NEWID());

PRINT N'Bắt đầu bơm dữ liệu...'

-- ==============================================================================
-- 9. BƠM 20 PHIẾU NHẬP KHO
-- ==============================================================================
DECLARE @i INT = 1;
DECLARE @RandomDate DATETIME;
DECLARE @ReceiptID INT;
DECLARE @VarID INT;
DECLARE @ImportPrice DECIMAL(18,2);
DECLARE @Qty INT;

WHILE @i <= 20
BEGIN
    SET @RandomDate = DATEADD(DAY, -(ABS(CHECKSUM(NEWID()) % 480)), GETDATE());

    INSERT INTO [dbo].[WarehouseReceipts] (SupplierID, EmployeeID, ImportDate, TotalAmount, Status)
    VALUES (@SupID, @EmpID, @RandomDate, ABS(CHECKSUM(NEWID()) % 50000000) + 10000000, 1);
    SET @ReceiptID = SCOPE_IDENTITY();

    SET @VarID = (SELECT TOP 1 VariantID FROM ProductVariants ORDER BY NEWID());
    SET @ImportPrice = ABS(CHECKSUM(NEWID()) % 150000) + 50000;
    SET @Qty = ABS(CHECKSUM(NEWID()) % 100) + 20;

    INSERT INTO [dbo].[WarehouseReceiptDetails] (ReceiptID, VariantID, Quantity, ImportPrice)
    VALUES (@ReceiptID, @VarID, @Qty, @ImportPrice);

    INSERT INTO [dbo].[InventoryTransactions] (VariantID, TransactionType, QuantityChange, ReceiptID, CreatedAt)
    VALUES (@VarID, 'IN', @Qty, @ReceiptID, @RandomDate);

    SET @i = @i + 1;
END

-- ==============================================================================
-- 10. BƠM 100 ĐƠN HÀNG (Sửa loại bỏ hoàn toàn logic random dính số 0 cũ)
-- ==============================================================================
SET @i = 1;
DECLARE @OrderID INT;
DECLARE @CusID UNIQUEIDENTIFIER;
DECLARE @OrderStatus INT;
DECLARE @TotalMoney DECIMAL(18,2);
DECLARE @RandStatus100 INT;

WHILE @i <= 100
BEGIN
    SET @RandomDate = DATEADD(DAY, -(ABS(CHECKSUM(NEWID()) % 480)), GETDATE());
    SET @CusID = (SELECT TOP 1 UserID FROM Users WHERE Role = 3 ORDER BY NEWID());
    
    -- Chia tỷ lệ ngẫu nhiên không chứa số 0 (1 -> Chờ duyệt, 2 -> Đã thanh toán, 3 -> Đang giao, 4 -> Thành công, 5 -> Đã hủy)
    SET @RandStatus100 = ABS(CHECKSUM(NEWID()) % 100);
    IF @RandStatus100 < 50 SET @OrderStatus = 4;      -- Thành công
    ELSE IF @RandStatus100 < 70 SET @OrderStatus = 3; -- Đang giao
    ELSE IF @RandStatus100 < 80 SET @OrderStatus = 2; -- Đã thanh toán
    ELSE IF @RandStatus100 < 90 SET @OrderStatus = 1; -- Chờ duyệt
    ELSE SET @OrderStatus = 5;                        -- Đã hủy

    SET @TotalMoney = ABS(CHECKSUM(NEWID()) % 2000000) + 150000;
    SET @Qty = ABS(CHECKSUM(NEWID()) % 3) + 1;

    INSERT INTO [dbo].[Orders] (CustomerID, OrderDate, OrderStatus, ShippingAddress, ReceiverName, ReceiverPhone, TotalMoney, ShippingProviderID, EmployeeID)
    VALUES (@CusID, @RandomDate, @OrderStatus, N'Địa chỉ khách ' + CAST(@i AS NVARCHAR), N'Khách Random ' + CAST(@i AS NVARCHAR), '0900000000', @TotalMoney, @ShipID, @EmpID);
    SET @OrderID = SCOPE_IDENTITY();

    SET @VarID = (SELECT TOP 1 VariantID FROM ProductVariants ORDER BY NEWID());
    INSERT INTO [dbo].[OrderDetails] (OrderID, VariantID, Quantity, PriceAtPurchase)
    VALUES (@OrderID, @VarID, @Qty, @TotalMoney);

    IF @OrderStatus IN (2, 3, 4)
    BEGIN
        INSERT INTO [dbo].[Invoices] (OrderID, Amount, PaymentDate, PaymentMethod, TransactionID, Status)
        VALUES (@OrderID, @TotalMoney, @RandomDate, 'VNPay', 'TXN' + CAST(@OrderID AS NVARCHAR), 3);

        INSERT INTO [dbo].[InventoryTransactions] (VariantID, TransactionType, QuantityChange, OrderID, CreatedAt)
        VALUES (@VarID, 'OUT', -(@Qty), @OrderID, @RandomDate);
    END
    ELSE
    BEGIN
        INSERT INTO [dbo].[Invoices] (OrderID, Amount, PaymentDate, PaymentMethod, TransactionID, Status)
        VALUES (@OrderID, @TotalMoney, NULL, 'COD', NULL, 0);
    END

    SET @i = @i + 1;
END
GO

USE [clothesstoremgt]
GO

SET NOCOUNT ON;

-- ==============================================================================
-- 11. THÊM DANH MỤC, SẢN PHẨM MỚI & SẢN PHẨM SẮP HẾT KHO (Độ lại SizeID không NULL)
-- ==============================================================================
DECLARE @CatAoKhoac INT = (SELECT TOP 1 CategoryID FROM Categories WHERE CategoryName = N'Áo Khoác');

INSERT INTO [dbo].[Categories] (CategoryName, Description) VALUES (N'Phụ Kiện', N'Mũ, nón, tất, thắt lưng');
DECLARE @CatPhuKien INT = SCOPE_IDENTITY();

DECLARE @ColorDen INT = (SELECT TOP 1 ColorID FROM Colors WHERE ColorName = N'Đen');
DECLARE @ColorTrang INT = (SELECT TOP 1 ColorID FROM Colors WHERE ColorName = N'Trắng');
DECLARE @SizeL INT = (SELECT TOP 1 SizeID FROM Sizes WHERE SizeName = 'L');
DECLARE @SizeFreesize INT = (SELECT TOP 1 SizeID FROM Sizes WHERE SizeName = 'Freesize');

INSERT INTO [dbo].[Products] (ProductName, Description, CategoryID)
VALUES
(N'Áo Khoác Bomber Vải Dù', N'Chống nước nhẹ, form chuẩn', @CatAoKhoac),
(N'Mũ Lưỡi Trai Thể Thao', N'Cotton thoáng khí, logo thêu nổi', @CatPhuKien),
(N'Áo Thun Polo Cổ Bẻ', N'Vải cá sấu thoáng mát, co giãn tốt.', (SELECT TOP 1 CategoryID FROM Categories WHERE CategoryName = N'Áo Thun')),
(N'Quần Short Jean Nam', N'Thích hợp đi chơi mùa hè, rách gối nhẹ.', (SELECT TOP 1 CategoryID FROM Categories WHERE CategoryName = N'Quần Jean')),
(N'Thắt Lưng Da Bò', N'Khóa tự động chống rỉ cao cấp.', @CatPhuKien);

DECLARE @ProBomber INT = (SELECT TOP 1 ProductID FROM Products WHERE ProductName = N'Áo Khoác Bomber Vải Dù');
DECLARE @ProMu INT = (SELECT TOP 1 ProductID FROM Products WHERE ProductName = N'Mũ Lưỡi Trai Thể Thao');
DECLARE @ProPolo INT = (SELECT TOP 1 ProductID FROM Products WHERE ProductName = N'Áo Thun Polo Cổ Bẻ');
DECLARE @ProShort INT = (SELECT TOP 1 ProductID FROM Products WHERE ProductName = N'Quần Short Jean Nam');
DECLARE @ProThatLung INT = (SELECT TOP 1 ProductID FROM Products WHERE ProductName = N'Thắt Lưng Da Bò');

-- Đã sửa: Gán SizeFreesize thay vì gán NULL cho chiếc Mũ và Thắt lưng
INSERT INTO [dbo].[ProductVariants] (ProductID, ColorID, SizeID, SKU, Price, AmountInStock, Img)
VALUES
(@ProBomber, @ColorDen, @SizeL, 'AK-BOMBER-DEN-L', 450000, 50, 'bomber.jpg'),
(@ProMu, @ColorDen, @SizeFreesize, 'PK-MU-DEN', 80000, 200, 'hat.jpg'),
(@ProPolo, @ColorTrang, @SizeL, 'AT-POLO-TRANG-L', 200000, 5, 'polo.jpg'),       -- Tồn kho thấp để test UI
(@ProShort, @ColorDen, @SizeL, 'QJ-SHORT-DEN-L', 250000, 2, 'short.jpg'),      -- Tồn kho thấp để test UI
(@ProThatLung, @ColorDen, @SizeFreesize, 'PK-TL-DEN', 150000, 8, 'belt.jpg');    -- Tồn kho thấp để test UI
GO

USE [clothesstoremgt]
GO

-- ==============================================================================
-- 12. BƠM 40 ĐƠN HÀNG VÀO 2 DANH MỤC MỚI (Sửa mã trạng thái từ 3 thành 4)
-- ==============================================================================
DECLARE @EmpID UNIQUEIDENTIFIER = (SELECT TOP 1 UserID FROM Users WHERE Role = 2 ORDER BY NEWID());
DECLARE @ShipID INT = (SELECT TOP 1 ShippingProviderID FROM ShippingProviders ORDER BY NEWID());
DECLARE @CusID UNIQUEIDENTIFIER;

DECLARE @i INT = 1;
DECLARE @RandomDate DATETIME;
DECLARE @OrderID INT;
DECLARE @VariantToBuy INT;
DECLARE @Price DECIMAL(18,2);

DECLARE @VarBomber INT = (SELECT TOP 1 VariantID FROM ProductVariants WHERE SKU = 'AK-BOMBER-DEN-L');
DECLARE @VarMu INT = (SELECT TOP 1 VariantID FROM ProductVariants WHERE SKU = 'PK-MU-DEN');

PRINT N'Bơm thêm doanh thu cho Áo Khoác và Phụ Kiện...'

WHILE @i <= 40
BEGIN
    SET @RandomDate = DATEADD(DAY, -(ABS(CHECKSUM(NEWID()) % 480)), GETDATE());
    SET @CusID = (SELECT TOP 1 UserID FROM Users WHERE Role = 3 ORDER BY NEWID());
    
    IF (ABS(CHECKSUM(NEWID()) % 2) = 0)
    BEGIN
        SET @VariantToBuy = @VarBomber;
        SET @Price = 450000;
    END
    ELSE
    BEGIN
        SET @VariantToBuy = @VarMu;
        SET @Price = 80000;
    END

    -- Đổi OrderStatus từ 3 thành 4 (Thành công) để gom nhóm thống kê doanh thu chính xác
    INSERT INTO [dbo].[Orders] (CustomerID, OrderDate, OrderStatus, ShippingAddress, ReceiverName, TotalMoney, ShippingProviderID, EmployeeID)
    VALUES (@CusID, @RandomDate, 4, N'Test Danh Mục', N'Khách ' + CAST(@i AS NVARCHAR), @Price, @ShipID, @EmpID);
    SET @OrderID = SCOPE_IDENTITY();

    INSERT INTO [dbo].[OrderDetails] (OrderID, VariantID, Quantity, PriceAtPurchase)
    VALUES (@OrderID, @VariantToBuy, 1, @Price);

    INSERT INTO [dbo].[Invoices] (OrderID, Amount, PaymentDate, PaymentMethod, Status)
    VALUES (@OrderID, @Price, @RandomDate, 'Banking', 3);

    INSERT INTO [dbo].[InventoryTransactions] (VariantID, TransactionType, QuantityChange, OrderID, CreatedAt)
    VALUES (@VariantToBuy, 'OUT', -1, @OrderID, @RandomDate);

    SET @i = @i + 1;
END
GO

USE [clothesstoremgt]
GO

-- ==============================================================================
-- 13. BƠM THÊM 200 ĐƠN HÀNG HOÀN TOÀN ĐA DẠNG TRẠNG THÁI (Mã hóa từ 1 -> 6 chuẩn xác)
-- ==============================================================================
DECLARE @i INT = 1;
DECLARE @RandomDate DATETIME;
DECLARE @OrderID INT;
DECLARE @VarID INT;
DECLARE @Qty INT;
DECLARE @CusID UNIQUEIDENTIFIER;
DECLARE @EmpSale UNIQUEIDENTIFIER;
DECLARE @ShipID INT;
DECLARE @OrderStatus INT;
DECLARE @TotalMoney DECIMAL(18, 2);
DECLARE @RandStatus INT;

PRINT N'Bắt đầu bơm thêm 200 Đơn hàng đa dạng trạng thái...'

WHILE @i <= 200
BEGIN
    SET @RandomDate = DATEADD(DAY, -(ABS(CHECKSUM(NEWID()) % 365)), GETDATE());

    SET @CusID = (SELECT TOP 1 UserID FROM Users WHERE Role = 3 ORDER BY NEWID());
    SET @EmpSale = (SELECT TOP 1 UserID FROM Users WHERE Role = 2 ORDER BY NEWID());
    SET @ShipID = (SELECT TOP 1 ShippingProviderID FROM ShippingProviders ORDER BY NEWID());

    SET @TotalMoney = ABS(CHECKSUM(NEWID()) % 1500000) + 150000;
    SET @Qty = ABS(CHECKSUM(NEWID()) % 3) + 1;

    SET @RandStatus = ABS(CHECKSUM(NEWID()) % 100);
    IF @RandStatus < 40 SET @OrderStatus = 4;      -- 4: Thành công
    ELSE IF @RandStatus < 60 SET @OrderStatus = 3; -- 3: Đang giao
    ELSE IF @RandStatus < 70 SET @OrderStatus = 2; -- 2: Đã thanh toán
    ELSE IF @RandStatus < 80 SET @OrderStatus = 1; -- 1: Chờ duyệt
    ELSE IF @RandStatus < 90 SET @OrderStatus = 5; -- 5: Đã hủy
    ELSE SET @OrderStatus = 6;                     -- 6: Trả hàng

    INSERT INTO [dbo].[Orders] (CustomerID, OrderDate, OrderStatus, ShippingAddress, ReceiverName, ReceiverPhone, TotalMoney, ShippingProviderID, EmployeeID)
    VALUES (@CusID, @RandomDate, @OrderStatus, N'Địa chỉ Random ' + CAST(@i AS NVARCHAR), N'Khách Random ' + CAST(@i AS NVARCHAR), '0900000000', @TotalMoney, @ShipID, @EmpSale);
    SET @OrderID = SCOPE_IDENTITY();

    SET @VarID = (SELECT TOP 1 VariantID FROM ProductVariants ORDER BY NEWID());
    INSERT INTO [dbo].[OrderDetails] (OrderID, VariantID, Quantity, PriceAtPurchase)
    VALUES (@OrderID, @VarID, @Qty, @TotalMoney);

    IF @OrderStatus IN (2, 3, 4) 
    BEGIN
        INSERT INTO [dbo].[Invoices] (OrderID, Amount, PaymentDate, PaymentMethod, TransactionID, Status)
        VALUES (@OrderID, @TotalMoney, @RandomDate, 'EBANK', 'TXN' + CAST(@OrderID AS NVARCHAR), 2);

        INSERT INTO [dbo].[InventoryTransactions] (VariantID, TransactionType, QuantityChange, OrderID, CreatedAt)
        VALUES (@VarID, 'BAN_HANG', -(@Qty), @OrderID, @RandomDate);
    END
    ELSE IF @OrderStatus = 6 
    BEGIN
        INSERT INTO [dbo].[Invoices] (OrderID, Amount, PaymentDate, PaymentMethod, TransactionID, Status)
        VALUES (@OrderID, @TotalMoney, @RandomDate, 'EBANK', 'TXN-REFUND' + CAST(@OrderID AS NVARCHAR), 2);

        INSERT INTO [dbo].[InventoryTransactions] (VariantID, TransactionType, QuantityChange, OrderID, CreatedAt)
        VALUES (@VarID, 'BAN_HANG', -(@Qty), @OrderID, DATEADD(DAY, -2, @RandomDate));

        INSERT INTO [dbo].[InventoryTransactions] (VariantID, TransactionType, QuantityChange, OrderID, CreatedAt)
        VALUES (@VarID, 'TRA_HANG', @Qty, @OrderID, @RandomDate);
    END
    ELSE 
    BEGIN
        INSERT INTO [dbo].[Invoices] (OrderID, Amount, PaymentDate, PaymentMethod, TransactionID, Status)
        VALUES (@OrderID, @TotalMoney, NULL, 'CASH', NULL, 0);
    END

    SET @i = @i + 1;
END

PRINT N'Bơm dữ liệu đồng bộ và hoàn chỉnh thành công!'
GO