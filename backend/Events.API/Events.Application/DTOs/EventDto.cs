namespace Events.Application.DTOs
{
    public record EventDto(
        Guid Id,
        string Description,
        string Place,
        string Category,
        int MaxParticipantCount,
        DateTime Date,
        ImageDto Image);
}
