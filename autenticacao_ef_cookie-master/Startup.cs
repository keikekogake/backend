using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autenticacao_EF_Cookie.Repositorio;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Autenticacao_EF_Cookie
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AutenticacaoContexto>(opt => opt.UseSqlServer(Configuration.GetConnectionString("BancoCursosOnline")));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options => {
                        options.LoginPath = "/Conta/Login";
                    });

            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template:"{controller=Financeiro}/{action=Index}/{id?}");
            });
        }
    }
}
