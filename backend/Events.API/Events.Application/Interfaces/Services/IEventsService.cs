using Events.Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace Events.Application.Interfaces.Services
{
    public interface IEventsService
    {
        Task<Guid> CreateEventAsync(
            string name, 
            string description, 
            string place,
            string category, 
            int maxParticipantCount, 
            DateTime date, 
            IFormFile imageFile,
            CancellationToken cancellationToken);
        Task<Guid> DeleteEventAsync(Guid eventId, CancellationToken cancellationToken);
        Task<EventDto?> GetEventByIdAsync(Guid idб , CancellationToken cancellationToken);
        Task<List<ParticipantDto>> GetEventParticipantsAsync(Guid eventIdб , CancellationToken cancellationToken);
        Task<PageListDto<EventDto>> GetEventsAsync(
            string? searchName,
            string? searchPlace,
            string? searchCategory,
            string? sortItem,
            string? sortOrder,
            CancellationToken cancellationToken,
            int page = 1,
            int pageSize = 10);
        Task<Guid> UpdateEventAync(
            Guid id,
            string name, 
            string description,
            string palce, 
            string category,
            int maxParticipantCount,
            DateTime date,
            CancellationToken cancellationToken);
    }
}