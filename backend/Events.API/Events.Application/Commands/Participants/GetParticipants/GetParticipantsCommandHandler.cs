using Events.Application.DTOs;
using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Participants.GetParticipants
{
    public class GetParticipantsCommandHandler
        : IRequestHandler<GetParticipantsCommand, List<ParticipantDto>>
    {
        private readonly IParticipantsService participantsService;

        public GetParticipantsCommandHandler(
            IParticipantsService participantsService)
        {
            this.participantsService = participantsService;
        }

        public async Task<List<ParticipantDto>> Handle(GetParticipantsCommand request, CancellationToken cancellationToken)
        {
            return await participantsService.GetParticipantsAsync();
        }
    }
}
