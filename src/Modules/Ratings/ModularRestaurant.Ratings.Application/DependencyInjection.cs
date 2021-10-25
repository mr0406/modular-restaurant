using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ModularRestaurant.Ratings.Application.Processing;
using ModularRestaurant.Shared.Application.Processing.Commands;
using ModularRestaurant.Shared.Application.Processing.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly(), GetInfrastructureAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestLoggingBehavior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RatingsUnitOfWorkBehavior<,>));

            return services;
        }

        private static Assembly GetInfrastructureAssembly()
        {
            var applicationName = Assembly.GetExecutingAssembly().GetName().Name;

            var infrastructureName = applicationName!.Replace("Application", "Infrastructure");

            return AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(assembly => assembly.GetName().Name == infrastructureName);
        }
    }
}
