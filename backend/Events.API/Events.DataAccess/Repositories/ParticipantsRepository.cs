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

        public async Task Create(Participant participant)
        {
            var participantEntity = mapper.Map<ParticipantEntity>(participant);
            await context.Participants.AddAsync(participantEntity);
        }

        public async Task<List<Participant>> Get()
        {
            var participantsEntities = await context.Participants.ToListAsync();

            return mapper.Map<List<Participant>>(participantsEntities);
        }

        public async Task<Participant> GetById(Guid id)
        {
            var participantEntity = await context.Participants
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id) ?? throw new Exception("Participant not found");

            return mapper.Map<Participant>(participantEntity);
        }

        public async Task Delete(Guid id)
        {
            var participant = await context.Participants
                .FirstOrDefaultAsync(p => p.Id == id);

            if (participant == null)
            {
                throw new InvalidOperationException($"Participant with Id {id} not found.");
            }

            context.Participants.Remove(participant);
        }
    }
}
