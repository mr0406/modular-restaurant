using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Shared.Domain.Common;
using System.Collections.Generic;
using System.Linq;

namespace ModularRestaurant.Menus.Domain.Rules
{
    internal class GroupCannotBeEmptyRule : IBusinessRule
    {
        public string Message => "Group cannot contain 0 items";

        private readonly List<Item> _items;

        internal GroupCannotBeEmptyRule(List<Item> items)
        {
            _items = items;
        }

        public bool IsBroken()
        {
            return _items is null || !_items.Any();
        }
    }
}