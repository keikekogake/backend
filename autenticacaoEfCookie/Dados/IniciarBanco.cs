using System;
using System.Linq;
using autenticacaoEfCookie.Models;

namespace autenticacaoEfCookie.Dados {
    public class IniciarBanco {
        public static void Inicializar (AutenticacaoContexto contexto) {
            contexto.Database.EnsureCreated ();

            if (contexto.Usuario.Any ()) {
                return;
            }
            var usuario = new Usuario () {
                Nome = "Keike Kogake",
                Email = "keike.kogake@gmail.com",
                Senha = "k300512k@"
            };
            contexto.Usuario.Add (usuario);

            var permissao = new Permissao () {
                Nome = "Financeiro"
            };
            contexto.Permissao.Add (permissao);

            var usuarioPermissao = new UsuarioPermissao () {
                IdUsuario = usuario.Id,
                IdPermissao = permissao.Id
            };
            contexto.UsuariosPermissoes.Add (usuarioPermissao);

            contexto.SaveChanges();
        }
    }
}