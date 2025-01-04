using Events.Core.Models;

namespace Events.Application.Services
{
    public interface IEventsService
    {
        Task Create(Event @event);
        Task<List<Event>> GetEvents();
        Task UpdateEvent(Guid id, string name, string description,
            string place, string category, int maxParticipantCount, DateTime time);
        Task DeleteEvent(Guid id);
    }
}