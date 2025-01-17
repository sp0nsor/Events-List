using AutoMapper;
using Events.Application.DTOs;
using Events.Application.Services;
using Events.Core.Models;
using Events.DataAccess.Interfaces.Repositories;
using Moq;

namespace Events.Tests.Participants.Service
{
    public class GetParticipantByIdAsyncTest
    {
        [Fact]
        public async Task ShouldReturnMappedParticipant()
        {
            //Arrange
            var mapperMock = new Mock<IMapper>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var participantRepoMock = new Mock<IParticipantsRepository>();

            unitOfWorkMock.Setup(
                u => u.Participants)
                .Returns(participantRepoMock.Object);

            var participant = Participant.Create(
                Guid.NewGuid(),
                "TestFirstName",
                "TestLastName",
                new DateTime(1999, 9, 9),
                "test@mail.com");

            var participantDto = new ParticipantDto(
                participant.Id,
                "TestFirstName",
                "TestLastName",
                "test@mail.com",
                new DateTime(1999, 9, 9));

            participantRepoMock
                .Setup(r => r.GetById(participant.Id, CancellationToken.None))
                .ReturnsAsync(participant);

            mapperMock
                .Setup(m => m.Map<ParticipantDto?>(participant))
                .Returns(participantDto);

            var service = new ParticipantsService(mapperMock.Object, unitOfWorkMock.Object);

            //Act
            var result = await service.GetParticipantByIdAsync(participant.Id, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(participantDto, result);
        }
    }
}
