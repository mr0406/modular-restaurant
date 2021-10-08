using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Domain.Entities
{
    public class Group
    {
        public string Name { get; private set; }

        public IReadOnlyList<Item> items;
        private List<Item> _items = new List<Item>();

        public Group(string name)
        {
            Name = name;
        }

        public static Group CreateNew(string name)
        {
            return new Group(name);
        }

        internal void AddItem(string itemName)
        {
            var item = Item.CreateNew(itemName);
            _items.Add(item);
        }
    }
}
