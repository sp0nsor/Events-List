using Events.Application.DTOs;
using MediatR;

namespace Events.Application.Queries.Events.GetEventById
{
    public record GetEventByIdQuery(
        Guid EventId) : IRequest<EventDto>;
}
