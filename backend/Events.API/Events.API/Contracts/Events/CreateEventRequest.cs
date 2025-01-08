namespace Events.API.Contracts.Events
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
