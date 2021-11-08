using System.Collections.Generic;
using System.Linq;
using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Exceptions;

namespace ModularRestaurant.Shared.Domain.Extensions
{
    public static class EntityExtensions
    {
        public static T FindOrThrow<T, TId>(this IEnumerable<T> entities, TId id)
            where T : Entity<TId>
            where TId : TypeId
        {
            var entity = entities.SingleOrDefault(x => x.Id == id);

            if (entity is null) throw new ObjectNotFoundException(typeof(T), id.Value);

            return entity;
        }
    }
}