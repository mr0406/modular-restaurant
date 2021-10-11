using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Menus.Application;
using ModularRestaurant.Shared.Infrastructure.Postgres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Infrastructure.EF
{
    //change DbContext type
    internal class MenusUnitOfWork : PostgresUnitOfWork<DbContext>, IMenusUnitOfWork
    {
        /*public MenusUnitOfWork(DbContext dbContext) : base(dbContext)*/ //change this
        //{
        //}
    }
}
