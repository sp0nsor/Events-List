using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Registrations.DeleteRegistration
{
    public class DeleteRegistrationCommandHandler
        : IRequestHandler<DeleteRegistrationCommand, Guid>
    {
        private readonly IRegistrationsService registrationsService;

        public DeleteRegistrationCommandHandler(
            IRegistrationsService registrationsService)
        {
            this.registrationsService = registrationsService;
        }

        public async Task<Guid> Handle(DeleteRegistrationCommand request, CancellationToken cancellationToken)
        {
            return await registrationsService.DeleteRegistrationAsync(request.RegistrationId, cancellationToken);
        }
    }
}
