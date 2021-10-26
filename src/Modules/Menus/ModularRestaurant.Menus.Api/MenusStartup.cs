using Autofac;
using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Menus.Api.IoCModules;
using ModularRestaurant.Menus.Infrastructure.EF;

namespace ModularRestaurant.Menus.Api
{
    public static class MenusStartup
    {
        private static IContainer _container;

        public static void Initialize(string connectionString)
        {
            ConfigureCompositionRoot(connectionString);
            ApplyMigrations();
        }

        private static void ConfigureCompositionRoot(string connectionString)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new DataAccessModule(connectionString));
            containerBuilder.RegisterModule(new ProcessingModule());

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