using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Shared.Domain.Types;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Domain.Repositories
{
    public interface IUserRatingRepository
    {
        Task AddAsync(UserRating userRating, CancellationToken cancellationToken = default);

        Task<UserRating> GetAsync(UserRatingId userRatingId, CancellationToken cancellationToken = default);
    }
}