using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModularRestaurant.Ratings.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Infrastructure.EF
{
    public class RatingsDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        public RatingsDbContext()
        {
        }

        public RatingsDbContext(DbContextOptions<RatingsDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile("appsettings.development.json")
                    .AddEnvironmentVariables()
                    .Build();

                var connectionString = configuration["Sql:ConnectionString"];
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ratings");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
