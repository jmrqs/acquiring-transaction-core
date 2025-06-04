IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'acquiringtransactioncoredb')
BEGIN
    CREATE DATABASE acquiringtransactioncoredb;
END
GO

USE acquiringtransactioncoredb;
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Accounts')
BEGIN
    CREATE TABLE Accounts (
        CustomerId UNIQUEIDENTIFIER NOT NULL,
        AccountId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
        AccountNumber INT NOT NULL,
        AvailableBalance DECIMAL(18,2) NOT NULL,
        ReservedBalance DECIMAL(18,2) NOT NULL,
        CreditLimit DECIMAL(18,2) NOT NULL,
        AccountStatus INT NOT NULL
    );
END;
GO

IF NOT EXISTS (SELECT * FROM Accounts)
BEGIN
    DECLARE @i INT = 1;
    DECLARE @customerId UNIQUEIDENTIFIER;
    DECLARE @accountNumber INT = 1000;

    SET @customerId = NEWID();

    WHILE @i <= 50
    BEGIN
        DECLARE @randomNumber INT = CAST(1 + FLOOR(RAND() * 10) AS INT);

        IF (@i % @randomNumber) = 1
        BEGIN
            SET @customerId = NEWID();
        END

        INSERT INTO Accounts (CustomerId, AccountId, AccountNumber, AvailableBalance, ReservedBalance, CreditLimit, AccountStatus)
        VALUES (
            @customerId,
            NEWID(),
            @accountNumber + @i,
            ROUND(CAST(RAND() * 10000 AS DECIMAL(18,2)), 2),
            ROUND(CAST(RAND() * 1000 AS DECIMAL(18,2)), 2),
            ROUND(CAST(RAND() * 5000 AS DECIMAL(18,2)), 2),
            CASE WHEN @i % 10 = 0 THEN 0 ELSE 1 END
        );

        SET @i = @i + 1;
    END
END;
GO