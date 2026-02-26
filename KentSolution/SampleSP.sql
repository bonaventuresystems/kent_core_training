
-- Stored Procedure: GetOrderSummaryReport
-- Joins 6 tables: Orders, Customers, Employees, Products, OrderDetails, Categories
-- Purpose: Comprehensive order report with customer, product category, employee, pricing details

CREATE PROCEDURE GetOrderSummaryReport
    @CustomerID INT = NULL,
    @EmployeeID INT = NULL,
    @StartDate DATETIME2 = NULL,
    @EndDate DATETIME2 = NULL,
    @TopN INT = 1000
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT TOP (@TopN)
        o.OrderID,
        o.OrderDate,
        o.ShipDate,
        o.Status,
        o.TotalAmount,
        o.Freight,
        
        -- Customer Details (Customers table)
        c.CustomerName,
        c.Email AS CustomerEmail,
        c.City AS CustomerCity,
        c.LoyaltyPoints,
        
        -- Employee Details (Employees table)
        e.FirstName + ' ' + e.LastName AS EmployeeName,
        e.Department,
        
        -- Product/Category Details (Products + Categories)
        p.ProductName,
        cat.CategoryName,
        od.Quantity,
        od.UnitPrice,
        od.Discount,
        od.LineTotal,
        
        -- Calculated Fields
        (od.UnitPrice * od.Quantity) AS Subtotal,
        (od.LineTotal * 1.0 / o.TotalAmount * 100) AS LineItemPercent
        
    FROM Orders o
        INNER JOIN Customers c ON o.CustomerID = c.CustomerID
        INNER JOIN Employees e ON o.EmployeeID = e.EmployeeID
        INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
        INNER JOIN Products p ON od.ProductID = p.ProductID
        INNER JOIN Categories cat ON p.CategoryID = cat.CategoryID
        
    WHERE (@CustomerID IS NULL OR o.CustomerID = @CustomerID)
      AND (@EmployeeID IS NULL OR o.EmployeeID = @EmployeeID)
      AND (@StartDate IS NULL OR o.OrderDate >= @StartDate)
      AND (@EndDate IS NULL OR o.OrderDate <= @EndDate)
      
    ORDER BY o.OrderDate DESC, o.TotalAmount DESC;
END;
GO

-- Example usage:
-- EXEC GetOrderSummaryReport;                    -- All recent orders (top 1000)
-- EXEC GetOrderSummaryReport @TopN = 50;         -- Top 50 orders
-- EXEC GetOrderSummaryReport @CustomerID = 1;    -- Orders for Customer 1
-- EXEC GetOrderSummaryReport @StartDate = '2025-01-01'; -- Orders from 2025