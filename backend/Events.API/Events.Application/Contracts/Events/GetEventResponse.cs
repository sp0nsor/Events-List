using Events.Application.Contracts.Images;

namespace Events.Application.Contracts.Events
{
    public record GetEventResponse(
        Guid Id,
        string Name,
        string Description, 
        string Place,
        DateTime Time, 
        string Category,
        int MaxParticipantCount,
        GetImageResponse Image);
}
