using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Menus.Application;
using ModularRestaurant.Shared.Infrastructure.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Infrastructure.EF
{
    internal class MenusUnitOfWork : EFUnitOfWork<MenusDbContext>, IMenusUnitOfWork
    {
        public MenusUnitOfWork(MenusDbContext dbContext) : base(dbContext)
        {
        }
    }
}
