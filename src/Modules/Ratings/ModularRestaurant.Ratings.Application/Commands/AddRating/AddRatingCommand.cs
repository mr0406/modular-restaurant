using MediatR;
using ModularRestaurant.Shared.Application.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Application.Commands.AddRating
{
    public record AddRatingCommand(Guid RestaurantId, Guid UserId, int Rating, string Text) : ICommand<Unit>;
}
