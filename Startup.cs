using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Netfilmes.Business.Servicos.Classes;
using Netfilmes.Business.Servicos.Interfaces;
using Netfilmes.Repository.Interfaces;
using Netfilmes.Repository.Classes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;

namespace Netfilmes
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            
            });

            services.AddScoped<IGeneroService, GeneroService>();
            services.AddScoped<IGeneroDAO, GeneroDAO>();
            services.AddScoped<IFilmeService, FilmeService>();
            services.AddScoped<IFilmeDAO, FilmeDAO>();
            services.AddScoped<ILocacaoService, LocacaoService>();
            services.AddScoped<ILocacaoDAO, LocacaoDAO>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioDAO, UsuarioDAO>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}");
            });
        }
    }
}
