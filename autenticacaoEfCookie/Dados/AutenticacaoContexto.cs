using autenticacaoEfCookie.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace autenticacaoEfCookie.Dados {
    public class AutenticacaoContexto : DbContext {
        public AutenticacaoContexto (DbContextOptions<AutenticacaoContexto> options) : base (options) {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Permissao> Permissao { get; set; }
        public DbSet<UsuarioPermissao> UsuariosPermissoes { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<Usuario> ().ToTable ("Usuario");
            modelBuilder.Entity<Permissao> ().ToTable ("Permissao");
            modelBuilder.Entity<UsuarioPermissao> ().ToTable ("UsuarioPermissao");

            base.OnModelCreating(modelBuilder);
        }
    }
}