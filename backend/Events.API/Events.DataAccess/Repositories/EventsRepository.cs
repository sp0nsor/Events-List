using AutoMapper;
using Events.Core.Models;
using Events.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;

namespace Events.DataAccess.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        private readonly EventsDbContext context;
        private readonly IMapper mapper;

        public EventsRepository(EventsDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task Create(Event Event)
        {
            var eventEnity = new EventEntity()
            {
                Id = Event.Id,
                Name = Event.Name,
                Description = Event.Description,
                Place = Event.Place,
                Category = Event.Category,
                MaxParticipantCount = Event.MaxParticipantCount,
                Time = Event.Time,
                ImageId = Event.Image.Id
            };

            await context.Events.AddAsync(eventEnity);
            await context.SaveChangesAsync();
        }

        public async Task<List<Event>> Get()
        {
            var eventEntities = await context.Events
                .AsNoTracking()
                .ToListAsync();

            return mapper.Map<List<Event>>(eventEntities);
        }

        public async Task Update(Guid id, string name, string description,
            string place, string category, int maxParticipantCount, DateTime time)
        {
            await context.Events
                .Where(e => e.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(e => e.Name, name)
                    .SetProperty(e => e.Description, description)
                    .SetProperty(e => e.Place, place)
                    .SetProperty(e => e.Category, category)
                    .SetProperty(e => e.MaxParticipantCount, maxParticipantCount)
                    .SetProperty(e => e.Time, time));
        }

        public async Task Delete(Guid id)
        {
            await context.Events
                .Where(e => e.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
