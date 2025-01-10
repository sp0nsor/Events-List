using Events.Application.Contracts.Registrations;

namespace Events.Application.Interfaces.UseCases.Registrations
{
    public interface ICreateRegistrationUseCase
    {
        Task Execute(CreateRegistrationRequest request);
    }
}