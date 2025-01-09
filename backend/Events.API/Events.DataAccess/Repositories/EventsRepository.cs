using AutoMapper;
using Events.Core.Models;
using Events.DataAccess.Interfaces;
using Events.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task Create(Event @event)
        {
            var eventEnity =  mapper.Map<EventEntity>(@event);
            await context.Events.AddAsync(eventEnity);
        }

        public async Task<List<Event>> Get(string? searchName, string? searchPlace,
            string? searchCategory, string? sortItem, string? sortOrder)
        {
            var eventsQuery = context.Events
                .Include(e => e.Image)
                .AsNoTracking()
                .Where(e =>
                    (string.IsNullOrWhiteSpace(searchName) || e.Name.ToLower().Contains(searchName.ToLower())) ||
                    (string.IsNullOrWhiteSpace(searchPlace) || e.Place.ToLower().Contains(searchPlace.ToLower())) ||
                    (string.IsNullOrWhiteSpace(searchCategory) || e.Category.ToLower().Contains(searchCategory.ToLower()))
                );

            Expression<Func<EventEntity, object>> selectorKey = sortItem?.ToLower() switch
            {
                "date" => @event => @event.Time,
                "name" => @event => @event.Name,
                _ => @event => @event.Id
            };

            eventsQuery = sortOrder == "desc"
                ? eventsQuery.OrderByDescending(selectorKey)
                : eventsQuery.OrderBy(selectorKey);

            var eventEntities = await eventsQuery
                .Include(e => e.Image)
                .AsNoTracking()
                .ToListAsync();

            return mapper.Map<List<Event>>(eventEntities);
        }

        public async Task<List<Participant>> GetParticipants(Guid eventId)
        {
            var participantsEntities = await context.Events
                .AsNoTracking()
                .Where(e => e.Id == eventId)
                .Include(e => e.Registrations)
                    .ThenInclude(r => r.Participant)
                .SelectMany(e => e.Registrations.Select(r => r.Participant))
                .ToListAsync();

            return mapper.Map<List<Participant>>(participantsEntities);
        }

        public async Task<Event> GetById(Guid id)
        {
            var eventEntity = await context.Events
                .Include(e => e.Image)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id) ?? throw new Exception("Event not found");

            return mapper.Map<Event>(eventEntity);
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
