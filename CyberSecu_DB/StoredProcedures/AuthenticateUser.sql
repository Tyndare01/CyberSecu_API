CREATE PROCEDURE AuthenticateUser
    @Email NVARCHAR(20),
    @inputPassword NVARCHAR(50)
AS
BEGIN
    DECLARE @storedSalt UNIQUEIDENTIFIER, @storedPasswordHash VARBINARY(64), @computedPasswordHash VARBINARY(64);

    SELECT @storedSalt = Salt, @storedPasswordHash = PasswordHash
    FROM Users
    WHERE @Email = @email;

    SET @computedPasswordHash = HASHBYTES('SHA2_256', CONCAT(@storedSalt, @inputPassword));

    IF @computedPasswordHash = @storedPasswordHash
    BEGIN
        PRINT 'Authentification réussie';
    END
    ELSE
    BEGIN
        PRINT 'Authentification échouée';
    END
END
