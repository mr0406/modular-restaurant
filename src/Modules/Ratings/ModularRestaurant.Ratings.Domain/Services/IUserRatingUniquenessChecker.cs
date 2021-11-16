using System.Threading.Tasks;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Ratings.Domain.Services
{
    public interface IUserRatingUniquenessChecker
    {
        Task<bool> CheckIsUnique(UserId userId, RestaurantId restaurantId);
    }
}