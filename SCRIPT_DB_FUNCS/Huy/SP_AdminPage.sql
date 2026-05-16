USE [clothesstoremgt]
GO
---------------------- Employee Managemenmt ----------------------
CREATE OR ALTER PROCEDURE [dbo].[sp_CreateEmployee]
    @Username NVARCHAR(50),
    @PasswordHash NVARCHAR(MAX),
    @FullName NVARCHAR(100),
    @Email NVARCHAR(100),
    @PhoneNumber NVARCHAR(20),
    @Address NVARCHAR(MAX),
    @Role INT,
    @IsActive BIT
AS
BEGIN
    INSERT INTO Users (UserID, Username, PasswordHash, FullName, Email, PhoneNumber, Address, Role, IsActive, CreatedAt)
    VALUES (NEWID(), @Username, @PasswordHash, @FullName, @Email, @PhoneNumber, @Address, @Role, @IsActive, GETDATE())
END
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_CheckUsernameExists]
    @Username NVARCHAR(50)
AS
BEGIN
    SELECT COUNT(1) 
    FROM Users 
    WHERE Username = @Username
END
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetAllEmployees]
AS
BEGIN
    SELECT 
        UserID, 
        Username, 
        FullName, 
        Email, 
        PhoneNumber, 
        Address, 
        Role, 
        IsActive, 
        CreatedAt
    FROM Users
    WHERE Role IN (1, 2, 3)
    ORDER BY UserID DESC 
END
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_ToggleUserStatus]
    @UserID UNIQUEIDENTIFIER,
    @IsActive BIT 
AS
BEGIN
    UPDATE Users
    SET IsActive = @IsActive
    WHERE UserID = @UserID
END
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_UpdateEmployee]
    @UserID UNIQUEIDENTIFIER,
    @FullName NVARCHAR(100),
    @Email NVARCHAR(100),
    @PhoneNumber NVARCHAR(20),
    @Address NVARCHAR(MAX),
    @Role INT
AS
BEGIN
    UPDATE Users
    SET FullName = @FullName,
        Email = @Email,
        PhoneNumber = @PhoneNumber,
        Address = @Address,
        Role = @Role
    WHERE UserID = @UserID
END
GO

CREATE OR ALTER PROCEDURE sp_ResetUserPassword
    @UserID UNIQUEIDENTIFIER,
    @PasswordHash NVARCHAR(MAX)
AS
BEGIN
    UPDATE Users SET PasswordHash = @PasswordHash WHERE UserId = @UserID;
END
GO



---------------------- Category Management ----------------------
CREATE OR ALTER PROCEDURE sp_GetAllCategories
AS
BEGIN
    SELECT CategoryID, CategoryName, Description 
    FROM Categories;
END
GO

CREATE OR ALTER PROCEDURE sp_CreateCategory
    @CategoryName NVARCHAR(100),
    @Description NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO Categories (CategoryName, Description)
    VALUES (@CategoryName, @Description);
END
GO

CREATE OR ALTER PROCEDURE sp_UpdateCategory
    @CategoryID INT,
    @CategoryName NVARCHAR(100),
    @Description NVARCHAR(MAX)
AS
BEGIN
    UPDATE Categories
    SET CategoryName = @CategoryName, Description = @Description
    WHERE CategoryID = @CategoryID;
END
GO
        
CREATE OR ALTER PROCEDURE sp_DeleteCategory
    @CategoryID INT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Products WHERE CategoryID = @CategoryID)
    BEGIN
        RAISERROR (N'Lỗi: Không thể xóa! Danh mục này đang chứa sản phẩm. Vui lòng chuyển các sản phẩm sang danh mục khác hoặc xóa sản phẩm trước.', 16, 1);
        RETURN; 
    END
    DELETE FROM Categories WHERE CategoryID = @CategoryID;
END
GO


CREATE OR ALTER PROCEDURE sp_GetAllColors
AS
BEGIN
    SELECT ColorID, ColorName FROM Colors;
END
GO

CREATE OR ALTER PROCEDURE sp_CreateColor
    @ColorName NVARCHAR(50) 
AS
BEGIN   
    INSERT INTO Colors (ColorName) VALUES (@ColorName);
END
GO

CREATE OR ALTER PROCEDURE sp_UpdateColor
    @ColorID INT,
    @ColorName NVARCHAR(50)
AS
BEGIN
    UPDATE Colors SET ColorName = @ColorName WHERE ColorID = @ColorID;
END
GO

CREATE OR ALTER PROCEDURE sp_DeleteColor
    @ColorID INT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM ProductVariants WHERE ColorID = @ColorID)
    BEGIN
        RAISERROR (N'Lỗi: Không thể xóa! Màu sắc này đang được sử dụng bởi một hoặc nhiều biến thể sản phẩm.', 16, 1);
        RETURN;
    END
    DELETE FROM Colors WHERE ColorID = @ColorID;
END
GO


CREATE OR ALTER PROCEDURE sp_GetAllSizes
AS
BEGIN
    SELECT SizeID, SizeName FROM Sizes;
END
GO

CREATE OR ALTER PROCEDURE sp_CreateSize
    @SizeName NVARCHAR(50)
AS
BEGIN
    INSERT INTO Sizes (SizeName) VALUES (@SizeName);
END
GO

CREATE OR ALTER PROCEDURE sp_UpdateSize
    @SizeID INT,
    @SizeName NVARCHAR(50)
AS
BEGIN
    UPDATE Sizes SET SizeName = @SizeName WHERE SizeID = @SizeID;
END
GO

CREATE OR ALTER PROCEDURE sp_DeleteSize
    @SizeID INT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM ProductVariants WHERE SizeID = @SizeID)
    BEGIN
        RAISERROR (N'Lỗi: Không thể xóa! Kích thước này đang được sử dụng bởi một hoặc nhiều biến thể sản phẩm.', 16, 1);
        RETURN;
    END
    DELETE FROM Sizes WHERE SizeID = @SizeID;
END
GO



---------------------- Product & ProductVariant Management ----------------------
CREATE OR ALTER PROCEDURE sp_GetAllProducts
AS
BEGIN
    SELECT 
        p.ProductID, 
        p.ProductName, 
        p.Description, 
        p.CategoryID, 
        c.CategoryName 
    FROM Products p
    LEFT JOIN Categories c ON p.CategoryID = c.CategoryID;
END
GO

CREATE OR ALTER PROCEDURE sp_CreateProduct
    @ProductName NVARCHAR(200),
    @Description NVARCHAR(MAX),
    @CategoryID INT
AS
BEGIN
    INSERT INTO Products (ProductName, Description, CategoryID)
    VALUES (@ProductName, @Description, @CategoryID);
END
GO

CREATE OR ALTER PROCEDURE sp_UpdateProduct
    @ProductID INT,
    @ProductName NVARCHAR(200),
    @Description NVARCHAR(MAX),
    @CategoryID INT
AS
BEGIN
    UPDATE Products
    SET ProductName = @ProductName, 
        Description = @Description, 
        CategoryID = @CategoryID
    WHERE ProductID = @ProductID;
END
GO

CREATE OR ALTER PROCEDURE sp_DeleteProduct
    @ProductID INT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM ProductVariants WHERE ProductID = @ProductID)
    BEGIN
        RAISERROR (N'Lỗi: Không thể xóa! Sản phẩm này đang có các biến thể (SKU) đi kèm. Vui lòng xóa hết các biến thể của sản phẩm này trước.', 16, 1);
        RETURN;
    END
    DELETE FROM Products WHERE ProductID = @ProductID;
END
GO

CREATE OR ALTER PROCEDURE sp_GetVariantsByProductID
    @ProductID INT
AS
BEGIN
    SELECT 
        v.VariantID, 
        v.ProductID, 
        v.ColorID, c.ColorName, 
        v.SizeID, s.SizeName,
        v.SKU, 
        v.Price, 
        v.AmountInStock, 
        v.Img
    FROM ProductVariants v
    LEFT JOIN Colors c ON v.ColorID = c.ColorID
    LEFT JOIN Sizes s ON v.SizeID = s.SizeID
    WHERE v.ProductID = @ProductID;
END
GO

CREATE OR ALTER PROCEDURE sp_CreateVariant
    @ProductID INT,
    @ColorID INT,
    @SizeID INT,
    @SKU NVARCHAR(50),
    @Price DECIMAL(18,2),
    @Img NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO ProductVariants (ProductID, ColorID, SizeID, SKU, Price, AmountInStock, Img)
    VALUES (@ProductID, @ColorID, @SizeID, @SKU, @Price, 0, @Img);
END
GO

CREATE OR ALTER PROCEDURE sp_UpdateVariant
    @VariantID INT,
    @ColorID INT,
    @SizeID INT,
    @SKU NVARCHAR(50),
    @Price DECIMAL(18,2),
    @Img NVARCHAR(MAX)
AS
BEGIN
    UPDATE ProductVariants
    SET ColorID = @ColorID,
        SizeID = @SizeID,
        SKU = @SKU,
        Price = @Price,
        Img = @Img
    WHERE VariantID = @VariantID;
END
GO

CREATE OR ALTER PROCEDURE sp_DeleteVariant
    @VariantID INT
AS
BEGIN
    DELETE FROM ProductVariants WHERE VariantID = @VariantID;
END
GO



---------------------- Customer Management ----------------------
CREATE OR ALTER PROCEDURE sp_GetAllCustomers
AS
BEGIN
    SELECT 
        UserID, 
        Username, 
        PasswordHash, 
        FullName, 
        Email, 
        PhoneNumber, 
        Address, 
        Role, 
        IsActive, 
        CreatedAt
    FROM Users 
    WHERE Role = 4; 
END
GO



---------------------- Stats Management ----------------------
CREATE OR ALTER PROC [dbo].[GetRevenueAndProfit]
    @FromDate DATE,
    @ToDate DATE
AS
BEGIN
    SELECT 
        MONTH(o.OrderDate)  AS [Month],
        YEAR(o.OrderDate)   AS [Year],
        SUM(od.PriceAtPurchase * od.Quantity)  AS Revenue,
        SUM(
            CASE 
                WHEN AvgCost.MAC IS NOT NULL
                THEN (od.PriceAtPurchase - AvgCost.MAC) * od.Quantity
                ELSE NULL  
            END
        ) AS Profit
    FROM Orders o
    JOIN OrderDetails od ON o.OrderID = od.OrderID
    OUTER APPLY (
        SELECT 
            SUM(wrd.ImportPrice * wrd.Quantity) * 1.0 / NULLIF(SUM(wrd.Quantity), 0) AS MAC
        FROM WarehouseReceiptDetails wrd
        JOIN WarehouseReceipts wr ON wrd.ReceiptID = wr.ReceiptID
        WHERE wrd.VariantID = od.VariantID 
          AND wr.ImportDate <= o.OrderDate 
    ) AS AvgCost

    WHERE o.OrderDate  >= @FromDate
      AND o.OrderDate  <= @ToDate
      AND o.OrderStatus = 2
    GROUP BY YEAR(o.OrderDate), MONTH(o.OrderDate)
    ORDER BY [Year], [Month];
END
GO

CREATE OR ALTER PROC [dbo].[GetProductCountByCategory]
    @FromDate DATE,
    @ToDate DATE
AS BEGIN
    SELECT 
        c.CategoryName,
        ISNULL(SUM(od.Quantity), 0) AS TotalVariants
    FROM Categories c
    LEFT JOIN Products p ON c.CategoryID = p.CategoryID
    LEFT JOIN ProductVariants pv ON p.ProductID = pv.ProductID
    LEFT JOIN OrderDetails od ON pv.VariantID = od.VariantID
    LEFT JOIN Orders o ON od.OrderID = o.OrderID
    WHERE (o.OrderStatus = 2
        AND o.OrderDate >= @FromDate 
        AND o.OrderDate <= @ToDate)
        OR o.OrderID IS NULL  
    GROUP BY c.CategoryName
    HAVING ISNULL(SUM(od.Quantity), 0) > 0
END
GO 

CREATE OR ALTER PROC [dbo].[GetTop5Products]
    @FromDate DATE,
    @ToDate DATE,
    @IsBestSeller BIT
AS BEGIN
    IF @IsBestSeller = 1
    BEGIN
        SELECT TOP 5 
            p.ProductID, 
            p.ProductName, 
            SUM(od.Quantity) AS TotalQty
        FROM Orders o
        JOIN OrderDetails od ON o.OrderID = od.OrderID
        JOIN ProductVariants pv ON od.VariantID = pv.VariantID
        JOIN Products p ON pv.ProductID = p.ProductID
        WHERE o.OrderDate >= @FromDate 
          AND o.OrderDate <= @ToDate
          AND o.OrderStatus = 2
        GROUP BY p.ProductID, p.ProductName
        ORDER BY TotalQty DESC;
    END
    ELSE
    BEGIN
        SELECT TOP 5 
            p.ProductID, 
            p.ProductName, 
            ISNULL(SUM(sold.Quantity), 0) AS TotalQty
        FROM Products p
        LEFT JOIN ProductVariants pv ON p.ProductID = pv.ProductID
        LEFT JOIN (
            SELECT od.VariantID, od.Quantity
            FROM OrderDetails od
            JOIN Orders o ON od.OrderID = o.OrderID
            WHERE o.OrderStatus = 2
              AND o.OrderDate >= @FromDate 
              AND o.OrderDate <= @ToDate
        ) AS sold ON pv.VariantID = sold.VariantID
        GROUP BY p.ProductID, p.ProductName
        ORDER BY TotalQty ASC;
    END
END
go

CREATE OR ALTER PROC [dbo].[GetOrderStatus]
    @FromDate DATE,
    @ToDate DATE
AS
BEGIN
    SELECT 
        CASE ISNULL(OrderStatus, 0)
            WHEN 1 THEN N'Chờ duyệt'
            WHEN 2 THEN N'Đã thanh toán'
            WHEN 3 THEN N'Đang giao'
            WHEN 4 THEN N'Thành công'
            WHEN 5 THEN N'Đã hủy'
            WHEN 6 THEN N'Trả hàng'
            ELSE N'Không xác định'
        END AS StatusName, 
        COUNT(OrderID) AS OrderCount
    FROM Orders
    WHERE OrderDate >= @FromDate AND OrderDate <= @ToDate
    GROUP BY ISNULL(OrderStatus, 0);
END
GO


CREATE OR ALTER PROC [dbo].[GetTopEmployees]
    @FromDate DATE,
    @ToDate DATE
AS
BEGIN
    SELECT TOP 5 
        u.UserID, 
        u.FullName, 
        COUNT(o.OrderID) AS OrderCount
    FROM Users u
    JOIN Orders o ON u.UserID = o.EmployeeID 
    WHERE o.OrderDate >= @FromDate AND o.OrderDate <= @ToDate
    GROUP BY u.UserID, u.FullName
    ORDER BY OrderCount DESC;
END
GO

CREATE OR ALTER PROC [dbo].[GetTopSuppliers]
AS
BEGIN
    SELECT TOP 5 
        s.SupplierID, 
        s.SupplierName, 
        COUNT(w.ReceiptID) AS ImportCount
    FROM Suppliers s
    JOIN WarehouseReceipts w ON s.SupplierID = w.SupplierID
    GROUP BY s.SupplierID, s.SupplierName
    ORDER BY ImportCount DESC;
END
GO

CREATE OR ALTER PROC [dbo].[GetLowStockProducts]
    @Threshold INT
AS
BEGIN
    SELECT 
        pv.VariantID, 
        p.ProductName, 
        pv.SKU, 
        pv.AmountInStock
    FROM ProductVariants pv
    JOIN Products p ON pv.ProductID = p.ProductID
    WHERE pv.AmountInStock <= @Threshold
    ORDER BY pv.AmountInStock ASC;
END
GO