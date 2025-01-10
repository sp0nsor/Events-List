using Events.Application.Contracts.Participants;

namespace Events.Application.Interfaces.UseCases.Events
{
    public interface IGetEventParticipantsUseCase
    {
        Task<List<GetParticipantResponse>> Execute(Guid id);
    }
}