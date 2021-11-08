using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Menus.Application.Queries.GetGroups;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Infrastructure.EF.QueryHandlers
{
    public class GetGroupsQueryHandler : IQueryHandler<GetGroupsQuery, GetGroupsQueryResult>
    {
        private readonly DbSet<Menu> _menus;

        public GetGroupsQueryHandler(MenusDbContext menusDbContext)
        {
            _menus = menusDbContext.Menus;
        }
        
        public async Task<GetGroupsQueryResult> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
        {
            var menuId = new MenuId(request.MenuId);

            return await _menus.Where(x => x.Id == menuId)
                .Select(menu => new GetGroupsQueryResult
                {
                    Groups = menu.Groups.Select(
                        group => new GetGroupsQueryResult.Group(group.Name))
                }).SingleOrDefaultAsync(cancellationToken);
        }
    }
}