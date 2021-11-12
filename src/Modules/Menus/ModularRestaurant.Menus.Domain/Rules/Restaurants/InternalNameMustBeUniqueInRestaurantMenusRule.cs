using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Menus.Domain.Services;
using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Domain.Rules.Restaurants
{
    public class InternalNameMustBeUniqueInRestaurantMenusRule : IBusinessRule
    {
        private readonly RestaurantId _restaurantId;
        private readonly string _newInternalMenuName;
        private readonly IMenuInternalNameUniquenessChecker _menuInternalNameUniquenessChecker;

        public InternalNameMustBeUniqueInRestaurantMenusRule(RestaurantId restaurantId, string newInternalMenuName, 
            IMenuInternalNameUniquenessChecker menuInternalNameUniquenessChecker)
        {
            _restaurantId = restaurantId;
            _newInternalMenuName = newInternalMenuName;
            _menuInternalNameUniquenessChecker = menuInternalNameUniquenessChecker;
        }

        public bool IsBroken() => !_menuInternalNameUniquenessChecker.Check(_restaurantId, _newInternalMenuName).Result;

        public string Message => "Internal menu name must be unique in restaurant";
    }
}