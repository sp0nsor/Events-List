using AutoMapper;
using Events.Application.Contracts.Participants;
using Events.Application.Interfaces.UseCases.Participants;
using Events.DataAccess.Interfaces.Repositories;

namespace Events.Application.UseCases.Participants
{
    public class GetParticipantByIdUseCase : IGetParticipantByIdUseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GetParticipantByIdUseCase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<GetParticipantResponse> Execute(Guid id)
        {
            var participant = await unitOfWork.Participants.GetById(id);

            return mapper.Map<GetParticipantResponse>(participant);
        }
    }
}
