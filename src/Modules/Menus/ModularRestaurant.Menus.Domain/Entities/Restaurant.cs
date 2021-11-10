using System.Collections.Generic;
using ModularRestaurant.Menus.Domain.Events;
using ModularRestaurant.Menus.Domain.Exceptions;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Menus.Domain.Rules.Menus;
using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Domain.Entities
{
    public class Restaurant : AggregateRoot<RestaurantId>
    {
        //TODO: check this, this is redundant to IsActive in menu
        public MenuId ActiveMenuId { get; private set; } //consider not store this in db

        public IReadOnlyList<MenuId> MenuIds => _menuIds;
        private List<MenuId> _menuIds = new();

        public Restaurant(RestaurantId id)
        {
            Id = id;
        }
        
        
        private Restaurant()
        {
        }

        public static Restaurant Create(RestaurantId id)
        {
            return new Restaurant(id);
        }

        public void DeactivateMenu(MenuId menuId)
        {
            ActiveMenuId = null;
            _events.Add(new MenuDeactivatedByRestaurantEvent(Id, menuId));
        }

        public void ChangeActiveMenu(MenuId newActiveMenuId)
        {
            ActiveMenuId = newActiveMenuId;
            _events.Add(new ActiveMenuChangedByRestaurantEvent(Id, newActiveMenuId));
        }

        private void CheckMenuExists(MenuId menuId)
        {
            if (!_menuIds.Contains(menuId))
            {
                throw new MenuInRestaurantNotFoundException(Id.Value, menuId.Value);
            }
        }
    }
}