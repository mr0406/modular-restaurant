using System.Reflection;
using Autofac;
using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Menus.Infrastructure.EF;
using ModularRestaurant.Shared.Api;

namespace ModularRestaurant.Menus.Api.IoCModules
{
    internal class DataAccessModule : Autofac.Module
    {
        private readonly string _connectionString;

        internal DataAccessModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<MenusDbContext>();
                dbContextOptionsBuilder.UseNpgsql(_connectionString);

                return new MenusDbContext(dbContextOptionsBuilder.Options);
            }).AsSelf().As<DbContext>().InstancePerLifetimeScope();

            var infrastructureAssembly = Assembly.GetExecutingAssembly().GetInfrastructure();

            builder.RegisterAssemblyTypes(infrastructureAssembly)
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}