using Events.Core.Models;
using Events.Application.Interfaces;
using Events.DataAccess.Interfaces;

namespace Events.Application.Services
{
    public class EventsService : IEventsService
    {
        private readonly IEventsRepository eventsRepository;

        public EventsService(IEventsRepository eventsRepository)
        {
            this.eventsRepository = eventsRepository;
        }

        public async Task CreateEvent(Event @event)
        {
            await eventsRepository.Create(@event);
        }

        public async Task<List<Event>> GetEvents(string? searchName, string? searchPlace,
            string? searchCategory, string? sortItem, string? sortOrder)
        {
            return await eventsRepository.Get(searchName, searchPlace,
                searchCategory, sortItem, sortOrder);
        }

        public async Task<List<Participant>> GetEventParticipant(Guid eventId)
        {
            var participants = await eventsRepository.GetParticipants(eventId);

            return participants;
        }

        public async Task<Event> GetEventById(Guid id)
        {
            return await eventsRepository.GetById(id);
        }

        public async Task UpdateEvent(Guid id, string name, string description,
            string place, string category, int maxParticipantCount, DateTime time)
        {
            await eventsRepository.Update(id, name, description,
                place, category, maxParticipantCount, time);
        }

        public async Task DeleteEvent(Guid id)
        {
            await eventsRepository.Delete(id);
        }
    }
}
