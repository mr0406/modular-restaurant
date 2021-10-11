﻿using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Shared.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Infrastructure.EF.Repositories
{
    internal class MenuRepository : IMenuRepository
    {
        private readonly MenusDbContext _dbContext;
        private readonly DbSet<Menu> _menus;

        public MenuRepository(MenusDbContext dbContext)
        {
            _dbContext = dbContext;
            _menus = dbContext.Menus;
        }

        public async Task AddAsync(Menu menu, CancellationToken token)
        {
            await _menus.AddAsync(menu, token);
        }
    }
}