namespace Events.Application.Interfaces.Services
{
    public interface IRegistrationsService
    {
        Task CreateRegistrationAsync(Guid eventId, Guid participantId);
        Task DeleteRegistrationAsync(Guid registrationId);
    }
}