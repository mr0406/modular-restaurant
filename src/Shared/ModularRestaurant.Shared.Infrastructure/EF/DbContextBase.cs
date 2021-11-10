using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Shared.Infrastructure.EF
{
    public abstract class DbContextBase : DbContext
    {
        private const string ConnectionString = "Sql:ConnectionString";
        private readonly IDomainEventPublisher _publisher;

        protected DbContextBase()
        {
        }

        protected DbContextBase(DbContextOptions options, IDomainEventPublisher publisher) : base(options)
        {
            _publisher = publisher;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //TODO: Consider applying outbox pattern!

            var result = await base.SaveChangesAsync(cancellationToken);
            if (result > 0)
            {
                var entitiesWithDomainEvents = ChangeTracker
                    .Entries<Entity>()
                    .Select(x => x.Entity)
                    .Where(x => x.Events.Any())
                    .ToArray();

                foreach(var entity in entitiesWithDomainEvents)
                {
                    foreach(var domainEvent in entity.Events)
                    {
                        domainEvent.Timestamp = DateTime.Now;
                        await _publisher.Publish(domainEvent);
                    }
                }
            }

            return result;
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