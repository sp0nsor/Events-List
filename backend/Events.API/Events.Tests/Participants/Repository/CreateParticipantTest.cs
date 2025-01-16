using Events.Core.Models;
using Events.DataAccess.Entities;
using Events.DataAccess.Repositories;
using Events.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace Events.Tests.Participants.Repository
{
    public class CreateParticipantTest
        : RepositoryTestBase
    {
        [Fact]
        public async Task Create_ShouldAddParticipantToDatabase()
        {
            //Arrange
            var participant = Participant.Create(
                Guid.NewGuid(),
                "TestFirstName",
                "TestLastName",
                new DateTime(1999, 9, 9),
                "test@mail.com");

            var participantEntity = new ParticipantEntity
            {
                Id = participant.Id,
                FirstName = participant.FirstName,
                LastName = participant.LastName,
                BirthDate = participant.BirthDate,
                Email = participant.Email,
            };

            MapperMock.Setup(m => 
                m.Map<ParticipantEntity>(participant))
                .Returns(participantEntity);

            await using var context = CreateContext();

            var repository = new ParticipantsRepository(context, MapperMock.Object);

            //Act
            var createdId = await repository.Create(participant);
            await context.SaveChangesAsync();

            //Assert
            var addedEntity = await context.Participants
                .FirstOrDefaultAsync(p => p.Id == createdId);

            Assert.NotNull(addedEntity);
            Assert.Equal(participant.Id, addedEntity.Id);
            Assert.Equal(participant.FirstName, addedEntity.FirstName);
        }
    }
}
