using ModularRestaurant.Shared.Application.CQRS;
using System;

namespace ModularRestaurant.Ratings.Application.Queries
{
    public record GetRestaurantRatingsQuery(Guid RestaurantId , int Page, int Size) : IQuery<GetRestaurantRatingsQueryResult>;
}