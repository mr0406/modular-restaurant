using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Ratings.Domain.Rules
{
    public class CanAddReplyOnlyToExistingUserRatingRule : IBusinessRule
    {
        private readonly UserRating _userRating;

        public CanAddReplyOnlyToExistingUserRatingRule(UserRating userRating)
        {
            _userRating = userRating;
        }

        public bool IsBroken() => _userRating is null;
        
        public string Message => "Cannot add reply to not existing user rating.";
    }
}