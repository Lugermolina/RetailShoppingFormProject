-- Retail Shopping System, iteration 2
-- Creates the database RetailShoppingdb and the Users table with three sample users.
-- Run on the local SQL Server instance (SSMS: Execute or F5).
-- The script can be run again: it only creates or converts what is missing and keeps the existing users.
-- Passwords are stored as SHA-256 hashes. Sample logins:
--   cashier / Cashier123     manager / Manager123     admin / Admin123

IF DB_ID('RetailShoppingdb') IS NULL
    CREATE DATABASE RetailShoppingdb;
GO

USE RetailShoppingdb;
GO

IF OBJECT_ID('Users') IS NULL
    CREATE TABLE Users
    (
        userid         INT          NOT NULL PRIMARY KEY,
        username       VARCHAR(30)  NOT NULL UNIQUE,
        passwordhash   CHAR(64)     NOT NULL,
        firstname      VARCHAR(30)  NOT NULL,
        lastname       VARCHAR(30)  NOT NULL,
        role           VARCHAR(10)  NOT NULL CHECK (role IN ('Cashier', 'Manager', 'Admin')),
        failedattempts INT          NOT NULL DEFAULT 0,
        locked         BIT          NOT NULL DEFAULT 0
    );
GO

-- Account lock columns, for a Users table created before the lock feature
IF COL_LENGTH('Users', 'failedattempts') IS NULL
    ALTER TABLE Users ADD failedattempts INT NOT NULL DEFAULT 0;
GO

IF COL_LENGTH('Users', 'locked') IS NULL
    ALTER TABLE Users ADD locked BIT NOT NULL DEFAULT 0;
GO

-- Conversion of the former fullname column into firstname and lastname (first word = first name)
IF COL_LENGTH('Users', 'fullname') IS NOT NULL
BEGIN
    IF COL_LENGTH('Users', 'firstname') IS NULL
        EXEC('ALTER TABLE Users ADD firstname VARCHAR(30) NULL, lastname VARCHAR(30) NULL');
    EXEC('UPDATE Users SET firstname = LEFT(fullname, CHARINDEX('' '', fullname + '' '') - 1),
                           lastname = LTRIM(SUBSTRING(fullname, CHARINDEX('' '', fullname + '' '') + 1, 60))');
    EXEC('ALTER TABLE Users ALTER COLUMN firstname VARCHAR(30) NOT NULL');
    EXEC('ALTER TABLE Users ALTER COLUMN lastname VARCHAR(30) NOT NULL');
    EXEC('ALTER TABLE Users DROP COLUMN fullname');
END
GO

IF NOT EXISTS (SELECT * FROM Users)
    INSERT INTO Users (userid, username, passwordhash, firstname, lastname, role) VALUES
        (1, 'admin',   '3B612C75A7B5048A435FB6EC81E52FF92D6D795A8B5A9C17070F6A63C97A53B2', 'Sarah',  'Pelletier', 'Admin'),
        (2, 'manager', '61B3AD24336C20515573DC7D875CB9295E8462CEC645C3604AC58F1E241E20E0', 'Nayeli', 'Iqaluk',    'Manager'),
        (3, 'cashier', '17F6AC95A64CE52E0A827F824A7B73C324B2C9A1801E59089FA77F1B3463C0F2', 'Amina',  'Haddad',    'Cashier');
GO

SELECT userid, username, firstname, lastname, role, failedattempts, locked FROM Users ORDER BY userid;
