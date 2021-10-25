using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Shared.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Infrastructure.EF
{
    public class RatingsDbContext : DbContextBase
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        public RatingsDbContext()
        {
        }

        public RatingsDbContext(DbContextOptions<RatingsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ratings");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
