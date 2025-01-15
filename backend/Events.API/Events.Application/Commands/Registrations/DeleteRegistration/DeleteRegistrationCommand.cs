using MediatR;

namespace Events.Application.Comands.Registrations.DeleteRegistration
{
    public record DeleteRegistrationCommand(
        Guid RegistrationId) : IRequest<Guid>;
}
