using ModularRestaurant.Ratings.Domain.Rules;
using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModularRestaurant.Ratings.Domain.Entities
{
    public class Restaurant : AggregateRoot<RestaurantId>
    {
        public IReadOnlyList<UserRating> UserRatings => _userRatings;
        private List<UserRating> _userRatings = new();

        private Restaurant()
        {
        }

        public Restaurant(RestaurantId id)
        {
            Id = id;
        }

        //TODO: Removed after add integration with restaurantModule
        public static Restaurant Create(RestaurantId id)
        {
            return new Restaurant(id);
        }

        public void AddUserRating(UserId userId, int ratingValue, string text)
        {
            CheckRule(new UserCanOnlyRateRestaurantOnceRule(userId, _userRatings));

            _userRatings.Add(UserRating.Create(userId, ratingValue, text));
        }

        public void AddReplyToUserRating(UserId userId, string text)
        {
            var userRating = UserRatings.SingleOrDefault(x => x.UserId == userId);
            
            CheckRule(new CanAddReplyOnlyToExistingUserRatingRule(userRating));
            
            userRating!.AddRestaurantReply(text);
        }
    }
}