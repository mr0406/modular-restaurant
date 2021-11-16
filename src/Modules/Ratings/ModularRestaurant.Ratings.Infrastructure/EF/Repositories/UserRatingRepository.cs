using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Ratings.Domain.Repositories;
using ModularRestaurant.Shared.Domain.Exceptions;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Ratings.Infrastructure.EF.Repositories
{
    public class UserRatingRepository : IUserRatingRepository
    {
        private readonly DbSet<UserRating> _userRatings;
        
        public UserRatingRepository(RatingsDbContext ratingsDbContext)
        {
            _userRatings = ratingsDbContext.UserRatings;
        }
        
        public async Task AddAsync(UserRating userRating, CancellationToken cancellationToken = default)
        {
            await _userRatings.AddAsync(userRating, cancellationToken);
        }

        public async Task<UserRating> GetAsync(UserRatingId userRatingId, CancellationToken cancellationToken = default)
        {
            var menu = await _userRatings.SingleOrDefaultAsync(x => x.Id == userRatingId, cancellationToken);
            if (menu is null) throw new ObjectNotFoundException(typeof(UserRating), userRatingId.Value);
            return menu;
        }

        public async Task<bool> CheckExists(UserId userId, RestaurantId restaurantId, CancellationToken cancellationToken = default)
        {
            var userRating = await _userRatings.SingleOrDefaultAsync(x => x.UserId == userId && x.RestaurantId == restaurantId,
                cancellationToken);

            return userRating is not null;
        }
    }
}