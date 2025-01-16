using Microsoft.AspNetCore.Mvc;
using MediatR;
using Events.Application.Comands.Registrations.CreateRegistration;
using Events.Application.Comands.Registrations.DeleteRegistration;
using Microsoft.AspNetCore.Authorization;
using Azure;
using FluentValidation;

namespace Events.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IValidator<CreateRegistrationCommand> createValidator;

        public RegistrationsController(
            IMediator mediator,
            IValidator<CreateRegistrationCommand> createValidator)
        {
            this.mediator = mediator;
            this.createValidator = createValidator;
        }

        [HttpPost]
        [Authorize(Policy = "UserPolicy")]
        public async Task<ActionResult> CreateRegistration([FromBody] CreateRegistrationCommand command)
        {
            var validationResult = await createValidator.ValidateAsync(command);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete]
        [Authorize(Policy = "UserPolicy")]
        public async Task<ActionResult> DeleteRegistration([FromQuery] DeleteRegistrationCommand command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }
    }
}
