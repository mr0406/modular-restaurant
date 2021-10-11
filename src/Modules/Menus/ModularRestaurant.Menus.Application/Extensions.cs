﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ModularRestaurant.Shared.Application.Processing.Queries;
using ModularRestaurant.Shared.Application.Processing.Commands;
using System.Diagnostics;

namespace ModularRestaurant.Menus.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly(), AppDomain.CurrentDomain.GetAssemblies()
                .SingleOrDefault(assembly => assembly.GetName().Name == "ModularRestaurant.Menus.Infrastructure"));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(QueryLoggingBehavior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandLoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(MenuUnitOfWorkBehavior<,>));

            return services;
        }
    }
}