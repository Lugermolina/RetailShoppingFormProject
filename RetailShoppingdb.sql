-- Retail Shopping System, iteration 3: database RetailShoppingdb on the local SQL Server instance
-- Seven tables: Users, Categories, Products, Customers, Orders, Payments, OrderLines
-- Sample logins: cashier / Cashier123     manager / Manager123     admin / Admin123

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

IF NOT EXISTS (SELECT * FROM Users)
    INSERT INTO Users (userid, username, passwordhash, firstname, lastname, role) VALUES
        (1, 'admin',   '3B612C75A7B5048A435FB6EC81E52FF92D6D795A8B5A9C17070F6A63C97A53B2', 'Sarah',  'Pelletier', 'Admin'),
        (2, 'manager', '61B3AD24336C20515573DC7D875CB9295E8462CEC645C3604AC58F1E241E20E0', 'Nayeli', 'Iqaluk',    'Manager'),
        (3, 'cashier', '17F6AC95A64CE52E0A827F824A7B73C324B2C9A1801E59089FA77F1B3463C0F2', 'Amina',  'Haddad',    'Cashier');
GO

-- child tables are dropped before their parent tables
DROP TABLE IF EXISTS OrderLines;
DROP TABLE IF EXISTS Payments;
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS Customers;
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS Categories;
GO

-- categoryid is also the first digit of the product codes of the category (block sequence code)
CREATE TABLE Categories
(
    categoryid    INT          NOT NULL PRIMARY KEY,
    categoryname  VARCHAR(30)  NOT NULL UNIQUE
);

CREATE TABLE Products
(
    productcode  VARCHAR(10)    NOT NULL PRIMARY KEY,
    productname  VARCHAR(50)    NOT NULL,
    categoryid   INT            NOT NULL FOREIGN KEY REFERENCES Categories(categoryid),
    unitprice    DECIMAL(10,2)  NOT NULL CHECK (unitprice > 0),
    stockqty     INT            NOT NULL CHECK (stockqty >= 0),
    minstock     INT            NOT NULL CHECK (minstock >= 0),
    taxable      BIT            NOT NULL DEFAULT 1
);

-- customer 0 groups the sales to walk in customers
CREATE TABLE Customers
(
    customerid  INT           NOT NULL PRIMARY KEY,
    firstname   VARCHAR(30)   NOT NULL,
    lastname    VARCHAR(30)   NOT NULL,
    address     VARCHAR(100)  NOT NULL DEFAULT '',
    phone       VARCHAR(12)   NOT NULL,
    email       VARCHAR(60)   NOT NULL DEFAULT ''
);

-- userid is NULL for the orders of iteration 1, recorded before the login existed
CREATE TABLE Orders
(
    orderid     INT            NOT NULL PRIMARY KEY,
    orderdate   DATE           NOT NULL,
    customerid  INT            NOT NULL FOREIGN KEY REFERENCES Customers(customerid),
    userid      INT            NULL     FOREIGN KEY REFERENCES Users(userid),
    subtotal    DECIMAL(10,2)  NOT NULL,
    gst         DECIMAL(10,2)  NOT NULL,
    qst         DECIMAL(10,2)  NOT NULL,
    total       DECIMAL(10,2)  NOT NULL
);

-- one payment per order (1:1): the primary key is also the foreign key
CREATE TABLE Payments
(
    orderid      INT            NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES Orders(orderid),
    method       VARCHAR(20)    NOT NULL CHECK (method IN ('Cash', 'Debit card', 'Credit card')),
    amountpaid   DECIMAL(10,2)  NOT NULL,
    changegiven  DECIMAL(10,2)  NOT NULL
);

-- associative entity of the M:N relationship between Orders and Products;
-- unitprice and taxable keep the values of the day of the sale
CREATE TABLE OrderLines
(
    orderid      INT            NOT NULL FOREIGN KEY REFERENCES Orders(orderid),
    productcode  VARCHAR(10)    NOT NULL FOREIGN KEY REFERENCES Products(productcode),
    quantity     INT            NOT NULL CHECK (quantity > 0),
    unitprice    DECIMAL(10,2)  NOT NULL,
    taxable      BIT            NOT NULL,
    PRIMARY KEY (orderid, productcode)
);
GO

-- data conversion: records of customers.txt, products.txt, orders.txt and orderlines.txt
INSERT INTO Categories (categoryid, categoryname) VALUES
    (1, 'Groceries'),
    (2, 'Beverages'),
    (3, 'Household'),
    (4, 'Personal Care'),
    (5, 'Electronics'),
    (6, 'Pantry');

INSERT INTO Products (productcode, productname, categoryid, unitprice, stockqty, minstock, taxable) VALUES
    ('P1001', 'Whole Milk 2L', 1, 5.49, 33, 20, 0),
    ('P1002', 'Brown Eggs 12', 1, 4.99, 28, 10, 0),
    ('P1003', 'Sliced Bread', 1, 3.79, 1, 12, 0),
    ('P1004', 'Butter 454g', 1, 7.49, 20, 8, 0),
    ('P1006', 'Cheddar Cheese 400g', 1, 9.49, 25, 8, 0),
    ('P2001', 'Orange Juice 1.75L', 2, 6.29, 23, 10, 0),
    ('P2002', 'Sparkling Water 12x355ml', 2, 7.99, 17, 8, 1),
    ('P2003', 'Ground Coffee 340g', 2, 11.49, 4, 6, 0),
    ('P3001', 'Dish Soap 740ml', 3, 3.99, 19, 10, 1),
    ('P3002', 'Paper Towels 6 Rolls', 3, 9.99, 0, 5, 1),
    ('P4001', 'Toothpaste 100ml', 4, 2.99, 30, 10, 1),
    ('P4002', 'Shampoo 400ml', 4, 8.49, 14, 6, 1),
    ('P5001', 'AA Batteries 8 Pack', 5, 12.99, 12, 5, 1),
    ('P5002', 'USB-C Cable 1m', 5, 14.99, 3, 4, 1),
    ('P6001', 'Basmati Rice 2kg', 6, 6.49, 30, 10, 0);

INSERT INTO Customers (customerid, firstname, lastname, address, phone, email) VALUES
    (0, 'Walk in', 'customer', '', '', ''),
    (1, 'Sophie', 'Tremblay', '710 Rue Jean-Talon Est, Montreal, QC H2R 1V1', '514-555-0149', 'sophie.tremblay@gmail.com'),
    (2, 'Marc', 'Gagnon', '88 Avenue du Parc, Montreal, QC H2V 4E7', '514-555-0178', 'marc.gagnon@gmail.com'),
    (3, 'Laura', 'Rossi', '5500 Rue Sherbrooke Ouest, Montreal, QC H4A 1W3', '514-555-0193', 'laura.rossi@gmail.com'),
    (4, 'Marie-Pier', 'Heritage', '9820 Avenue Chestnut, Montreal, QC H3L 1A1', '514-341-7845', 'mp.heritage@outlook.com'),
    (5, 'Valeria', 'Alonzo', '4167 Laurier Crescent', '438-555-0164', 'valonz@gmail.com'),
    (6, 'Jerome', 'Bristol', '', '514-303-9190', ''),
    (7, 'Mateo', 'Alonzo', '4167 Laurier Crescent', '438-555-0164', 'mateo.alonzo@gmail.com');

INSERT INTO Orders (orderid, orderdate, customerid, userid, subtotal, gst, qst, total) VALUES
    (1, '2026-09-21', 1, NULL, 31.44, 1.57, 3.14, 36.15),
    (2, '2026-09-22', 2, NULL, 31.53, 1.58, 3.15, 36.25),
    (3, '2026-09-24', 1, NULL, 14.77, 0.74, 1.47, 16.98),
    (4, '2026-09-24', 4, NULL, 2.99, 0.15, 0.30, 3.44),
    (5, '2026-10-13', 2, NULL, 21.96, 0.55, 1.10, 23.60),
    (6, '2026-10-13', 3, NULL, 8.78, 0.00, 0.00, 8.78),
    (7, '2026-10-14', 0, 3, 12.97, 0.40, 0.80, 14.17),
    (8, '2026-10-15', 0, 3, 9.48, 0.20, 0.40, 10.08);

INSERT INTO Payments (orderid, method, amountpaid, changegiven) VALUES
    (1, 'Cash', 40.00, 3.85),
    (2, 'Credit card', 36.25, 0.00),
    (3, 'Cash', 20.00, 3.02),
    (4, 'Cash', 5.00, 1.56),
    (5, 'Cash', 30.00, 6.40),
    (6, 'Debit card', 8.78, 0.00),
    (7, 'Cash', 20.00, 5.83),
    (8, 'Cash', 20.00, 9.92);

INSERT INTO OrderLines (orderid, productcode, quantity, unitprice, taxable) VALUES
    (1, 'P1001', 2, 5.49, 1),
    (1, 'P2003', 1, 11.49, 1),
    (1, 'P4001', 3, 2.99, 1),
    (2, 'P2001', 2, 6.29, 1),
    (2, 'P1003', 5, 3.79, 1),
    (3, 'P1001', 2, 5.49, 1),
    (3, 'P1003', 1, 3.79, 1),
    (4, 'P4001', 1, 2.99, 1),
    (5, 'P1001', 2, 5.49, 0),
    (5, 'P4001', 1, 2.99, 1),
    (5, 'P2002', 1, 7.99, 1),
    (6, 'P1003', 1, 3.79, 0),
    (6, 'P1002', 1, 4.99, 0),
    (7, 'P1002', 1, 4.99, 0),
    (7, 'P3001', 2, 3.99, 1),
    (8, 'P1001', 1, 5.49, 0),
    (8, 'P3001', 1, 3.99, 1);
GO

-- control totals of the conversion, expected from the text files:
-- 6 categories, 15 products, 7 customers plus customer 0, 8 orders, 8 payments, 17 order lines,
-- 28 units sold, sales before taxes 133.92, total sales 149.45
SELECT (SELECT COUNT(*) FROM Categories) AS categories,
       (SELECT COUNT(*) FROM Products) AS products,
       (SELECT COUNT(*) FROM Customers WHERE customerid > 0) AS customers,
       (SELECT COUNT(*) FROM Orders) AS orders,
       (SELECT COUNT(*) FROM Payments) AS payments,
       (SELECT COUNT(*) FROM OrderLines) AS orderlines,
       (SELECT SUM(quantity) FROM OrderLines) AS unitssold,
       (SELECT SUM(subtotal) FROM Orders) AS subtotalsum,
       (SELECT SUM(total) FROM Orders) AS totalsum;
