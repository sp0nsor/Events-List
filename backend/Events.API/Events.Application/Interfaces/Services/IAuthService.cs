namespace Events.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string email, string password);
        Task RegisterAsync(string userName, string email, string password);
    }
}