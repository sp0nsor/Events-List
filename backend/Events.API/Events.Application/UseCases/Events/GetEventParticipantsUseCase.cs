using AutoMapper;
using Events.Application.Contracts.Participants;
using Events.Application.Interfaces.UseCases.Events;
using Events.DataAccess.Interfaces;

namespace Events.Application.UseCases.Events
{
    public class GetEventParticipantsUseCase : IGetEventParticipantsUseCase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetEventParticipantsUseCase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<GetParticipantResponse>> Execute(Guid id)
        {
            var participants = await unitOfWork.Events.GetParticipants(id);

            return mapper.Map<List<GetParticipantResponse>>(participants);
        }
    }
}
