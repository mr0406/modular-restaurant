﻿using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Ratings.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Infrastructure.EF
{
    public class RatingsDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

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