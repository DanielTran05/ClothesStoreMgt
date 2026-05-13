USE [clothesstoremgt];
GO
--- SP này fix vấn đề ảo profit cho những dòng có giá nhập
CREATE OR ALTER PROC [dbo].[GetRevenueAndProfit]
    @FromDate DATE,
    @ToDate DATE
AS BEGIN
    SELECT 
        MONTH(o.OrderDate) AS [Month], 
        YEAR(o.OrderDate)  AS [Year],
        SUM(od.PriceAtPurchase * od.Quantity) AS Revenue,
        SUM(
            CASE 
                WHEN LatestImport.ImportPrice IS NOT NULL
                THEN (od.PriceAtPurchase - LatestImport.ImportPrice) * od.Quantity
                ELSE NULL  
            END
        ) AS Profit

    FROM Orders o
    JOIN OrderDetails od ON o.OrderID = od.OrderID
    OUTER APPLY (
        SELECT TOP 1 wrd.ImportPrice
        FROM WarehouseReceiptDetails wrd
        JOIN WarehouseReceipts wr ON wrd.ReceiptID = wr.ReceiptID
        WHERE wrd.VariantID = od.VariantID 
          AND wr.ImportDate <= o.OrderDate
        ORDER BY wr.ImportDate DESC
    ) AS LatestImport

    WHERE o.OrderDate >= @FromDate 
      AND o.OrderDate <= @ToDate 
      AND o.OrderStatus = 2
    GROUP BY YEAR(o.OrderDate), MONTH(o.OrderDate)
    ORDER BY [Year], [Month];
END
GO
--- SP này gây vấn đề ảo profit cho những dòng không giá nhập (dùng test case khi chưa có mock data warehouse)
CREATE or ALTER PROC [dbo].[GetRevenueAndProfit]
    @FromDate DATE,
    @ToDate DATE
AS
BEGIN
    SELECT 
        MONTH(o.OrderDate) AS [Month], 
        YEAR(o.OrderDate) AS [Year], 
        SUM(od.PriceAtPurchase * od.Quantity) AS Revenue, 
        SUM((od.PriceAtPurchase - ISNULL(LatestImport.ImportPrice, 0)) * od.Quantity) AS Profit
        
    FROM Orders o
    JOIN OrderDetails od ON o.OrderID = od.OrderID
    OUTER APPLY (
        SELECT TOP 1 wrd.ImportPrice
        FROM WarehouseReceiptDetails wrd
        JOIN WarehouseReceipts wr ON wrd.ReceiptID = wr.ReceiptID
        WHERE wrd.VariantID = od.VariantID 
          AND wr.ImportDate <= o.OrderDate
        ORDER BY wr.ImportDate DESC
    ) AS LatestImport
    
    WHERE o.OrderDate >= @FromDate AND o.OrderDate <= @ToDate 
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
            WHEN 0 THEN N'Chờ duyệt'
            WHEN 1 THEN N'Đang giao'
            WHEN 2 THEN N'Thành công'
            WHEN 3 THEN N'Đã hủy'
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