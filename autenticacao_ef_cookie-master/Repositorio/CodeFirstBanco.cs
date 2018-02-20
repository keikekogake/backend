using System.Linq;
using Autenticacao_EF_Cookie.Models;

namespace Autenticacao_EF_Cookie.Repositorio
{
    public class CodeFirstBanco
    {
        public static void Inicializar(AutenticacaoContexto contexto)
        {
            contexto.Database.EnsureCreated();

            if (contexto.Usuarios.Any()) return;

            var usuario = new Usuario()
            {
                Nome = "Fernando",
                Email = "fernando.guerra@corujasdev.com.br",
                Senha = "123456"
            };

            contexto.Usuarios.Add(usuario);

            var permissao = new Permissao()
            {
                Nome = "Administrador"
            };
            contexto.Permissoes.Add(permissao);

            var usuariopermissao = new UsuariosPermissoes()
            {
                IdUsuario = usuario.IdUsuario,
                IdPermissao = permissao.IdPermissao
            };

            contexto.UsuariosPermissoes.Add(usuariopermissao);
            contexto.SaveChanges();

        }
    }
}