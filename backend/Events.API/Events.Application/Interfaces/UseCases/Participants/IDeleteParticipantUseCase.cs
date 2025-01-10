
namespace Events.Application.Interfaces.UseCases.Participants
{
    public interface IDeleteParticipantUseCase
    {
        Task Execute(Guid id);
    }
}