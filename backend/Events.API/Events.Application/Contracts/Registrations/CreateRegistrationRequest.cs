namespace Events.Application.Contracts.Registrations
{
    public record CreateRegistrationRequest(
        Guid EventId,
        Guid ParticipantId);
}
