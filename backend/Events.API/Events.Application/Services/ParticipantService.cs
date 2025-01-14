using AutoMapper;
using Events.Application.DTOs;
using Events.Application.Interfaces.Services;
using Events.Core.Models;
using Events.DataAccess.Interfaces.Repositories;

namespace Events.Application.Services
{
    public class ParticipantService : IParticipantsService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ParticipantService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task CreateParticipantAsync(
            string firstName,
            string lastName,
            DateTime birthDate,
            string email)
        {
            var participant = Participant.Create(
                Guid.NewGuid(),
                firstName,
                lastName,
                birthDate,
                email);

            await unitOfWork.Participants.Create(participant);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteParticipantAsync(Guid participantId)
        {
            await unitOfWork.Participants.Delete(participantId);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ParticipantDto>> GetParticipantsAsync()
        {
            var participants = await unitOfWork.Participants.Get();

            return mapper.Map<List<ParticipantDto>>(participants);
        }

        public async Task<ParticipantDto?> GetParticipantByIdAsync(Guid participantId)
        {
            var participant = await unitOfWork.Participants.GetById(participantId);

            return mapper.Map<ParticipantDto?>(participant);
        }
    }
}
