using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudCarsEsme.Models;

public partial class DbcarsContext : DbContext
{
    public DbcarsContext()
    {
    }

    public DbcarsContext(DbContextOptions<DbcarsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auto> Autos { get; set; }

    public virtual DbSet<MStatus> MStatuses { get; set; }

    public virtual DbSet<Vhstatus> Vhstatuses { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auto>(entity =>
        {
            entity.HasKey(e => e.Idauto).HasName("PK__Autos__31C94F84A3ECC63C");

            entity.Property(e => e.Idauto).HasColumnName("IDauto");
            entity.Property(e => e.Anio)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.ImgRuta).HasColumnType("text");
            entity.Property(e => e.Marca).HasMaxLength(50);
            entity.Property(e => e.MiStatus).HasColumnName("miStatus");
            entity.Property(e => e.Modelo)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MStatus>(entity =>
        {
            entity.HasKey(e => e.Idstatus).HasName("PK__mStatus__8DA2451031FD1D2E");

            entity.ToTable("mStatus");

            entity.Property(e => e.Idstatus).HasColumnName("IDStatus");
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<Vhstatus>(entity =>
        {
            entity.HasKey(e => e.Idstatus).HasName("PK__VHStatus__8DA24510DC990FCF");

            entity.ToTable("VHStatus");

            entity.Property(e => e.Idstatus).HasColumnName("IDStatus");
            entity.Property(e => e.Descripcion).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
