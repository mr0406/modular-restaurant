using ModularRestaurant.Menus.Domain.Rules;
using ModularRestaurant.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Domain.Entities
{
    public class Group : ValueObject
    {
        public string Name { get; private set; }

        public IReadOnlyList<Item> Items => _items;
        private List<Item> _items = new List<Item>();

        private Group(string name, List<Item> items)
        {
            Name = name;
            _items = items;
        }

        private Group() { }

        public static Group CreateNew(string name, List<Item> items)
        {
            CheckRule(new GroupCannotBeEmptyRule(items));

            return new Group(name, items);
        }

        public void EditItems(List<Item> items)
        {
            CheckRule(new GroupCannotBeEmptyRule(items));

            _items = items;
        }
    }
}
