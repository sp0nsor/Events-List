using Events.Application.Contracts.Events;
using Events.Application.Contracts.Participants;
using Events.Core.Models;

namespace Events.Application.Interfaces
{
    public interface IEventsService
    {
        Task CreateEvent(CreateEventRequest request);
        Task UpdateEvent(Guid id, UpdateEventRequest request);
        Task<List<GetEventResponse>> GetEvents(GetEventRequest request);
        Task<List<GetParticipantResponse>> GetEventParticipants(Guid id);
        Task<GetEventResponse> GetEventById(Guid id);
        Task DeleteEvent(Guid id);
    }
}