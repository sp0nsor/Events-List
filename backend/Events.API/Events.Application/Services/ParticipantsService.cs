using AutoMapper;
using Events.Application.DTOs;
using Events.Application.Interfaces.Services;
using Events.Core.Models;
using Events.DataAccess.Interfaces.Repositories;

namespace Events.Application.Services
{
    public class ParticipantsService : IParticipantsService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ParticipantsService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Guid> CreateParticipantAsync(
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

            var id = await unitOfWork.Participants.Create(participant);
            await unitOfWork.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> DeleteParticipantAsync(Guid participantId)
        {
            var id = await unitOfWork.Participants.Delete(participantId);
            await unitOfWork.SaveChangesAsync();

            return id;
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
