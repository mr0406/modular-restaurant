using Microsoft.AspNetCore.Mvc;

namespace ModularRestaurant.Bootstrapper.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Modular Restaurant API!";
        }
    }
}