using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menu.Api.Controllers
{
    public class MenuController : MenuControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get() => "Menu items";
    }
}
