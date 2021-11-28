using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ModularRestaurant.Shared.Infrastructure.EF
{
    public class DbContextBase : DbContext
    {
        private const string ConnectionString = "Sql:ConnectionString";

        public DbContextBase()
        {
        }

        public DbContextBase(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.{env}.json", true)
                    .AddEnvironmentVariables()
                    .Build();

                var connectionString = configuration[ConnectionString];
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
    }
}