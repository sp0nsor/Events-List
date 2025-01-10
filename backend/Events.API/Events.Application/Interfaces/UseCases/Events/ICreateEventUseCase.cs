using Events.Application.Contracts.Events;

namespace Events.Application.Interfaces.UseCases.Events
{
    public interface ICreateEventUseCase
    {
        Task Execute(CreateEventRequest request);
    }
}