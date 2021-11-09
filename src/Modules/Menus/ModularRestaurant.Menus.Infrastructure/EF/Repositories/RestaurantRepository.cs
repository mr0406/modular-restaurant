using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Shared.Domain.Exceptions;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Infrastructure.EF.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly MenusDbContext _dbContext;
        private readonly DbSet<Restaurant> _restaurants;

        public RestaurantRepository(MenusDbContext dbContext)
        {
            _restaurants = dbContext.Restaurants;
            _dbContext = dbContext;
        }

        public async Task AddAsync(Restaurant restaurant, CancellationToken token = default)
        {
            await _restaurants.AddAsync(restaurant, token);
        }

        public async Task<Restaurant> GetAsync(RestaurantId restaurantId, CancellationToken token = default)
        {
            var menu = await _restaurants.SingleOrDefaultAsync(x => x.Id == restaurantId, token);
            if (menu is null) throw new ObjectNotFoundException(typeof(Menu), restaurantId.Value);
            return menu;
        }

        public async Task<MenuId> GetActiveMenuIdInRestaurantAsync(RestaurantId restaurantId, CancellationToken token = default)
        {
            return (await GetAsync(restaurantId, token)).ActiveMenuId;
        }

        public async Task<bool> DoesHaveMenuWithThisInternalName(RestaurantId restaurantId, string internalName,
            CancellationToken token = default)
        {
            return await Task.FromResult(_dbContext.Menus.Any(x => x.RestaurantId == restaurantId && x.InternalName == internalName));
        }
    }
}