using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ModularRestaurant.Bootstrapper.ExceptionHandling;
using ModularRestaurant.Bootstrapper.Swagger;
using ModularRestaurant.Menus.Api;
using ModularRestaurant.Ratings.Api;
using ModularRestaurant.Shared.Infrastructure.Config;
using Prometheus;
using Serilog;

namespace ModularRestaurant.Bootstrapper
{
    public class Startup
    {
        private const string ConnectionString = "Sql:ConnectionString";
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddExceptionHandling();

            services.AddRouting(x => x.LowercaseUrls = true);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "ModularRestaurant", Version = "v1"});
                c.CustomSchemaIds(x => x.FullName);
                c.OperationFilter<SwaggerFileOperationFilter>();
            });

            services.Configure<AzureStorageOptions>(options => _configuration.GetSection("AzureStorage").Bind(options));

            InitializeModules();
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            var logger = Log.Logger;
            containerBuilder.RegisterInstance(logger).As<ILogger>().SingleInstance();
            
            containerBuilder.RegisterType<MenusExecutor>().As<IMenusExecutor>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<RatingsExecutor>().As<IRatingsExecutor>().InstancePerLifetimeScope();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var container = app.ApplicationServices.GetAutofacRoot();
            
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            
            app.UseExceptionHandling();
            
            app.UseRouting();
            app.UseHttpMetrics();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapMetrics();
            });
            
            InitializeModules();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ModularRestaurant v1");
                c.DefaultModelsExpandDepth(-1);
            });

            //app.UseHttpsRedirection();
        }

        private void InitializeModules()
        {
            AzureStorageOptions azureStorageOptions = new ();
            _configuration.GetSection("AzureStorage").Bind(azureStorageOptions);
            
            MenusStartup.Initialize(_configuration[ConnectionString], azureStorageOptions);
            RatingsStartup.Initialize(_configuration[ConnectionString]);
        }
    }
}