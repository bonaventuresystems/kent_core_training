using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PFAPI.Models;

public partial class Jddb2Context : DbContext
{
    public Jddb2Context()
    {
    }

    public Jddb2Context(DbContextOptions<Jddb2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Pf> Pfs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=JDDB2;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pf>(entity =>
        {
            entity.HasKey(e => e.Pfacno).HasName("PK__PF__7C9277C8833E6191");

            entity.ToTable("PF");

            entity.Property(e => e.Pfacno).HasColumnName("PFACNo");
            entity.Property(e => e.Cno).HasColumnName("CNo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
