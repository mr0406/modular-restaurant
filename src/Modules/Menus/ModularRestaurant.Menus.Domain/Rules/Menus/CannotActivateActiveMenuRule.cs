using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Domain.Rules.Menus
{
    public class CannotActivateActiveMenuRule : IBusinessRule
    {
        private readonly MenuId _currentActiveMenuId;
        private readonly MenuId _menuToDeactivateId;

        public CannotActivateActiveMenuRule(MenuId currentActiveMenuId, MenuId menuToDeactivateId)
        {
            _currentActiveMenuId = currentActiveMenuId;
            _menuToDeactivateId = menuToDeactivateId;
        }

        public bool IsBroken() => _currentActiveMenuId == _menuToDeactivateId;

        public string Message => "Menu is already active. Cannot activate active menu.";
    }
}