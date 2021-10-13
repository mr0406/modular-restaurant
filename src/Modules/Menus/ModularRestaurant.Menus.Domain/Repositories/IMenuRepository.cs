using ModularRestaurant.Menus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Domain.Repositories
{
    public interface IMenuRepository
    {
        Task AddAsync(Menu menu, CancellationToken token);
        Task<Menu> GetAsync(MenuId menuId, CancellationToken token);
    }
}
