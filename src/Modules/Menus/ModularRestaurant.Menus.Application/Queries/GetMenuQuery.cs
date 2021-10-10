using ModularRestaurant.Menus.Application.DTOs;
using ModularRestaurant.Shared.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Application.Queries
{
    public record GetMenuQuery(Guid Id) : IQuery<MenuDTO>;

    public class GetMenuQueryHandler : IQueryHandler<GetMenuQuery, MenuDTO>
    {
        public async Task<MenuDTO> Handle(GetMenuQuery query, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new MenuDTO());
        }
    }
}
