namespace Events.Application.DTOs
{
    public record EventDto(
        Guid Id,
        string Name,
        string Description,
        string Place,
        DateTime Time,
        string Category,
        int MaxParticipantCount,
        ImageDto Image);
}
