using ModularRestaurant.Menus.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Domain.Repositories
{
    public interface IMenuRepository
    {
        Task AddAsync(Menu menu, CancellationToken token = default);
        
        Task<Menu> GetAsync(MenuId menuId, CancellationToken token = default);
        
        Task<Menu> GetActiveMenuInRestaurant(RestaurantId restaurantId);

        Task<bool> CheckExists(RestaurantId restaurantId, string internalMenuName);
    }
}