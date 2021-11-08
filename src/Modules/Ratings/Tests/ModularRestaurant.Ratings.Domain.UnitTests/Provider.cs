using System;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Ratings.Domain.UnitTests
{
    internal static class Provider
    {
        internal static Guid GetUserGuid() => new("6CD363B0-B335-4DDA-A12D-4AA214678888");

        internal static UserId GetUserId() => new(GetUserGuid());

        internal static Guid GetRestaurantGuid() => new("945A4382-75DB-4EED-830F-753ED8DA0832");
        
        internal static RestaurantId GetRestaurantId() => new(GetRestaurantGuid());

        internal static int GetRatingValue() => 5;

        internal static string GetUserComment() => "comment";

        internal static string GetRestaurantReply() => "reply";
    }
}