using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularRestaurant.Menus.Application;
using ModularRestaurant.Menus.Application.Processing;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Menus.Infrastructure.EF;
using ModularRestaurant.Menus.Infrastructure.EF.Repositories;
using ModularRestaurant.Shared.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenusUnitOfWork, MenusUnitOfWork>();

            var options = services.GetOptions<SqlOptions>("Sql");
            services.AddDbContext<MenusDbContext>(o => 
                o.UseSqlServer(options.ConnectionString));

            return services;
        }

        //TODO: Change that

        private static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : new()
        {
            using var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            return configuration.GetOptions<T>(sectionName);
        }

        private static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : new()
        {
            var options = new T();
            configuration.GetSection(sectionName).Bind(options);
            return options;
        }
    }
}
