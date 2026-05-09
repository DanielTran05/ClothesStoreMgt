USE clothesstoremgt;
GO


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