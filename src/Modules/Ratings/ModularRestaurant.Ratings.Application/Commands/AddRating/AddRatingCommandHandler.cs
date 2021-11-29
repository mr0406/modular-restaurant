using System;
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
        private readonly IUserRatingUniquenessChecker _userRatingUniquenessChecker;

        public AddRatingCommandHandler(IUserRatingRepository userRatingRepository, IUserRatingUniquenessChecker userRatingUniquenessChecker)
        {
            _userRatingRepository = userRatingRepository;
            _userRatingUniquenessChecker = userRatingUniquenessChecker;
        }

        public async Task<Guid> Handle(AddRatingCommand command, CancellationToken token)
        {
            var userId = new UserId(command.UserId);
            var restaurantId = new RestaurantId(command.RestaurantId);
            var rating = Rating.FromValue(command.Value);
            
            var userRating = UserRating.Create(userId, restaurantId, rating, command.Text, _userRatingUniquenessChecker);

            await _userRatingRepository.AddAsync(userRating, token);

            return userRating.Id.Value;
        }
    }
}