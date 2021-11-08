using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Domain.Rules.Restaurants
{
    public class InternalNameMustBeUniqueInRestaurantMenusRule : IBusinessRule
    {
        private readonly RestaurantId _restaurantId;
        private readonly string _newInternalMenuName;
        private readonly IMenuRepository _menuRepository;
        
        public InternalNameMustBeUniqueInRestaurantMenusRule(RestaurantId restaurantId, string newInternalMenuName, IMenuRepository menuRepository)
        {
            _restaurantId = restaurantId;
            _newInternalMenuName = newInternalMenuName;
            _menuRepository = menuRepository;
        }

        public bool IsBroken() => _menuRepository.DoesRestaurantHaveMenuWithThisInternalNameAsync(_restaurantId, _newInternalMenuName).Result;

        public string Message => "Internal menu name must be unique in restaurant";
    }
}