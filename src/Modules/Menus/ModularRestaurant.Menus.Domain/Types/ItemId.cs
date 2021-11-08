using System;
using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Menus.Domain.Types
{
    public class ItemId : TypeId
    {
        public ItemId(Guid value) : base(value)
        {
        }
    }
}