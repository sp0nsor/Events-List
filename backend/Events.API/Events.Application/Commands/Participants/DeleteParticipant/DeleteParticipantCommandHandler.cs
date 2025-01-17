using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Participants.DeleteParticipant
{
    public class DeleteParticipantCommandHandler
        : IRequestHandler<DeleteParticipantCommand, Guid>
    {
        private readonly IParticipantsService participantsService;

        public DeleteParticipantCommandHandler(
            IParticipantsService participantsService)
        {
            this.participantsService = participantsService;
        }

        public async Task<Guid> Handle(DeleteParticipantCommand request, CancellationToken cancellationToken)
        {
            return await participantsService.DeleteParticipantAsync(request.ParticipantId, cancellationToken);
        }
    }
}
