using Microsoft.AspNetCore.Mvc;

namespace ModularRestaurant.Ratings.Api.Controllers
{
    [ApiController]
    public class HomeController : RatingsControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get() => "Ratings API!";
    }
}
