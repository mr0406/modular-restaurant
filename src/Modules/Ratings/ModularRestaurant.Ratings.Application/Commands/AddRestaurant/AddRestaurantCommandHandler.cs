using MediatR;
using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Ratings.Domain.Repositories;
using ModularRestaurant.Shared.Application.CQRS;
using System.Threading;
using System.Threading.Tasks;
using ModularRestaurant.Shared.Domain.Types;

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
            var restaurantId = new RestaurantId(command.Id);
            var restaurant = Restaurant.Create(restaurantId);

            await _restaurantRepository.AddAsync(restaurant, token);

            return Unit.Value;
        }
    }
}