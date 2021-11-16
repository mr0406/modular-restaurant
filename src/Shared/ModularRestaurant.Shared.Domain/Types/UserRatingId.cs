using System;
using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Shared.Domain.Types
{
    public class UserRatingId : TypeId
    {
        public UserRatingId(Guid value) 
            : base(value)
        {
        }
    }
}