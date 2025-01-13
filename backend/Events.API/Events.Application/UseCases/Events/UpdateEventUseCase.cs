using Events.Application.Contracts.Events;
using Events.Application.Interfaces.UseCases.Events;
using Events.DataAccess.Interfaces.Repositories;

namespace Events.Application.UseCases.Events
{
    public class UpdateEventUseCase : IUpdateEventUseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateEventUseCase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Execute(Guid id, UpdateEventRequest request)
        {
            await unitOfWork.Events.Update(
                id,
                request.Name,
                request.Description,
                request.Place,
                request.Category,
                request.MaxParticipantCount,
                request.Time);

            await unitOfWork.SaveChangesAsync();
        }
    }
}
