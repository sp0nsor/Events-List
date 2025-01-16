using AutoMapper;
using Events.Application.DTOs;
using Events.Application.Services;
using Events.Core.Models;
using Events.DataAccess.Interfaces.Repositories;
using Moq;

namespace Events.Tests.Participants.Service
{
    public class GetParticipantsAsyncTest
    {
        [Fact]
        public async Task ShouldReturnMappedParticipants()
        {
            //Arrange
            var mapperMock = new Mock<IMapper>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var participantRepoMock = new Mock<IParticipantsRepository>();

            unitOfWorkMock.Setup(
                u => u.Participants)
                .Returns(participantRepoMock.Object);

            var participants = new List<Participant>
            {
                Participant.Create(
                    Guid.NewGuid(),
                    "TestLastName",
                    "TestFirstName",
                    new DateTime(1990, 1, 1),
                    "test@mail.com")
            };

            var participantDtos = new List<ParticipantDto>
            {
                new ParticipantDto(
                    participants[0].Id,
                    "TestlastName",
                    "TestFirstName",
                    "tets@mail.ru",
                    new DateTime(1990, 1, 1))
            };

            participantRepoMock
                .Setup(r => r.Get())
                .ReturnsAsync(participants);

            mapperMock
                .Setup(m => m.Map<List<ParticipantDto>>(participants))
                .Returns(participantDtos);

            var service = new ParticipantsService(mapperMock.Object, unitOfWorkMock.Object);

            //Act
            var result = await service.GetParticipantsAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(participantDtos, result);
        }
    }
}
