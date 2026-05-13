-- Stored Procedure - Supplier
-- CRUD Supplier
-- GET ALL
CREATE OR ALTER PROC sp_GetSuppliers
AS
BEGIN
    SELECT * FROM Suppliers
END
GO
-- INSERT
CREATE OR ALTER PROC sp_AddSupplier
    @Name NVARCHAR(200),
    @Phone NVARCHAR(20)
AS
BEGIN
    INSERT INTO Suppliers(SupplierName, PhoneNumber)
    VALUES (@Name, @Phone)
END
GO
-- UPDATE
CREATE OR ALTER PROC sp_UpdateSupplier
    @Id INT,
    @Name NVARCHAR(200),
    @Phone NVARCHAR(20)
AS
BEGIN
    UPDATE Suppliers
    SET SupplierName = @Name,
        PhoneNumber = @Phone
    WHERE SupplierID = @Id
END
GO
-- DELETE
CREATE OR ALTER PROC sp_DeleteSupplier
    @Id INT
AS
BEGIN
    DELETE FROM Suppliers WHERE SupplierID = @Id
END
GO
-- Stored Procedure - Nhập kho
CREATE OR ALTER PROC sp_CreateReceipt
    @SupplierId INT,
    @EmployeeId UNIQUEIDENTIFIER
AS
BEGIN
    INSERT INTO WarehouseReceipts(SupplierID, EmployeeID, Status)
    VALUES (@SupplierId, @EmployeeId, 1)

    SELECT SCOPE_IDENTITY()
END
GO

CREATE OR ALTER PROC sp_AddReceiptDetail
    @ReceiptId INT,
    @VariantId INT,
    @Quantity INT,
    @Price DECIMAL(18,2)
AS
BEGIN
    INSERT INTO WarehouseReceiptDetails
    (ReceiptID, VariantID, Quantity, ImportPrice)
    VALUES (@ReceiptId, @VariantId, @Quantity, @Price)
END
GO

-- TRIGGER 
-- Khi nhập kho → tự cộng tồn
CREATE OR ALTER TRIGGER trg_UpdateStock
ON WarehouseReceiptDetails
AFTER INSERT
AS
BEGIN
    UPDATE pv
    SET pv.AmountInStock = pv.AmountInStock + i.Quantity
    FROM ProductVariants pv
    JOIN inserted i ON pv.VariantID = i.VariantID
END
GO

CREATE OR ALTER PROC sp_AddInventoryTransaction
    @VariantID INT,
    @TransactionType NVARCHAR(20),
    @QuantityChange INT,
    @ReceiptID INT
AS
BEGIN
    INSERT INTO InventoryTransactions
    (
        VariantID,
        TransactionType,
        QuantityChange,
        ReceiptID,
        CreatedAt
    )
    VALUES
    (
        @VariantID,
        @TransactionType,
        @QuantityChange,
        @ReceiptID,
        GETDATE()
    )
END
GO

-- INVENTORY FORM (TỒN KHO)
--CREATE OR ALTER PROC sp_GetInventory
--AS
--SELECT p.ProductName, v.AmountInStock, v.Price
--FROM ProductVariants v
--JOIN Products p ON p.ProductID = v.ProductID

--GO
--CREATE OR ALTER PROC sp_TodaySales
--AS
--SELECT 
--    SUM(od.Quantity * od.PriceAtPurchase) AS Total
--FROM Orders o
--JOIN OrderDetails od ON o.OrderID = od.OrderID
--WHERE CAST(o.OrderDate AS DATE) = CAST(GETDATE() AS DATE)

CREATE OR ALTER PROC sp_TodaySales
AS
BEGIN
    SELECT 
        ISNULL(SUM(od.Quantity * od.PriceAtPurchase), 0) AS Total
    FROM Orders o
    JOIN OrderDetails od ON o.OrderID = od.OrderID
    WHERE o.OrderDate >= CAST(GETDATE() AS DATE)
      AND o.OrderDate < DATEADD(DAY, 1, CAST(GETDATE() AS DATE))
END
GO

CREATE OR ALTER PROC sp_GetInventory
AS
BEGIN
    SELECT 
        p.ProductID,
        p.ProductName,
        v.SKU,
        v.AmountInStock,
        v.Price
    FROM ProductVariants v
    JOIN Products p 
        ON p.ProductID = v.ProductID
END
GO

GO
CREATE OR ALTER PROC sp_SearchProductStaff
    @Keyword NVARCHAR(200)
AS
BEGIN
    SELECT 
        v.VariantID,
        p.ProductID,
        p.ProductName,
        v.SKU,
        v.Price,
        v.AmountInStock,

        CASE 
            WHEN v.AmountInStock > 0 
            THEN N'Còn hàng'
            ELSE N'Hết hàng'
        END AS Status

    FROM ProductVariants v

    JOIN Products p 
        ON p.ProductID = v.ProductID

    WHERE p.ProductName LIKE '%' + @Keyword + '%'
       OR v.SKU LIKE '%' + @Keyword + '%'
END
GO
CREATE OR ALTER PROC sp_TodayStatistic
AS
BEGIN
    SELECT
        p.ProductName,

        ISNULL(SUM(
            CASE
                WHEN it.TransactionType = 'SALE'
                THEN it.QuantityChange
                ELSE 0
            END
        ),0) AS SoldQuantity,

        ISNULL(SUM(
            CASE
                WHEN it.TransactionType = 'IMPORT'
                THEN it.QuantityChange
                ELSE 0
            END
        ),0) AS ImportedQuantity

    FROM InventoryTransactions it

    JOIN ProductVariants pv
        ON pv.VariantID = it.VariantID

    JOIN Products p
        ON p.ProductID = pv.ProductID

    WHERE CAST(it.CreatedAt AS DATE) =
          CAST(GETDATE() AS DATE)

    GROUP BY p.ProductName
END
GO

CREATE OR ALTER PROC sp_GetCustomerService
AS
BEGIN
    SELECT *
    FROM CustomerService
    ORDER BY Date DESC
END
GO

CREATE OR ALTER PROC sp_AddCustomerService
    @CustomerID UNIQUEIDENTIFIER,
    @Reason NVARCHAR(500)
AS
BEGIN
    INSERT INTO CustomerService
    (
        CustomerID,
        Reason,
        Date,
        Status
    )
    VALUES
    (
        @CustomerID,
        @Reason,
        GETDATE(),
        0
    )
END
GO

CREATE OR ALTER PROC sp_HandleCustomerService
    @CustomerServiceID INT,
    @EmployeeID UNIQUEIDENTIFIER
AS
BEGIN
    UPDATE CustomerService
    SET
        Status = 1,
        EmployeeID = @EmployeeID
    WHERE CustomerServiceID =
        @CustomerServiceID
END
GO

CREATE OR ALTER PROC sp_RejectCustomerService
    @CustomerServiceID INT,
    @EmployeeID UNIQUEIDENTIFIER
AS
BEGIN
    UPDATE CustomerService
    SET
        Status = 3,
        EmployeeID = @EmployeeID
    WHERE CustomerServiceID =
        @CustomerServiceID
END
GO

CREATE OR ALTER PROC sp_SolveCustomerService
    @CustomerServiceID INT,
    @EmployeeResponse NVARCHAR(MAX),
    @EmployeeID UNIQUEIDENTIFIER
AS
BEGIN
    UPDATE dbo.CustomerService
    SET
        Status = 2,
        EmployeeResponse = @EmployeeResponse,
        ResponseDate = GETDATE(),
        EmployeeID = @EmployeeID
    WHERE CustomerServiceID =
        @CustomerServiceID
END
GO

SELECT *
FROM CustomerService

USE clothesstoremgt
GO

-- Test Chức năng thống kê cơ bản doanh thu hôm nay
SELECT * FROM Products
SELECT * FROM ProductVariants
SELECT * FROM InventoryTransactions

EXEC sp_TodayStatistic

SELECT *
FROM InventoryTransactions

INSERT INTO InventoryTransactions
(
    VariantID,
    TransactionType,
    QuantityChange,
    ReceiptID,
    OrderID,
    CreatedAt
)
VALUES
(1, 'IMPORT', 15, 1, NULL, GETDATE()),

(1, 'SALE', 3, NULL, 1, GETDATE()),

(2, 'IMPORT', 20, 1, NULL, GETDATE()),

(2, 'SALE', 5, NULL, 2, GETDATE())
GO

EXEC sp_TodayStatistic

DECLARE @OrderID INT;

INSERT INTO Orders (OrderDate)
VALUES (GETDATE());

SET @OrderID = SCOPE_IDENTITY();

INSERT INTO OrderDetails (OrderID, VariantID, Quantity, PriceAtPurchase)
VALUES 
(@OrderID, 1, 3, 250000),
(@OrderID, 2, 2, 400000);

EXEC sp_TodaySales