using Events.Application.Contracts.Events;
using Events.Application.Contracts.Participants;
using Events.Application.Interfaces.Services;
using Events.Application.Interfaces.UseCases.Events;

namespace Events.Application.Services
{
    public class EventsService : IEventsService
    {
        private readonly ICreateEventUseCase createEventUseCase;
        private readonly IGetEventsUseCase getEventsUseCase;
        private readonly IGetEventParticipantsUseCase getEventParticipantsUseCase;
        private readonly IGetEventByIdUseCase getEventByIdUseCase;
        private readonly IUpdateEventUseCase updateEventUseCase;
        private readonly IDeleteEventUseCase deleteEventUseCase;

        public EventsService(
            ICreateEventUseCase createEventUseCase,
            IGetEventsUseCase getEventsUseCase,
            IGetEventParticipantsUseCase getEventParticipantsUseCase,
            IGetEventByIdUseCase getEventByIdUseCase,
            IUpdateEventUseCase updateEventUseCase,
            IDeleteEventUseCase deleteEventUseCase)
        {
            this.createEventUseCase = createEventUseCase;
            this.getEventsUseCase = getEventsUseCase;
            this.getEventParticipantsUseCase = getEventParticipantsUseCase;
            this.getEventByIdUseCase = getEventByIdUseCase;
            this.updateEventUseCase = updateEventUseCase;
            this.deleteEventUseCase = deleteEventUseCase;
        }

        public async Task CreateEvent(CreateEventRequest request)
        {
            await createEventUseCase.Execute(request);
        }

        public async Task<EventsPageResponse> GetEvents(GetEventRequest request)
        {
            return await getEventsUseCase.Execute(request);
        }

        public async Task<List<GetParticipantResponse>> GetEventParticipants(Guid id)
        {
            return await getEventParticipantsUseCase.Execute(id);
        }

        public async Task<GetEventResponse> GetEventById(Guid id)
        {
            return await getEventByIdUseCase.Execute(id);
        }

        public async Task UpdateEvent(Guid id, UpdateEventRequest request)
        {
            await updateEventUseCase.Execute(id, request);
        }

        public async Task DeleteEvent(Guid id)
        {
            await deleteEventUseCase.Execute(id);
        }
    }
}
