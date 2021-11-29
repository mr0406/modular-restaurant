using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Ratings.Application.Queries;
using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Types;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Infrastructure.EF.QueryHandlers
{
    public class GetRestaurantRatingsQueryHandler : IQueryHandler<GetRestaurantRatingsQuery, GetRestaurantRatingsQueryResult>
    {
        private readonly DbSet<UserRating> _userRatings;

        public GetRestaurantRatingsQueryHandler(RatingsDbContext ratingsDbContext)
        {
            _userRatings = ratingsDbContext.UserRatings;
        }

        public async Task<GetRestaurantRatingsQueryResult> Handle(GetRestaurantRatingsQuery query, CancellationToken token)
        {
            var restaurantId = new RestaurantId(query.RestaurantId);
            
            var restaurantRatingsQuery = _userRatings
                .Where(x => x.RestaurantId == restaurantId)
                .GroupBy(x => x.RestaurantId)
                .Select(x => new { Sum = x.Sum(userRating => userRating.Rating.Value), Count = x.Count() })
                .SingleOrDefaultAsync(token);

            var userRatingsQuery = _userRatings
                .Where(x => x.RestaurantId == restaurantId)
                .OrderBy(x => x.UserId)                     //Should be ordered by date
                .Skip((query.Page - 1) * query.Size).Take(query.Size)
                .Select(x => new GetRestaurantRatingsQueryResult.UserRating
                {
                    UserId = x.UserId.Value,
                    Username = "No username for now",
                    Rating = x.Rating.Value,
                    RestaurantReply = x.RestaurantReply
                })   
                .ToListAsync(token);

            var restaurantRatings = await restaurantRatingsQuery;
            var userRatings = await userRatingsQuery;

            return new GetRestaurantRatingsQueryResult
            {
                SumOfRatings = restaurantRatings.Sum,
                NumberOfRatings = restaurantRatings.Count,
                UserRatings = userRatings
            };
        }
    }
}