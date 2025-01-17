using MediatR;

namespace Events.Application.Commands.Events.DeleteEvent
{
    public record DeleteEventCommand(Guid EventId) : IRequest<Guid>;
}
