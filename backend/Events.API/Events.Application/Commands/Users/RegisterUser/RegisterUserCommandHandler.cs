using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Commands.Users.RegisterUser
{
    public class RegisterUserCommandHandler 
        : IRequestHandler<RegisterUserCommand>
    {
        private readonly IAuthService usersService;

        public RegisterUserCommandHandler(
            IAuthService usersService)
        {
            this.usersService = usersService;
        }

        public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            await usersService.RegisterAsync(
                request.UserName,
                request.Email,
                request.Password);
        }
    }
}
