using System.Threading.Tasks;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Domain.Services
{
    public class MenuInternalNameUniquenessChecker : DomainService, IMenuInternalNameUniquenessChecker
    {
        private readonly IMenuRepository _menuRepository;

        public MenuInternalNameUniquenessChecker(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        
        public async Task<bool> CheckIsUnique(RestaurantId restaurantId, string newInternalName)
        {
            var isUnique = !await _menuRepository.CheckExists(restaurantId, newInternalName);

            return isUnique;
        }
    }
}