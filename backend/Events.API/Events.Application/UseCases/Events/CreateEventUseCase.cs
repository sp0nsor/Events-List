using Events.Application.Contracts.Events;
using Events.Application.Interfaces.Services;
using Events.Application.Interfaces.UseCases.Events;
using Events.Core.Models;
using Events.DataAccess.Interfaces.Repositories;

namespace Events.Application.UseCases.Events
{
    public class CreateEventUseCase : ICreateEventUseCase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IImageService imageService;

        public CreateEventUseCase(IUnitOfWork unitOfWork, IImageService imageService)
        {
            this.unitOfWork = unitOfWork;
            this.imageService = imageService;
        }

        public async Task Execute(CreateEventRequest request)
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
    }
}
