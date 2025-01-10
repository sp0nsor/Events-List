using Events.Application.Contracts.Events;
using Events.Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Events.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IValidator<CreateEventRequest> createEventValidator;
        private readonly IEventsService eventsService;

        public EventsController(
            IValidator<CreateEventRequest> createEventValidator,
            IEventsService eventsService)
        {
            this.createEventValidator = createEventValidator;
            this.eventsService = eventsService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateEvent([FromForm] CreateEventRequest request)
        {
            var validationResult = createEventValidator.Validate(request);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            await eventsService.CreateEvent(request);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetEvents([FromQuery] GetEventRequest request)
        {
            var response = await eventsService.GetEvents(request);

            return Ok(response);
        }

        [HttpGet("Participants")]
        public async Task<ActionResult> GetEventParticipants([FromQuery] Guid id)
        {
            var response = await eventsService.GetEventParticipants(id);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEventById([FromRoute] Guid id)
        {
            var response = await eventsService.GetEventById(id);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEvent([FromRoute] Guid id, [FromBody] UpdateEventRequest request)
        {
            await eventsService.UpdateEvent(id, request);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvent([FromRoute] Guid id)
        {
            await eventsService.DeleteEvent(id);

            return Ok();
        }
    }
}
