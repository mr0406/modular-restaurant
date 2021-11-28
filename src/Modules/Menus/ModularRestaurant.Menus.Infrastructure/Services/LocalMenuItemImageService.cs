using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Menus.Application.Services;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Infrastructure.EF;

namespace ModularRestaurant.Menus.Infrastructure.Services
{
    public class LocalMenuItemImageService : IMenuItemImageService
    {
        private readonly DbSet<Menu> _menus;
        
        public LocalMenuItemImageService(MenusDbContext menusDbContext)
        {
            _menus = menusDbContext.Menus;
        }
        
        public async Task SaveImage(string imageName, IFormFile image)
        {
            string folderPath = GetFolderPath();

            Directory.CreateDirectory(folderPath);
            
            if (image.Length > 0)
            {
                string filePath = Path.Combine(folderPath, imageName);

                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
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

            var folderPath = GetFolderPath();

            if (Directory.Exists(folderPath))
            {
                var imagesInDirectory = Directory.GetFiles(folderPath).Select(Path.GetFileName).ToList();

                var imagesToRemove = imagesInDirectory.Except(usedImages);

                foreach (var image in imagesToRemove)
                {
                    var imagePath = Path.Combine(folderPath + "\\" + image);
                    File.Delete(imagePath);
                }
            }
        }

        private string GetFolderPath()
            => Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.MyPictures), "modular-restaurant");
    }
}