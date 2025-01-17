using Microsoft.AspNetCore.Mvc;
using MediatR;
using Events.Application.Comands.Participants.CreateParticipant;
using Events.Application.Comands.Participants.DeleteParticipant;
using Microsoft.AspNetCore.Authorization;
using Events.Core.Enums;
using FluentValidation;
using Events.Application.Queries.Participants.GetParticipants;
using Events.Application.Queries.Participants.GetParticipantById;

namespace Events.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParticipantsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IValidator<CreateParticipantCommand> createValidator;

        public ParticipantsController(
            IMediator mediator,
            IValidator<CreateParticipantCommand> createValidator)
        {
            this.mediator = mediator;
            this.createValidator = createValidator;
        }

        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult> CreateParticipant([FromBody] CreateParticipantCommand command)
        {
            var validationResult = await createValidator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        [Authorize(Policy = "UserPolicy")]
        public async Task<ActionResult> GetParticipants([FromQuery] GetParticipantsQuery query)
        {
            var response = await mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("id")]
        [Authorize(Policy = "UserPolicy")]
        public async Task<ActionResult> GetParticipantById([FromQuery] GetParticipantByIdQuery query)
        {
            var response = await mediator.Send(query);

            return Ok(response);
        }

        [HttpDelete]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult> DeleteParticipant([FromQuery] DeleteParticipantCommand command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }
    }
}
