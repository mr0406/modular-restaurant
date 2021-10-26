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
        public static Restaurant Create(Guid id)
        {
            return new Restaurant(new RestaurantId(id));
        }

        public void AddUserRating(UserId userId, int ratingValue, string text)
        {
            CheckRule(new UserCanOnlyRateRestaurantOnceRule(userId, _userRatings));

            _userRatings.Add(UserRating.Create(userId, ratingValue, text));
        }

        public void AddCommentToUserRating(UserId userId, string text)
        {
            var userRating = UserRatings.Single(x => x.UserId == userId);
            userRating.AddRestaurantReply(text);
        }
    }
}