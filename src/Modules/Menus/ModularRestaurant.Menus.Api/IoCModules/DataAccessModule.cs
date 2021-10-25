using Autofac;
using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Menus.Infrastructure.EF;

namespace ModularRestaurant.Menus.Api.IoCModules
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
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<MenusDbContext>();
                dbContextOptionsBuilder.UseNpgsql(_connectionString);

                return new MenusDbContext(dbContextOptionsBuilder.Options);
            }).AsSelf().As<DbContext>().InstancePerLifetimeScope();

            var infrastructureAssembly = typeof(MenusDbContext).Assembly;

            builder.RegisterAssemblyTypes(infrastructureAssembly)
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}