using Events.Application.DTOs;
using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Queries.Participants.GetParticipantById
{
    public class GetParticipantByIdQueryHandler
        : IRequestHandler<GetParticipantByIdQuery, ParticipantDto>
    {
        private readonly IParticipantsService participantsService;

        public GetParticipantByIdQueryHandler(
            IParticipantsService participantsService)
        {
            this.participantsService = participantsService;
        }

        public async Task<ParticipantDto> Handle(GetParticipantByIdQuery request, CancellationToken cancellationToken)
        {
            return await participantsService.GetParticipantByIdAsync(request.ParticipantId);
        }
    }
}
