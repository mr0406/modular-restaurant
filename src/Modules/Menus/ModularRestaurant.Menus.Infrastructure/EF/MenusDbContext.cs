using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Shared.Infrastructure;
using ModularRestaurant.Shared.Infrastructure.EF;

namespace ModularRestaurant.Menus.Infrastructure.EF
{
    public class MenusDbContext : DbContextBase
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        public MenusDbContext()
        {
        }

        public MenusDbContext(DbContextOptions<MenusDbContext> options, IMenusDomainEventPublisher publisher) : base(options, publisher)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("menus");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}