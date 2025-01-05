using Events.Core.Models;
using Events.DataAccess.Repositories;

namespace Events.Application.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantsRepository participantsRepository;

        public ParticipantService(IParticipantsRepository participantsRepository)
        {
            this.participantsRepository = participantsRepository;
        }

        public async Task CreateParticipant(Participant participant)
        {
            await participantsRepository.Create(participant);
        }

        public async Task<List<Participant>> GetPartcipants()
        {
            return await participantsRepository.Get();
        }

        public async Task<Participant> GetPartcipantById(Guid id)
        {
            return await participantsRepository.GetById(id);
        }

        public async Task DeleteParticipant(Guid id)
        {
            await participantsRepository.Delete(id);
        }
    }
}
