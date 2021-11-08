using System;
using ModularRestaurant.Menus.Domain.Types;
using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Menus.Domain.Entities
{
    public class Item : Entity<ItemId>
    {
        public string Name { get; private set; }

        private Item(string name)
        {
            Id = new ItemId(Guid.NewGuid());
            Name = name;
        }

        private Item()
        {
        }

        internal Item GetCopy()
        {
            return new(Name);
        }

        public static Item Create(string name)
        {
            return new Item(name);
        }

        //TODO: Consider, cannot change to same name as exists?
        internal void ChangeName(string newName)
        {
            Name = newName;
        }
    }
}