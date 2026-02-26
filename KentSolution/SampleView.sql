---- CORRECTED: Comprehensive E-Commerce Analytics View (Fixed Syntax Error)
---- The error was on Line 47: "od TrackingNumber AS LineTrackingNumber" 
---- Missing comma before column reference

--CREATE VIEW vw_ECommerceAnalytics AS
--SELECT TOP 100000
--    -- Order Core (5 cols)
--    o.OrderID,
--    o.OrderDate,
--    o.ShipDate,
--    o.Status AS OrderStatus,
--    o.TotalAmount,
    
--    -- Customer Details (9 cols)
--    c.CustomerID,
--    c.CustomerName,
--    c.Email AS CustomerEmail,
--    c.Phone AS CustomerPhone,
--    c.City AS CustomerCity,
--    c.Country AS CustomerCountry,
--    c.PostalCode,
--    c.RegistrationDate,
--    c.LoyaltyPoints,
    
--    -- Employee Details (5 cols)
--    e.EmployeeID,
--    e.FirstName + ' ' + e.LastName AS EmployeeFullName,
--    e.Email AS EmployeeEmail,
--    e.Department,
--    e.Salary,
    
--    -- Product & Category (8 cols)
--    p.ProductID,
--    p.ProductName,
--    p.UnitPrice AS ProductUnitPrice,
--    p.UnitsInStock,
--    cat.CategoryID,
--    cat.CategoryName,
--    cat.Description AS CategoryDescription,
--    s.SupplierName,
    
--    -- Order Line Details (6 cols) - FIXED: Added comma before od.TrackingNumber
--    od.OrderDetailID,
--    od.Quantity,
--    od.Discount AS LineDiscount,
--    od.LineTotal,
--    od.ShippedDate AS LineShippedDate,
--    od.TrackingNumber AS LineTrackingNumber,  -- ← COMMA ADDED HERE
    
--    -- Financial Details (5 cols)
--    pay.PaymentID,
--    pay.Amount AS PaymentAmount,
--    pay.PaymentMethod,
--    pay.Status AS PaymentStatus,
--    pay.TransactionID,
    
--    -- Shipping Details (5 cols)
--    ship.ShippingID,
--    ship.Carrier,
--    ship.TrackingNumber AS ShippingTracking,
--    ship.Status AS ShippingStatus,
--    ship.Cost AS ShippingCost,
    
--    -- Review & Inventory (8 cols)
--    r.ReviewID,
--    r.Rating,
--    r.IsApproved,
--    i.Warehouse,
--    i.Quantity AS InventoryQuantity,
--    i.ReservedQuantity,
--    i.MinStockLevel,
--    prom.PromotionName,
    
--    -- Calculated Business Metrics (7 cols)
--    od.Quantity * p.UnitPrice AS LineSubtotal,
--    o.TotalAmount - o.Freight AS NetOrderAmount,
--    c.LoyaltyPoints * 0.01 AS LoyaltyDiscountValue,
--    DATEDIFF(DAY, o.OrderDate, ISNULL(ship.DeliveredDate, GETDATE())) AS DaysToDeliver,
--    CASE WHEN r.Rating >= 4 THEN 'High' WHEN r.Rating >= 3 THEN 'Medium' ELSE 'Low' END AS RatingTier,
--    CASE WHEN i.Quantity < i.MinStockLevel THEN 'Low Stock' ELSE 'In Stock' END AS StockStatus,
--    ROW_NUMBER() OVER (PARTITION BY c.CustomerID ORDER BY o.OrderDate DESC) AS CustomerOrderRank

--FROM Orders o
--    INNER JOIN Customers c ON o.CustomerID = c.CustomerID
--    INNER JOIN Employees e ON o.EmployeeID = e.EmployeeID
--    INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
--    INNER JOIN Products p ON od.ProductID = p.ProductID
--    INNER JOIN Categories cat ON p.CategoryID = cat.CategoryID
--    INNER JOIN Suppliers s ON p.SupplierID = s.SupplierID
--    LEFT JOIN Payments pay ON o.OrderID = pay.OrderID
--    LEFT JOIN Shipping ship ON o.OrderID = ship.OrderID
--    LEFT JOIN Reviews r ON p.ProductID = r.ProductID AND c.CustomerID = r.CustomerID
--    LEFT JOIN Inventory i ON p.ProductID = i.ProductID
--    LEFT JOIN Promotions prom ON p.ProductID = prom.ProductID OR cat.CategoryID = prom.CategoryID;
--GO


use Kent;
SELECT top(100)* FROM vw_ECommerceAnalytics;
