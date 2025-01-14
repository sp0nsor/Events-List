namespace Events.Application.DTOs
{
    public record ParticipantDto(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        DateTime BirthDate);
}
