using ControloFinanceiro.API.Validacoes;
using ControloFinanceiro.API.ViewModels;
using ControloFinanceiro.BLL.Models;
using ControloFinanceiro.DAL;
using ControloFinanceiro.DAL.Interfaces;
using ControloFinanceiro.DAL.Repositorios;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ControloFinanceiro.API
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
            // Contexto
            services.AddDbContext<Contexto>(opcoes => opcoes.UseSqlServer(Configuration.GetConnectionString("ConexaoBD")));

            // Identity
            services.AddIdentity<Utilizador, Funcao>().AddEntityFrameworkStores<Contexto>();

            // Interfaces e Repositorios
            services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddScoped<ITipoRepositorio, TipoRepositorio>();
            services.AddScoped<IFuncaoRepositorio, FuncaoRepositorio>();
            services.AddScoped<IUtilizadorRepositorio, UtilizadorRepositorio>();

            services.AddTransient<IValidator<Categoria>, CategoriaValidator>();
            services.AddTransient<IValidator<FuncoesViewModel>, FuncoesViewModelValidator>();
            services.AddTransient<IValidator<RegistoViewModel>, RegistoViewModelValidator>();

            services.AddCors();

            services.AddSpaStaticFiles(diretorio =>
            {
                diretorio.RootPath = "ControloFinanceiro-UI";
            });

            // Para API ignorar valores nulos -> .AddJsonOptions(opcoes => opcoes.JsonSerializerOptions.IgnoreNullValues = true)
            services.AddControllers()
                .AddFluentValidation()
                .AddJsonOptions(opcoes =>
                {
                    opcoes.JsonSerializerOptions.IgnoreNullValues = true;
                })
                // para ignorar referencias https://pt.stackoverflow.com/questions/123121/refer%C3%AAncia-circular-entre-dois-projetos
                .AddNewtonsoftJson(opcoes =>
                {
                    opcoes.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseCors(opcoes => opcoes.AllowAnyOrigin().AllowAnyMethod().AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseSpaStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                // combinar o atual diretorio com o diretorio do angular ("ControloFinanceiro")
                spa.Options.SourcePath = Path.Combine(Directory.GetCurrentDirectory(), "ControloFinanceiro-UI");

                // para executar o angular e a api juntos
                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer($"http://localhost:4200/");
                }

            });


        }
    }
}
