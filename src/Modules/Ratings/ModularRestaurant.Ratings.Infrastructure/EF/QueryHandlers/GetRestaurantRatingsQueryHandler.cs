using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Ratings.Application.Queries;
using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Infrastructure.EF.QueryHandlers
{
    public class GetRestaurantRatingsQueryHandler : IQueryHandler<GetRestaurantRatingsQuery, GetRestaurantRatingsQueryResult>
    {
        private readonly DbSet<Restaurant> _restaurants;

        public GetRestaurantRatingsQueryHandler(RatingsDbContext ratingsDbContext)
        {
            _restaurants = ratingsDbContext.Restaurants;
        }

        public async Task<GetRestaurantRatingsQueryResult> Handle(GetRestaurantRatingsQuery query, CancellationToken token)
        {
            var restaurant = await _restaurants.Where(x => x.Id == new RestaurantId(query.RestaurantId))
                .Select(x => new GetRestaurantRatingsQueryResult()
                {
                    NumberOfRatings = x.UserRatings.Count,
                    SumOfRatings = x.UserRatings.Sum(y => y.Rating.Value),
                    UserRatings = x.UserRatings.Select(y => new GetRestaurantRatingsQueryResult.UserRating
                    {
                        UserId = y.UserId.Value,
                        Rating = y.Rating.Value,
                        Comment = y.Comment,
                        RestaurantReply = y.RestaurantReply
                    }).Skip((query.Page - 1) * query.Size).Take(query.Size).ToList()
                })
                .SingleOrDefaultAsync(token);

            if (restaurant is null) return null; //TODO: Not Found

            return restaurant;

            if (restaurant.NumberOfRatings > 0)
            {
                var a = GetUserDetailsFromOtherModule(restaurant.UserRatings.Select(x => x.UserId)).ToList();

                for (var i = 0; i < restaurant.UserRatings.Count(); i++)
                    restaurant.UserRatings[i].Username =
                        a.Single(x => x.Id == restaurant.UserRatings[i].UserId).Username;
            }

            return restaurant;
        }

        public static IEnumerable<UserDetails> GetUserDetailsFromOtherModule(IEnumerable<Guid> userIds)
        {
            return userIds.Select(id => new UserDetails {Id = id, Username = $"NameFor: {id}"});
        }
    }

    public class UserDetails
    {
        public Guid Id { get; set; }

        public string Username { get; set; }
    }
}