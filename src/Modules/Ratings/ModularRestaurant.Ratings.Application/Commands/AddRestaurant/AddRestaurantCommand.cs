using MediatR;
using ModularRestaurant.Shared.Application.CQRS;
using System;

namespace ModularRestaurant.Ratings.Application.Commands.AddRestaurant
{
    public record AddRestaurantCommand(Guid Id) : ICommand<Unit>;
}