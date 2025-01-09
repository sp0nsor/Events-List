using AutoMapper;
using Events.Application.Contracts.Participants;
using Events.Application.Interfaces;
using Events.Core.Models;
using Events.DataAccess.Interfaces;

namespace Events.Application.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ParticipantService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task CreateParticipant(CreateParticipantRequest request)
        {
            var participant = Participant.Create(
                Guid.NewGuid(),
                request.FirstName,
                request.LastName,
                request.BirthDate,
                request.Email);

            await unitOfWork.Participants.Create(participant);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<GetParticipantResponse>> GetPartcipants()
        {
            var participants = await unitOfWork.Participants.Get();

            return mapper.Map<List<GetParticipantResponse>>(participants);
        }

        public async Task<GetParticipantResponse> GetPartcipantById(Guid id)
        {
            var partcipant = await unitOfWork.Participants.GetById(id);

            return mapper.Map<GetParticipantResponse>(partcipant);
        }

        public async Task DeleteParticipant(Guid id)
        {
            await unitOfWork.Participants.Delete(id);
        }
    }
}
