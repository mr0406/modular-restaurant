using Microsoft.AspNetCore.Mvc;

namespace ModularRestaurant.Ratings.Api.Controllers
{
    [Route("ratings-module")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Ratings API!";
        }
    }
}