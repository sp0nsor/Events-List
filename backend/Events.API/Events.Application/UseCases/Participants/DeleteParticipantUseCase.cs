using Events.Application.Interfaces.UseCases.Participants;
using Events.DataAccess.Interfaces;

namespace Events.Application.UseCases.Participants
{
    public class DeleteParticipantUseCase : IDeleteParticipantUseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteParticipantUseCase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Execute(Guid id)
        {
            await unitOfWork.Participants.Delete(id);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
