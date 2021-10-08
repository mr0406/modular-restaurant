using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Shared.Api
{
    public interface IModule
    {
        string Name { get; }
        string Path { get; }
        void Register(IServiceCollection services);
        void Use(IApplicationBuilder app);
    }
}
