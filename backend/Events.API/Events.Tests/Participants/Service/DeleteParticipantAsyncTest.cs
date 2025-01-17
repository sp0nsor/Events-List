using Events.Application.Services;
using Events.DataAccess.Interfaces.Repositories;
using Moq;

namespace Events.Tests.Participants.Service
{
    public class DeleteParticipantAsyncTest
    {
        [Fact]
        public async Task ShouldDeleteParticipantAndReturnId()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var participantRepoMock = new Mock<IParticipantsRepository>();
            unitOfWorkMock.Setup(u => u.Participants).Returns(participantRepoMock.Object);

            var service = new ParticipantsService(null, unitOfWorkMock.Object);

            var participantId = Guid.NewGuid();
            participantRepoMock
                .Setup(r => r.Delete(participantId, CancellationToken.None))
                .ReturnsAsync(participantId);

            //Act
            var result = await service
                .DeleteParticipantAsync(participantId, CancellationToken.None);

            //Assert
            Assert.Equal(participantId, result);
            participantRepoMock.Verify(r => r.Delete(participantId, CancellationToken.None), Times.Once);
            unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);

        }
    }
}
