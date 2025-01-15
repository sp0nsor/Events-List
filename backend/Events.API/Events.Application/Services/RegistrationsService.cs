using Events.Application.Interfaces.Services;
using Events.Core.Models;
using Events.DataAccess.Interfaces.Repositories;

namespace Events.Application.Services
{
    public class RegistrationsService : IRegistrationsService
    {
        private readonly IUnitOfWork unitOfWork;

        public RegistrationsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Guid> DeleteRegistrationAsync(Guid registrationId)
        {
            var id = await unitOfWork.Registrations.Delete(registrationId);
            await unitOfWork.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> CreateRegistrationAsync(Guid eventId, Guid participantId)
        {
            var registration = Registration.Create(
                Guid.NewGuid(),
                eventId,
                participantId);

            var id = await unitOfWork.Registrations.Create(registration);
            await unitOfWork.SaveChangesAsync();

            return id;
        }
    }
}
