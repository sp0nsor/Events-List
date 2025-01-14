using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Participants.CreateParticipant
{
    public class CreateParticipantComandHandler
        : IRequestHandler<CreateParticipantComand>
    {
        private readonly IParticipantsService participantsService;

        public CreateParticipantComandHandler(
            IParticipantsService participantsService)
        {
            this.participantsService = participantsService;
        }

        public async Task Handle(CreateParticipantComand request, CancellationToken cancellationToken)
        {
            await participantsService.CreateParticipantAsync(
                request.FirstName,
                request.LastName,
                request.BirthDate,
                request.Email);
        }
    }
}
