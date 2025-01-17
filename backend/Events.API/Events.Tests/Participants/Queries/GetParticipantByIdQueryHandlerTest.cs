using Events.Application.DTOs;
using Events.Application.Interfaces.Services;
using Events.Application.Queries.Participants.GetParticipantById;
using Moq;

namespace Events.Tests.Participants.Queries
{
    public class GetParticipantByIdQueryHandlerTest
    {
        [Fact]
        public async Task Handle_ShouldReturnParticipant_WhenParticipantExists()
        {
            // Arrange
            var mockParticipantsService = new Mock<IParticipantsService>();
            var expectedParticipant = new ParticipantDto
            (
                Guid.NewGuid(),
                "FirstName",
                "LastName",
                "email.email@email.com",
                new DateTime(1990, 1, 1)
            );

            mockParticipantsService
                .Setup(service => service.GetParticipantByIdAsync(expectedParticipant.Id, CancellationToken.None))
                .ReturnsAsync(expectedParticipant);

            var handler = new GetParticipantByIdQueryHandler(mockParticipantsService.Object);

            var command = new GetParticipantByIdQuery
            (
                expectedParticipant.Id
            );

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedParticipant.Id, result.Id);
            Assert.Equal(expectedParticipant.FirstName, result.FirstName);
            Assert.Equal(expectedParticipant.LastName, result.LastName);
            Assert.Equal(expectedParticipant.Email, result.Email);
            Assert.Equal(expectedParticipant.BirthDate, result.BirthDate);

            mockParticipantsService.Verify(service => service
            .GetParticipantByIdAsync(expectedParticipant.Id, CancellationToken.None), Times.Once);
        }

    }
}
