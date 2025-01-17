using Events.Application.Comands.Participants.DeleteParticipant;
using Events.Application.Interfaces.Services;
using Moq;

namespace Events.Tests.Participants.Comands
{
    public class DeleteParticipantCommandHandlerTest
    {
        [Fact]
        public async Task Handle_ShouldReturnGuid_WhenParticipantWasDeleted()
        {
            //Arrange
            var mockParticipantsService = new Mock<IParticipantsService>();
            var exectedGuid = Guid.NewGuid();

            mockParticipantsService
                .Setup(service => service
                .DeleteParticipantAsync(exectedGuid, CancellationToken.None))
                .ReturnsAsync(exectedGuid);

            var handler = new DeleteParticipantCommandHandler(mockParticipantsService.Object);

            var command = new DeleteParticipantCommand(exectedGuid);

            //Act
            var result = await handler.Handle(
                command,
                CancellationToken.None);

            //Assert
            Assert.Equal(exectedGuid, result);

            mockParticipantsService.Verify(service => service
            .DeleteParticipantAsync(exectedGuid, CancellationToken.None), Times.Once());
        }
    }
}
