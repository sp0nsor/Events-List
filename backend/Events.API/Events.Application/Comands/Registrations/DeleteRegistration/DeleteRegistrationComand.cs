using MediatR;

namespace Events.Application.Comands.Registrations.DeleteRegistration
{
    public record DeleteRegistrationComand(Guid RegistrationId) : IRequest;
}
