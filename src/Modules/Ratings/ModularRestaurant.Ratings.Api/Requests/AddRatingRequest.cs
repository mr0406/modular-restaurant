using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Api.Requests
{
    public record AddRatingRequest(Guid RestaurantId, Guid UserId, int Rating, string Text)
    {
    }
}
