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
        private readonly DbSet<UserRating> _useRatings;
        
        public UserRatingRepository(RatingsDbContext ratingsDbContext)
        {
            _useRatings = ratingsDbContext.UserRatings;
        }
        
        public async Task AddAsync(UserRating userRating, CancellationToken cancellationToken = default)
        {
            await _useRatings.AddAsync(userRating, cancellationToken);
        }

        public async Task<UserRating> GetAsync(UserRatingId userRatingId, CancellationToken cancellationToken = default)
        {
            var menu = await _useRatings.SingleOrDefaultAsync(x => x.Id == userRatingId, cancellationToken);
            if (menu is null) throw new ObjectNotFoundException(typeof(UserRating), userRatingId.Value);
            return menu;
        }
    }
}