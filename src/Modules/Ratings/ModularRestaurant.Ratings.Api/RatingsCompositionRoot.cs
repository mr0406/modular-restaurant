using Autofac;

namespace ModularRestaurant.Ratings.Api
{
    internal static class RatingsCompositionRoot
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