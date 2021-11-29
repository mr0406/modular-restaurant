using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Menus.Application.Services;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Infrastructure.EF;
using ModularRestaurant.Shared.Infrastructure.Config;
using System.Linq;
using Azure.Storage.Blobs.Models;

namespace ModularRestaurant.Menus.Infrastructure.Services
{
    public class AzureMenuItemImageService : IMenuItemImageService
    {
        private readonly DbSet<Menu> _menus;
        
        private readonly string _connectionString;
        private readonly string _containerName;

        public AzureMenuItemImageService(MenusDbContext menusDbContext, AzureStorageOptions options)
        {
            _menus = menusDbContext.Menus;
            
            _connectionString = options.ConnectionString;
            _containerName = options.MenuItemContainerName;
        }
        public async Task SaveImage(string imageName, IFormFile file)
        {
            var blobServiceClient = new BlobServiceClient(_connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(imageName);

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                stream.Position = 0;
                await blobClient.UploadAsync(stream);
            }
        }

        public async Task CleanUpUnusedImages()
        {
            var usedImages = await _menus
                .SelectMany(x => x.Groups
                    .SelectMany(x => x.Items
                        .Select(x => x.Image)))
                .Where(x => x != null)
                .Distinct()
                .ToListAsync();

            var blobServiceClient = new BlobServiceClient(_connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(_containerName);
            
            var imagesInStorage = new List<string>();
            foreach (BlobItem blobItem in containerClient.GetBlobs())
            {
                imagesInStorage.Add(blobItem.Name);
            }

            var imagesToRemove = imagesInStorage.Except(usedImages);
            var tasks = new List<Task>();
            foreach (var image in imagesToRemove)
            {
                var blob = containerClient.GetBlobClient(image);
                tasks.Add(blob.DeleteIfExistsAsync());
            }

            await Task.WhenAll(tasks);
        }
    }
}