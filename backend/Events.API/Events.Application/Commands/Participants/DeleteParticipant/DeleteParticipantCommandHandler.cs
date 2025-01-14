using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Participants.DeleteParticipant
{
    public class DeleteParticipantCommandHandler
        : IRequestHandler<DeleteParticipantCommand>
    {
        private readonly IParticipantsService participantsService;

        public DeleteParticipantCommandHandler(
            IParticipantsService participantsService)
        {
            this.participantsService = participantsService;
        }

        public async Task Handle(DeleteParticipantCommand request, CancellationToken cancellationToken)
        {
            await participantsService.DeleteParticipantAsync(request.ParticipantId);
        }
    }
}
