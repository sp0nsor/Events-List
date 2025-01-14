using Events.Application.DTOs;
using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Participants.GetParticipantById
{
    public class GetParticipantByIdCommandHandler
        : IRequestHandler<GetParticipantByIdCommand, ParticipantDto>
    {
        private readonly IParticipantsService participantsService;

        public GetParticipantByIdCommandHandler(
            IParticipantsService participantsService)
        {
            this.participantsService = participantsService;
        }

        public async Task<ParticipantDto> Handle(GetParticipantByIdCommand request, CancellationToken cancellationToken)
        {
            return await participantsService.GetParticipantByIdAsync(request.ParticipantId);
        }
    }
}
