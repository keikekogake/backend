using Autenticacao_EF_Cookie.Models;
using Microsoft.EntityFrameworkCore;

namespace Autenticacao_EF_Cookie.Repositorio
{
    public class AutenticacaoContexto : DbContext
    {
        public AutenticacaoContexto(DbContextOptions<AutenticacaoContexto> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios  {get;set;}

        public DbSet<Permissao> Permissoes  {get;set;}
 
        public DbSet<UsuariosPermissoes> UsuariosPermissoes  {get;set;}
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Permissao>().ToTable("Permissoes");
            modelBuilder.Entity<UsuariosPermissoes>().ToTable("UsuariosPermissoes");


            base.OnModelCreating(modelBuilder);
        }
    }
}