using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CsharpCamada.API.Models;

namespace CsharpCamada.API.DAL
{
    public partial class csharpCamadasContext : DbContext
    {
        public csharpCamadasContext()
        {
        }

        public csharpCamadasContext(DbContextOptions<csharpCamadasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Motoristum> Motorista { get; set; } = null!;
        public virtual DbSet<Posto> Postos { get; set; } = null!;
        public virtual DbSet<TiposDeCombustivel> TiposDeCombustivels { get; set; } = null!;
        public virtual DbSet<Veiculo> Veiculos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Chinook");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Motoristum>(entity =>
            {
                entity.HasKey(e => e.MotId)
                    .HasName("PK__Motorist__E07522413BAC5107");

                entity.HasOne(d => d.Vei)
                    .WithMany(p => p.Motorista)
                    .HasForeignKey(d => d.VeiId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Motorista__vei_i__286302EC");
            });

            modelBuilder.Entity<Posto>(entity =>
            {
                entity.HasKey(e => e.PosId)
                    .HasName("PK__Posto__D1A4EB12149F9FCE");
            });

            modelBuilder.Entity<TiposDeCombustivel>(entity =>
            {
                entity.HasKey(e => e.TipoId)
                    .HasName("PK__TiposDeC__94F92001B31D79D6");

                entity.HasOne(d => d.Pos)
                    .WithMany(p => p.TiposDeCombustivels)
                    .HasForeignKey(d => d.PosId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__TiposDeCo__pos_i__2B3F6F97");
            });

            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.HasKey(e => e.VeiId)
                    .HasName("PK__Veiculo__136D0F56530331CC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
