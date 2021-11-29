using NUnit.Framework;

namespace ModularRestaurant.Menus.IntegrationTests
{
    [TestFixture]
    public class AddMenuTest : TestBase
    {
        /*[Test]
        public async Task CreateMenu()
        {
            var client = Factory.CreateClient();

            Guid restaurantId = new("1CA93CE7-5C58-4881-97A9-921A3D516980");
            var internalName = "MenuInternalName";

            var command = new CreateMenuCommand(restaurantId, internalName);
            var content = JsonContent.Create(command);
            
            var postResponse = await client.PostAsync("/menus-module/menus/create", content);
            postResponse.EnsureSuccessStatusCode();
            var menuId = await postResponse.Content.ReadFromJsonAsync<Guid>();

            var getResponse = await client.GetAsync($"menus-module/Menus/{menuId}");
            getResponse.EnsureSuccessStatusCode();
            var menu = await getResponse.Content.ReadFromJsonAsync<GetMenuQueryResult>();

            menu.Should().NotBeNull();
            menu.Groups.Count().Should().Be(0);
        }*/
    }
}