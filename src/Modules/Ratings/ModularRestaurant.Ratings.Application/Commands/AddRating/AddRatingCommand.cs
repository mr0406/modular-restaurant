using MediatR;
using ModularRestaurant.Shared.Application.CQRS;
using System;

namespace ModularRestaurant.Ratings.Application.Commands.AddRating
{
    public record AddRatingCommand(Guid RestaurantId, Guid UserId, int Rating, string Text) : ICommand<Unit>;
}