using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Menus.Application.Queries.GetRestaurantMenus;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Infrastructure.EF.QueryHandlers
{
    public class GetRestaurantMenusQueryHandler : IQueryHandler<GetRestaurantMenusQuery, GetRestaurantMenusQueryResult>
    {
        private readonly DbSet<Menu> _menus;
        
        public GetRestaurantMenusQueryHandler(MenusDbContext menusDbContext)
        {
            _menus = menusDbContext.Menus;
        }

        public async Task<GetRestaurantMenusQueryResult> Handle(GetRestaurantMenusQuery request, CancellationToken cancellationToken)
        {
            var restaurantId = new RestaurantId(request.RestaurantId);
            var menus = await _menus.Where(x => x.RestaurantId == restaurantId)
                                    .Select(x => new GetRestaurantMenusQueryResult.Menu(x.InternalName, x.IsActive))
                                    .ToListAsync(cancellationToken);
            
            return new GetRestaurantMenusQueryResult
            {
                Menus = menus
            };
        }
    }
}