using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Commands.Users.LoginUser
{
    public class LoginUserCommandHandler
        : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IUsersService usersService;

        public LoginUserCommandHandler(
            IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return await usersService.LoginAsync(
                request.Email,
                request.Password);
        }
    }
}
