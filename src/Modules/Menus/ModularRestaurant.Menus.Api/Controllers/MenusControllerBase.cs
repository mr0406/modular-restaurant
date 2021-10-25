using Microsoft.AspNetCore.Mvc;

namespace ModularRestaurant.Menus.Api.Controllers
{
    
    [Route("menus-module/[controller]")]
    public abstract class MenusControllerBase : ControllerBase
    {
        protected readonly IMenusModule _menusModule;
        
        public MenusControllerBase(IMenusModule menusModule)
        {
            _menusModule = menusModule;
        }
    }
}