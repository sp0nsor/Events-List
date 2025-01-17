using Events.Application.Authentication;
using Events.Application.Interfaces.Services;
using Events.Core.Models;
using Events.DataAccess.Interfaces.Repositories;

namespace Events.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPasswordHasher passwordHasher;
        private readonly IJwtProvider jwtProvider;

        public AuthService(
            IUnitOfWork unitOfWork,
            IPasswordHasher passwordHasher,
            IJwtProvider jwtProvider)
        {
            this.unitOfWork = unitOfWork;
            this.passwordHasher = passwordHasher;
            this.jwtProvider = jwtProvider;
        }

        public async Task RegisterAsync(
            string userName,
            string email,
            string password,
            CancellationToken cancellationToken)
        {
            var hashedPassword = passwordHasher.Generate(password);

            var user = User.Create(
                Guid.NewGuid(),
                userName,
                hashedPassword,
                email);

            await unitOfWork.Users.Add(user, cancellationToken);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<string> LoginAsync(
            string email,
            string password,
            CancellationToken cancellationToken)
        {
            var user = await unitOfWork.Users.GetByEmail(email, cancellationToken);

            var result = passwordHasher.Verify(password, user.PasswordHash);

            if (!result)
            {
                throw new Exception("Fail to login");
            }

            var token = jwtProvider.Generate(user);

            return token;
        }
    }
}
