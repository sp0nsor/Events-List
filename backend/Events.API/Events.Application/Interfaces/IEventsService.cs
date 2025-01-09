using Events.Application.Contracts.Events;
using Events.Core.Models;

namespace Events.Application.Interfaces
{
    public interface IEventsService
    {
        Task CreateEvent(CreateEventRequest request);
        Task<List<GetEventResponse>> GetEvents(GetEventRequest request);
        Task UpdateEvent(Guid id, UpdateEventRequest request);
        Task<GetEventResponse> GetEventById(Guid id);
        Task DeleteEvent(Guid id);
    }
}