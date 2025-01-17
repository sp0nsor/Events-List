namespace Events.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string> LoginAsync(
            string email, 
            string password,
            CancellationToken cancellationToken);
        Task RegisterAsync(
            string userName,
            string email,
            string password, 
            CancellationToken cancellationToken);
    }
}