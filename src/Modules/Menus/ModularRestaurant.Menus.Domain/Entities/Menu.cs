using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using ModularRestaurant.Menus.Domain.Rules.Groups;
using ModularRestaurant.Menus.Domain.Rules.Menus;
using ModularRestaurant.Menus.Domain.Rules.Restaurants;
using ModularRestaurant.Menus.Domain.Services;
using ModularRestaurant.Menus.Domain.Types;
using ModularRestaurant.Shared.Domain.Extensions;
using ModularRestaurant.Shared.Domain.ValueObjects;

namespace ModularRestaurant.Menus.Domain.Entities
{
    public class Menu : AggregateRoot<MenuId>
    {
        public string InternalName { get; private set; }
        
        public RestaurantId RestaurantId { get; private set; }

        public IReadOnlyList<Group> Groups => _groups;
        private List<Group> _groups = new();
        public bool IsActive { get; private set; }
        
        private Menu(RestaurantId restaurantId, string internalName)
        {
            Id = new MenuId(Guid.NewGuid());
            InternalName = internalName;
            RestaurantId = restaurantId;
            IsActive = false;
            Version = 0;
        }
        
        private Menu()
        {
        }

        public Menu GetCopy(string newInternalName, IMenuInternalNameUniquenessChecker menuInternalNameUniquenessChecker)
        {
            CheckRule(new InternalNameMustBeUniqueInRestaurantMenusRule(RestaurantId, newInternalName, menuInternalNameUniquenessChecker));
            
            var menu = new Menu(RestaurantId, newInternalName)
            {
                _groups = _groups.Select(x => x.GetCopy()).ToList()
            };
            
            return menu;
        }
        
        internal void Activate()
        {
            CheckRule(new ActiveMenuMustHaveAtLeastOneGroup(_groups));

            _groups.ForEach(x => x.CheckConsistency());
            
            IsActive = true;
            
            IncrementVersion();
        }

        internal void Deactivate()
        {
            IsActive = false;
            
            IncrementVersion();
        }

        public static Menu Create(RestaurantId restaurantId, string internalName, IMenuInternalNameUniquenessChecker menuInternalNameUniquenessChecker)
        {
            CheckRule(new InternalNameMustBeUniqueInRestaurantMenusRule(restaurantId, internalName, menuInternalNameUniquenessChecker));
            return new Menu(restaurantId, internalName);
        }

        public void ChangeInternalName(string newInternalName, IMenuInternalNameUniquenessChecker menuInternalNameUniquenessChecker)
        {
            CheckRule(new InternalNameMustBeUniqueInRestaurantMenusRule(RestaurantId, newInternalName, menuInternalNameUniquenessChecker));
            InternalName = newInternalName;
            
            IncrementVersion();
        }
        
        public void AddGroup(string groupName)
        {
            CheckRule(new CannotChangeActiveMenuRule(IsActive));
            CheckRule(new GroupNameMustBeUniqueRule(_groups, groupName));

            _groups.Add(Group.Create(groupName));
            
            IncrementVersion();
        }

        public void ChangeGroupName(GroupId groupId, string newGroupName)
        {
            CheckRule(new CannotChangeActiveMenuRule(IsActive));
            CheckRule(new GroupNameMustBeUniqueRule(_groups, newGroupName));

            var group = _groups.FindOrThrow(groupId);
            group.ChangeName(newGroupName);
            
            IncrementVersion();
        }

        public void AddItemToGroup(GroupId groupId, string itemName, string itemDescription, Money itemPrice)
        {
            CheckRule(new CannotChangeActiveMenuRule(IsActive));

            var group = _groups.FindOrThrow(groupId);
            group.AddItem(itemName, itemDescription, itemPrice);
            
            IncrementVersion();
        }

        public void RemoveItemFromGroup(GroupId groupId, ItemId itemId)
        {
            CheckRule(new CannotChangeActiveMenuRule(IsActive));

            var group = _groups.FindOrThrow(groupId);
            group.RemoveItem(itemId);

            IncrementVersion();;
        }

        public void ChangeItemName(GroupId groupId, ItemId itemId, string newItemName)
        {
            CheckRule(new CannotChangeActiveMenuRule(IsActive));

            var group = _groups.FindOrThrow(groupId);
            group.ChangeItemName(itemId, newItemName);
            
            IncrementVersion();
        }

        public void ChangeItemDescription(GroupId groupId, ItemId itemId, string newItemDescription)
        {
            CheckRule(new CannotChangeActiveMenuRule(IsActive));

            var group = _groups.FindOrThrow(groupId);
            group.ChangeItemDescription(itemId, newItemDescription);
            
            IncrementVersion();
        }

        public void ChangeItemPrice(GroupId groupId, ItemId itemId, Money newItemPrice)
        {
            CheckRule(new CannotChangeActiveMenuRule(IsActive));

            var group = _groups.FindOrThrow(groupId);
            group.ChangeItemPrice(itemId, newItemPrice);
            
            IncrementVersion();
        }

        public void RemoveGroup(GroupId groupId)
        {
            CheckRule(new CannotChangeActiveMenuRule(IsActive));

            var group = _groups.FindOrThrow(groupId);
            _groups.Remove(group);
            
            IncrementVersion();
        }
    }
}