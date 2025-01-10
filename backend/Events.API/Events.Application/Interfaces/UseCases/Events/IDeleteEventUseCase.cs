namespace Events.Application.Interfaces.UseCases.Events
{
    public interface IDeleteEventUseCase
    {
        Task Execute(Guid id);
    }
}