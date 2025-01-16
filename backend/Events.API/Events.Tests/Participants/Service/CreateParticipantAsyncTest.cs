using Events.Application.Services;
using Events.Core.Models;
using Events.DataAccess.Interfaces.Repositories;
using Moq;

namespace Events.Tests.Participants.Service
{
    public class CreateParticipantAsyncTest
    {
        [Fact]
        public async Task ShouldCreateParticipantAndReturnId()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var participantRepoMock = new Mock<IParticipantsRepository>();
            unitOfWorkMock.Setup(u => u.Participants).Returns(participantRepoMock.Object);

            var service = new ParticipantsService(null, unitOfWorkMock.Object);

            var participantId = Guid.NewGuid();
            participantRepoMock
                .Setup(r => r.Create(It.IsAny<Participant>()))
                .ReturnsAsync(participantId);

            //Act
            var result = await service.CreateParticipantAsync(
                "TestFirstName",
                "TestLastName",
                new DateTime(1999, 9, 9),
                "test@email.com");

            //Assert
            Assert.Equal(participantId, result);
            participantRepoMock.Verify(r => r.Create(It.IsAny<Participant>()), Times.Once);
            unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
        }
    }
}
