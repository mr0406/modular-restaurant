using System;
using System.Threading.Tasks;
using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Ratings.Domain.Services;
using ModularRestaurant.Shared.Domain.Types;
using Moq;

namespace ModularRestaurant.Ratings.Domain.UnitTests
{
    internal static class Provider
    {
        internal static Guid GetUserGuid() => new("6CD363B0-B335-4DDA-A12D-4AA214678888");

        internal static UserId GetUserId() => new(GetUserGuid());

        internal static Guid GetRestaurantGuid() => new("945A4382-75DB-4EED-830F-753ED8DA0832");
        
        internal static RestaurantId GetRestaurantId() => new(GetRestaurantGuid());

        internal static int GetRatingValue() => 5;
        
        internal static Rating GetRating() => Rating.FromValue(GetRatingValue());

        internal static string GetUserComment() => "comment";
        
        internal static int GetCommentCharacterLimit() => 500;
        
        internal static string GetRestaurantReply() => "reply";

        internal static int GetRestaurantReplyCharacterLimi() => 500;

        internal static IUserRatingUniquenessChecker GetUniquenessCheckerWhichPass()
        {
            var mock = new Mock<IUserRatingUniquenessChecker>();
            mock.Setup(x => x.CheckIsUnique(It.IsAny<UserId>(), It.IsAny<RestaurantId>()))
                .Returns(Task.FromResult(true));

            return mock.Object;
        }
        
        internal static IUserRatingUniquenessChecker GetUniquenessCheckerWhichFails()
        {
            var mock = new Mock<IUserRatingUniquenessChecker>();
            mock.Setup(x => x.CheckIsUnique(It.IsAny<UserId>(), It.IsAny<RestaurantId>()))
                .Returns(Task.FromResult(false));

            return mock.Object;
        }

        internal static UserRating GetUserRatingWithoutReply() => UserRating.Create(GetUserId(), GetRestaurantId(),
            GetRating(), GetUserComment(), GetUniquenessCheckerWhichPass());

        internal static UserRating GetUserRatingWithReply()
        {
            var userRating = GetUserRatingWithoutReply();
            var reply = GetRestaurantReply();
            userRating.AddRestaurantReply(reply);
            return userRating;
        }
    }
}