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

        public async Task<Image> CreateImage(IFormFile eventImage, Guid eventId)
        {
            var fileName = Path.GetFileName(eventImage.FileName);
            var filePath = Path.Combine(staticFilePath, fileName);

            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await eventImage.CopyToAsync(stream);
            }

            var image = Image.Create(Guid.NewGuid(), eventId, filePath);

            return image;
        }
    }
}
