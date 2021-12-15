using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Api.CrossCutting.DependecyInjection;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace application
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

            //Cofigurando motores de DI
            ConfigureService.ConfigureDependeciesService(services);
            ConfigureRepository.ConfigureDependeciesRepository(services);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API - DDD",
                    Version = "v1",
                    Description = "Projeto criado com base no curso API - AspNetCore - DDD",
                    Contact = new OpenApiContact
                    {
                        Name = "Gabriel Silva Rodrigues Mota",
                        Email = "gabriel.rodrigues.mota@outlook.com",
                        Url = new Uri("https://github.com/GabrielRodriguesDev/CSharp-API-DDD.git")
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Asp.Net - DDD");
                    c.RoutePrefix = string.Empty;
                    c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
                });
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
