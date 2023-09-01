using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Back.Data;

public partial class OriginSolutionsContext : DbContext
{
    public OriginSolutionsContext()
    {
    }

    public OriginSolutionsContext(DbContextOptions<OriginSolutionsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Operacion> Operacions { get; set; }

    public virtual DbSet<Tarjeta> Tarjeta { get; set; }

    public virtual DbSet<TipoOperacion> TipoOperacions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Operacion>(entity =>
        {
            entity.HasKey(e => e.IdOperacion);

            entity.ToTable("Operacion", tb => tb.HasTrigger("RestarSaldo"));

            entity.Property(e => e.Hora).HasColumnType("smalldatetime");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdTarjetaNavigation).WithMany(p => p.Operacions)
                .HasForeignKey(d => d.IdTarjeta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Operacion_Tarjeta");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Operacions)
                .HasForeignKey(d => d.IdTipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Operacion_TipoOperacion");
        });

        modelBuilder.Entity<Tarjeta>(entity =>
        {
            entity.HasKey(e => e.IdTarjeta);

            entity.Property(e => e.Numero).HasMaxLength(50);
            entity.Property(e => e.Pin)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Saldo).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<TipoOperacion>(entity =>
        {
            entity.HasKey(e => e.IdTipo);

            entity.ToTable("TipoOperacion");

            entity.Property(e => e.Descripcion).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
