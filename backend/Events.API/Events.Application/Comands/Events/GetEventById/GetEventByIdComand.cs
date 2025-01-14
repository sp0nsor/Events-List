using Events.Application.DTOs;
using MediatR;

namespace Events.Application.Comands.Events.GetEventById
{
    public record GetEventByIdComand(Guid EventId) : IRequest<EventDto>;
}
