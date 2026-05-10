USE clothesstoremgt;
GO

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