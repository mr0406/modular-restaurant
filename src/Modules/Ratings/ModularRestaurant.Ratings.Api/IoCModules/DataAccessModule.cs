using System.Reflection;
using Autofac;
using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Ratings.Infrastructure.EF;
using ModularRestaurant.Shared.Api;

namespace ModularRestaurant.Ratings.Api.IoCModules
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
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<RatingsDbContext>();
                dbContextOptionsBuilder.UseNpgsql(_connectionString);

                return new RatingsDbContext(dbContextOptionsBuilder.Options);
            }).AsSelf().As<DbContext>().InstancePerLifetimeScope();

            var infrastructureAssembly = Assembly.GetExecutingAssembly().GetInfrastructure();

            builder.RegisterAssemblyTypes(infrastructureAssembly)
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            Assembly.GetExecutingAssembly().GetDomain();
        }
    }
}