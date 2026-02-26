using System;
using System.Collections.Generic;

namespace DemoEFMVC.Models;

public partial class VwEcommerceAnalytic
{
    public int OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? ShipDate { get; set; }

    public string? OrderStatus { get; set; }

    public decimal? TotalAmount { get; set; }

    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string? CustomerEmail { get; set; }

    public string? CustomerPhone { get; set; }

    public string? CustomerCity { get; set; }

    public string? CustomerCountry { get; set; }

    public string? PostalCode { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public int? LoyaltyPoints { get; set; }

    public int EmployeeId { get; set; }

    public string EmployeeFullName { get; set; } = null!;

    public string? EmployeeEmail { get; set; }

    public string? Department { get; set; }

    public decimal? Salary { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal? ProductUnitPrice { get; set; }

    public int? UnitsInStock { get; set; }

    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? CategoryDescription { get; set; }

    public string SupplierName { get; set; } = null!;

    public int OrderDetailId { get; set; }

    public int? Quantity { get; set; }

    public decimal? LineDiscount { get; set; }

    public decimal? LineTotal { get; set; }

    public DateTime? LineShippedDate { get; set; }

    public string? LineTrackingNumber { get; set; }

    public int? PaymentId { get; set; }

    public decimal? PaymentAmount { get; set; }

    public string? PaymentMethod { get; set; }

    public string? PaymentStatus { get; set; }

    public string? TransactionId { get; set; }

    public int? ShippingId { get; set; }

    public string? Carrier { get; set; }

    public string? ShippingTracking { get; set; }

    public string? ShippingStatus { get; set; }

    public decimal? ShippingCost { get; set; }

    public int? ReviewId { get; set; }

    public int? Rating { get; set; }

    public bool? IsApproved { get; set; }

    public string? Warehouse { get; set; }

    public int? InventoryQuantity { get; set; }

    public int? ReservedQuantity { get; set; }

    public int? MinStockLevel { get; set; }

    public string? PromotionName { get; set; }

    public decimal? LineSubtotal { get; set; }

    public decimal? NetOrderAmount { get; set; }

    public decimal? LoyaltyDiscountValue { get; set; }

    public int? DaysToDeliver { get; set; }

    public string RatingTier { get; set; } = null!;

    public string StockStatus { get; set; } = null!;

    public long? CustomerOrderRank { get; set; }
}
