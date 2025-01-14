using Events.Application.DTOs;

namespace Events.Application.Interfaces.Services
{
    public interface IParticipantsService
    {
        Task CreateParticipantAsync(string firstName, string lastName, DateTime birthDate, string email);
        Task DeleteParticipantAsync(Guid participantId);
        Task<ParticipantDto?> GetParticipantByIdAsync(Guid participantId);
        Task<List<ParticipantDto>> GetParticipantsAsync();
    }
}