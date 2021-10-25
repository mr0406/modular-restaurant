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
        public RatingsController(IRatingsExecutor executor) : base(executor)
        {
        }
        
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RestaurantDTO>> Get([FromQuery] Guid id)
            => Ok(await Executor.ExecuteQuery(new GetRestaurantRatingsQuery(id)));

        [HttpPost]
        public async Task<ActionResult> AddRestaurant([FromBody] AddRestaurantRequest addRestaurantRequest)
            => Ok(await Executor.ExecuteCommand(new AddRestaurantCommand(addRestaurantRequest.Id)));

        [HttpPost("addRating")]
        public async Task<ActionResult> AddRating([FromBody] AddRatingRequest addRatingRequest)
            => Ok(await Executor.ExecuteCommand(new AddRatingCommand(
                addRatingRequest.RestaurantId,
                addRatingRequest.UserId,
                addRatingRequest.Rating,
                addRatingRequest.Text)));
    }
}
