using AutoMapper;
using Events.Application.Contracts.Participants;
using Events.Application.UseCases.Participants;
using Events.DataAccess;
using Events.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Events.Tests.Tests.UseCases
{
    public class ParticipantUseCasesTests
    {
        private readonly IMapper mapper;
        private readonly EventsDbContext context;

        public ParticipantUseCasesTests()
        {
            mapper = TestConfig.GetMapper();
            context = TestConfig.GetDbContext();
        }

        [Fact]
        public async Task CreateParticipantUseCase_ShouldCreateParticipant()
        {
            var unitOfWork = new UnitOfWork(context, mapper);
            var useCase = new CreateParticipantUseCase(unitOfWork);

            var request = new CreateParticipantRequest(
                "qwe",
                "qwe",
                "qwe@mail.ru",
                new DateTime(2004, 7, 29));

            await useCase.Execute(request);

            var participant = await context.Participants.FirstOrDefaultAsync();

            Assert.NotNull(participant);
            Assert.Equal(request.FirstName, participant.FirstName);
            Assert.Equal(request.LastName, participant.LastName);
        }

        [Fact]
        public async Task GetParticipantByIdUseCase_ShouldReturnCorrectParticipant()
        {
            var participantId = Guid.NewGuid();

            var participantEntity = new ParticipantEntity()
            {
                Id = participantId,
                FirstName = "qwe",
                LastName = "qwe",
                BirthDate = new DateTime(2004, 7, 29),
                Email = "qwe@mail.ru"
            };

            context.Participants.Add(participantEntity);
            await context.SaveChangesAsync();

            var unitOfWork = new UnitOfWork(context, mapper);

            var useCase = new GetParticipantByIdUseCase(mapper, unitOfWork);

            var result = await useCase.Execute(participantId);

            Assert.NotNull(result);
            Assert.Equal(participantEntity.FirstName, result.FirstName);
            Assert.Equal(participantEntity.LastName, result.LastName);
        }

        [Fact]
        public async Task GetParticipantsUseCase_ShouldReturnCorrectParticipantCount()
        {
            var participantEntity = new ParticipantEntity()
            {
                Id = Guid.NewGuid(),
                FirstName = "qwe",
                LastName = "qwe",
                BirthDate = new DateTime(2004, 7, 29),
                Email = "qwe@mail.ru"
            };

            context.Participants.Add(participantEntity);
            await context.SaveChangesAsync();

            var unitOfWork = new UnitOfWork(context, mapper);

            var useCase = new GetParticipantsUseCase(unitOfWork, mapper);

            var result = await useCase.Execute();

            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task DeleteParticipantUseCase_ShouldRemoveParticipant()
        {
            var participantEntity = new ParticipantEntity()
            {
                Id = Guid.NewGuid(),
                FirstName = "qwe",
                LastName = "qwe",
                BirthDate = new DateTime(2004, 7, 29),
                Email = "qwe@mail.ru"
            };

            context.Participants.Add(participantEntity);
            await context.SaveChangesAsync();

            var unitOfWork = new UnitOfWork(context, mapper);

            var useCase = new DeleteParticipantUseCase(unitOfWork);
            await useCase.Execute(participantEntity.Id);

            var deletedParticipant = await context.Participants
                .FirstOrDefaultAsync(p => p.Id == participantEntity.Id);

            Assert.Null(deletedParticipant);
        }
    }
}
