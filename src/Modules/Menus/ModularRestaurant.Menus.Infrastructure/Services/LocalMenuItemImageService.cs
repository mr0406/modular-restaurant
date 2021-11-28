using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ModularRestaurant.Menus.Application.Services;

namespace ModularRestaurant.Menus.Infrastructure.Services
{
    public class LocalMenuItemImageService : IMenuItemImageService
    {
        public async Task SaveImage(string imageName, IFormFile image)
        {
            string folderPath = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.MyPictures), "modular-restaurant");

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
    }
}