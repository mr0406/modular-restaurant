using ModularRestaurant.Ratings.Domain.Rules;
using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Ratings.Domain.Entities
{
    public class UserRating : Entity
    {
        public UserId UserId { get; private set; }

        public Rating Rating { get; private set; }

        public Comment Comment { get; private set; }

        private UserRating(UserId userId, Rating rating)
        {
            UserId = userId;
            Rating = rating;
        }

        internal static UserRating Create(UserId userId, int ratingValue)
            => new UserRating(userId, Rating.FromValue(ratingValue));

        internal void AddComment(string text)
        {

        }
    }
}
