using Events.Application.Interfaces;
using Events.Application.Contracts.Registrations;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using Events.API.Validators;

namespace Events.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationsController : ControllerBase
    {
        private readonly IValidator<CreateRegistrationRequest> createRegistrationValidator;
        private readonly IRegistrationsService registrationsService;

        public RegistrationsController(
            IValidator<CreateRegistrationRequest> createRegistrationValidator,
            IRegistrationsService registrationsService)
        {
            this.createRegistrationValidator = createRegistrationValidator;
            this.registrationsService = registrationsService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateRegistration([FromBody] CreateRegistrationRequest request)
        {
            var validationResult = createRegistrationValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await registrationsService.CreateRegistration(request);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRegistration([FromRoute] Guid id)
        {
            await registrationsService.DeleteRegistration(id);

            return Ok();
        }
    }
}
