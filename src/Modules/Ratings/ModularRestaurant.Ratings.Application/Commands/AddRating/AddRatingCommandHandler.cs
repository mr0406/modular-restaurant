using MediatR;
using ModularRestaurant.Ratings.Domain.Repositories;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Types;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Application.Commands.AddRating
{
    public class AddRatingCommandHandler : ICommandHandler<AddRatingCommand, Unit>
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public AddRatingCommandHandler(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<Unit> Handle(AddRatingCommand command, CancellationToken token)
        {
            var restaurant = await _restaurantRepository.GetAsync(new RestaurantId(command.RestaurantId), token);

            restaurant.AddUserRating(new UserId(command.UserId), command.Rating, command.Text);

            return Unit.Value;
        }
    }
}