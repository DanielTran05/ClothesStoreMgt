USE [clothesstoremgt]
GO

PRINT N'BƯỚC 1: DỌN DẸP DỮ LIỆU GIAO DỊCH CŨ...';
DELETE FROM OrderDetails;
DELETE FROM Orders;
DELETE FROM WarehouseReceiptDetails;
DELETE FROM WarehouseReceipts;

PRINT N'BƯỚC 2: BƠM THÊM NHÂN VIÊN VÀ SẢN PHẨM ĐA DẠNG...';
-- 2.1 Thêm 8 Nhân viên mới (Role = 1) để đua Top
DECLARE @DefaultHash NVARCHAR(MAX) = 'AQAAAAEAACcQAAAA...'; -- Pass ảo, vì ta chỉ cần ID để test đơn hàng
DECLARE @E1 UNIQUEIDENTIFIER = NEWID(), @E2 UNIQUEIDENTIFIER = NEWID(), @E3 UNIQUEIDENTIFIER = NEWID(), @E4 UNIQUEIDENTIFIER = NEWID();
DECLARE @E5 UNIQUEIDENTIFIER = NEWID(), @E6 UNIQUEIDENTIFIER = NEWID(), @E7 UNIQUEIDENTIFIER = NEWID(), @E8 UNIQUEIDENTIFIER = NEWID();

INSERT INTO [dbo].[Users] (UserID, Username, PasswordHash, FullName, Role, IsActive, CreatedAt) VALUES 
(@E1, CAST(NEWID() AS NVARCHAR(50)), @DefaultHash, N'Lê Thị Doanh Thu', 1, 1, GETDATE()),
(@E2, CAST(NEWID() AS NVARCHAR(50)), @DefaultHash, N'Trần Văn Chốt Đơn', 1, 1, GETDATE()),
(@E3, CAST(NEWID() AS NVARCHAR(50)), @DefaultHash, N'Phạm Bán Hàng', 1, 1, GETDATE()),
(@E4, CAST(NEWID() AS NVARCHAR(50)), @DefaultHash, N'Nguyễn Thị Kpi', 1, 1, GETDATE()),
(@E5, CAST(NEWID() AS NVARCHAR(50)), @DefaultHash, N'Hoàng Tháng Máy', 1, 1, GETDATE()),
(@E6, CAST(NEWID() AS NVARCHAR(50)), @DefaultHash, N'Vũ Lên Top', 1, 1, GETDATE()),
(@E7, CAST(NEWID() AS NVARCHAR(50)), @DefaultHash, N'Đặng Bán Ế', 1, 1, GETDATE()),
(@E8, CAST(NEWID() AS NVARCHAR(50)), @DefaultHash, N'Bùi Hủy Đơn', 1, 1, GETDATE());

-- 2.2 Thêm 10 Sản phẩm & Variant đa dạng (Dùng Bảng tạm để lưu ID)
DECLARE @VariantIDs TABLE (VID INT, Price DECIMAL(18,2));

-- Cố tình Insert chay Products để lấy ID sinh ra ngẫu nhiên
INSERT INTO Products (ProductName, CategoryID) VALUES 
(N'Áo Sơ Mi Nam Tay Dài Trắng', 1), (N'Áo Khoác Bomber Vải Dù', 3), 
(N'Quần Tây Nam Dáng Basic', 2), (N'Váy Hoa Nhí Mùa Hè', 1), 
(N'Mũ Bucket Thêu Logo', 1), (N'Áo Hoodie Unisex Form Rộng', 3),
(N'Quần Short Kaki Đi Biển', 2), (N'Áo Len Cổ Lọ Thu Đông', 1),
(N'Đầm Dạ Hội Cúp Ngực', 1), (N'Túi Đeo Chéo Canvas', 1);

-- Thêm 10 Variants tương ứng với giá dao động từ 150k đến 800k
INSERT INTO ProductVariants (ProductID, SKU, Price, AmountInStock)
OUTPUT inserted.VariantID, inserted.Price INTO @VariantIDs
SELECT ProductID, 'SKU-' + CAST(ProductID AS NVARCHAR), 150000 + (ProductID * 50000), 500 
FROM Products WHERE ProductID IN (SELECT TOP 10 ProductID FROM Products ORDER BY ProductID DESC);

PRINT N'BƯỚC 3: TẠO PHIẾU NHẬP KHO ĐẦU NĂM (Để có giá vốn tính lợi nhuận)...';
INSERT INTO WarehouseReceipts (SupplierID, EmployeeID, ImportDate, Status) VALUES (1, @E1, '2024-12-01', 1);
DECLARE @ReceiptID INT = SCOPE_IDENTITY();

-- Giá nhập kho = Giá bán * 0.6 (Lãi 40%)
INSERT INTO WarehouseReceiptDetails (ReceiptID, VariantID, Quantity, ImportPrice)
SELECT @ReceiptID, VID, 1000, Price * 0.6 FROM @VariantIDs;


PRINT N'BƯỚC 4: RẢI NGẪU NHIÊN HÀNG NGÀN ĐƠN HÀNG TỪ 01/2025 ĐẾN 06/2026...';
DECLARE @CurrDate DATE = '2025-01-01';
DECLARE @EndDate DATE = '2026-06-30';
DECLARE @CusID UNIQUEIDENTIFIER = (SELECT TOP 1 UserID FROM Users WHERE Role = 0); -- Lấy đại 1 khách

WHILE @CurrDate <= @EndDate
BEGIN
    -- Mỗi ngày có từ 5 đến 20 đơn hàng ngẫu nhiên
    DECLARE @OrdersPerDay INT = ABS(CHECKSUM(NEWID())) % 16 + 5; 
    DECLARE @i INT = 0;
    
    WHILE @i < @OrdersPerDay
    BEGIN
        -- Lấy 1 nhân viên ngẫu nhiên
        DECLARE @RandEmp UNIQUEIDENTIFIER = (SELECT TOP 1 UserID FROM Users WHERE Role = 1 ORDER BY NEWID());
        
        -- Tỉ lệ đơn: 80% Thành công(2), 10% Chờ duyệt(0), 10% Đã hủy(3)
        DECLARE @RandStatus INT = ABS(CHECKSUM(NEWID())) % 100;
        DECLARE @Status INT = CASE WHEN @RandStatus < 80 THEN 2 WHEN @RandStatus < 90 THEN 0 ELSE 3 END;

        -- Tạo Đơn hàng
        INSERT INTO Orders (CustomerID, OrderDate, OrderStatus, EmployeeID) 
        VALUES (@CusID, @CurrDate, @Status, @RandEmp);
        DECLARE @NewOrderID INT = SCOPE_IDENTITY();
        
        -- Thêm từ 1 đến 4 món hàng vào đơn này
        DECLARE @Lines INT = ABS(CHECKSUM(NEWID())) % 4 + 1;
        DECLARE @j INT = 0;
        WHILE @j < @Lines
        BEGIN
            -- Lấy 1 sản phẩm ngẫu nhiên
            DECLARE @RandVar INT = (SELECT TOP 1 VID FROM @VariantIDs ORDER BY NEWID());
            DECLARE @Price DECIMAL(18,2) = (SELECT Price FROM @VariantIDs WHERE VID = @RandVar);
            DECLARE @RandQty INT = ABS(CHECKSUM(NEWID())) % 3 + 1; -- Mua từ 1-3 cái
            
            -- Tránh trùng Variant trong cùng 1 đơn
            IF NOT EXISTS (SELECT 1 FROM OrderDetails WHERE OrderID = @NewOrderID AND VariantID = @RandVar)
            BEGIN
                INSERT INTO OrderDetails (OrderID, VariantID, Quantity, PriceAtPurchase)
                VALUES (@NewOrderID, @RandVar, @RandQty, @Price);
            END
            SET @j = @j + 1;
        END
        SET @i = @i + 1;
    END
    -- Sang ngày tiếp theo
    SET @CurrDate = DATEADD(DAY, 1, @CurrDate);
END

PRINT N'BƯỚC 5: CHỐT SỔ TỔNG TIỀN CHO TẤT CẢ ĐƠN HÀNG...';
UPDATE o 
SET TotalMoney = ISNULL((SELECT SUM(Quantity * PriceAtPurchase) FROM OrderDetails od WHERE od.OrderID = o.OrderID), 0) 
FROM Orders o;

PRINT N'HOÀN TẤT! DỮ LIỆU ĐÃ SẴN SÀNG ĐỂ BẠN TEST DASHBOARD!';
GO



USE [clothesstoremgt]
GO

-- Lấy lại ID của Nhân viên và Khách hàng mặc định từ script trước
DECLARE @Emp1 UNIQUEIDENTIFIER = '11111111-1111-1111-1111-111111111111';
DECLARE @Cus1 UNIQUEIDENTIFIER = 'AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA';

-- ===================================================================================
-- Bước 1: NHẬP KHO LÔ HÀNG LỚN ĐẦU NĂM 2025 (Để có Giá vốn tính Lợi nhuận cho cả năm)
-- ===================================================================================
INSERT INTO [dbo].[WarehouseReceipts] (SupplierID, EmployeeID, ImportDate, Status)
VALUES (1, @Emp1, '2025-01-01', 1);

DECLARE @BaseReceiptID INT = SCOPE_IDENTITY();

INSERT INTO [dbo].[WarehouseReceiptDetails] (ReceiptID, VariantID, Quantity, ImportPrice)
VALUES 
(@BaseReceiptID, 1, 5000, 100000), -- Nhập 5000 Áo thun (Vốn 100k, Bán 200k)
(@BaseReceiptID, 3, 5000, 200000); -- Nhập 5000 Quần Jean (Vốn 200k, Bán 350k)

-- ===================================================================================
-- Bước 2: TỰ ĐỘNG SINH ĐƠN HÀNG TRẢI DÀI TỪ THÁNG 05/2025 ĐẾN 05/2026 BẰNG VÒNG LẶP
-- ===================================================================================
DECLARE @CurrentDate DATE = '2025-05-01';
DECLARE @EndDate DATE = '2026-05-30';
DECLARE @NewOrderID INT;
DECLARE @RandomQty INT;

WHILE @CurrentDate <= @EndDate
BEGIN
    -- 1. Tạo 1 đơn hàng mới (Status = 2: Thành công)
    INSERT INTO [dbo].[Orders] (CustomerID, OrderDate, OrderStatus, ShippingProviderID, EmployeeID)
    VALUES (@Cus1, @CurrentDate, 2, 1, @Emp1); 
    
    SET @NewOrderID = SCOPE_IDENTITY();
    
    -- 2. Thêm mặt hàng Áo Thun (Bán ngẫu nhiên từ 5 đến 20 cái mỗi đơn)
    SET @RandomQty = CAST(RAND() * 16 + 5 AS INT); 
    INSERT INTO [dbo].[OrderDetails] (OrderID, VariantID, Quantity, PriceAtPurchase)
    VALUES (@NewOrderID, 1, @RandomQty, 200000); 

    -- 3. Thỉnh thoảng (vào các tháng chẵn) khách mua thêm Quần Jean
    IF (MONTH(@CurrentDate) % 2 = 0)
    BEGIN
        SET @RandomQty = CAST(RAND() * 5 + 2 AS INT);
        INSERT INTO [dbo].[OrderDetails] (OrderID, VariantID, Quantity, PriceAtPurchase)
        VALUES (@NewOrderID, 3, @RandomQty, 350000);
    END

    -- 4. Nhảy cóc ngẫu nhiên từ 6 đến 12 ngày để tạo đơn hàng tiếp theo
    SET @CurrentDate = DATEADD(DAY, CAST(RAND() * 7 + 6 AS INT), @CurrentDate);
END

-- ===================================================================================
-- Bước 3: CẬP NHẬT LẠI CỘT TỔNG TIỀN (TotalMoney) CHO TOÀN BỘ ĐƠN HÀNG
-- ===================================================================================
UPDATE o
SET TotalMoney = ISNULL((SELECT SUM(Quantity * PriceAtPurchase) FROM OrderDetails od WHERE od.OrderID = o.OrderID), 0)
FROM Orders o;

PRINT N'Đã bơm thành công kho dữ liệu bán hàng ảo trải dài 12 tháng!';
GO



