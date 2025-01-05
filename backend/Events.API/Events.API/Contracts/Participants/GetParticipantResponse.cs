namespace Events.API.Contracts.Participants
{
    public record GetParticipantResponse(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        DateTime BithDate);
}
