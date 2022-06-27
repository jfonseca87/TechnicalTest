using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ReservasRepository.Models;

namespace ReservasRepository.Implementaciones
{
    public partial class ReservashotelContext : DbContext
    {
        public ReservashotelContext()
        {
        }

        public ReservashotelContext(DbContextOptions<ReservashotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Habitacion> Habitacion { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Habitacion>(entity =>
            {
                entity.HasKey(e => e.Idhabitacion)
                    .HasName("PK__Habitaci__2B83BE8AA1CE3C8E");

                entity.Property(e => e.Idhabitacion).HasColumnName("idhabitacion");

                entity.Property(e => e.Descripcion).HasColumnName("descripcion");

                entity.Property(e => e.Idhotel).HasColumnName("idhotel");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .HasColumnName("tipo");

                entity.HasOne(d => d.IdhotelNavigation)
                    .WithMany(p => p.Habitacion)
                    .HasForeignKey(d => d.Idhotel)
                    .HasConstraintName("FK__Habitacio__idhot__29572725");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.HasKey(e => e.Idhotel)
                    .HasName("PK__Hotel__C03CFD55774E9CBD");

                entity.Property(e => e.Idhotel).HasColumnName("idhotel");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion).HasColumnName("descripcion");

                entity.Property(e => e.Latitud)
                    .HasMaxLength(100)
                    .HasColumnName("latitud");

                entity.Property(e => e.Longitud)
                    .HasMaxLength(100)
                    .HasColumnName("longitud");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Numerohabitaciones).HasColumnName("numerohabitaciones");

                entity.Property(e => e.Pais)
                    .HasMaxLength(100)
                    .HasColumnName("pais");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.Idreserva)
                    .HasName("PK__Reserva__7326DE2084F9A06E");

                entity.Property(e => e.Idreserva).HasColumnName("idreserva");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Fechaentrada)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaentrada");

                entity.Property(e => e.Fechareserva)
                    .HasColumnType("datetime")
                    .HasColumnName("fechareserva");

                entity.Property(e => e.Fechasalida)
                    .HasColumnType("datetime")
                    .HasColumnName("fechasalida");

                entity.Property(e => e.Idhabitacion).HasColumnName("idhabitacion");

                entity.Property(e => e.Idhotel).HasColumnName("idhotel");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.HasOne(d => d.IdhabitacionNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.Idhabitacion)
                    .HasConstraintName("FK__Reserva__idhabit__2E1BDC42");

                entity.HasOne(d => d.IdhotelNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.Idhotel)
                    .HasConstraintName("FK__Reserva__idhotel__2D27B809");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("FK__Reserva__idusuar__2C3393D0");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("PK__Usuario__080A97430DF1E88E");

                entity.HasIndex(e => e.Mail, "UQ__Usuario__7A21290482B643EB")
                    .IsUnique();

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .HasColumnName("direccion");

                entity.Property(e => e.Mail)
                    .HasMaxLength(150)
                    .HasColumnName("mail");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}