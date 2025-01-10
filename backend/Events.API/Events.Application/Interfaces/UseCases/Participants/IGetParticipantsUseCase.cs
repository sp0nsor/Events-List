using Events.Application.Contracts.Participants;

namespace Events.Application.Interfaces.UseCases.Participants
{
    public interface IGetParticipantsUseCase
    {
        Task<List<GetParticipantResponse>> Execute();
    }
}