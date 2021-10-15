using ModularRestaurant.Ratings.Application.DTOs;
using ModularRestaurant.Ratings.Application.Queries;
using ModularRestaurant.Shared.Application.CQRS;
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
        public async Task<RestaurantDTO> Handle(GetRestaurantRatingsQuery query, CancellationToken token)
        {
            var restaurant = GetRestaurant(query.Id);

            var a = GetUserDetailsFromOtherModule(restaurant.UserRatings.Select(x => x.UserId));

            foreach(var rating in restaurant.UserRatings)
            {
                rating.Username = a.Single(x => x.Id == rating.UserId).UserName;
            }

            return restaurant;
        }

        public static RestaurantDTO GetRestaurant(Guid id)
        {
            return new RestaurantDTO
            {
                Id = id,
                AverageRating = 4.3,
                UserRatings = new List<UserRatingDTO>
                {
                    new UserRatingDTO()
                    {
                        UserId = Guid.NewGuid(),
                        Rating = 5,
                        Comment = "Everything fine!!!",
                        RestaurantReply = "Thanks!!!"
                    },
                    new UserRatingDTO()
                    {
                        UserId = Guid.NewGuid(),
                        Rating = 2,
                        Comment = "So bad!!!"
                    },
                }
            };
        }

        public static IEnumerable<UserDetails> GetUserDetailsFromOtherModule(IEnumerable<Guid> userIds)
        {
            return userIds.Select(id => new UserDetails { Id = id, UserName = $"NameFor{id}" });
        }
    }

    public class UserDetails
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }
    }
}
