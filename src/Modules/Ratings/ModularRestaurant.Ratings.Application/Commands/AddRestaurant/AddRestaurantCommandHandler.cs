using MediatR;
using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Ratings.Domain.Repositories;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Application.Commands.AddRestaurant
{
    public class AddRestaurantCommandHandler : ICommandHandler<AddRestaurantCommand, Unit>
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public AddRestaurantCommandHandler(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<Unit> Handle(AddRestaurantCommand command, CancellationToken token)
        {
            var restaurant = Restaurant.Create(command.Id);

            await _restaurantRepository.AddAsync(restaurant, token);

            return Unit.Value;
        }
    }
}
