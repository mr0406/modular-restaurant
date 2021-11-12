using System.Threading.Tasks;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Domain.Services
{
    public class MenuActivityService : IMenuActivityService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuActivityService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        
        public async Task ChangeActive(RestaurantId restaurantId, MenuId menuToActivateId)
        {
            var currentActiveMenu = await _menuRepository.GetActiveMenuInRestaurant(restaurantId);
            currentActiveMenu?.Deactivate();

            var menuToActivate = await _menuRepository.GetAsync(menuToActivateId);
            menuToActivate.Activate();
        }

        public async Task Deactivate(MenuId menuToDeactivateId)
        {
            var currentActiveMenu = await _menuRepository.GetAsync(menuToDeactivateId);
            currentActiveMenu.Deactivate();
        }
    }
}