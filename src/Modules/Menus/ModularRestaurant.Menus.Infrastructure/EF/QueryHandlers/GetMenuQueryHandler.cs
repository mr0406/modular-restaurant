using System.Linq;
using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Types;
using System.Threading;
using System.Threading.Tasks;
using ModularRestaurant.Menus.Application.Queries.GetMenu;

namespace ModularRestaurant.Menus.Infrastructure.EF.QueryHandlers
{
    public class GetMenuQueryHandler : IQueryHandler<GetMenuQuery, GetMenuQueryResult>
    {
        private readonly DbSet<Menu> _menus;

        public GetMenuQueryHandler(MenusDbContext menusDbContext)
        {
            _menus = menusDbContext.Menus;
        }

        public async Task<GetMenuQueryResult> Handle(GetMenuQuery query, CancellationToken cancellationToken)
        {
            var menuId = new MenuId(query.Id);
            
            return await _menus.Where(x => x.Id == menuId)
                .Select(menu => new GetMenuQueryResult
                {
                    Groups = menu.Groups.Select(
                        group => new GetMenuQueryResult.Group(group.Id.Value, group.Name, group.Items.Select(
                            item => new GetMenuQueryResult.Item(item.Id.Value, item.Name))))
                })
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}