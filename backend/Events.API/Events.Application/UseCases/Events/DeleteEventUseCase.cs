using Events.Application.Interfaces.UseCases.Events;
using Events.DataAccess.Interfaces.Repositories;

namespace Events.Application.UseCases.Events
{
    public class DeleteEventUseCase : IDeleteEventUseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteEventUseCase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Execute(Guid id)
        {
            await unitOfWork.Events.Delete(id);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
