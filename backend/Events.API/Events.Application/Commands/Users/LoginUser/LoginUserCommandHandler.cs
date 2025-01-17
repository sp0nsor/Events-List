using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Commands.Users.LoginUser
{
    public class LoginUserCommandHandler
        : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IAuthService authService;

        public LoginUserCommandHandler(
            IAuthService authService)
        {
            this.authService = authService;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return await authService.LoginAsync(
                request.Email,
                request.Password);
        }
    }
}
