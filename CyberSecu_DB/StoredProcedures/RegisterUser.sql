CREATE PROCEDURE RegisterUser
    @Email NVARCHAR(50),
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @password NVARCHAR(50)

AS
BEGIN
    DECLARE @salt UNIQUEIDENTIFIER, @passwordHash VARBINARY(64);

    SET @salt = NEWID(); -- Génère un nouveau sel
    SET @passwordHash = HASHBYTES('SHA2_256', CONCAT(@salt, @password)); -- Hache le mot de passe salé

    INSERT INTO Users (UserName, Salt, PasswordHash)
    VALUES (@userName, @salt, @passwordHash);
END
