using Events.Application.DTOs;
using MediatR;

namespace Events.Application.Comands.Events.GetEventParticipants
{
    public record GetEventParticipantsComand(Guid EventId) : IRequest<List<ParticipantDto>>;
}
