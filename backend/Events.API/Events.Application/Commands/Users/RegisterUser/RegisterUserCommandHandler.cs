using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Commands.Users.RegisterUser
{
    public class RegisterUserCommandHandler 
        : IRequestHandler<RegisterUserCommand>
    {
        private readonly IUsersService usersService;

        public RegisterUserCommandHandler(
            IUsersService usersService)
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
