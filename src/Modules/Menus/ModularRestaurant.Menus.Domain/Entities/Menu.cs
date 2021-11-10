using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Menus.Domain.Rules.Groups;
using ModularRestaurant.Menus.Domain.Rules.Menus;
using ModularRestaurant.Menus.Domain.Rules.Restaurants;
using ModularRestaurant.Menus.Domain.Types;
using ModularRestaurant.Shared.Domain.Extensions;

namespace ModularRestaurant.Menus.Domain.Entities
{
    public class Menu : AggregateRoot<MenuId>
    {
        //TODO: check this, this is redundant to ActiveMenuId in Restaurant
        public bool IsActive { get; private set; }
        public string InternalName { get; private set; }
        
        public RestaurantId RestaurantId { get; private set; }

        public IReadOnlyList<Group> Groups => _groups;
        private List<Group> _groups = new();

        private Menu(RestaurantId restaurantId, string internalName)
        {
            Id = new MenuId(Guid.NewGuid());
            InternalName = internalName;
            RestaurantId = restaurantId;
            IsActive = false;
        }
        
        private Menu()
        {
        }

        public Menu GetCopy(string newInternalName, IRestaurantRepository restaurantRepository)
        {
            CheckRule(new InternalNameMustBeUniqueInRestaurantMenusRule(RestaurantId, newInternalName, restaurantRepository));
            
            var menu = new Menu(RestaurantId, newInternalName)
            {
                _groups = _groups.Select(x => x.GetCopy()).ToList()
            };
            
            return menu;
        }
        
        public void Activate()
        {
            CheckRule(new ActiveMenuMustHaveAtLeastOneGroup(_groups));
            
            _groups.ForEach(x => x.CheckConsistency());
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public static Menu Create(RestaurantId restaurantId, string internalName, IRestaurantRepository restaurantRepository)
        {
            CheckRule(new InternalNameMustBeUniqueInRestaurantMenusRule(restaurantId, internalName, restaurantRepository));
            return new Menu(restaurantId, internalName);
        }

        public void ChangeInternalName(string newInternalName, IRestaurantRepository restaurantRepository)
        {
            CheckRule(new InternalNameMustBeUniqueInRestaurantMenusRule(RestaurantId, newInternalName, restaurantRepository));
            InternalName = newInternalName;
        }
        
        //TODO: consider use full group object
        public void AddGroup(string groupName, IRestaurantRepository restaurantRepository)
        {
            CheckRule(new CannotChangeActiveMenuRule(restaurantRepository, RestaurantId, Id));
            CheckRule(new GroupNameMustBeUniqueRule(_groups, groupName));

            _groups.Add(Group.Create(groupName));
        }

        public void ChangeGroupName(GroupId groupId, string newGroupName, IRestaurantRepository restaurantRepository)
        {
            CheckRule(new CannotChangeActiveMenuRule(restaurantRepository, RestaurantId, Id));
            CheckRule(new GroupNameMustBeUniqueRule(_groups, newGroupName));

            var group = _groups.FindOrThrow(groupId);
            group.ChangeName(newGroupName);
        }

        public void AddItemToGroup(GroupId groupId, string itemName, IRestaurantRepository restaurantRepository)
        {
            CheckRule(new CannotChangeActiveMenuRule(restaurantRepository, RestaurantId, Id));

            var group = _groups.FindOrThrow(groupId);
            group.AddItem(itemName);
        }

        public void RemoveItemFromGroup(GroupId groupId, ItemId itemId, IRestaurantRepository restaurantRepository)
        {
            CheckRule(new CannotChangeActiveMenuRule(restaurantRepository, RestaurantId, Id));

            var group = _groups.FindOrThrow(groupId);
            group.RemoveItem(itemId);
        }

        public void ChangeItemName(GroupId groupId, ItemId itemId, string newItemName, IRestaurantRepository restaurantRepository)
        {
            CheckRule(new CannotChangeActiveMenuRule(restaurantRepository, RestaurantId, Id));

            var group = _groups.FindOrThrow(groupId);
            group.ChangeItemName(itemId, newItemName);
        }

        public void RemoveGroup(GroupId groupId, IRestaurantRepository restaurantRepository)
        {
            CheckRule(new CannotChangeActiveMenuRule(restaurantRepository, RestaurantId, Id));

            var group = _groups.FindOrThrow(groupId);
            _groups.Remove(group);
        }
    }
}