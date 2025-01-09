using Events.Application.Contracts.Events;
using Events.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Events.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IImageService imageService;
        private readonly IEventsService eventsService;

        public EventsController(IImageService imageService, IEventsService eventsService)
        {
            this.imageService = imageService;
            this.eventsService = eventsService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateEvent([FromForm] CreateEventRequest request)
        {
            await eventsService.CreateEvent(request);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetEvents([FromQuery] GetEventRequest request)
        {
            var response = await eventsService.GetEvents(request);

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
