using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Ratings.Domain.Repositories;
using ModularRestaurant.Shared.Domain.Types;
using System;
using System.Threading;
using System.Threading.Tasks;
using ModularRestaurant.Shared.Domain.Exceptions;

namespace ModularRestaurant.Ratings.Infrastructure.EF.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RatingsDbContext _dbContext;
        private readonly DbSet<Restaurant> _restaurants;

        public RestaurantRepository(RatingsDbContext dbContext)
        {
            _dbContext = dbContext;
            _restaurants = dbContext.Restaurants;
        }

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
                throw new ObjectNotFoundException(typeof(Restaurant), restaurantId.Value);
            }

            return restaurant;
        }
    }
}