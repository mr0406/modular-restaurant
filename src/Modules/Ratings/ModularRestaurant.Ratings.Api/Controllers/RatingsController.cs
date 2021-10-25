using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult> AddRestaurant([FromBody] AddRestaurantCommand command)
            => Ok(await Executor.ExecuteCommand(command));

        [HttpPost("addRating")]
        public async Task<ActionResult> AddRating([FromBody] AddRatingCommand command)
            => Ok(await Executor.ExecuteCommand(command));
    }
}
