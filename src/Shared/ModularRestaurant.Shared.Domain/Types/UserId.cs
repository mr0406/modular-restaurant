using System;

namespace ModularRestaurant.Shared.Domain.Types
{
    public class UserId : TypeId
    {
        public UserId(Guid value)
            : base(value)
        {
        }
    }
}