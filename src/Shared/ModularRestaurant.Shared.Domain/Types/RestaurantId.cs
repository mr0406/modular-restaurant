using System;

namespace ModularRestaurant.Shared.Domain.Types
{
    public class RestaurantId : TypeId
    {
        public RestaurantId(Guid value)
            : base(value)
        {
        }
    }
}