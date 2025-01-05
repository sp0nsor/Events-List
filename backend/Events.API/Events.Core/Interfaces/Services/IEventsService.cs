using Events.Core.Models;

namespace Events.Application.Services
{
    public interface IEventsService
    {
        Task Create(Event @event);
        Task<List<Event>> GetEvents(string? searchName, string? searchPlace,
            string? searchCategory, string? sortItem, string? sortOrder);
        Task UpdateEvent(Guid id, string name, string description, string place,
            string category, int maxParticipantCount, DateTime time);
        Task<Event> GetEventById(Guid id);
        Task DeleteEvent(Guid id);
    }
}