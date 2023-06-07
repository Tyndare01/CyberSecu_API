CREATE PROCEDURE AuthenticateUser
    @inputEmail NVARCHAR(20),
    @inputPassword NVARCHAR(50)
AS
BEGIN
    
    SELECT USER_ID, firstName, lastName, Email 
    FROM [User]
    WHERE @inputEmail = Email AND [PasswordHash] = HASHBYTES('SHA2_256', CONCAT([Salt], @inputPassword))


END
