using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Participants.DeleteParticipant
{
    public class DeleteParticipantComandHandler
        : IRequestHandler<DeleteParticipantComand>
    {
        private readonly IParticipantsService participantsService;

        public DeleteParticipantComandHandler(
            IParticipantsService participantsService)
        {
            this.participantsService = participantsService;
        }

        public async Task Handle(DeleteParticipantComand request, CancellationToken cancellationToken)
        {
            await participantsService.DeleteParticipantAsync(request.ParticipantId);
        }
    }
}
