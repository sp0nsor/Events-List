using Events.Core.Models;
using Events.DataAccess.Entities;
using Events.DataAccess.Repositories;
using Events.Tests.Common;
using Moq;

namespace Events.Tests.Participants.Repository
{
    public class GetParticipantsTest : RepositoryTestBase
    {
        [Fact]
        public async Task Get_ShouldReturnPagedListOfParticipants()
        {
            // Arrange
            var participantsEntities = new List<ParticipantEntity>
            {
                new ParticipantEntity
                {
                    Id = Guid.NewGuid(),
                    FirstName = "TestFirstName1",
                    LastName = "TestLastName1",
                    BirthDate = new DateTime(1990, 1, 1),
                    Email = "test1@mail.com"
                },
                new ParticipantEntity
                {
                    Id = Guid.NewGuid(),
                    FirstName = "TestFirstName2",
                    LastName = "TestLastName2",
                    BirthDate = new DateTime(1992, 2, 2),
                    Email = "test2@mail.com"
                }
            };

            var participants = new List<Participant>
            {
                Participant.Create(
                    participantsEntities[0].Id,
                    "TestFirstName1",
                    "TestLastName1",
                    new DateTime(1990, 1, 1),
                    "test1@mail.com"),
                Participant.Create(
                    participantsEntities[1].Id,
                    "TestFirstName2",
                    "TestLastName2",
                    new DateTime(1992, 2, 2),
                    "test2@mail.com")
            };

            MapperMock.Setup(m => m.Map<List<Participant>>(It.IsAny<List<ParticipantEntity>>()))
                .Returns(participants);

            await using var context = CreateContext();
            await context.Participants.AddRangeAsync(participantsEntities);
            await context.SaveChangesAsync();

            var repository = new ParticipantsRepository(context, MapperMock.Object);

            int page = 1;
            int pageSize = 2;

            // Act
            var result = await repository.Get(page, pageSize);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.TotalCount);
            Assert.Equal(1, result.CurrentPage);
            Assert.Equal(pageSize, result.PageSize);
            Assert.Equal(1, result.TotalPages);
            Assert.Equal(2, result.Items.Count);
            Assert.Equal("TestFirstName1", result.Items[0].FirstName);
            Assert.Equal("TestFirstName2", result.Items[1].FirstName);
        }
    }
}
