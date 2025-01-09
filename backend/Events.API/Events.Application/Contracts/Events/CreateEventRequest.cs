using Microsoft.AspNetCore.Http;

namespace Events.Application.Contracts.Events
{
    public record CreateEventRequest(
        string Name,
        string Description,
        string Place,
        string Category,
        int MaxParticipantCount,
        DateTime Time,
        IFormFile Image);
}
