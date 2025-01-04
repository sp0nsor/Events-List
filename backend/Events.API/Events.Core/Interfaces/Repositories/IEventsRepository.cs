using Events.Core.Models;

namespace Events.DataAccess.Repositories
{
    public interface IEventsRepository
    {
        Task Create(Event Event);
        Task Delete(Guid id);
        Task<List<Event>> Get();
        Task Update(Guid id, string name, string description, string place, string category, int maxParticipantCount, DateTime time);
    }
}