using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Domain.Rules
{
    public class GroupCannotBeEmptyRule : IBusinessRule
    {
        private readonly List<Item> _items;

        internal GroupCannotBeEmptyRule(List<Item> items)
        {
            _items = items;
        }

        public bool IsBroken() => _items is null || !_items.Any();

        public string Message => "Group cannot contain 0 items"; 
    }
}
