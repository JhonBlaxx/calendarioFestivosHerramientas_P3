using Microsoft.EntityFrameworkCore;
using apiFestivos.dominio.Entidades;

namespace Apifestivos.infraestructura.Datos
{
    public class FestivosDbContext : DbContext
    {
        public FestivosDbContext(DbContextOptions<FestivosDbContext> options) : base(options)
        {
        }

        public DbSet<Pais> Paises { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Festivo> Festivos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pais>().ToTable("Pais");

            modelBuilder.Entity<Tipo>().ToTable("Tipo");
            modelBuilder.Entity<Tipo>().Property(t => t.Nombre).HasColumnName("Tipo");

            modelBuilder.Entity<Festivo>().ToTable("Festivo");

            base.OnModelCreating(modelBuilder);
        }
    }
}
