using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UESAN.RESERVASPC01.CORE.CORE.Entities;

public partial class ReservaCanchasContext : DbContext
{
    public ReservaCanchasContext()
    {
    }

    public ReservaCanchasContext(DbContextOptions<ReservaCanchasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Canchas> Canchas { get; set; }

    public virtual DbSet<Clientes> Clientes { get; set; }

    public virtual DbSet<HorariosDisponibles> HorariosDisponibles { get; set; }

    public virtual DbSet<Pagos> Pagos { get; set; }

    public virtual DbSet<Reservas> Reservas { get; set; }

    public virtual DbSet<Tarifas> Tarifas { get; set; }

    public virtual DbSet<VwReservasDetalle> VwReservasDetalle { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Jose;Database=ReservaCanchas;Integrated Security =true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Canchas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Canchas__3214EC07981C4523");

            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Tipo).HasMaxLength(50);
            entity.Property(e => e.Ubicacion).HasMaxLength(200);
        });

        modelBuilder.Entity<Clientes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clientes__3214EC07F8E9609C");

            entity.HasIndex(e => e.Email, "UQ__Clientes__A9D1053417F57081").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<HorariosDisponibles>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Horarios__3214EC076BBBB08F");

            entity.HasOne(d => d.Cancha).WithMany(p => p.HorariosDisponibles)
                .HasForeignKey(d => d.CanchaId)
                .HasConstraintName("FK_Horarios_Canchas");
        });

        modelBuilder.Entity<Pagos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pagos__3214EC07E91A1A25");

            entity.HasIndex(e => e.ReservaId, "IX_Pagos_Reserva");

            entity.Property(e => e.FechaPago).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.MetodoPago).HasMaxLength(50);
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Reserva).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.ReservaId)
                .HasConstraintName("FK_Pagos_Reservas");
        });

        modelBuilder.Entity<Reservas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservas__3214EC0734A24C36");

            entity.HasIndex(e => new { e.Fecha, e.CanchaId }, "IX_Reservas_Fecha_Cancha");

            entity.HasOne(d => d.Cancha).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.CanchaId)
                .HasConstraintName("FK_Reservas_Canchas");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservas_Clientes");
        });

        modelBuilder.Entity<Tarifas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tarifas__3214EC07F435B6EC");

            entity.HasIndex(e => e.CanchaId, "UQ__Tarifas__A3D318C95A92FB9B").IsUnique();

            entity.Property(e => e.PrecioHora).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Cancha).WithOne(p => p.Tarifas)
                .HasForeignKey<Tarifas>(d => d.CanchaId)
                .HasConstraintName("FK_Tarifas_Canchas");
        });

        modelBuilder.Entity<VwReservasDetalle>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ReservasDetalle");

            entity.Property(e => e.Cancha).HasMaxLength(100);
            entity.Property(e => e.Cliente).HasMaxLength(100);
            entity.Property(e => e.MetodoPago).HasMaxLength(50);
            entity.Property(e => e.MontoPagado).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TarifaPorHora).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TipoCancha).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
