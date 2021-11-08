using Autofac;

namespace ModularRestaurant.Menus.Api
{
    internal static class MenusCompositionRoot
    {
        private static IContainer _container;

        internal static void SetContainer(IContainer container)
        {
            _container = container;
        }
        
        internal static ILifetimeScope BeginLifeTimeScope()
        {
            return _container.BeginLifetimeScope();
        }
    }
}