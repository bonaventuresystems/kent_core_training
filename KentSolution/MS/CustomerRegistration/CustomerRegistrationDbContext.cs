using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CustomerRegistration;

public partial class CustomerRegistrationDbContext : DbContext
{
    public CustomerRegistrationDbContext()
    {
    }

    public CustomerRegistrationDbContext(DbContextOptions<CustomerRegistrationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=CustomerRegistrationDB;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PK__Customer__C1F8DC59B1E18B77");

            entity.ToTable("Customer");

            entity.Property(e => e.Cid).HasColumnName("CID");
            entity.Property(e => e.Cage).HasColumnName("CAGE");
            entity.Property(e => e.Cmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CMAIL");
            entity.Property(e => e.Cname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CNAME");
            entity.Property(e => e.Kycstatus).HasColumnName("KYCSTATUS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
