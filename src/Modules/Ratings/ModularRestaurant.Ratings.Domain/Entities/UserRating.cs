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

        public Comment RestaurantReply { get; private set; }

        private UserRating()
        {
        }

        private UserRating(UserId userId, Rating rating, Comment comment)
        {
            UserId = userId;
            Rating = rating;
            Comment = comment;
        }

        internal static UserRating Create(UserId userId, int ratingValue, string text)
            => new UserRating(userId, Rating.FromValue(ratingValue), Comment.FromText(text));

        internal void AddRestaurantReply(string text) => RestaurantReply = Comment.FromText(text);
    }
}
