using ModularRestaurant.Ratings.Domain.Rules;
using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Ratings.Domain.Entities
{
    public class UserRating : Entity
    {
        public UserId UserId { get; private set; }

        public Rating Rating { get; private set; }

        public string Comment { get; private set; }

        public string RestaurantReply { get; private set; }

        private UserRating()
        {
        }

        private UserRating(UserId userId, Rating rating, string comment)
        {
            UserId = userId;
            Rating = rating;

            if (comment is not null) Comment = comment;
        }

        public static UserRating Create(UserId userId, int ratingValue, string comment)
        {
            comment = comment?.Trim();
            
            CheckRule(new CommentCannotExceedCharacterLimit(comment));
            
            return new(userId, Rating.FromValue(ratingValue), comment);
        }

        public void AddRestaurantReply(string restaurantReply)
        {
            CheckRule(new CanReplyToUserRatingOnlyOnceRule(RestaurantReply));
            
            restaurantReply = restaurantReply?.Trim();
            
            CheckRule(new RestaurantReplyCannotBeEmptyRule(restaurantReply));
            CheckRule(new RestaurantReplyCannotExceedCharacterLimit(restaurantReply));
            
            RestaurantReply = restaurantReply;
        }
    }
}