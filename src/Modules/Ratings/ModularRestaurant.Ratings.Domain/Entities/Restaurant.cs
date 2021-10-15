using ModularRestaurant.Ratings.Domain.Rules;
using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Domain.Entities
{
    public class Restaurant : AggregateRoot<RestaurantId>
    {
        public IReadOnlyList<UserRating> UserRatings;
        private List<UserRating> _userRatings = new();

        public void Create() { } //communicate from restaurant module when restaurant is created

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
