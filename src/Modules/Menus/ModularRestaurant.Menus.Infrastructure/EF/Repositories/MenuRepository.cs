using System.Linq;
using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Shared.Domain.Types;
using System.Threading;
using System.Threading.Tasks;
using ModularRestaurant.Shared.Domain.Exceptions;

namespace ModularRestaurant.Menus.Infrastructure.EF.Repositories
{
    internal class MenuRepository : IMenuRepository
    {
        private readonly MenusDbContext _dbContext;
        private readonly DbSet<Menu> _menus;

        public MenuRepository(MenusDbContext dbContext)
        {
            _dbContext = dbContext;
            _menus = dbContext.Menus;
        }

        public async Task AddAsync(Menu menu, CancellationToken token)
        {
            await _menus.AddAsync(menu, token);
        }

        public async Task<Menu> GetAsync(MenuId menuId, CancellationToken token)
        {
            var menu = await _menus.SingleOrDefaultAsync(x => x.Id == menuId, token);
            if (menu is null) throw new ObjectNotFoundException(typeof(Menu), menuId.Value);
            return menu;
        }

        public async Task<Menu> GetActiveMenuInRestaurant(RestaurantId restaurantId, CancellationToken token = default)
        {
            return await _menus.SingleOrDefaultAsync(x => x.RestaurantId == restaurantId && x.IsActive);
        }

        public async Task<bool> CheckExists(RestaurantId restaurantId, string internalMenuName)
        {
            return await Task.FromResult(_menus.Any(x => x.RestaurantId == restaurantId && x.InternalName == internalMenuName));
        }
    }
}