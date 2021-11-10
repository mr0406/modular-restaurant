using Microsoft.AspNetCore.Mvc;
using ModularRestaurant.Ratings.Application.Commands.AddRating;
using ModularRestaurant.Ratings.Application.Commands.AddRestaurant;
using ModularRestaurant.Ratings.Application.Queries;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ModularRestaurant.Ratings.Infrastructure;
using ModularRestaurant.Shared.Api;

namespace ModularRestaurant.Ratings.Api.Controllers
{
    public class RatingsController : RatingsControllerBase
    {
        public RatingsController(IRatingsExecutor executor) : base(executor)
        {
        }

        [HttpGet("{restaurantId:guid}")]
        [ProducesResponseType(typeof(GetRestaurantRatingsQueryResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetRestaurantRatingsQueryResult>> Get([FromRoute] Guid restaurantId, [FromQuery] int page = 1, [FromQuery] int size = 10)
            => Ok(await Executor.ExecuteQuery(new GetRestaurantRatingsQuery(restaurantId, page, size)));

        [HttpPost("add-restaurant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> AddRestaurant([FromBody] AddRestaurantCommand command)
            => Ok(await Executor.ExecuteCommand(command));

        [HttpPost("add-rating")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> AddRating([FromBody] AddRatingCommand command)
            => Ok(await Executor.ExecuteCommand(command));
        
        //TODO: Add method for AddRestaurantReply
    }
}