namespace Events.Application.Contracts.Events
{
    public record UpdateEventRequest(
        string Name,
        string Description,
        string Place,
        string Category,
        int MaxParticipantCount,
        DateTime Time);
}
