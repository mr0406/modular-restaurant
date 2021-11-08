using ModularRestaurant.Menus.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Domain.Repositories
{
    public interface IMenuRepository
    {
        Task AddAsync(Menu menu, CancellationToken token);
        
        Task<Menu> GetAsync(MenuId menuId, CancellationToken token);
        
        Task<Menu> GetActiveMenuInRestaurant(RestaurantId restaurantId);

        Task<bool> DoesRestaurantHaveActiveMenuAsync(RestaurantId restaurantId);

        Task<bool> DoesRestaurantHaveMenuWithThisInternalNameAsync(RestaurantId restaurantId, string internalMenuName);
    }
}