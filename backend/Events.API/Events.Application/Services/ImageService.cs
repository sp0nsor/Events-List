using Events.Application.Interfaces;
using Events.Core.Models;
using Events.DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Events.Application.Services
{
    public class ImageService : IImageService
    {
        private readonly string staticFilePath =
             Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles\\Images");

        private readonly IImageRepository imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        public async Task<Image> CreateImage(IFormFile eventImage)
        {
            var fileName = Path.GetFileName(eventImage.FileName);
            var filePath = Path.Combine(staticFilePath, fileName);

            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await eventImage.CopyToAsync(stream);
            }

            var image = Image.Create(Guid.NewGuid(), Guid.NewGuid(), filePath);

            return image;
        }
    }
}
