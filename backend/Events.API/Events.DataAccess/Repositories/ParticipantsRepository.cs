using AutoMapper;
using Events.Core.Models;
using Events.DataAccess.Entities;
using Events.DataAccess.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Events.DataAccess.Repositories
{
    public class ParticipantsRepository : IParticipantsRepository
    {
        private readonly EventsDbContext context;
        private readonly IMapper mapper;

        public ParticipantsRepository(EventsDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Guid> Create(Participant participant)
        {
            var participantEntity = mapper.Map<ParticipantEntity>(participant);
            await context.Participants.AddAsync(participantEntity);

            return participantEntity.Id;
        }

        public async Task<PagedList<Participant>> Get(int page, int pageSize)
        {
            var participantQuery = context.Participants.AsNoTracking();

            var totalCount = await participantQuery.CountAsync();

            var participantEntities = await participantQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var participants = mapper.Map<List<Participant>>(participantEntities);

            return PagedList<Participant>.Create(
                participants,
                totalCount,
                page,
                pageSize,
                (int)Math.Ceiling((double)totalCount / pageSize));
        }

        public async Task<Participant> GetById(Guid id)
        {
            var participantEntity = await context.Participants
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id) ?? throw new Exception("Participant not found");

            return mapper.Map<Participant>(participantEntity);
        }

        public async Task<Guid> Delete(Guid id)
        {
            var participant = await context.Participants
                .FirstOrDefaultAsync(p => p.Id == id);

            if (participant == null)
            {
                throw new InvalidOperationException($"Participant with Id {id} not found.");
            }

            context.Participants.Remove(participant);

            return id;
        }
    }
}
