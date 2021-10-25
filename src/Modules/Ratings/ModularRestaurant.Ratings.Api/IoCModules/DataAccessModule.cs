using Autofac;
using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Ratings.Infrastructure.EF;

namespace ModularRestaurant.Ratings.Api.IoCModules
{
    internal class DataAccessModule : Module
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

            var infrastructureAssembly = typeof(RatingsDbContext).Assembly;

            builder.RegisterAssemblyTypes(infrastructureAssembly)
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}