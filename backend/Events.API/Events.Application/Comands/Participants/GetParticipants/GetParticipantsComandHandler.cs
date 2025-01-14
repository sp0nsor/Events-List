using Events.Application.DTOs;
using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Participants.GetParticipants
{
    public class GetParticipantsComandHandler
        : IRequestHandler<GetParticipantsComand, List<ParticipantDto>>
    {
        private readonly IParticipantsService participantsService;

        public GetParticipantsComandHandler(
            IParticipantsService participantsService)
        {
            this.participantsService = participantsService;
        }

        public async Task<List<ParticipantDto>> Handle(GetParticipantsComand request, CancellationToken cancellationToken)
        {
            return await participantsService.GetParticipantsAsync();
        }
    }
}
