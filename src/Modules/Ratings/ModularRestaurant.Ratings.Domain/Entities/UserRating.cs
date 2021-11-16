using System;
using ModularRestaurant.Ratings.Domain.Rules;
using ModularRestaurant.Ratings.Domain.Services;
using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Ratings.Domain.Entities
{
    public class UserRating : AggregateRoot<UserRatingId>
    {
        public UserId UserId { get; private set; }
        
        public RestaurantId RestaurantId { get; private set; }

        public Rating Rating { get; private set; }

        public string Comment { get; private set; }

        public string RestaurantReply { get; private set; }

        private UserRating()
        {
        }

        private UserRating(RestaurantId restaurantId, UserId userId, Rating rating, string comment)
        {
            Id = new UserRatingId(Guid.NewGuid());
            UserId = userId;
            RestaurantId = restaurantId;
            Rating = rating;

            if (comment is not null) Comment = comment;
        }

        public static UserRating Create(UserId userId, RestaurantId restaurantId, Rating rating, 
            string comment, IUserRatingUniquenessChecker userRatingUniquenessChecker)
        {
            comment = comment?.Trim();
            comment = string.IsNullOrEmpty(comment) ? null : comment; 
            
            CheckRule(new UserCanOnlyRateRestaurantOnceRule(userId, restaurantId, userRatingUniquenessChecker));
            CheckRule(new CommentCannotExceedCharacterLimit(comment));
            
            return new(restaurantId, userId, rating, comment);
        }

        public void AddRestaurantReply(string reply)
        {
            reply = reply?.Trim();
            
            CheckRule(new CanReplyToUserRatingOnlyOnceRule(RestaurantReply));
            CheckRule(new RestaurantReplyCannotBeEmptyRule(reply));
            CheckRule(new RestaurantReplyCannotExceedCharacterLimit(reply));
            
            RestaurantReply = reply;
        }
    }
}