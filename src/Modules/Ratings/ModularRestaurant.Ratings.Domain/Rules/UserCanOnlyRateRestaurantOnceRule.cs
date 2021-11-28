using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Types;
using ModularRestaurant.Ratings.Domain.Services;

namespace ModularRestaurant.Ratings.Domain.Rules
{
    public class UserCanOnlyRateRestaurantOnceRule : IBusinessRule
    {
        private readonly UserId _userId;
        private readonly RestaurantId _restaurantId;
        private readonly IUserRatingUniquenessChecker _userRatingUniquenessChecker;


        public UserCanOnlyRateRestaurantOnceRule(UserId userId, RestaurantId restaurantId, IUserRatingUniquenessChecker userRatingUniquenessChecker)
        {
            _userId = userId;
            _restaurantId = restaurantId;
            _userRatingUniquenessChecker = userRatingUniquenessChecker;
        }

        public bool IsBroken() => !_userRatingUniquenessChecker.CheckIsUnique(_userId, _restaurantId).Result;
        
        public string Message => "Cannot rate restaurant more than once.";
    }
}