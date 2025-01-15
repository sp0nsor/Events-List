﻿using Events.Application.Comands.Participants.GetParticipantById;
using Events.Application.DTOs;
using Events.Application.Interfaces.Services;
using Moq;

namespace Events.Tests.Participants.Comands
{
    public class GetParticipantByIdCommandHandlerTest
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
                .Setup(service => service.GetParticipantByIdAsync(expectedParticipant.Id))
                .ReturnsAsync(expectedParticipant);

            var handler = new GetParticipantByIdCommandHandler(mockParticipantsService.Object);

            var command = new GetParticipantByIdCommand
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
            .GetParticipantByIdAsync(expectedParticipant.Id), Times.Once);
        }

    }
}