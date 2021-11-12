using System.Threading.Tasks;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Domain.Services
{
    public class MenuInternalNameUniquenessChecker : IMenuInternalNameUniquenessChecker
    {
        private readonly IMenuRepository _menuRepository;

        public MenuInternalNameUniquenessChecker(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        
        public async Task<bool> Check(RestaurantId restaurantId, string newInternalName)
        {
            var exists = await _menuRepository.CheckExists(restaurantId, newInternalName);

            return !exists;
        }
    }
}