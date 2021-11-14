using System;
using ModularRestaurant.Menus.Domain.Types;
using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.ValueObjects;

namespace ModularRestaurant.Menus.Domain.Entities
{
    public class Item : Entity<ItemId>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Money Price { get; private set; }

        private Item(string name, string description, Money price)
        {
            Id = new ItemId(Guid.NewGuid());
            Name = name;
            Description = description;
            Price = price;
        }

        private Item()
        {
        }

        internal Item GetCopy()
        {
            return new(Name, Description, Price);
        }

        public static Item Create(string name, string description, Money price)
        {
            return new Item(name, description, price);
        }

        //TODO: Consider, cannot change to same name as exists?
        internal void ChangeName(string newName)
        {
            Name = newName;
        }

        internal void ChangeDescription(string newDescription)
        {
            Description = newDescription;
        }

        internal void ChangePrice(Money price)
        {
            Price = price;
        }
    }
}