using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LoginRedes.Data;
using LoginRedes.Models;
using LoginRedes.Services;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace LoginRedes
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            #region Facebook
            services.AddAuthentication().AddFacebook(facebookOptions => {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });
            #endregion
            

            #region GitHub
            // Criar seu aplicativo em https://developer.github.com
            // abaixar o pacote AspNet.Security.OAuth.GitHub
            // rodar no terminal dotnet add package AspNet.Security.OAuth.GitHub
            //rodar dotnet restore
            // reiniciar o visual studio
            services.AddAuthentication().AddGitHub(githubOptions =>
            {
                githubOptions.ClientId = Configuration["Authentication:GitHub:clientid"];
                githubOptions.ClientSecret = Configuration["Authentication:GitHub:clientSecret"];
            });
                
            #endregion
            
            #region Linkedin
            // Criar seu aplicativo em https://www.linkedin.com/developer/apps
            // abaixar o pacote AspNet.Security.OAuth.LinkedIn
            // rodar no terminal dotnet add package AspNet.Security.OAuth.LinkedIn --version 2.0.0-rc2-final
            //rodar dotnet restore
            // reiniciar o visual studio
            services.AddAuthentication().AddLinkedIn(options =>  
            {  
                options.ClientId = Configuration["Authentication:linkedin:clientid"];  
                options.ClientSecret = Configuration["Authentication:linkedin:clientSecret"];  
            }); 
            #endregion


            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
