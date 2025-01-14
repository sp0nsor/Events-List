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

        public async Task DeleteRegistrationAsync(Guid registrationId)
        {
            await unitOfWork.Registrations.Delete(registrationId);
        }

        public async Task CreateRegistrationAsync(Guid eventId, Guid participantId)
        {
            var registration = Registration.Create(
                Guid.NewGuid(),
                eventId,
                participantId);

            await unitOfWork.Registrations.Create(registration);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
