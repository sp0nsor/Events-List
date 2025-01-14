using MediatR;

namespace Events.Application.Comands.Events.DeleteEvent
{
    public record DeleteEventComand(Guid EventId) : IRequest;
}
