using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModularRestaurant.Menus.Infrastructure.EF;
using NUnit.Framework;

namespace ModularRestaurant.Menus.IntegrationTests
{
    [TestFixture]
    public abstract class TestBase
    {
        protected CustomWebApplicationFactory Factory;
        protected IConfiguration Config;
        protected string ConnectionString;
        protected DbContextOptions<MenusDbContext> DbContextOptions;

        [SetUp]
        public void Setup()
        {
            using (var dbContext = new MenusDbContext(DbContextOptions))
            {
                dbContext.Database.EnsureDeleted();
            }
        }
        
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Factory = new CustomWebApplicationFactory();
            Config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.Testing.json", true)
                .AddEnvironmentVariables()
                .Build();
            
            ConnectionString = Config["Sql:ConnectionString"];
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<MenusDbContext>();
            dbContextOptionsBuilder.UseNpgsql(ConnectionString);
            DbContextOptions = dbContextOptionsBuilder.Options;
            
            using (var dbContext = new MenusDbContext(DbContextOptions))
            {
                dbContext.Database.Migrate();
            }
        }
    }
}