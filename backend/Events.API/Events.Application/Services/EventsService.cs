using Events.Core.Models;
using Events.Application.Interfaces;
using Events.DataAccess.Interfaces;
using Azure.Core;
using Events.Application.Contracts.Events;
using AutoMapper;
using Events.Application.Contracts.Participants;

namespace Events.Application.Services
{
    public class EventsService : IEventsService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IImageService imageService;
        private readonly IMapper mapper;

        public EventsService(
            IUnitOfWork unitOfWork,
            IImageService imageService,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.imageService = imageService;
            this.mapper = mapper;
        }

        public async Task CreateEvent(CreateEventRequest request)
        {
            var eventId = Guid.NewGuid();

            var image = await imageService.CreateImage(request.Image, eventId);

            var @event = Event.Create(
                eventId,
                request.Name,
                request.Description,
                request.Place,
                request.Time,
                request.Category,
                request.MaxParticipantCount,
                image);

            await unitOfWork.Events.Create(@event);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<GetEventResponse>> GetEvents(GetEventRequest request)
        {
            var events = await unitOfWork.Events.Get(request.SearchName, request.SearchPlace,
                request.SearchCategory, request.SortItem, request.SortOrder);

            return mapper.Map<List<GetEventResponse>>(events);
        }

        public async Task<List<GetParticipantResponse>> GetEventParticipants(Guid id)
        {
            var participants = await unitOfWork.Events.GetParticipants(id);

            return mapper.Map<List<GetParticipantResponse>>(participants);
        }

        public async Task<GetEventResponse> GetEventById(Guid id)
        {
            var @event = await unitOfWork.Events.GetById(id);

            return mapper.Map<GetEventResponse>(@event);
        }

        public async Task UpdateEvent(Guid id, UpdateEventRequest request)
        {
            await unitOfWork.Events.Update(id, request.Name, request.Description,
                request.Place, request.Category, request.MaxParticipantCount, request.Time);
        }

        public async Task DeleteEvent(Guid id)
        {
            await unitOfWork.Events.Delete(id);
        }
    }
}
