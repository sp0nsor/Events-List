using Events.Application.DTOs;
using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Participants.GetParticipantById
{
    public class GetParticipantByIdComandHandler
        : IRequestHandler<GetParticipantByIdComand, ParticipantDto>
    {
        private readonly IParticipantsService participantsService;

        public GetParticipantByIdComandHandler(
            IParticipantsService participantsService)
        {
            this.participantsService = participantsService;
        }

        public async Task<ParticipantDto> Handle(GetParticipantByIdComand request, CancellationToken cancellationToken)
        {
            return await participantsService.GetParticipantByIdAsync(request.ParticipantId);
        }
    }
}
