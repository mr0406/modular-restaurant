using ModularRestaurant.Shared.Domain;
using ModularRestaurant.Shared.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Domain.Entities
{
    public class Item : ValueObject
    {
        public string Name { get; private set; }

        private Item(string name)
        {
            Name = name;
        }

        private Item() { }

        public static Item CreateNew(string name)
        {
            return new Item(name);
        }
    }
}
