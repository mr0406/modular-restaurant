using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Shared.Domain;
using ModularRestaurant.Shared.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool IsBroken() => _items is null || !_items.Any();
    }
}
