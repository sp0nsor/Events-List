using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Registrations.DeleteRegistration
{
    public class DeleteRegistrationComandHandler
        : IRequestHandler<DeleteRegistrationComand>
    {
        private readonly IRegistrationsService registrationsService;

        public DeleteRegistrationComandHandler(
            IRegistrationsService registrationsService)
        {
            this.registrationsService = registrationsService;
        }

        public async Task Handle(DeleteRegistrationComand request, CancellationToken cancellationToken)
        {
            await registrationsService.DeleteRegistrationAsync(request.RegistrationId);
        }
    }
}
