using ModularRestaurant.Menus.Domain.Rules;
using ModularRestaurant.Shared.Domain.Common;
using System.Collections.Generic;

namespace ModularRestaurant.Menus.Domain.Entities
{
    public class Group : ValueObject
    {
        public string Name { get; private set; }

        public IReadOnlyList<Item> Items => _items;
        private List<Item> _items = new();

        private Group(string name)
        {
            Name = name;
        }

        private Group()
        {
        }

        public static Group CreateNew(string name)
        {
            //CheckRule(new GroupCannotBeEmptyRule(items));

            return new Group(name);
        }

        public void EditItems(List<Item> items)
        {
            CheckRule(new GroupCannotBeEmptyRule(items));

            _items = items;
        }
    }
}