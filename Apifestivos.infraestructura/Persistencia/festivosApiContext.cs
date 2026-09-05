using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using apiFestivos.dominio;

namespace Apifestivos.infraestructura.Persistencia
{
    public class festivosApiContext : DbContext 
    {
        public festivosApiContext(DbContextOptions<festivosApiContext> options) : base(options)
        {
        }

        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Festivo> Festivos { get; set; }

        protected override void OnModelCreating(ModelBuilder constructor)
        {
            base.OnModelCreating(constructor);

            constructor.Entity<Tipo>(entity =>
            {
               

                entity.HasKey(t => t.Id)
                      .HasName("pkTipo_Id");

                entity.Property(t => t.Id)
                      .ValueGeneratedOnAdd(); 

                entity.Property(t => t.Tipo1)
                      .HasColumnName("Tipo")
                      .IsRequired();
            });

            constructor.Entity<Pais>(entity =>
            {
                entity.ToTable("Pais");

                entity.HasKey(p => p.Id)
                      .HasName("pkPais_Id");

                entity.Property(p => p.Id)
                      .ValueGeneratedOnAdd(); 

                entity.Property(p => p.Nombre)
                      .IsRequired();
            });

            constructor.Entity<Festivo>(entity =>
            {
                entity.ToTable("Festivo");

                entity.HasKey(f => f.Id)
                      .HasName("pkFestivo_Id");

                entity.Property(f => f.Id)
                      .ValueGeneratedOnAdd(); 

                entity.Property(f => f.Nombre)
                      .IsRequired();

                entity.Property(f => f.Dia)
                      .IsRequired();

                entity.Property(f => f.Mes)
                      .IsRequired();

                entity.Property(f => f.DiasPascua)
                      .IsRequired();

                entity.Property(f => f.IdTipo)
                      .IsRequired();

                entity.Property(f => f.IdPais)
                      .IsRequired();

                entity.HasOne(f => f.Tipo)
                      .WithMany(t => t.Festivos)
                      .HasForeignKey(f => f.IdTipo)
                      .HasConstraintName("fkFestivo_Tipo")
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(f => f.Pais)
                      .WithMany(p => p.Festivos)
                      .HasForeignKey(f => f.IdPais)
                      .HasConstraintName("fkFestivo_Pais")
                      .OnDelete(DeleteBehavior.Restrict);
            });

        }

        }
}
