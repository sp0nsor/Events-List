using Events.Application.DTOs;
using MediatR;

namespace Events.Application.Comands.Events.GetEventById
{
    public record GetEventByIdCommand(Guid EventId) : IRequest<EventDto>;
}
