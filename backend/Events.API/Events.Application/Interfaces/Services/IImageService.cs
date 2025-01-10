using Events.Core.Models;
using Microsoft.AspNetCore.Http;

namespace Events.Application.Interfaces.Services
{
    public interface IImageService
    {
        Task<Image> CreateImage(IFormFile eventImage, Guid eventId);
    }
}