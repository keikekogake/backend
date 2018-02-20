using Autenticacao_EF_JWT.Models;
using Microsoft.EntityFrameworkCore;

namespace Autenticacao_EF_JWT.Dados
{
    public class AutenticacaoContexto : DbContext
    {
        public AutenticacaoContexto(DbContextOptions<AutenticacaoContexto> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios  {get;set;}

        public DbSet<Permissao> Permissoes  {get;set;}
 
        public DbSet<UsuarioPermissao> UsuariosPermissoes  {get;set;}
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Permissao>().ToTable("Permissoes");
            modelBuilder.Entity<UsuarioPermissao>().ToTable("UsuariosPermissoes");


            base.OnModelCreating(modelBuilder);
        }
    }
}