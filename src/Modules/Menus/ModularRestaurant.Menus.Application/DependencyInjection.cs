using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ModularRestaurant.Shared.Application.Processing.Commands;
using System.Diagnostics;
using ModularRestaurant.Menus.Application.Processing;
using ModularRestaurant.Shared.Application.Processing.Requests;

namespace ModularRestaurant.Menus.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly(), GetInfrastructureAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestLoggingBehavior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(MenuUnitOfWorkBehavior<,>));

            return services;
        }

        private static Assembly GetInfrastructureAssembly()
        {
            var applicationName = Assembly.GetExecutingAssembly().GetName().Name;

            var infrastructureName = applicationName.Replace("Application", "Infrastructure");

            return AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(assembly => assembly.GetName().Name == infrastructureName);
        }
    }
}
