using System;
using System.Collections.Generic;
using System.Linq;
using ModularRestaurant.Menus.Domain.Rules.Groups;
using ModularRestaurant.Menus.Domain.Rules.Items;
using ModularRestaurant.Menus.Domain.Types;
using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Extensions;

namespace ModularRestaurant.Menus.Domain.Entities
{
    public class Group : Entity<GroupId>
    {
        public string Name { get; private set; }

        public IReadOnlyList<Item> Items => _items;
        private List<Item> _items = new();

        private Group(string name)
        {
            Id = new GroupId(Guid.NewGuid());
            Name = name;
        }

        internal Group GetCopy()
        {
            var group = new Group(Name)
            {
                _items = _items.Select(x => x.GetCopy()).ToList()
            };
            
            return group;
        }
        
        internal void CheckConsistency()
        {
            CheckRule(new GroupMustHaveAtLeastOneItem(_items));
        }
        
        private Group()
        {
        }

        public static Group Create(string name)
        {
            return new Group(name);
        }

        internal void ChangeName(string newName)
        {
            Name = newName;
        }

        internal void AddItem(string itemName, string itemDescription)
        {
            CheckRule(new ItemNameMustBeUniqueRule(_items, itemName));
            CheckRule(new ItemDescriptionCannotExceedCharacterLimitRule(itemDescription));
            
            var item = Item.Create(itemName, itemDescription);
            _items.Add(item);
        }

        internal void ChangeItemName(ItemId itemId, string newItemName)
        {
            CheckRule(new ItemNameMustBeUniqueRule(_items, newItemName));

            var item = _items.FindOrThrow(itemId);
            item.ChangeName(newItemName);
        }

        internal void ChangeItemDescription(ItemId itemId, string newItemDescription)
        {
            CheckRule(new ItemDescriptionCannotExceedCharacterLimitRule(newItemDescription));

            var item = _items.FindOrThrow(itemId);
            item.ChangeDescription(newItemDescription);
        }

        internal void RemoveItem(ItemId itemId)
        {
            var item = _items.FindOrThrow(itemId);
            _items.Remove(item);
        }
    }
}