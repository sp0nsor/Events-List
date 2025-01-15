using MediatR;

namespace Events.Application.Comands.Events.DeleteEvent
{
    public record DeleteEventCommand(Guid EventId) : IRequest<Guid>;
}
