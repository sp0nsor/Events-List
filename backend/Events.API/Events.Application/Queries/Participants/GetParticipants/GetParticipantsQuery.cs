using Events.Application.DTOs;
using MediatR;

namespace Events.Application.Queries.Participants.GetParticipants
{
    public record GetParticipantsQuery(int Page = 1, int PageSize = 10)
        : IRequest<PageListDto<ParticipantDto>>;
}
