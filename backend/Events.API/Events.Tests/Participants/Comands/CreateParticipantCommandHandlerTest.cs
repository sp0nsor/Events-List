using Events.Application.Comands.Participants.CreateParticipant;
using Events.Application.Interfaces.Services;
using Moq;

namespace Events.Tests.Participants.Comands
{
    public class CreateParticipantCommandHandlerTest 
    {
        [Fact]
        public async Task Handle_ShouldReturnGuid_WhenParticipantIsCreated()
        {
            //Arrange
            var mockParticipantsService = new Mock<IParticipantsService>();
            var expectedGuid = Guid.NewGuid();

            mockParticipantsService
                .Setup(service => service.CreateParticipantAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<DateTime>(),
                    It.IsAny<string>(),
                    CancellationToken.None))
                .ReturnsAsync(expectedGuid);

            var handler = new CreateParticipantCommandHandler(mockParticipantsService.Object);

            var command = new CreateParticipantCommand
                (
                    "FirstName",
                    "LastName",
                    "email@email.com",
                    new DateTime(1990, 1, 1)
                );

            //Act
            var result = await handler.Handle(
                command,
                CancellationToken.None);

            //Assert
            Assert.Equal(expectedGuid, result);

            mockParticipantsService.Verify(service => service.CreateParticipantAsync(
                command.FirstName,
                command.LastName,
                command.BirthDate,
                command.Email,
                CancellationToken.None), Times.Once);
        }
    }
}
