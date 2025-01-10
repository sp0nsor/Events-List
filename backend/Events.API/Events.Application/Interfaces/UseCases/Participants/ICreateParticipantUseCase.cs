using Events.Application.Contracts.Participants;

namespace Events.Application.Interfaces.UseCases.Participants
{
    public interface ICreateParticipantUseCase
    {
        Task Execute(CreateParticipantRequest request);
    }
}