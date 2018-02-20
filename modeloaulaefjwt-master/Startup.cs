using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using modeloaulaefjwt_master.Models;
using modeloaulaefjwt_master.Repositorio;
using modelobasicoefjwt.Repositorio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace modelobasicoefjwt {
    public class Startup {
        public IConfiguration configuration { get; }

        public Startup (IConfiguration Configuration) {
            this.configuration = Configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices (IServiceCollection services) {
            services.AddDbContext<AutenticacaoContext> (opt => opt.UseSqlServer (configuration.GetConnectionString ("BancoAutenticacaoEfJwt")));
            services.AddMvc ();

            var signingConfigurations = new SigningConfigurations ();
            services.AddSingleton (signingConfigurations);

            var tokenConfigurations = new TokenConfigurations ();
            new ConfigureFromConfigurationOptions<TokenConfigurations> (configuration.GetSection ("TokenConfigurations")).Configure (tokenConfigurations);

            services.AddSingleton (tokenConfigurations);

            services.AddAuthentication (authOptions => {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer (bearerOptions => {
                var parametrosValidacao = bearerOptions.TokenValidationParameters;
                parametrosValidacao.IssuerSigningKey = signingConfigurations.Key;
                parametrosValidacao.ValidAudience = tokenConfigurations.Audience;
                parametrosValidacao.ValidateIssuerSigningKey = true;
            });

            services.AddAuthorization (auth => {
                auth.AddPolicy ("Bearer", new AuthorizationPolicyBuilder ()
                    .AddAuthenticationSchemes (JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser ().Build ());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }
            app.UseMvc ();
        }
    }
}