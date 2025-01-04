using Events.Core.Models;
using Events.DataAccess.Repositories;

namespace Events.Application.Services
{
    public class EventsService : IEventsService
    {
        private readonly IEventsRepository eventsRepository;

        public EventsService(IEventsRepository eventsRepository)
        {
            this.eventsRepository = eventsRepository;
        }

        public async Task Create(Event @event)
        {
            await eventsRepository.Create(@event);
        }

        public async Task<List<Event>> GetEvents()
        {
            return await eventsRepository.Get();
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
