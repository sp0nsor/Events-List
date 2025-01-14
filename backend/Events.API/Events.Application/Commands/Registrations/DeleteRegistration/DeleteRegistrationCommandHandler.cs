using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Registrations.DeleteRegistration
{
    public class DeleteRegistrationCommandHandler
        : IRequestHandler<DeleteRegistrationCommand>
    {
        private readonly IRegistrationsService registrationsService;

        public DeleteRegistrationCommandHandler(
            IRegistrationsService registrationsService)
        {
            this.registrationsService = registrationsService;
        }

        public async Task Handle(DeleteRegistrationCommand request, CancellationToken cancellationToken)
        {
            await registrationsService.DeleteRegistrationAsync(request.RegistrationId);
        }
    }
}
