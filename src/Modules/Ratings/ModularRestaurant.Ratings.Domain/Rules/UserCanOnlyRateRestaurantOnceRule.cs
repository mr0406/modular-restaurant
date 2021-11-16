using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Types;
using System.Collections.Generic;
using System.Linq;
using ModularRestaurant.Ratings.Domain.Services;

namespace ModularRestaurant.Ratings.Domain.Rules
{
    public class UserCanOnlyRateRestaurantOnceRule : IBusinessRule
    {
        private readonly UserId _userId;
        private readonly RestaurantId _restaurantId;
        private readonly IUserNotRateRestaurantChecker _userNotRateRestaurantChecker;


        public UserCanOnlyRateRestaurantOnceRule(UserId userId, RestaurantId restaurantId, IUserNotRateRestaurantChecker userNotRateRestaurantChecker)
        {
            _userId = userId;
            _restaurantId = restaurantId;
            _userNotRateRestaurantChecker = userNotRateRestaurantChecker;
        }

        public bool IsBroken() => !_userNotRateRestaurantChecker.CheckRatingNotExists(_userId, _restaurantId).Result;
        
        public string Message => "Cannot rate restaurant more than once.";
    }
}