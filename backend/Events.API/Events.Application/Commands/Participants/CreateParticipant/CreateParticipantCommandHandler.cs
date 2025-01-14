using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Participants.CreateParticipant
{
    public class CreateParticipantCommandHandler
        : IRequestHandler<CreateParticipantCommand>
    {
        private readonly IParticipantsService participantsService;

        public CreateParticipantCommandHandler(
            IParticipantsService participantsService)
        {
            this.participantsService = participantsService;
        }

        public async Task Handle(CreateParticipantCommand request, CancellationToken cancellationToken)
        {
            await participantsService.CreateParticipantAsync(
                request.FirstName,
                request.LastName,
                request.BirthDate,
                request.Email);
        }
    }
}
