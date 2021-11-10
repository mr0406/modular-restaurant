using Autofac;
using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Ratings.Api.IoCModules;
using ModularRestaurant.Ratings.Infrastructure;
using ModularRestaurant.Ratings.Infrastructure.EF;
using Serilog;

namespace ModularRestaurant.Ratings.Api
{
    public class RatingsStartup
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

            var logger = Log.Logger;
            containerBuilder.RegisterInstance(logger).As<ILogger>().SingleInstance();
            containerBuilder.RegisterType<RatingsDomainEventPublisher>().As<IRatingsDomainEventPublisher>().InstancePerLifetimeScope();

            containerBuilder.RegisterModule(new DataAccessModule(connectionString));
            containerBuilder.RegisterModule(new ProcessingModule());

            _container = containerBuilder.Build();

            RatingsCompositionRoot.SetContainer(_container);
        }

        private static void ApplyMigrations()
        {
            using (var scope = RatingsCompositionRoot.BeginLifeTimeScope())
            {
                var dbContext = scope.Resolve<RatingsDbContext>();
                dbContext.Database.Migrate();
            }
        }
    }
}