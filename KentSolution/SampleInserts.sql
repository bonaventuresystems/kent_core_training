--WITH Numbers AS (
--    SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n
--    FROM (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) a(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) b(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) c(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0)) d(n)
--)
-- Now populate each table with 10,000 records using realistic sample data generation

-- Categories (10k)
--INSERT INTO Categories (CategoryName, Description, ParentCategoryID, IsActive, UpdatedDate, ImageUrl, SortOrder, MetaTitle)
--SELECT 
--    'Category ' + CAST(n % 100 + 1 AS NVARCHAR(10)),
--    'Description for category ' + CAST(n % 100 + 1 AS NVARCHAR(10)),
--    CASE WHEN n % 20 = 0 THEN NULL ELSE (n % 50) + 1 END,
--    1,
--    DATEADD(DAY, n % 365 * -1, GETDATE()),
--    '/images/cat' + CAST(n % 100 AS NVARCHAR(10)) + '.jpg',
--    n % 200,
--    'Meta ' + CAST(n % 100 AS NVARCHAR(10))
--FROM Numbers WHERE n < 10000;

-- Suppliers (10k)
--WITH Numbers AS (
--    SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n
--    FROM (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) a(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) b(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) c(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0)) d(n)
--)
--INSERT INTO Suppliers (SupplierName, ContactName, Email, Phone, Address, City, Country, Rating)
--SELECT 
--    'Supplier ' + CAST(n % 500 + 1 AS NVARCHAR(10)),
--    'Contact ' + CAST(n % 100 + 1 AS NVARCHAR(10)),
--    'supplier' + CAST(n % 500 AS NVARCHAR(10)) + '@example.com',
--    '+91-' + RIGHT('0000000000' + CAST(n AS NVARCHAR(10)), 10),
--    'Address ' + CAST(n % 200 AS NVARCHAR(10)),
--    'City ' + CAST(n % 50 AS NVARCHAR(10)),
--    CASE n % 5 WHEN 0 THEN 'India' WHEN 1 THEN 'USA' WHEN 2 THEN 'UK' WHEN 3 THEN 'China' ELSE 'Germany' END,
--    CAST(ROUND(RAND(n)*5, 2) AS DECIMAL(3,2))
--FROM Numbers WHERE n < 10000;


--WITH Numbers AS (
--    SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n
--    FROM (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) a(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) b(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) c(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0)) d(n)
--)
---- Products (10k) - depends on Categories and Suppliers (use first 1000 for FKs)
--INSERT INTO Products (ProductName, Description, CategoryID, SupplierID, UnitPrice, UnitsInStock, ReorderLevel, Discontinued, ImageUrl)
--SELECT 
--    'Product ' + CAST(n + 1 AS NVARCHAR(10)),
--    'Detailed product desc ' + CAST(n + 1 AS NVARCHAR(10)),
--    1 + (n % 1000),
--    1 + (n % 1000),
--    CAST(ROUND(10 + RAND(n)*200, 2) AS DECIMAL(10,2)),
--    1 + (n % 500),
--    1 + (n % 100),
--    CASE WHEN n % 10 = 0 THEN 1 ELSE 0 END,
--    '/products/prod' + CAST(n % 10000 AS NVARCHAR(10)) + '.jpg'
--FROM Numbers WHERE n < 10000;

-- Continue similarly for other tables...

--WITH Numbers AS (
--    SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n
--    FROM (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) a(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) b(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) c(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0)) d(n)
--)
---- Customers (10k)
--INSERT INTO Customers (CustomerName, Email, Phone, Address, City, Country, PostalCode, RegistrationDate, LoyaltyPoints)
--SELECT 
--    'Customer ' + CAST(n + 1 AS NVARCHAR(10)),
--    'cust' + CAST(n AS NVARCHAR(10)) + '@gmail.com',
--    '+91-' + RIGHT('0000000000' + CAST(n AS NVARCHAR(10)), 10),
--    '123 Main St ' + CAST(n % 100 AS NVARCHAR(10)),
--    'Pune', -- User's location
--    'India',
--    '411001',
--    DATEADD(DAY, -(n % 1000), GETDATE()),
--    n % 10000
--FROM Numbers WHERE n < 10000;



--WITH Numbers AS (
--    SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n
--    FROM (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) a(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) b(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) c(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0)) d(n)
--)
---- Employees (10k)
---- Continuing from previous script...

---- Employees (10k)
--INSERT INTO Employees (FirstName, LastName, Email, Phone, Salary, Department, ManagerID, IsActive)
--SELECT 
--    CASE (n % 10)
--        WHEN 0 THEN 'Mahesh' WHEN 1 THEN 'Priya' WHEN 2 THEN 'Rahul' WHEN 3 THEN 'Neha' WHEN 4 THEN 'Amit'
--        WHEN 5 THEN 'Sunita' WHEN 6 THEN 'Vikas' WHEN 7 THEN 'Sneha' WHEN 8 THEN 'Rohan' WHEN 9 THEN 'Anjali'
--    END,
--    'Panhale', -- Nod to user
--    LOWER(CASE (n % 10) WHEN 0 THEN 'mahesh' ELSE 'user' END) + CAST(n AS NVARCHAR(10)) + '@company.com',
--    '+91-9' + RIGHT('00000000' + CAST(n AS NVARCHAR(10)), 8),
--    CAST(ROUND(30000 + RAND(n)*70000, 2) AS DECIMAL(10,2)),
--    CASE (n % 5) WHEN 0 THEN 'Sales' WHEN 1 THEN 'IT' WHEN 2 THEN 'HR' WHEN 3 THEN 'Marketing' ELSE 'Finance' END,
--    CASE WHEN n > 100 THEN 1 + (n % 100) ELSE NULL END,
--    1
--FROM Numbers WHERE n < 10000;


--WITH Numbers AS (
--    SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n
--    FROM (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) a(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) b(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) c(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0)) d(n)
--)
---- Orders (10k)
--INSERT INTO Orders (CustomerID, EmployeeID, OrderDate, ShipDate, ShipCity, ShipCountry, Freight, Status, TotalAmount)
--SELECT 
--    1 + (n % 10000),
--    1 + (n % 10000),
--    DATEADD(DAY, -(n % 365), GETDATE()),
--    DATEADD(DAY, -(n % 365) + 2 + (n % 5), GETDATE()),
--    'Pimpri',
--    'India',
--    CAST(ROUND(50 + RAND(n)*500, 2) AS DECIMAL(10,2)),
--    CASE (n % 4) WHEN 0 THEN 'Pending' WHEN 1 THEN 'Shipped' WHEN 2 THEN 'Delivered' ELSE 'Cancelled' END,
--    CAST(ROUND(100 + RAND(n)*2000, 2) AS DECIMAL(10,2))
--FROM Numbers WHERE n < 10000;



--WITH Numbers AS (
--    SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n
--    FROM (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) a(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) b(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) c(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0)) d(n)
--)
---- OrderDetails (10k)
--INSERT INTO OrderDetails (OrderID, ProductID, Quantity, UnitPrice, Discount, ShippedDate, Notes)
--SELECT 
--    1 + (n % 10000),
--    1 + (n % 10000),
--    1 + (n % 10),
--    CAST(ROUND(10 + RAND(n)*100, 2) AS DECIMAL(10,2)),
--    CAST(RAND(n)*0.2 AS DECIMAL(3,2)),
--    DATEADD(DAY, -(n % 30), GETDATE()),
--    'Sample note ' + CAST(n % 100 AS NVARCHAR(10))
--FROM Numbers WHERE n < 10000;



--WITH Numbers AS (
--    SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n
--    FROM (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) a(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) b(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) c(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0)) d(n)
--)
---- Inventory (10k)
--INSERT INTO Inventory (ProductID, Warehouse, Quantity, ReservedQuantity, MinStockLevel, Location, CostPrice, BatchNumber)
--SELECT 
--    1 + (n % 10000),
--    CASE (n % 3) WHEN 0 THEN 'Pune-WH1' WHEN 1 THEN 'Mumbai-WH2' ELSE 'Delhi-WH3' END,
--    50 + (n % 1000),
--    10 + (n % 100),
--    20,
--    'Shelf ' + CAST(n % 100 AS NVARCHAR(10)),
--    CAST(ROUND(5 + RAND(n)*50, 2) AS DECIMAL(10,2)),
--    'BATCH' + FORMAT(GETDATE() - n % 365, 'yyyyMMdd') + RIGHT('000' + CAST(n % 100 AS NVARCHAR(10)), 3)
--FROM Numbers WHERE n < 10000;



--WITH Numbers AS (
--    SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n
--    FROM (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) a(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) b(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) c(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0)) d(n)
--)
---- Payments (10k)
--INSERT INTO Payments (OrderID, Amount, PaymentMethod, TransactionID, Status, Gateway, CardLast4)
--SELECT 
--    1 + (n % 10000),
--    CAST(ROUND(100 + RAND(n)*1500, 2) AS DECIMAL(10,2)),
--    CASE (n % 4) WHEN 0 THEN 'CreditCard' WHEN 1 THEN 'DebitCard' WHEN 2 THEN 'UPI' ELSE 'NetBanking' END,
--    'TXN' + FORMAT(n, '000000'),
--    CASE (n % 3) WHEN 0 THEN 'Completed' WHEN 1 THEN 'Pending' ELSE 'Failed' END,
--    CASE (n % 2) WHEN 0 THEN 'Razorpay' ELSE 'Paytm' END,
--    RIGHT('0000' + CAST(ABS(CHECKSUM(NewId())) % 10000 AS NVARCHAR(10)), 4)
--FROM Numbers WHERE n < 10000;



--WITH Numbers AS (
--    SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n
--    FROM (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) a(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) b(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) c(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0)) d(n)
--)
---- Shipping (10k)
--INSERT INTO Shipping (OrderID, Carrier, TrackingNumber, ShippedDate, DeliveredDate, Cost, Status, Address)
--SELECT 
--    1 + (n % 10000),
--    CASE (n % 3) WHEN 0 THEN 'DTDC' WHEN 1 THEN 'BlueDart' ELSE 'FedEx' END,
--    'TRACK' + FORMAT(n, '000000'),
--    DATEADD(DAY, -(n % 30), GETDATE()),
--    DATEADD(DAY, -(n % 30) + 3 + (n % 3), GETDATE()),
--    CAST(ROUND(20 + RAND(n)*100, 2) AS DECIMAL(10,2)),
--    CASE (n % 3) WHEN 0 THEN 'Shipped' WHEN 1 THEN 'Delivered' ELSE 'InTransit' END,
--    'Shipping Addr Pimpri, Pune'
--FROM Numbers WHERE n < 10000;



--WITH Numbers AS (
--    SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n
--    FROM (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) a(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) b(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) c(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0)) d(n)
--)
---- Reviews (10k)
--INSERT INTO Reviews (ProductID, CustomerID, Rating, ReviewText, IsApproved, HelpfulVotes, Title)
--SELECT 
--    1 + (n % 10000),
--    1 + (n % 10000),
--    1 + (n % 5),
--    'Great product! Rating ' + CAST(1 + (n % 5) AS NVARCHAR(10)),
--    CASE WHEN n % 3 = 0 THEN 1 ELSE 0 END,
--    n % 50,
--    'Title for review ' + CAST(n % 100 AS NVARCHAR(10))
--FROM Numbers WHERE n < 10000;


--WITH Numbers AS (
--    SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n
--    FROM (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) a(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) b(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) c(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0)) d(n)
--)
---- Promotions (10k)
--INSERT INTO Promotions (PromotionName, DiscountPercent, StartDate, EndDate, ProductID, CategoryID, UsageLimit, Code)
--SELECT 
--    'Promo ' + CAST(n % 100 + 1 AS NVARCHAR(10)),
--    CAST(ROUND(5 + RAND(n)*45, 2) AS DECIMAL(5,2)),
--    DATEADD(DAY, -(n % 90), GETDATE()),
--    DATEADD(DAY, 30 - (n % 30), DATEADD(DAY, -(n % 90), GETDATE())),
--    CASE WHEN n % 2 = 0 THEN 1 + (n % 10000) ELSE NULL END,
--    CASE WHEN n % 2 = 1 THEN 1 + (n % 1000) ELSE NULL END,
--    100 + (n % 500),
--    'PROMO' + RIGHT('000' + CAST(n % 1000 AS NVARCHAR(10)), 3)
--FROM Numbers WHERE n < 10000;



--WITH Numbers AS (
--    SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n
--    FROM (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) a(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) b(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) c(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0)) d(n)
--)
---- Coupons (10k)
--INSERT INTO Coupons (Code, DiscountAmount, DiscountPercent, ValidFrom, ValidTo, MinOrderAmount, MaxUses)
--SELECT 
--    'COUPON' + RIGHT('0000' + CAST(n AS NVARCHAR(10)), 4),
--    CAST(ROUND(50 + RAND(n)*200, 2) AS DECIMAL(10,2)),
--    CAST(ROUND(RAND(n)*30, 2) AS DECIMAL(5,2)),
--    DATEADD(DAY, -(n % 60), GETDATE()),
--    DATEADD(DAY, 60 - (n % 60), GETDATE()),
--    CAST(ROUND(500 + RAND(n)*1000, 2) AS DECIMAL(10,2)),
--    1000 + (n % 5000)
--FROM Numbers WHERE n < 10000;



--WITH Numbers AS (
--    SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n
--    FROM (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) a(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) b(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) c(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0)) d(n)
--)
---- Wishlists (10k)
--INSERT INTO Wishlists (CustomerID, ProductID, Notes, Priority)
--SELECT 
--    1 + (n % 10000),
--    1 + (n % 10000),
--    'Wishlist note ' + CAST(n % 50 AS NVARCHAR(10)),
--    n % 5
--FROM Numbers WHERE n < 10000;


--WITH Numbers AS (
--    SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n
--    FROM (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) a(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) b(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) c(n)
--    CROSS JOIN (VALUES(0),(0),(0),(0)) d(n)
--)
---- Logs (10k - but BIGINT for high volume)
--INSERT INTO Logs (TableName, RecordID, Action, OldValue, NewValue, UserID, IPAddress, SessionID)
--SELECT 
--    CASE (n % 7)
--        WHEN 0 THEN 'Orders' WHEN 1 THEN 'Products' WHEN 2 THEN 'Customers' WHEN 3 THEN 'Employees'
--        WHEN 4 THEN 'Reviews' WHEN 5 THEN 'Inventory' ELSE 'Payments'
--    END,
--    1 + (n % 10000),
--    CASE (n % 3) WHEN 0 THEN 'INSERT' WHEN 1 THEN 'UPDATE' ELSE 'DELETE' END,
--    'Old: ' + CAST(n AS NVARCHAR(10)),
--    'New: ' + CAST(n + 1 AS NVARCHAR(10)),
--    1 + (n % 10000),
--    CASE WHEN n % 2 = 0 THEN '192.168.1.' + CAST(n % 255 AS NVARCHAR(10)) ELSE '10.0.0.' + CAST(n % 255 AS NVARCHAR(10)) END,
--    'SESS' + FORMAT(n, '00000')
--FROM Numbers WHERE n < 10000;

-- Script complete! Verify row counts:
-- SELECT TABLE_NAME, SUM(p.rows) AS RowCounts FROM sys.tables t INNER JOIN sys.partitions p ON t.object_id = p.object_id WHERE p.index_id IN (0,1) GROUP BY t.TABLE_NAME ORDER BY RowCounts DESC;

--PRINT 'Sample database created successfully with 15 tables and ~10k records each! [web:3][web:16]';


SELECT * FROM Categories ORDER BY CategoryID;
SELECT * FROM Suppliers ORDER BY SupplierID;
SELECT * FROM Products ORDER BY ProductID;
SELECT * FROM Customers ORDER BY CustomerID;
SELECT * FROM Employees ORDER BY EmployeeID;
SELECT * FROM Orders ORDER BY OrderID;
SELECT * FROM OrderDetails ORDER BY OrderDetailID;
SELECT * FROM Inventory ORDER BY InventoryID;
SELECT * FROM Payments ORDER BY PaymentID;
SELECT * FROM Shipping ORDER BY ShippingID;
SELECT * FROM Reviews ORDER BY ReviewID;
SELECT * FROM Promotions ORDER BY PromotionID;
SELECT * FROM Coupons ORDER BY CouponID;
SELECT * FROM Wishlists ORDER BY WishlistID;
SELECT * FROM Logs ORDER BY LogID;