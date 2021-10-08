using Microsoft.AspNetCore.Mvc;
using ModularRestaurant.Menus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Api.Controllers
{
    public class MenuController : MenusControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            var menu = Menu.CreateNew();
            menu.AddGroup("First Group");
            menu.AddItemToGroup("First Group", "First Item");
            menu.AddItemToGroup("First Group", "Another Item");
            menu.AddGroup("Second Group");

            return "menu";
        }
    }
}
