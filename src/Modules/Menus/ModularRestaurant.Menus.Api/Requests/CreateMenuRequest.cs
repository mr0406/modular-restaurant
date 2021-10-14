using MediatR;
using ModularRestaurant.Menus.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Api.Requests
{
    public record CreateMenuRequest
    {
        public Guid RestaurantId { get; init; }

        public CreateMenuRequest(Guid restaurantId)
        {
            RestaurantId = restaurantId;
        }
    }

}
