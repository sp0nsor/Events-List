using Events.Application.DTOs;
using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Participants.GetParticipants
{
    public class GetParticipantsCommandHandler
        : IRequestHandler<GetParticipantsCommand, PageListDto<ParticipantDto>>
    {
        private readonly IParticipantsService participantsService;

        public GetParticipantsCommandHandler(
            IParticipantsService participantsService)
        {
            this.participantsService = participantsService;
        }

        public async Task<PageListDto<ParticipantDto>> Handle(GetParticipantsCommand request, CancellationToken cancellationToken)
        {
            return await participantsService.GetParticipantsAsync(request.Page, request.PageSize);
        }
    }
}
