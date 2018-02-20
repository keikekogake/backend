using System;
using System.Linq;
using modelobasicoefjwt.Models;

namespace modelobasicoefjwt.Repositorio {
    public class CodeFirstBanco {
        public static void Inicializar (AutenticacaoContext contexto) {

            if (contexto.Usuarios.Any ()) return;

            var usuario = new Usuario () {
                Nome = "Fernando",
                Email = "fernando.guerra@corujasdev.com.br",
                Senha = "123456",
                DataNascimento = Convert.ToDateTime("01-04-1991"),
                Cpf = "403.142.568-65"
            };

            contexto.Usuarios.Add (usuario);

            var permissao = new Permissao () {
                Nome = "Conversor"
            };

            contexto.Permissoes.Add (permissao);

            var usuariopermissao = new UsuarioPermissao () {
                IdUsuario = usuario.IdUsuario,
                IdPermissao = permissao.IdPermissao
            };

            contexto.UsuariosPermissoes.Add (usuariopermissao);
            contexto.SaveChanges ();

        }
    }
}