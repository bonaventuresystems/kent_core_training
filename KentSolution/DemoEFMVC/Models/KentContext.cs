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

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07C46CF01D");

            entity.ToTable("Customer");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
