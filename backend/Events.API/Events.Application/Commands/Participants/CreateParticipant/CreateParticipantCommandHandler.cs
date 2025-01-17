using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Participants.CreateParticipant
{
    public class CreateParticipantCommandHandler
        : IRequestHandler<CreateParticipantCommand, Guid>
    {
        private readonly IParticipantsService participantsService;

        public CreateParticipantCommandHandler(
            IParticipantsService participantsService)
        {
            this.participantsService = participantsService;
        }

        public async Task<Guid> Handle(CreateParticipantCommand request, CancellationToken cancellationToken)
        {
            return await participantsService.CreateParticipantAsync(
                request.FirstName,
                request.LastName,
                request.BirthDate,
                request.Email,
                CancellationToken.None);
        }
    }
}
