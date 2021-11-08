using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ModularRestaurant.Menus.IntegrationTests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Bootstrapper.Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");
        }
    }
}