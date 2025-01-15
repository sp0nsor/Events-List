namespace Events.Application.Interfaces.Services
{
    public interface IRegistrationsService
    {
        Task<Guid> CreateRegistrationAsync(Guid eventId, Guid participantId);
        Task<Guid> DeleteRegistrationAsync(Guid registrationId);
    }
}