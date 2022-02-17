using ApiControleFinanceiro.ApiControleFinanceiro.Domain.Middlewares;
using ApiControleFinanceiro.Context;
using ApiControleFinanceiro.Repositories;
using ApiControleFinanceiro.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace ApiControleFinanceiro
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
            services.AddControllers();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", 
                    new OpenApiInfo 
                    { 
                        Title = "api-controle-financeiro", 
                        Version = "v1",
                        Description = "API REST criada com o ASP.NET Core 3.1 para desafio Itaú controle-financeiro",
                        Contact = new OpenApiContact
                        {
                            Name = "Carlos Oliveira",
                            Url = new Uri("https://github.com/DevCarlosOli")
                        }
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);

            });

            services.AddDbContext<DataContext>(option => option.UseNpgsql(Configuration.GetConnectionString("ApiConnection")));

            services.AddScoped<ICategoriaRepository, CategoriaService>();
            services.AddScoped<ISubcategoriaRepository, SubcategoriaService>();
            services.AddScoped<ILancamentoRepository, LancamentoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware(typeof(ErrorMiddleware));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
