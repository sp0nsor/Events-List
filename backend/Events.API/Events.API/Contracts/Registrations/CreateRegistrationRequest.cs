namespace Events.API.Contracts.Registrations
{
    public record CreateRegistrationRequest(
        Guid EventId,
        Guid ParticipantId);
}
