using Events.Application.DTOs;
using MediatR;

namespace Events.Application.Queries.Participants.GetParticipants
{
    public record GetParticipantsQuery(int Page, int PageSize)
        : IRequest<PageListDto<ParticipantDto>>;
}
