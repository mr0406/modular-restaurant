using ModularRestaurant.Shared.Application.CQRS;
using System;

namespace ModularRestaurant.Ratings.Application.Commands.AddRating
{
    public record AddRatingCommand(Guid RestaurantId, Guid UserId, int Value, string Text) : ICommand<Guid>;
}