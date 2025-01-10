using Events.Application.Contracts.Participants;
using Events.Application.Interfaces.UseCases.Participants;
using Events.Core.Models;
using Events.DataAccess.Interfaces;

namespace Events.Application.UseCases.Participants
{
    public class CreateParticipantUseCase : ICreateParticipantUseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateParticipantUseCase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Execute(CreateParticipantRequest request)
        {
            var participant = Participant.Create(
                Guid.NewGuid(),
                request.FirstName,
                request.LastName,
                request.BirthDate,
                request.Email);

            await unitOfWork.Participants.Create(participant);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
