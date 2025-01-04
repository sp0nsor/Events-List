namespace Events.API.Contracts.Events
{
    public record GetEventResponse(
        Guid Id,
        string Name,
        string Description, 
        string Place,
        DateTime Time, 
        string Category,
        int MaxParticipantCount,
        string ImagePath);
}
