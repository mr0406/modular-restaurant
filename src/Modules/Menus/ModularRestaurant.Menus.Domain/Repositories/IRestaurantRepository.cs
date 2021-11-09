using System.Threading;
using System.Threading.Tasks;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Domain.Repositories
{
    public interface IRestaurantRepository
    {
        Task AddAsync(Restaurant restaurant, CancellationToken token = default);

        Task<Restaurant> GetAsync(RestaurantId restaurantId, CancellationToken token = default);

        Task<MenuId> GetActiveMenuIdInRestaurantAsync(RestaurantId restaurantId, CancellationToken token = default);

        Task<bool> DoesHaveMenuWithThisInternalName(RestaurantId restaurantId, string internalName, CancellationToken token = default);
    }
}