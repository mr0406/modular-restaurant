using Microsoft.AspNetCore.Mvc;

namespace ModularRestaurant.Ratings.Api.Controllers
{
    [ApiController]
    public class HomeController : RatingsControllerBase
    {
        public HomeController(IRatingsExecutor executor) : base(executor)
        {
        }
        
        [HttpGet("")]
        public ActionResult<string> Get() => "Ratings API!";
        
    }
}
