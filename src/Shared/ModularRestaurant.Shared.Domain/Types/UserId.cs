using System;
using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Shared.Domain.Types
{
    public class UserId : TypeId
    {
        public UserId(Guid value) : base(value)
        {
        }
    }
}