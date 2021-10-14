using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ModularRestaurant.Bootstrapper.ExceptionHandling;
using ModularRestaurant.Menus.Api;
using ModularRestaurant.Shared.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModularRestaurant.Bootstrapper
{
    public class Startup
    {
        private readonly List<IModule> _modules;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _modules = GetModules();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddExceptionHandling();

            services.AddRouting(x => x.LowercaseUrls = true);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ModularRestaurant", Version = "v1" });
            });

            foreach(var module in _modules)
            {
                module.Register(services);
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseExceptionHandling();

            foreach (var module in _modules)
            {
                module.Use(app);
            }

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ModularRestaurant v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            _modules.Clear();
        }

        //TODO: Problem with controllers
        private List<IModule> GetModules()
        {
            return new List<IModule>()
            {
                new MenusModule()
            };
        }
    }
}
