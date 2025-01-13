using AutoMapper;
using Events.Application.Contracts.Events;
using Events.Application.Interfaces.UseCases.Events;
using Events.DataAccess.Interfaces.Repositories;

namespace Events.Application.UseCases.Events
{
    public class GetEventByIdUseCase : IGetEventByIdUseCase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetEventByIdUseCase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<GetEventResponse> Execute(Guid id)
        {
            var @event = await unitOfWork.Events.GetById(id);

            return mapper.Map<GetEventResponse>(@event);
        }
    }
}
