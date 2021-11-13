using System;
using MediatR;
using ModularRestaurant.Shared.Application.CQRS;

namespace ModularRestaurant.Ratings.Application.Commands.AddRestaurantReply
{
    public record AddRestaurantReplyCommand(Guid UserRatingId, string Reply) : ICommand<Unit>;
}