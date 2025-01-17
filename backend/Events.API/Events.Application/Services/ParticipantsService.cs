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
            string email,
            CancellationToken cancellationToken)
        {
            var participant = Participant.Create(
                Guid.NewGuid(),
                firstName,
                lastName,
                birthDate,
                email);

            var id = await unitOfWork.Participants.Create(participant, cancellationToken);
            await unitOfWork.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> DeleteParticipantAsync(Guid participantId, CancellationToken cancellationToken)
        {
            var id = await unitOfWork.Participants.Delete(participantId, cancellationToken);
            await unitOfWork.SaveChangesAsync();

            return id;
        }

        public async Task<PageListDto<ParticipantDto>> GetParticipantsAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            var participantsPage = await unitOfWork.Participants.Get(page, pageSize, cancellationToken);

            return mapper.Map<PageListDto<ParticipantDto>>(participantsPage);
        }

        public async Task<ParticipantDto?> GetParticipantByIdAsync(Guid participantId, CancellationToken cancellationToken)
        {
            var participant = await unitOfWork.Participants.GetById(participantId, cancellationToken);

            return mapper.Map<ParticipantDto?>(participant);
        }
    }
}
