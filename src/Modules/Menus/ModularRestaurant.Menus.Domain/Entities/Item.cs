using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Domain.Entities
{
    public class Item
    {
        public string Name { get; private set; }

        private Item(string name)
        {
            Name = name;
        }

        internal static Item CreateNew(string name)
        {
            return new Item(name);
        }
    }
}
