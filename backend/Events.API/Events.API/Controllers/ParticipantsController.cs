using Events.Application.Interfaces;
using Events.Application.Contracts.Participants;
using Microsoft.AspNetCore.Mvc;

namespace Events.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParticipantsController : ControllerBase
    {
        private readonly IParticipantService participantService;

        public ParticipantsController(IParticipantService participantService)
        {
            this.participantService = participantService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateParticipant([FromBody] CreateParticipantRequest request)
        {
            await participantService.CreateParticipant(request);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetParticipants()
        {
            var response = await participantService.GetPartcipants();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetParticipantById([FromRoute] Guid id)
        {
            var response = await participantService.GetPartcipantById(id);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteParticipant([FromRoute] Guid id)
        {
            await participantService.DeleteParticipant(id);

            return Ok();
        }
    }
}
