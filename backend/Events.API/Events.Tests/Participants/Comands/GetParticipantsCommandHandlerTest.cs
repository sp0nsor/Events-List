using Events.Application.Comands.Participants.GetParticipants;
using Events.Application.DTOs;
using Events.Application.Interfaces.Services;
using Moq;

namespace Events.Tests.Participants.Comands
{
    public class GetParticipantsCommandHandlerTest
    {
/*        [Fact]
        public async Task Handle_ShouldReturnListOfParticipants_WhenParticipantsExist()
        {
            // Arrange
            var mockParticipantsService = new Mock<IParticipantsService>();

            var expectedParticipants = new List<ParticipantDto>
            {
                new ParticipantDto
                (
                    Guid.NewGuid(),
                    "TestFirstName1",
                    "TestLastName1",
                    "test1@mail.com",
                    new DateTime(1990, 1, 1)
                ),
                new ParticipantDto
                (
                    Guid.NewGuid(),
                    "TestFirstName2",
                    "TestLastName2",
                    "test2@mail.com",
                    new DateTime(1992, 2, 2)
                )
            };

            mockParticipantsService
                .Setup(service => service.GetParticipantsAsync())
                .ReturnsAsync(expectedParticipants);

            var handler = new GetParticipantsCommandHandler(mockParticipantsService.Object);

            var command = new GetParticipantsCommand();

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedParticipants.Count, result.Count);
            Assert.Equal(expectedParticipants, result);

            mockParticipantsService.Verify(service => service.GetParticipantsAsync(), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldReturnEmptyList_WhenNoParticipantsExist()
        {
            // Arrange
            var mockParticipantsService = new Mock<IParticipantsService>();

            mockParticipantsService
                .Setup(service => service.GetParticipantsAsync())
                .ReturnsAsync(new List<ParticipantDto>());

            var handler = new GetParticipantsCommandHandler(mockParticipantsService.Object);

            var command = new GetParticipantsCommand();

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);

            mockParticipantsService.Verify(service => service.GetParticipantsAsync(), Times.Once);
        }*/
    }
}
