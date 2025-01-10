using Events.Application.Contracts.Registrations;
using Events.Application.Interfaces.Services;
using Events.Application.Interfaces.UseCases.Registrations;

namespace Events.Application.Services
{
    public class RegistrationsService : IRegistrationsService
    {
        private readonly ICreateRegistrationUseCase createRegistrationUseCase;
        private readonly IDeleteRegistrationUseCase deleteRegistrationUseCase;

        public RegistrationsService(
            ICreateRegistrationUseCase createRegistrationUseCase,
            IDeleteRegistrationUseCase deleteRegistrationUseCase)
        {
            this.createRegistrationUseCase = createRegistrationUseCase;
            this.deleteRegistrationUseCase = deleteRegistrationUseCase;
        }

        public async Task CreateRegistration(CreateRegistrationRequest request)
        {
            await createRegistrationUseCase.Execute(request);
        }

        public async Task DeleteRegistration(Guid id)
        {
            await deleteRegistrationUseCase.Execute(id);
        }
    }
}
