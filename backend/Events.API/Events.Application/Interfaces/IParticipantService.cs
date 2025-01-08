using Events.Core.Models;

namespace Events.Application.Interfaces
{
    public interface IParticipantService
    {
        Task CreateParticipant(Participant participant);
        Task DeleteParticipant(Guid id);
        Task<Participant> GetPartcipantById(Guid id);
        Task<List<Participant>> GetPartcipants();
    }
}