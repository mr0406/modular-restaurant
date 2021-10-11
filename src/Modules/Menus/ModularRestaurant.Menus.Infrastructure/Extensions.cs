using Microsoft.Extensions.DependencyInjection;
using ModularRestaurant.Menus.Application;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Menus.Infrastructure.EF;
using ModularRestaurant.Menus.Infrastructure.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenusUnitOfWork, MenusUnitOfWork>();

            return services;
        }
    }
}
