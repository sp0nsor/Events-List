using AutoMapper;
using Events.Core.Models;
using Events.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Events.DataAccess.Interfaces.Repositories;

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

        public async Task<Guid> Create(Event @event, CancellationToken cancellationToken = default)
        {
            var eventEntity = mapper.Map<EventEntity>(@event);
            await context.Events.AddAsync(eventEntity, cancellationToken);

            return eventEntity.Id;
        }

        public async Task<PagedList<Event>> Get(
            string? searchName,
            string? searchPlace,
            string? searchCategory,
            string? sortItem,
            string? sortOrder,
            int page,
            int pageSize,
            CancellationToken cancellationToken = default)
        {
            var eventsQuery = context.Events
                .Include(e => e.Image)
                .AsNoTracking()
                .Where(e =>
                    (string.IsNullOrWhiteSpace(searchName) || e.Name.ToLower().Contains(searchName.ToLower())) &&
                    (string.IsNullOrWhiteSpace(searchPlace) || e.Place.ToLower().Contains(searchPlace.ToLower())) &&
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

            var totalCount = await eventsQuery.CountAsync(cancellationToken);

            var eventEntities = await eventsQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var events = mapper.Map<List<Event>>(eventEntities);

            return PagedList<Event>.Create(
                events,
                totalCount,
                page,
                pageSize,
                (int)Math.Ceiling((double)totalCount / pageSize));
        }

        public async Task<List<Participant>> GetParticipants(Guid eventId, CancellationToken cancellationToken = default)
        {
            var participantsEntities = await context.Events
                .AsNoTracking()
                .Where(e => e.Id == eventId)
                .Include(e => e.Registrations)
                    .ThenInclude(r => r.Participant)
                .SelectMany(e => e.Registrations.Select(r => r.Participant))
                .ToListAsync(cancellationToken);

            return mapper.Map<List<Participant>>(participantsEntities);
        }

        public async Task<Event> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            var eventEntity = await context.Events
                .Include(e => e.Image)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

            return mapper.Map<Event>(eventEntity);
        }

        public async Task<Guid> Update(
            Guid id,
            string name,
            string description,
            string place,
            string category,
            int maxParticipantCount,
            DateTime time,
            CancellationToken cancellationToken = default)
        {
            await context.Events
                .Where(e => e.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(e => e.Name, name)
                    .SetProperty(e => e.Description, description)
                    .SetProperty(e => e.Place, place)
                    .SetProperty(e => e.Category, category)
                    .SetProperty(e => e.MaxParticipantCount, maxParticipantCount)
                    .SetProperty(e => e.Time, time),
                    cancellationToken);

            return id;
        }

        public async Task<Guid> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            await context.Events
                .Where(e => e.Id == id)
                .ExecuteDeleteAsync(cancellationToken);

            return id;
        }
    }
}
