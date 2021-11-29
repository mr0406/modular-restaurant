using Autofac;
using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Menus.Api.IoCModules;
using ModularRestaurant.Menus.Application.Services;
using ModularRestaurant.Menus.Domain.Services;
using ModularRestaurant.Menus.Infrastructure.EF;
using ModularRestaurant.Menus.Infrastructure.Services;
using ModularRestaurant.Shared.Infrastructure.Config;
using Serilog;

namespace ModularRestaurant.Menus.Api
{
    public static class MenusStartup
    {
        private static IContainer _container;

        public static void Initialize(string connectionString, AzureStorageOptions azureStorageOptions)
        {
            ConfigureCompositionRoot(connectionString, azureStorageOptions);
            ApplyMigrations();
        }

        private static void ConfigureCompositionRoot(string connectionString, AzureStorageOptions azureStorageOptions)
        {
            var containerBuilder = new ContainerBuilder();

            var logger = Log.Logger;
            containerBuilder.RegisterInstance(logger).As<ILogger>().SingleInstance();
            
            containerBuilder.Register(x => azureStorageOptions).As<AzureStorageOptions>().SingleInstance();
            
            containerBuilder.RegisterModule(new DataAccessModule(connectionString));
            containerBuilder.RegisterModule(new ProcessingModule());

            containerBuilder.RegisterType<MenuActivityService>().As<IMenuActivityService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<MenuInternalNameUniquenessChecker>().As<IMenuInternalNameUniquenessChecker>()
                .InstancePerLifetimeScope();
            containerBuilder.RegisterType<AzureMenuItemImageService>().As<IMenuItemImageService>()
                .InstancePerLifetimeScope();

            _container = containerBuilder.Build();

            MenusCompositionRoot.SetContainer(_container);
        }

        private static void ApplyMigrations()
        {
            using (var scope = MenusCompositionRoot.BeginLifeTimeScope())
            {
                var dbContext = scope.Resolve<MenusDbContext>();
                dbContext.Database.Migrate();
            }
        }
    }
}