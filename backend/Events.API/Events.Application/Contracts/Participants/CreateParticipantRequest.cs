namespace Events.Application.Contracts.Participants
{
    public record CreateParticipantRequest(
        string FirstName,
        string LastName,
        string Email,
        DateTime BirthDate);
}
