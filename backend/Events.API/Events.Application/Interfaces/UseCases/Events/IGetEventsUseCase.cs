using Events.Application.Contracts.Events;

namespace Events.Application.Interfaces.UseCases.Events
{
    public interface IGetEventsUseCase
    {
        Task<EventsPageResponse> Execute(GetEventRequest request);
    }
}