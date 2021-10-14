using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Shared.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Domain.Repositories
{
    public interface IRestaurantRepository
    {
        Task AddAsync(Restaurant restaurant, CancellationToken token);
        Task<Restaurant> GetAsync(RestaurantId restaurantId, CancellationToken token);
    }
}
