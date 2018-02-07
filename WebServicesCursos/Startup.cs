using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using WebServicesCursos.Dados;

namespace WebServicesCursos {
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        IConfiguration Configuration { get; }
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc ();
            services.AddDbContext<CursosContexto> (options => options.UseSqlServer (Configuration.GetConnectionString ("BancoCursosEF")));

            // Instalar o Swashbuckle.AspNetCore do nuget.org
            services.AddSwaggerGen (c => {
                // Cria as informações da documentação Swagger
                c.SwaggerDoc ("v1", new Info {
                    Version = "V1",
                        Title = "Cursos API",
                        Description = "Teste simples",
                        TermsOfService = "None",
                        Contact = new Contact {
                            Name = "Roberto Keike Kogake", 
                            Email = "keike.kogake@gmail.com", 
                            Url = "https://github.com/keikekogake"
                        }
                });
                // Caminho da documentação
                var basePath = AppContext.BaseDirectory;
                // Combina o caminho com o nome do arquivo;
                var xmlPath = Path.Combine (basePath, "CursosOnline.xml");
                // Gera o arquivo Swagger
                c.IncludeXmlComments (xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }
            app.UseMvc ();
            app.UseSwagger ();
            app.UseSwaggerUI (c => {
                c.SwaggerEndpoint ("/swagger/v1/swagger.json", "API V!");
            });
        }
    }
}