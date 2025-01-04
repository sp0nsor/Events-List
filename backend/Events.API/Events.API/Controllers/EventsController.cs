﻿using Events.API.Contracts.Events;
using Events.Application.Services;
using Events.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Events.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly string staticFilePath =
            Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles\\Images");

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
            var image = await imageService.CreateImage(request.Image, staticFilePath);

            var @event = Event.Create(
                image.EventId,
                request.Name,
                request.Description,
                request.Place,
                request.Time,
                request.Category,
                request.MaxParticipantCount,
                image);

            await eventsService.Create(@event);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetEvents()
        {
            var events = await eventsService.GetEvents();

            var response = events
                .Select(e => new GetEventResponse(
                        e.Id,
                        e.Name,
                        e.Description,
                        e.Place,
                        e.Time,
                        e.Category,
                        e.MaxParticipantCount,
                        e.Image.FileName));

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEvent([FromRoute] Guid id, [FromBody] UpdateEventRequest request)
        {
            await eventsService.UpdateEvent(id, request.Name, request.Description,
                request.Place, request.Category, request.MaxParticipantCount, request.Time);

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
