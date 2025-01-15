using AutoMapper;
using Events.Application.DTOs;
using Events.Application.Interfaces.Services;
using Events.Core.Models;
using Events.DataAccess.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;

namespace Events.Application.Services
{
    public class EventsService : IEventsService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IImageService imageService;

        public EventsService(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IImageService imageService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.imageService = imageService;
        }

        public async Task<Guid> CreateEventAsync(
            string name,
            string description,
            string place,
            string category,
            int maxParticipantCount,
            DateTime date,
            IFormFile imageFile)
        {
            var eventId = Guid.NewGuid();

            var image = await imageService.CreateImage(imageFile, eventId);

            var @event = Event.Create(
                eventId,
                name,
                description,
                place,
                date,
                category,
                maxParticipantCount,
                image);

            var id = await unitOfWork.Events.Create(@event);
            await unitOfWork.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> DeleteEventAsync(Guid eventId)
        {
            var id = await unitOfWork.Events.Delete(eventId);
            await unitOfWork.SaveChangesAsync();

            return id;
        }

        public async Task<EventDto?> GetEventByIdAsync(Guid id)
        {
            var @event = await unitOfWork.Events.GetById(id);

            return mapper.Map<EventDto?>(@event);
        }

        public async Task<EventsPageDto> GetEventsAsync(
            string? searchName,
            string? searchPlace,
            string? searchCategory,
            string? sortItem,
            string? sortOrder,
            int page = 1,
            int pageSize = 10)
        {
            var eventsPage = await unitOfWork.Events.Get(
                searchName,
                searchPlace,
                searchCategory,
                sortItem,
                sortOrder,
                page,
                pageSize);

            return mapper.Map<EventsPageDto>(eventsPage);
        }

        public async Task<Guid> UpdateEventAync(
            Guid id,
            string name,
            string description,
            string palce,
            string category,
            int maxParticipantCount,
            DateTime date)
        {
            var resultId = await unitOfWork.Events.Update(
                id,
                name,
                description,
                palce,
                category,
                maxParticipantCount,
                date);

            await unitOfWork.SaveChangesAsync();

            return resultId;
        }

        public async Task<List<ParticipantDto>> GetEventParticipantsAsync(Guid eventId)
        {
            var participants = await unitOfWork.Events.GetParticipants(eventId);

            return mapper.Map<List<ParticipantDto>>(participants);
        }
    }
}
