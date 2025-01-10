using Events.Application.Contracts.Participants;
using Events.Application.Interfaces.Services;
using Events.Application.Interfaces.UseCases.Participants;

namespace Events.Application.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly ICreateParticipantUseCase createParticipantUseCase;
        private readonly IGetParticipantsUseCase getParticipantsUseCase;
        private readonly IDeleteParticipantUseCase deleteParticipantUseCase;
        private readonly IGetParticipantByIdUseCase getParticipantByIdUseCase;

        public ParticipantService(
            ICreateParticipantUseCase createParticipantUseCase,
            IGetParticipantsUseCase getParticipantsUseCase,
            IGetParticipantByIdUseCase getParticipantByIdUseCase,
            IDeleteParticipantUseCase deleteParticipantUseCase)
        {
            this.getParticipantByIdUseCase = getParticipantByIdUseCase;
            this.createParticipantUseCase = createParticipantUseCase;
            this.getParticipantsUseCase = getParticipantsUseCase;
            this.deleteParticipantUseCase = deleteParticipantUseCase;
        }

        public async Task CreateParticipant(CreateParticipantRequest request)
        {
            await createParticipantUseCase.Execute(request);
        }

        public async Task<List<GetParticipantResponse>> GetPartcipants()
        {
            return await getParticipantsUseCase.Execute();
        }

        public async Task DeleteParticipant(Guid id)
        {
            await deleteParticipantUseCase.Execute(id);
        }

        public async Task<GetParticipantResponse> GetPartcipantById(Guid id)
        {
            return await getParticipantByIdUseCase.Execute(id);
        }
    }
}
