using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Shared.Application;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Application.Commands.CreateMenu
{
    public record CreateMenuCommand : ICommand<Guid>
    {
        public Guid RestaurantId { get; init; }

        public CreateMenuCommand(Guid restaurantId)
        {
            RestaurantId = restaurantId;
        }
    }
}
