using AutoMapper;
using Events.Application.Contracts.Participants;
using Events.Application.Interfaces.UseCases.Participants;
using Events.DataAccess.Interfaces.Repositories;

namespace Events.Application.UseCases.Participants
{
    public class GetParticipantsUseCase : IGetParticipantsUseCase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetParticipantsUseCase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<GetParticipantResponse>> Execute()
        {
            var participants = await unitOfWork.Participants.Get();
            return mapper.Map<List<GetParticipantResponse>>(participants);
        }
    }
}
