USE clothesstoremgt;
GO


CREATE OR ALTER PROCEDURE sp_GetAllCategories
AS
BEGIN
    SELECT CategoryID, CategoryName, Description FROM Categories;
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
    DELETE FROM Sizes WHERE SizeID = @SizeID;
END
GO