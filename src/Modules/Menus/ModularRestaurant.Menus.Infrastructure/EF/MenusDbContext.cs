using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Shared.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Infrastructure.EF
{
    public class MenusDbContext : DbContextBase
    {
        public DbSet<Menu> Menus { get; set; }

        public MenusDbContext()
        {
        }

        public MenusDbContext(DbContextOptions<MenusDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("menus");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
