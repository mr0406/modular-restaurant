using System.Collections.Generic;
using ModularRestaurant.Menus.Domain.Exceptions;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Menus.Domain.Rules.Menus;
using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Domain.Entities
{
    public class Restaurant : AggregateRoot<RestaurantId>
    {
        public MenuId ActiveMenuId { get; private set; }

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

        public void DeactivateMenu(MenuId menuId, IMenuRepository menuRepository)
        {
            CheckMenuExists(menuId);
            CheckRule(new CannotDeactivateInactiveMenuRule(ActiveMenuId, menuId));

            ActiveMenuId = null;
        }

        public void ChangeActiveMenu(MenuId newActiveMenuId, IMenuRepository menuRepository)
        {
            CheckMenuExists(newActiveMenuId);
            CheckRule(new CannotActivateActiveMenuRule(ActiveMenuId, newActiveMenuId));
            
            var menu = menuRepository.GetAsync(newActiveMenuId).Result;
            menu.Activate();
            ActiveMenuId = newActiveMenuId;
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