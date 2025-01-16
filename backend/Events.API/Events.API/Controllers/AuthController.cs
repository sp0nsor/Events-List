using Events.Application.Commands.Users.LoginUser;
using Events.Application.Commands.Users.RegisterUser;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Events.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IValidator<RegisterUserCommand> registerValidator;

        public AuthController(
            IMediator mediator,
            IValidator<RegisterUserCommand> registerValidator)
        {
            this.mediator = mediator;
            this.registerValidator = registerValidator;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterUserCommand command)
        {
            var validationResult = await registerValidator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await mediator.Send(command);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginUser(
            [FromBody] LoginUserCommand command)
        {
            var token = await mediator.Send(command);

            HttpContext.Response.Cookies.Append("tasty-cookies", token);

            return Ok(token);
        }
    }
}
