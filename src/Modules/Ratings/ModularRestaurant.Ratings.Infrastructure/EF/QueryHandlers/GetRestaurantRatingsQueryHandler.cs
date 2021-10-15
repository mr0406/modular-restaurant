using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Ratings.Application.DTOs;
using ModularRestaurant.Ratings.Application.Queries;
using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Infrastructure.EF.QueryHandlers
{
    public class GetRestaurantRatingsQueryHandler : IQueryHandler<GetRestaurantRatingsQuery, RestaurantDTO>
    {
        private readonly DbSet<Restaurant> _restaurants;

        public GetRestaurantRatingsQueryHandler(RatingsDbContext dbContext)
        {
            _restaurants = dbContext.Restaurants;
        }

        public async Task<RestaurantDTO> Handle(GetRestaurantRatingsQuery query, CancellationToken token)
        {
            var restaurant = await _restaurants.Where(x => x.Id == new RestaurantId(query.Id))
                                               .Select(x => new RestaurantDTO()
                                               {
                                                    Id = x.Id.Value,
                                                    AverageRating = x.UserRatings.Sum(y => y.Rating.Value) / x.UserRatings.Count(),
                                                    UserRatings = x.UserRatings.Select(y => new UserRatingDTO
                                                    {
                                                        UserId = y.UserId.Value,
                                                        Rating = y.Rating.Value,
                                                        Comment = y.Comment.Text,
                                                        RestaurantReply = y.RestaurantReply.Text
                                                    }).Take(2).ToList()
                                               })
                                               .SingleOrDefaultAsync(token);

            if(restaurant is null)
            {
                return null; //TODO: Not Found
            }

            var a = GetUserDetailsFromOtherModule(restaurant.UserRatings.Select(x => x.UserId)).ToList();

            for(int i = 0; i < restaurant.UserRatings.Count(); i++)
            {
                restaurant.UserRatings[i].Username = a.Single(x => x.Id == restaurant.UserRatings[i].UserId).Username;
            }

            return restaurant;
        }

        public static IEnumerable<UserDetails> GetUserDetailsFromOtherModule(IEnumerable<Guid> userIds)
        {
            return userIds.Select(id => new UserDetails { Id = id, Username = $"NameFor: {id}" });
        }
    }

    public class UserDetails
    {
        public Guid Id { get; set; }

        public string Username { get; set; }
    }
}
