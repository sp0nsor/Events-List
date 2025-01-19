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
            IFormFile imageFile,
            CancellationToken cancellationToken)
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

            var id = await unitOfWork.Events.Create(@event, cancellationToken);
            await unitOfWork.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> DeleteEventAsync(Guid eventId, CancellationToken cancellationToken)
        {
            var id = await unitOfWork.Events.Delete(eventId, cancellationToken);
            await unitOfWork.SaveChangesAsync();

            return id;
        }

        public async Task<EventDto?> GetEventByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var @event = await unitOfWork.Events.GetById(id, cancellationToken);

            return mapper.Map<EventDto?>(@event);
        }

        public async Task<PageListDto<EventDto>> GetEventsAsync(
            string? searchName,
            string? searchPlace,
            string? searchCategory,
            string? sortItem,
            string? sortOrder,
            CancellationToken cancellationToken,
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
                pageSize,
                cancellationToken);

            var eventDtos = (await Task.WhenAll(eventsPage.Items.Select(async e =>
            {
                var base64Image = await imageService.GetImageAsBase64(e.Image.FileName);

                return new EventDto(
                    e.Id,
                    e.Name,
                    e.Description,
                    e.Place,
                    e.Time,
                    e.Category,
                    e.MaxParticipantCount,
                    new ImageDto(base64Image)
                );
            }))).ToList();

            return new PageListDto<EventDto>(
                eventDtos,
                eventsPage.TotalCount,
                eventsPage.CurrentPage,
                eventsPage.PageSize,
                eventsPage.TotalPages);

        }

        public async Task<Guid> UpdateEventAync(
            Guid id,
            string name,
            string description,
            string palce,
            string category,
            int maxParticipantCount,
            DateTime date, 
            CancellationToken cancellationToken)
        {
            var resultId = await unitOfWork.Events.Update(
                id,
                name,
                description,
                palce,
                category,
                maxParticipantCount,
                date, 
                cancellationToken);

            await unitOfWork.SaveChangesAsync();

            return resultId;
        }

        public async Task<List<ParticipantDto>> GetEventParticipantsAsync(Guid eventId, CancellationToken cancellationToken)
        {
            var participants = await unitOfWork.Events.GetParticipants(eventId ,cancellationToken);

            return mapper.Map<List<ParticipantDto>>(participants);
        }
    }
}
