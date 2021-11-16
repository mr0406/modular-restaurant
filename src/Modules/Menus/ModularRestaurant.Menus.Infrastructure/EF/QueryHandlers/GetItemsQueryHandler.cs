using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Menus.Application.Queries.GetItems;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Domain.Types;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Extensions;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Infrastructure.EF.QueryHandlers
{
    public class GetItemsQueryHandler : IQueryHandler<GetItemsQuery, GetItemsQueryResult>
    {
        private readonly DbSet<Menu> _menus;

        public GetItemsQueryHandler(MenusDbContext menusDbContext)
        {
            _menus = menusDbContext.Menus;
        }
        
        public async Task<GetItemsQueryResult> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            var menuId = new MenuId(request.MenuId);
            var groupId = new GroupId(request.GroupId);

            var menu = await _menus.SingleOrDefaultAsync(x => x.Id == menuId, cancellationToken);
            var items = menu.Groups.FindOrThrow(groupId).Items
                .Select(item => new GetItemsQueryResult.Item(item.Id.Value, item.Name));

            return new GetItemsQueryResult
            {
                Items = items
            };
        }
    }
}