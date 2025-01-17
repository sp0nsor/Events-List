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
        public async Task ShouldReturnMappedParticipantsPage()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var participantRepoMock = new Mock<IParticipantsRepository>();

            unitOfWorkMock.Setup(u => u.Participants)
                .Returns(participantRepoMock.Object);

            var participants = new List<Participant>
            {
                Participant.Create(
                    Guid.NewGuid(),
                    "TestFirstName",
                    "TestLastName",
                    new DateTime(1990, 1, 1),
                    "test@mail.com")
            };

            var pagedParticipants = PagedList<Participant>.Create(
                participants,
                participants.Count,
                1,
                10,
                1);

            var participantDtos = new List<ParticipantDto>
            {
                new ParticipantDto(
                    participants[0].Id,
                    "TestFirstName",
                    "TestLastName",
                    "test@mail.com",
                    new DateTime(1990, 1, 1))
            };

            var pagedParticipantDtos = new PageListDto<ParticipantDto>(
                participantDtos,
                participants.Count,
                1,
                10,
                1);

            participantRepoMock
                .Setup(r => r.Get(1, 10, CancellationToken.None))
                .ReturnsAsync(pagedParticipants);

            mapperMock
                .Setup(m => m.Map<PageListDto<ParticipantDto>>(pagedParticipants))
                .Returns(pagedParticipantDtos);

            var service = new ParticipantsService(mapperMock.Object, unitOfWorkMock.Object);

            // Act
            var result = await service.GetParticipantsAsync(1, 10, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(pagedParticipantDtos.TotalCount, result.TotalCount);
            Assert.Equal(pagedParticipantDtos.CurrentPage, result.CurrentPage);
            Assert.Equal(pagedParticipantDtos.PageSize, result.PageSize);
            Assert.Single(result.Items);
            Assert.Equal(pagedParticipantDtos.Items[0].Id, result.Items[0].Id);
            Assert.Equal(pagedParticipantDtos.Items[0].FirstName, result.Items[0].FirstName);
        }
    }
}
