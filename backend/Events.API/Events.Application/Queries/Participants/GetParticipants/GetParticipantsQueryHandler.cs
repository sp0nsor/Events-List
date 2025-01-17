using Events.Application.DTOs;
using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Queries.Participants.GetParticipants
{
    public class GetParticipantsQueryHandler
        : IRequestHandler<GetParticipantsQuery, PageListDto<ParticipantDto>>
    {
        private readonly IParticipantsService participantsService;

        public GetParticipantsQueryHandler(
            IParticipantsService participantsService)
        {
            this.participantsService = participantsService;
        }

        public async Task<PageListDto<ParticipantDto>> Handle(GetParticipantsQuery request, CancellationToken cancellationToken)
        {
            return await participantsService.GetParticipantsAsync(request.Page, request.PageSize);
        }
    }
}
