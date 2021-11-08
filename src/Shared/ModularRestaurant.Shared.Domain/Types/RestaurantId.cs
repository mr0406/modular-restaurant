using System;
using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Shared.Domain.Types
{
    public class RestaurantId : TypeId
    {
        public RestaurantId(Guid value) : base(value)
        {
        }
    }
}