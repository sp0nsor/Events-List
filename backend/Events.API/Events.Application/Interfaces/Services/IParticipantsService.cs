using Events.Application.DTOs;

namespace Events.Application.Interfaces.Services
{
    public interface IParticipantsService
    {
        Task<Guid> CreateParticipantAsync(string firstName, string lastName, DateTime birthDate, string email);
        Task<Guid> DeleteParticipantAsync(Guid participantId);
        Task<ParticipantDto?> GetParticipantByIdAsync(Guid participantId);
        Task<PageListDto<ParticipantDto>> GetParticipantsAsync(int page, int pageSize);
    }
}