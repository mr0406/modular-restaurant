using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Ratings.Domain.Repositories;
using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Infrastructure.EF.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RatingsDbContext _dbContext;
        private readonly DbSet<Restaurant> _restaurants; 

        public async Task AddAsync(Restaurant restaurant, CancellationToken token)
        {
            await _restaurants.AddAsync(restaurant, token);
        }

        public async Task<Restaurant> GetAsync(RestaurantId restaurantId, CancellationToken token)
        {
            Restaurant restaurant;
            try
            {
                restaurant = await _restaurants.SingleAsync(x => x.Id == restaurantId, token);
            }
            catch (Exception)
            {
                throw new EntityNotFoundException(nameof(Restaurant), restaurantId.Value);
            }

            return restaurant;
        }
    }
}
