using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ModularRestaurant.Menus.Application;
using ModularRestaurant.Menus.Domain;
using ModularRestaurant.Menus.Infrastructure;
using ModularRestaurant.Shared.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Api
{
    public class MenusModule : IModule
    {
        public const string BasePath = "menus-module";
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
