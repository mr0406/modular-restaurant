using ModularRestaurant.Ratings.Application.DTOs;
using ModularRestaurant.Shared.Application.CQRS;
using System;

namespace ModularRestaurant.Ratings.Application.Queries
{
    public record GetRestaurantRatingsQuery(Guid Id , int Page, int Size) : IQuery<RestaurantDTO>;
}