using Microsoft.AspNetCore.Mvc;
using ModularRestaurant.Ratings.Api.Requests;
using ModularRestaurant.Ratings.Application.Commands.AddRating;
using ModularRestaurant.Ratings.Application.Commands.AddRestaurant;
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
        public async Task<ActionResult<RestaurantDTO>> Get(Guid id)
            => Ok(await Mediator.Send(new GetRestaurantRatingsQuery(id)));

        [HttpPost]
        public async Task<ActionResult> AddRestaurant(AddRestaurantRequest addRestaurantRequest)
            => Ok(await Mediator.Send(new AddRestaurantCommand(addRestaurantRequest.Id)));

        [HttpPost("addRating")]
        public async Task<ActionResult> AddRating(AddRatingRequest addRatingRequest)
            => Ok(await Mediator.Send(new AddRatingCommand(
                    addRatingRequest.RestaurantId,
                    addRatingRequest.UserId,
                    addRatingRequest.Rating,
                    addRatingRequest.Text)));
    }
}
