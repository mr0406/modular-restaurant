using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Menus.Application.DTOs;
using ModularRestaurant.Menus.Application.Queries;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Infrastructure.EF.Mappings;
using ModularRestaurant.Shared.Application;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Types;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Infrastructure.EF.QueryHandlers
{
    public class GetMenuQueryHandler : IQueryHandler<GetMenuQuery, MenuDTO>
    {
        private readonly DbSet<Menu> _menus;

        public GetMenuQueryHandler(MenusDbContext dbContext)
        {
            _menus = dbContext.Menus;
        }

        public async Task<MenuDTO> Handle(GetMenuQuery query, CancellationToken cancellationToken)
            =>  (await _menus.SingleOrDefaultAsync(x => x.Id == new MenuId(query.Id), cancellationToken)).ToDTO();
    }
}
