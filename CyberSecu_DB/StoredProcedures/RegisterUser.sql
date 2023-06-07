CREATE PROCEDURE RegisterUser
    @Email NVARCHAR(50),
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @password NVARCHAR(50)

AS
BEGIN
    DECLARE @salt NVARCHAR, @passwordHash VARBINARY(64);

    SET @salt = NEWID(); -- Génère un nouveau sel
    SET @passwordHash = HASHBYTES('SHA2_256', CONCAT(@salt, @password)); -- Hache le mot de passe salé

    INSERT INTO [User] (Email,FirstName, LastName, Salt, PasswordHash)
    VALUES (@Email, @FirstName, @LastName, @salt, @passwordHash);
END
