using Events.Application.Contracts.Participants;
using Events.Core.Models;

namespace Events.Application.Interfaces.Services
{
    public interface IParticipantService
    {
        Task CreateParticipant(CreateParticipantRequest request);
        Task DeleteParticipant(Guid id);
        Task<GetParticipantResponse> GetPartcipantById(Guid id);
        Task<List<GetParticipantResponse>> GetPartcipants();
    }
}