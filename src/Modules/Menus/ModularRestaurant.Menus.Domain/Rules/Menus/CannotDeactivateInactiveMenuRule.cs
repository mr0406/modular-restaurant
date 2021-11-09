using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Domain.Rules.Menus
{
    public class CannotDeactivateInactiveMenuRule : IBusinessRule
    {
        private readonly MenuId _currentActiveMenuId;
        private readonly MenuId _menuToDeactivateId;

        public CannotDeactivateInactiveMenuRule(MenuId currentActiveMenuId, MenuId menuToDeactivateId)
        {
            _currentActiveMenuId = currentActiveMenuId;
            _menuToDeactivateId = menuToDeactivateId;
        }

        public bool IsBroken() => _currentActiveMenuId != _menuToDeactivateId;

        public string Message => "Menu is already inactive. Cannot deactivate inactive menu.";
    }
}