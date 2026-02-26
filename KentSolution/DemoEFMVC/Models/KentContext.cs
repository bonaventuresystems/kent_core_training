using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoEFMVC.Models;

public partial class KentContext : DbContext
{
    public KentContext()
    {
    }

    public KentContext(DbContextOptions<KentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<VwEcommerceAnalytic> VwEcommerceAnalytics { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VwEcommerceAnalytic>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ECommerceAnalytics");

            entity.Property(e => e.Carrier).HasMaxLength(50);
            entity.Property(e => e.CategoryDescription).HasMaxLength(255);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(50);
            entity.Property(e => e.CustomerCity).HasMaxLength(50);
            entity.Property(e => e.CustomerCountry).HasMaxLength(50);
            entity.Property(e => e.CustomerEmail).HasMaxLength(100);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CustomerName).HasMaxLength(100);
            entity.Property(e => e.CustomerPhone).HasMaxLength(20);
            entity.Property(e => e.Department).HasMaxLength(50);
            entity.Property(e => e.EmployeeEmail).HasMaxLength(100);
            entity.Property(e => e.EmployeeFullName).HasMaxLength(101);
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.LineDiscount).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.LineSubtotal).HasColumnType("decimal(21, 2)");
            entity.Property(e => e.LineTotal).HasColumnType("decimal(26, 4)");
            entity.Property(e => e.LineTrackingNumber).HasMaxLength(50);
            entity.Property(e => e.LoyaltyDiscountValue).HasColumnType("numeric(13, 2)");
            entity.Property(e => e.NetOrderAmount).HasColumnType("decimal(11, 2)");
            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.OrderStatus).HasMaxLength(20);
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.PaymentStatus).HasMaxLength(20);
            entity.Property(e => e.PostalCode).HasMaxLength(20);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(100);
            entity.Property(e => e.ProductUnitPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PromotionName).HasMaxLength(100);
            entity.Property(e => e.RatingTier)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ShippingCost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ShippingId).HasColumnName("ShippingID");
            entity.Property(e => e.ShippingStatus).HasMaxLength(20);
            entity.Property(e => e.ShippingTracking).HasMaxLength(100);
            entity.Property(e => e.StockStatus)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.SupplierName).HasMaxLength(100);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(100)
                .HasColumnName("TransactionID");
            entity.Property(e => e.Warehouse).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
