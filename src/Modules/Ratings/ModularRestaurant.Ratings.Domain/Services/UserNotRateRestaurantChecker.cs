using System.Threading.Tasks;
using ModularRestaurant.Ratings.Domain.Repositories;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Ratings.Domain.Services
{
    public class UserNotRateRestaurantChecker : IUserNotRateRestaurantChecker
    {
        private readonly IUserRatingRepository _userRatingRepository;

        public UserNotRateRestaurantChecker(IUserRatingRepository userRatingRepository)
        {
            _userRatingRepository = userRatingRepository;
        }

        public async Task<bool> CheckRatingNotExists(UserId userId, RestaurantId restaurantId)
        {
            return !await _userRatingRepository.CheckExists(userId, restaurantId);
        }
    }
}