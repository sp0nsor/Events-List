using Events.Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace Events.Application.Interfaces.Services
{
    public interface IEventsService
    {
        Task CreateEventAsync(string name, string description, string place, string category, int maxParticipantCount, DateTime date, IFormFile imageFile);
        Task DeleteEventAsync(Guid eventId);
        Task<EventDto?> GetEventByIdAsync(Guid id);
        Task<List<ParticipantDto>> GetEventParticipantsAsync(Guid eventId);
        Task<EventsPageDto> GetEventsAsync(string? searchName, string? searchPlace, string? searchCategory, string? sortItem, string? sortOrder, int page = 1, int pageSize = 10);
        Task UpdateEventAync(Guid id, string name, string description, string palce, string category, int maxParticipantCount, DateTime date);
    }
}