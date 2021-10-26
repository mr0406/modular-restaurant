using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Types;
using System.Collections.Generic;
using System.Linq;

namespace ModularRestaurant.Ratings.Domain.Rules
{
    public class UserCanOnlyRateRestaurantOnceRule : IBusinessRule
    {
        public string Message => "Cannot rate restaurant more than once";

        private readonly UserId _userId;
        private readonly List<UserRating> _userRatings;

        public UserCanOnlyRateRestaurantOnceRule(UserId userId, List<UserRating> userRatings)
        {
            _userId = userId;
            _userRatings = userRatings;
        }

        public bool IsBroken()
        {
            return _userRatings.Select(x => x.UserId).Contains(_userId);
        }
    }
}