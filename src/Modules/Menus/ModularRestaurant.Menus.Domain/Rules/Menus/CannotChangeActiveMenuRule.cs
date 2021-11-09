using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Domain.Rules.Menus
{
    public class CannotChangeActiveMenuRule : IBusinessRule
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly RestaurantId _restaurantId;
        private readonly MenuId _menuId;

        public CannotChangeActiveMenuRule(IRestaurantRepository restaurantRepository, 
            RestaurantId restaurantId, MenuId menuId)
        {
            _restaurantRepository = restaurantRepository;
            _restaurantId = restaurantId;
            _menuId = menuId;
        }

        public bool IsBroken()
        {
            var activeMenuId = _restaurantRepository.GetActiveMenuIdInRestaurantAsync(_restaurantId).Result;

            return activeMenuId == _menuId;
        }

        public string Message => "Can change only inactive menu.";
    }
}