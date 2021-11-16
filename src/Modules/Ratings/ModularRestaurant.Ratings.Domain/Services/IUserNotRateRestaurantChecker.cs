using System.Threading.Tasks;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Ratings.Domain.Services
{
    public interface IUserNotRateRestaurantChecker
    {
        Task<bool> CheckRatingNotExists(UserId userId, RestaurantId restaurantId);
    }
}