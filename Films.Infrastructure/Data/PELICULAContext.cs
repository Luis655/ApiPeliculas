using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiLibros.Domain.Data
{
    public partial class PELICULAContext : DbContext
    {
        public PELICULAContext()
        {
        }

        public PELICULAContext(DbContextOptions<PELICULAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Datospelicula> Datospeliculas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-QFEKVLB1\\FERNS;Initial Catalog=PELICULA;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Datospelicula>(entity =>
            {
                entity.HasKey(e => e.Idpelicula)
                    .HasName("PK_IDPELICULA");

                entity.ToTable("DATOSPELICULAS");

                entity.Property(e => e.Idpelicula).HasColumnName("IDPELICULA");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TITULO");

                entity.Property(e => e.Director)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DIRECTOR");

                entity.Property(e => e.Fechalanzamiento)
                    .HasColumnType("date")
                    .HasColumnName("FECHALANZAMIENTO");

                entity.Property(e => e.Genero)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GENERO");

                entity.Property(e => e.Puntuacion).HasColumnName("PUNTUACION");

                entity.Property(e => e.Rating)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RATING");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
