using MediatR;
using ModularRestaurant.Shared.Application.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Application.Commands.AddRestaurant
{
    public record AddRestaurantCommand(Guid Id) : ICommand<Unit>;
}