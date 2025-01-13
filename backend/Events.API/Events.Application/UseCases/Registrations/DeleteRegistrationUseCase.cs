using Events.Application.Interfaces.UseCases.Registrations;
using Events.DataAccess.Interfaces.Repositories;

namespace Events.Application.UseCases.Registrations
{
    public class DeleteRegistrationUseCase : IDeleteRegistrationUseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteRegistrationUseCase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Execute(Guid id)
        {
            await unitOfWork.Registrations.Delete(id);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
