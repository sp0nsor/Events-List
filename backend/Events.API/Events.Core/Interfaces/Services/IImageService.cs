using Events.Core.Models;
using Microsoft.AspNetCore.Http;

namespace Events.Application.Services
{
    public interface IImageService
    {
        Task<Image> CreateImage(IFormFile eventImage, string path);
    }
}