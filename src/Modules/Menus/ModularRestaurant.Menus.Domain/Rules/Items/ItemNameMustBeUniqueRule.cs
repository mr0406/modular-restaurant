using System.Collections.Generic;
using System.Linq;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Menus.Domain.Rules.Items
{
    public class ItemNameMustBeUniqueRule : IBusinessRule
    {
        private readonly List<Item> _items;
        private readonly string _itemName;

        internal ItemNameMustBeUniqueRule(List<Item> items, string itemName)
        {
            _items = items;
            _itemName = itemName;
        }

        public bool IsBroken() => _items.Any(x => x.Name == _itemName);

        public string Message => "Item name must be unique in group.";
    }
}