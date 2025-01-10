using Events.Application.Contracts.Events;

namespace Events.Application.Interfaces.UseCases.Events
{
    public interface IGetEventByIdUseCase
    {
        Task<GetEventResponse> Execute(Guid id);
    }
}