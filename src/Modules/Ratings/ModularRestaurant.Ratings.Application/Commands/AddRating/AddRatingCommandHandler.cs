using System;
using MediatR;
using ModularRestaurant.Ratings.Domain.Repositories;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Types;
using System.Threading;
using System.Threading.Tasks;
using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Ratings.Domain.Services;

namespace ModularRestaurant.Ratings.Application.Commands.AddRating
{
    public class AddRatingCommandHandler : ICommandHandler<AddRatingCommand, Guid>
    {
        private readonly IUserRatingRepository _userRatingRepository;
        private readonly IUserNotRateRestaurantChecker _userNotRateRestaurantChecker;

        public AddRatingCommandHandler(IUserRatingRepository userRatingRepository, IUserNotRateRestaurantChecker userNotRateRestaurantChecker)
        {
            _userRatingRepository = userRatingRepository;
            _userNotRateRestaurantChecker = userNotRateRestaurantChecker;
        }

        public async Task<Guid> Handle(AddRatingCommand command, CancellationToken token)
        {
            var userId = new UserId(command.UserId);
            var restaurantId = new RestaurantId(command.RestaurantId);
            
            var userRating = UserRating.Create(userId, restaurantId, command.Value, command.Text, _userNotRateRestaurantChecker);

            await _userRatingRepository.AddAsync(userRating, token);

            return userRating.Id.Value;
        }
    }
}