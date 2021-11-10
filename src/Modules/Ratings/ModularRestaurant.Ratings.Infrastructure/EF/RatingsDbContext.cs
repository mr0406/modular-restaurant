﻿using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Shared.Infrastructure;
using ModularRestaurant.Shared.Infrastructure.EF;

namespace ModularRestaurant.Ratings.Infrastructure.EF
{
    public class RatingsDbContext : DbContextBase
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        public RatingsDbContext()
        {
        }

        public RatingsDbContext(DbContextOptions<RatingsDbContext> options, IRatingsDomainEventPublisher publisher) : base(options, publisher)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ratings");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}