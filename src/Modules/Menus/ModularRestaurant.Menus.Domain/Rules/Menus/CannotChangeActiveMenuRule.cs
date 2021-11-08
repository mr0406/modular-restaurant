using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Menus.Domain.Rules.Menus
{
    public class CannotChangeActiveMenuRule : IBusinessRule
    {
        private readonly bool _isMenuActive; 
        
        public CannotChangeActiveMenuRule(bool isMenuActive)
        {
            _isMenuActive = isMenuActive;
        }

        public bool IsBroken() => _isMenuActive;

        public string Message => "Can change only inactive menu.";
    }
}