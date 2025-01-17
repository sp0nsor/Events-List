using Events.Application.DTOs;

namespace Events.Application.Interfaces.Services
{
    public interface IParticipantsService
    {
        Task<Guid> CreateParticipantAsync(
            string firstName,
            string lastName, 
            DateTime birthDate, 
            string email,
            CancellationToken cancellationToken);
        Task<Guid> DeleteParticipantAsync(Guid participantId, CancellationToken cancellationToken);
        Task<ParticipantDto?> GetParticipantByIdAsync(Guid participantId, CancellationToken cancellationToken);
        Task<PageListDto<ParticipantDto>> GetParticipantsAsync(int page, int pageSize, CancellationToken cancellationToken);
    }
}