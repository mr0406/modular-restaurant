using ModularRestaurant.Shared.Domain.Exceptions;

namespace ModularRestaurant.Shared.Domain.Common
{
    public abstract class AggregateRoot<T> : Entity<T> where T : TypeId
    {
        // Marker class
    }
}