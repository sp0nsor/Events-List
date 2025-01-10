using Events.Application.Contracts.Events;

namespace Events.Application.Interfaces.UseCases.Events
{
    public interface IUpdateEventUseCase
    {
        Task Execute(Guid id, UpdateEventRequest request);
    }
}