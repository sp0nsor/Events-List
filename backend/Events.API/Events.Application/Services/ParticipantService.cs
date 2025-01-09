using AutoMapper;
using Events.Application.Contracts.Participants;
using Events.Application.Interfaces;
using Events.Core.Models;
using Events.DataAccess.Interfaces;

namespace Events.Application.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IMapper mapper;
        private readonly IParticipantsRepository participantsRepository;

        public ParticipantService(
            IMapper mapper,
            IParticipantsRepository participantsRepository)
        {
            this.mapper = mapper;
            this.participantsRepository = participantsRepository;
        }

        public async Task CreateParticipant(CreateParticipantRequest request)
        {
            var participant = Participant.Create(
                Guid.NewGuid(),
                request.FirstName,
                request.LastName,
                request.BirthDate,
                request.Email);

            await participantsRepository.Create(participant);
        }

        public async Task<List<GetParticipantResponse>> GetPartcipants()
        {
            var participants = await participantsRepository.Get();

            return mapper.Map<List<GetParticipantResponse>>(participants);
        }

        public async Task<GetParticipantResponse> GetPartcipantById(Guid id)
        {
            var partcipant = await participantsRepository.GetById(id);

            return mapper.Map<GetParticipantResponse>(partcipant);
        }

        public async Task DeleteParticipant(Guid id)
        {
            await participantsRepository.Delete(id);
        }
    }
}
