namespace Events.Application.Interfaces.UseCases.Registrations
{
    public interface IDeleteRegistrationUseCase
    {
        Task Execute(Guid id);
    }
}