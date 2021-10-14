using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ModularRestaurant.Ratings.Application;
using ModularRestaurant.Ratings.Domain;
using ModularRestaurant.Ratings.Infrastructure;
using ModularRestaurant.Shared.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Api
{
    public class RatingsModule : IModule
    {
        public const string BasePath = "ratings-module";
        public string Name => "Ratings";
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
