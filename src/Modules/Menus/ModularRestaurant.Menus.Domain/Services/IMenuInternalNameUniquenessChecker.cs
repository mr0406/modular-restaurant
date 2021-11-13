using System.Threading.Tasks;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Domain.Services
{
    public interface IMenuInternalNameUniquenessChecker
    {
        Task<bool> CheckIsUnique(RestaurantId restaurantId, string newInternalName);
    }
}