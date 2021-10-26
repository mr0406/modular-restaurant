using ModularRestaurant.Shared.Application.CQRS;
using System;

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