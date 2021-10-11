using ModularRestaurant.Menus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Domain.Repositories
{
    public interface IMenuRepository
    {
        Task AddAsync(Menu menu, CancellationToken token);
    }
}
