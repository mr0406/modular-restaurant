using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModularRestaurant.Menus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Infrastructure.EF
{
    public class MenusDbContext : DbContext
    {
        public DbSet<Menu> Menus { get; set; }

        public MenusDbContext()
        {
        }

        public MenusDbContext(DbContextOptions<MenusDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.{env}.json", optional: true)
                    .AddEnvironmentVariables()
                    .Build();

                var connectionString = configuration["Sql:ConnectionString"];
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("menus");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
