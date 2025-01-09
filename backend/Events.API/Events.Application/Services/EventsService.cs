using Events.Core.Models;
using Events.Application.Interfaces;
using Events.DataAccess.Interfaces;
using Azure.Core;
using Events.Application.Contracts.Events;
using AutoMapper;

namespace Events.Application.Services
{
    public class EventsService : IEventsService
    {
        private readonly IEventsRepository eventsRepository;
        private readonly IImageService imageService;
        private readonly IMapper mapper;

        public EventsService(
            IEventsRepository eventsRepository,
            IImageService imageService,
            IMapper mapper)
        {
            this.eventsRepository = eventsRepository;
            this.imageService = imageService;
            this.mapper = mapper;
        }

        public async Task CreateEvent(CreateEventRequest request)
        {
            var image = await imageService.CreateImage(request.Image);

            var @event = Event.Create(
                image.EventId,
                request.Name,
                request.Description,
                request.Place,
                request.Time,
                request.Category,
                request.MaxParticipantCount,
                image);

            await eventsRepository.Create(@event);
        }

        public async Task<List<GetEventResponse>> GetEvents(GetEventRequest request)
        {
            var events = await eventsRepository.Get(request.SearchName, request.SearchPlace,
                request.SearchCategory, request.SortItem, request.SortOrder);

            return mapper.Map<List<GetEventResponse>>(events);
        }

        public async Task<GetEventResponse> GetEventById(Guid id)
        {
            var @event = await eventsRepository.GetById(id);

            return mapper.Map<GetEventResponse>(@event);
        }

        public async Task UpdateEvent(Guid id, UpdateEventRequest request)
        {
            await eventsRepository.Update(id, request.Name, request.Description,
                request.Place, request.Category, request.MaxParticipantCount, request.Time);
        }

        public async Task DeleteEvent(Guid id)
        {
            await eventsRepository.Delete(id);
        }
    }
}
