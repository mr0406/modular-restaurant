using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Ratings.Domain.Rules
{
    public class CanAddReplyToExistingUserRatingRule : IBusinessRule
    {
        public string Message => "Cannot add reply to not existing user rating.";

        private readonly UserRating _userRating;

        public CanAddReplyToExistingUserRatingRule(UserRating userRating)
        {
            _userRating = userRating;
        }

        public bool IsBroken() => _userRating is null;
    }
}