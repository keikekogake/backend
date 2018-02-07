using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using autenticacaoEfCookie.Dados;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace autenticacaoEfCookie {
    public class Program {
        public static void Main (string[] args) {
            var ambiente = BuildWebHost (args);

            using (var escopo = ambiente.Services.CreateScope ()) {
                var servico = escopo.ServiceProvider;
                try {
                    var contexto = servico.GetRequiredService<AutenticacaoContexto> ();
                    IniciarBanco.Inicializar (contexto);
                } catch (Exception ex) {
                    var saida = servico.GetRequiredService<ILogger<Program>> ();
                    saida.LogError (ex.Message, " Erro ao criar banco");
                }
            }
        }

        public static IWebHost BuildWebHost (string[] args) =>
            WebHost.CreateDefaultBuilder (args)
            .UseStartup<Startup> ()
            .Build ();
    }
}