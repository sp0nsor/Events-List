using Events.Application.DTOs;
using Events.Application.Interfaces.Services;
using Events.Application.Queries.Participants.GetParticipants;
using Moq;
using Xunit;

namespace Events.Tests.Participants.Queries
{
    public class GetParticipantsQueryHandlerTest
    {
        [Fact]
        public async Task Handle_ShouldReturnPageListOfParticipants_WhenParticipantsExist()
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

            var expectedPageList = new PageListDto<ParticipantDto>(
                Items: expectedParticipants,
                TotalCount: 2,
                CurrentPage: 1,
                PageSize: 2,
                TotalPages: 1
            );

            mockParticipantsService
                .Setup(service => service.GetParticipantsAsync(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(expectedPageList);

            var handler = new GetParticipantsQueryHandler(mockParticipantsService.Object);

            var query = new GetParticipantsQuery (1, 2);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedPageList.TotalCount, result.TotalCount);
            Assert.Equal(expectedPageList.Items.Count, result.Items.Count);
            Assert.Equal(expectedPageList, result);

            mockParticipantsService.Verify(
                service => service.GetParticipantsAsync(query.Page, query.PageSize),
                Times.Once
            );
        }

        [Fact]
        public async Task Handle_ShouldReturnEmptyPageList_WhenNoParticipantsExist()
        {
            // Arrange
            var mockParticipantsService = new Mock<IParticipantsService>();

            var expectedPageList = new PageListDto<ParticipantDto>(
                Items: new List<ParticipantDto>(),
                TotalCount: 0,
                CurrentPage: 1,
                PageSize: 2,
                TotalPages: 0
            );

            mockParticipantsService
                .Setup(service => service.GetParticipantsAsync(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(expectedPageList);

            var handler = new GetParticipantsQueryHandler(mockParticipantsService.Object);

            var query = new GetParticipantsQuery(1, 2);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result.Items);
            Assert.Equal(0, result.TotalCount);

            mockParticipantsService.Verify(
                service => service.GetParticipantsAsync(query.Page, query.PageSize),
                Times.Once
            );
        }
    }
}
