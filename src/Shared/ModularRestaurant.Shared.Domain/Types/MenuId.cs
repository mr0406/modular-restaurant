using System;
using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Shared.Domain.Types
{
    public class MenuId : TypeId
    {
        public MenuId(Guid value) : base(value)
        {
        }
    }
}