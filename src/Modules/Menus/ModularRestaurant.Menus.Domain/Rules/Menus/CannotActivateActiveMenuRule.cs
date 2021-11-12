using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Menus.Domain.Rules.Menus
{
    public class CannotActivateActiveMenuRule : IBusinessRule
    {
        private readonly Menu _menuToActivate;
        private readonly Menu _currentActiveMenu;


        public CannotActivateActiveMenuRule(Menu currentActiveMenu, Menu menuToActivate)
        {
            _menuToActivate = menuToActivate;
            _currentActiveMenu = currentActiveMenu;
        }

        public bool IsBroken()
        {
            if (_currentActiveMenu is null) return false;

            return _menuToActivate.Id == _currentActiveMenu.Id;
        }

        public string Message => "Menu is already active. Cannot activate active menu.";
    }
}