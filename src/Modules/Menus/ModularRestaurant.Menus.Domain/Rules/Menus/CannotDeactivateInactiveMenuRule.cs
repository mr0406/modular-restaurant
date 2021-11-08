using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Menus.Domain.Rules.Menus
{
    public class CannotDeactivateInactiveMenuRule : IBusinessRule
    {
        private readonly bool _isActive;

        public CannotDeactivateInactiveMenuRule(bool isActive)
        {
            _isActive = isActive;
        }

        public bool IsBroken() => !_isActive;

        public string Message => "Menu is already inactive. Cannot deactivate inactive menu.";
    }
}