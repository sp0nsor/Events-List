using Events.Application.Interfaces;
using Events.API.Contracts.Participants;
using Events.Core.Models;
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
            var participant = Participant.Create(
                Guid.NewGuid(),
                request.FirstName,
                request.LastName,
                request.BirthDate,
                request.Email);

            await participantService.CreateParticipant(participant);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetParticipants()
        {
            var participants = await participantService.GetPartcipants();

            var response = participants.Select(p =>
                new GetParticipantResponse(
                    p.Id,
                    p.FirstName,
                    p.LastName,
                    p.Email,
                    p.BirthDate));

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetParticipantById([FromRoute] Guid id)
        {
            var participant = await participantService.GetPartcipantById(id);

            var response = new GetParticipantResponse(
                participant.Id,
                participant.FirstName,
                participant.LastName,
                participant.Email,
                participant.BirthDate);

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
