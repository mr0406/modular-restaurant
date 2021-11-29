namespace ModularRestaurant.Shared.Infrastructure.Config
{
    public class AzureStorageOptions
    {
        public string ConnectionString { get; set; }
        
        public string MenuItemContainerName { get; set; }
    }
}