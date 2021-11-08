using System;
using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Menus.Domain.Types
{
    public class GroupId : TypeId
    {
        public GroupId(Guid value) : base(value)
        {
        }
    }
}