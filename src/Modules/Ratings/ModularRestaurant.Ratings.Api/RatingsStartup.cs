using Autofac;
using ModularRestaurant.Ratings.Api.IoCModules;

namespace ModularRestaurant.Ratings.Api
{
    public class RatingsStartup
    {
        private static IContainer _container;
        
        public static void Initialize(string connectionString)
        {
            ConfigureCompositionRoot(connectionString);
        }

        private static void ConfigureCompositionRoot(string connectionString)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new DataAccessModule(connectionString));
            containerBuilder.RegisterModule(new ProcessingModule());

            _container = containerBuilder.Build();
            
            RatingsCompositionRoot.SetContainer(_container);
        }
    }
}