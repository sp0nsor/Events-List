namespace Events.Application.Interfaces.Services
{
    public interface IUsersService
    {
        Task<string> LoginAsync(string email, string password);
        Task RegisterAsync(string userName, string email, string password);
    }
}