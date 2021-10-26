using Microsoft.AspNetCore.Mvc;

namespace ModularRestaurant.Ratings.Api.Controllers
{
    [Route("ratings-module/[controller]")]
    public abstract class RatingsControllerBase : ControllerBase
    {
        protected readonly IRatingsExecutor Executor;

        public RatingsControllerBase(IRatingsExecutor executor)
        {
            Executor = executor;
        }
    }
}