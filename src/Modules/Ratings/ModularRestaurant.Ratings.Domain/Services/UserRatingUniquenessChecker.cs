using System.Threading.Tasks;
using ModularRestaurant.Ratings.Domain.Repositories;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Ratings.Domain.Services
{
    public class UserRatingUniquenessChecker : IUserRatingUniquenessChecker
    {
        private readonly IUserRatingRepository _userRatingRepository;

        public UserRatingUniquenessChecker(IUserRatingRepository userRatingRepository)
        {
            _userRatingRepository = userRatingRepository;
        }

        public async Task<bool> CheckIsUnique(UserId userId, RestaurantId restaurantId)
        {
            var isUnique = !await _userRatingRepository.CheckExists(userId, restaurantId);
            return isUnique;
        }
    }
}