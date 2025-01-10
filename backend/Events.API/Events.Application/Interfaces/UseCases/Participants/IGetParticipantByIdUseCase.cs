using Events.Application.Contracts.Participants;

namespace Events.Application.Interfaces.UseCases.Participants
{
    public interface IGetParticipantByIdUseCase
    {
        Task<GetParticipantResponse> Execute(Guid id);
    }
}