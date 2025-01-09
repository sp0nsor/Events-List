using Events.Application.Interfaces;
using Events.Application.Contracts.Registrations;
using Microsoft.AspNetCore.Mvc;

namespace Events.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationsController : ControllerBase
    {
        private readonly IRegistrationsService registrationsService;

        public RegistrationsController(IRegistrationsService registrationsService)
        {
            this.registrationsService = registrationsService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateRegistration([FromBody] CreateRegistrationRequest request)
        {
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
