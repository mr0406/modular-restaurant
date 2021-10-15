using ModularRestaurant.Ratings.Application.DTOs;
using ModularRestaurant.Shared.Application.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Application.Queries
{
    public record GetRestaurantRatingsQuery(Guid Id/*, int RecordsPerPage, int PageNumber*/) : IQuery<RestaurantDTO>;
}
