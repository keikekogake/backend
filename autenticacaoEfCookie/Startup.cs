using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using autenticacaoEfCookie.Dados;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace autenticacaoEfCookie {

    public class Startup {

        public IConfiguration configuration { get; }
        public Startup (IConfiguration configuration) {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc ();
            services.AddDbContext<AutenticacaoContexto> (opt => opt.UseSqlServer (configuration.GetConnectionString ("BancoAutenticacao")));

            // ADICIONA O SERVIÇO DE AUTENTICAÇÃO POR COOKIES
            // SE O USUÁRIO NÃO ESTIVER AUTENTICADO, ELE SERÁ DIRECIONADO PARA A PÁGINA /CONTA/LOGIN
            services.AddAuthentication (CookieAuthenticationDefaults.AuthenticationScheme).AddCookie (options => {
                options.LoginPath = "/Conta/Login";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseAuthentication();

            // ADICIONA UMA ROTA DEFAULT PARA A PÁGINA INDEX
            app.UseMvc (routes => {
                routes.MapRoute (
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}