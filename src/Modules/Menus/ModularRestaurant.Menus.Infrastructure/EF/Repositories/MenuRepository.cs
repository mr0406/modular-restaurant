using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Infrastructure.EF.Repositories
{
    internal class MenuRepository : IMenuRepository
    {
        public async Task<Menu> GetAsync()
        {
            var menu = Menu.CreateNew();
            menu.AddGroup("First Group");
            menu.AddItemToGroup("First Group", "First Item");
            menu.AddItemToGroup("First Group", "Another Item");
            menu.AddGroup("Second Group");

            return await Task.FromResult(menu);
        }
    }
}
