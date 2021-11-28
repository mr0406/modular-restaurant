using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ModularRestaurant.Menus.Application.Services
{
    public interface IMenuItemImageService
    {
        public Task SaveImage(string imageName, IFormFile file);
    }
}