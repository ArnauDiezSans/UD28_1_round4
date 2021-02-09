using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UD28_1_round4.Models
{
    public partial class UD28_1Context : DbContext
    {

        public UD28_1Context(DbContextOptions<UD28_1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Piezas> Piezas { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<Suministra> Suministra { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Piezas>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__Piezas__06370DAD2A5293E2");

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Proveedores>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Suministra>(entity =>
            {
                entity.HasKey(e => new { e.CodigoPieza, e.IdProveedor });

                entity.Property(e => e.IdProveedor)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.CodigoPiezaNavigation)
                    .WithMany(p => p.Suministra)
                    .HasForeignKey(d => d.CodigoPieza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Suministr__Codig__3A81B327");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Suministra)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Suministr__IdPro__3B75D760");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CC4CC7E407FA");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAlta)
                    .HasColumnName("Fecha_alta")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
