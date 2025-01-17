namespace Events.Application.Interfaces.Services
{
    public interface IRegistrationsService
    {
        Task<Guid> CreateRegistrationAsync(
            Guid eventId,
            Guid participantId,
            CancellationToken cancellationToken);
        Task<Guid> DeleteRegistrationAsync(
            Guid registrationId,
            CancellationToken cancellationToken);
    }
}