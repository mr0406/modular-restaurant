using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Domain.Rules.Restaurants
{
    public class InternalNameMustBeUniqueInRestaurantMenusRule : IBusinessRule
    {
        private readonly RestaurantId _restaurantId;
        private readonly string _newInternalMenuName;
        private readonly IRestaurantRepository _restaurantRepository;

        public InternalNameMustBeUniqueInRestaurantMenusRule(RestaurantId restaurantId, string newInternalMenuName, IRestaurantRepository restaurantRepository)
        {
            _restaurantId = restaurantId;
            _newInternalMenuName = newInternalMenuName;
            _restaurantRepository = restaurantRepository;
        }

        public bool IsBroken() => _restaurantRepository.DoesHaveMenuWithThisInternalName(_restaurantId, _newInternalMenuName).Result;

        public string Message => "Internal menu name must be unique in restaurant";
    }
}