using System.Threading.Tasks;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Menus.Domain.Rules.Menus;
using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Domain.Services
{
    public class MenuActivityService : DomainService, IMenuActivityService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuActivityService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        
        public async Task ChangeActive(RestaurantId restaurantId, MenuId menuToActivateId)
        {
            var currentActiveMenu = await _menuRepository.GetActiveMenuInRestaurant(restaurantId);
            var menuToActivate = await _menuRepository.GetAsync(menuToActivateId);
            
            CheckRule(new CannotActivateActiveMenuRule(currentActiveMenu, menuToActivate));

            currentActiveMenu?.Deactivate();
            menuToActivate.Activate();
        }

        public async Task Deactivate(MenuId menuToDeactivateId)
        {
            var currentActiveMenu = await _menuRepository.GetAsync(menuToDeactivateId);
            CheckRule(new CannotDeactivateInactiveMenuRule(currentActiveMenu.IsActive));
            currentActiveMenu.Deactivate();
        }
    }
}