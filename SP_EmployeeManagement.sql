USE [clothesstoremgt]
GO

CREATE PROCEDURE [dbo].[sp_CreateEmployee]
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

CREATE PROCEDURE [dbo].[sp_CheckUsernameExists]
    @Username NVARCHAR(50)
AS
BEGIN
    SELECT COUNT(1) 
    FROM Users 
    WHERE Username = @Username
END
GO

CREATE PROCEDURE [dbo].[sp_GetAllEmployees]
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

CREATE PROCEDURE [dbo].[sp_ToggleUserStatus]
    @UserID UNIQUEIDENTIFIER,
    @IsActive BIT 
AS
BEGIN
    UPDATE Users
    SET IsActive = @IsActive
    WHERE UserID = @UserID
END
GO

CREATE PROCEDURE [dbo].[sp_UpdateEmployee]
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