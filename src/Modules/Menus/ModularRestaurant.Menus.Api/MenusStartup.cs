using Autofac;
using ModularRestaurant.Menus.Api.IoCModules;

namespace ModularRestaurant.Menus.Api
{
    public static class MenusStartup
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
            
            MenusCompositionRoot.SetContainer(_container);
        }
    }
}