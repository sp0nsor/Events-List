using Events.Core.Models;
using Events.DataAccess.Repositories;
using Microsoft.AspNetCore.Http;

namespace Events.Application.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        public async Task<Image> CreateImage(IFormFile eventImage, string path)
        {
            var fileName = Path.GetFileName(eventImage.FileName);
            var filePath = Path.Combine(path, fileName);

            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await eventImage.CopyToAsync(stream);
            }

            var image = Image.Create(Guid.NewGuid(), Guid.NewGuid(), filePath);

            return image;
        }
    }
}
