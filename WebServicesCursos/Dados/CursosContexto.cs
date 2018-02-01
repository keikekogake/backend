using Microsoft.EntityFrameworkCore;
using WebServicesCursos.Model;

namespace WebServicesCursos.Dados {
    public class CursosContexto : DbContext {
        public CursosContexto (DbContextOptions<CursosContexto> options) : base (options) {

        }
        public DbSet<Area> Area { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<DataHora> DataHora { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<Area> ().ToTable ("Area");
            modelBuilder.Entity<Curso> ().ToTable ("Curso");
            modelBuilder.Entity<DataHora> ().ToTable ("DataHora");
        }
    }
}