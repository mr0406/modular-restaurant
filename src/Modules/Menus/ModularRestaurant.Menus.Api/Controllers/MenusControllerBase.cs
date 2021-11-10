using Microsoft.AspNetCore.Mvc;
using ModularRestaurant.Menus.Infrastructure;

namespace ModularRestaurant.Menus.Api.Controllers
{
    [Route("menus-module/[controller]")]
    public abstract class MenusControllerBase : ControllerBase
    {
        protected readonly IMenusExecutor Executor;

        public MenusControllerBase(IMenusExecutor executor)
        {
            Executor = executor;
        }
    }
}