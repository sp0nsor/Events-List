using AutoMapper;
using Events.Core.Models;
using Events.DataAccess;
using Events.DataAccess.Entities;
using Events.DataAccess.Interfaces;
using Events.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Events.Tests.Tests.Repositories
{
    public class ParticipantRepositoryTests
    {
        private readonly EventsDbContext context;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ParticipantRepositoryTests()
        {
            context = TestConfig.GetDbContext();
            mapper = TestConfig.GetMapper();

            unitOfWork = new UnitOfWork(context, mapper);
        }

        [Fact]
        public async Task Create_ShouldSaveParticipant()
        {
            var participant = Participant.Create(
                Guid.NewGuid(),
                "qwe",
                "qwe",
                new DateTime(2004, 7, 29),
                "qwe@qwe.qwe");

            await unitOfWork.Participants.Create(participant);
            await unitOfWork.SaveChangesAsync();

            var createdParticipant = await context.Participants
                .FirstOrDefaultAsync();

            Assert.NotNull(createdParticipant);
            Assert.Equal(participant.FirstName, createdParticipant.FirstName);
        }

        [Fact]
        public async Task GetById_ShouldReturnParticipantById()
        {
            var participant = Participant.Create(
                Guid.NewGuid(),
                "qwe",
                "qwe",
                new DateTime(2004, 7, 29),
                "qwe@qwe.qwe");

            await unitOfWork.Participants.Create(participant);
            await unitOfWork.SaveChangesAsync();

            var result = await unitOfWork.Participants.GetById(participant.Id);

            Assert.NotNull(result);
        }
    }
}
