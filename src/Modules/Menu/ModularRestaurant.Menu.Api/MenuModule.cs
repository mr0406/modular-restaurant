using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ModularRestaurant.Menu.Application;
using ModularRestaurant.Menu.Domain;
using ModularRestaurant.Menu.Infrastructure;
using ModularRestaurant.Shared.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menu.Api
{
    public class MenuModule : IModule
    {
        public const string BasePath = "menu-module";
        public string Name => "Menu";
        public string Path => BasePath;

        public void Register(IServiceCollection services)
        {
            services.AddDomain()
                    .AddApplication()
                    .AddInfrastructure();
        }

        public void Use(IApplicationBuilder app)
        {

        }
    }
}
