using Events.Core.Models;

namespace Events.DataAccess.Interfaces
{
    public interface IImageRepository
    {
        Task Create(Image image);
        Task<List<Image>> Get();
    }
}