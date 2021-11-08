using System.Collections.Generic;
using System.Linq;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Menus.Domain.Rules.Groups
{
    public class GroupMustHaveAtLeastOneItem : IBusinessRule
    {
        private readonly List<Item> _items;
        
        public GroupMustHaveAtLeastOneItem(List<Item> items)
        {
            _items = items;
        }

        public bool IsBroken() => _items is null || !_items.Any();

        public string Message => "Group must have at least one item.";
    }
}