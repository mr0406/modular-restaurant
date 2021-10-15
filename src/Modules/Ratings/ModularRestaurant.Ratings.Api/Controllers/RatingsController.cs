using Microsoft.AspNetCore.Mvc;
using ModularRestaurant.Ratings.Application.DTOs;
using ModularRestaurant.Ratings.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Api.Controllers
{
    public class RatingsController : RatingsControllerBase
    {
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RestaurantDTO>> GetRestaurant(Guid id)
            => Ok(await Mediator.Send(new GetRestaurantRatingsQuery(id)));
    }
}
