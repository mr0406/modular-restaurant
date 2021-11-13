using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularRestaurant.Ratings.Domain.Repositories;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Ratings.Application.Commands.AddRestaurantReply
{
    public class AddRestaurantReplyCommandHandler : ICommandHandler<AddRestaurantReplyCommand, Unit>
    {
        private readonly IUserRatingRepository _userRatingRepository;

        public AddRestaurantReplyCommandHandler(IUserRatingRepository userRatingRepository)
        {
            _userRatingRepository = userRatingRepository;
        }
        
        public async Task<Unit> Handle(AddRestaurantReplyCommand request, CancellationToken cancellationToken)
        {
            var userRatingId = new UserRatingId(request.UserRatingId);

            var userRating = await _userRatingRepository.GetAsync(userRatingId, cancellationToken);
            
            userRating.AddRestaurantReply(request.Reply);

            return Unit.Value;
        }
    }
}