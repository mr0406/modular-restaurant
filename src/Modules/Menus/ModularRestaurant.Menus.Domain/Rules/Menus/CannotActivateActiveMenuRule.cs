using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Menus.Domain.Rules.Menus
{
    public class CannotActivateActiveMenuRule : IBusinessRule
    {
        private readonly bool _isActive;

        public CannotActivateActiveMenuRule(bool isActive)
        {
            _isActive = isActive;
        }

        public bool IsBroken() => _isActive;

        public string Message => "Menu is already active. Cannot activate active menu.";
    }
}