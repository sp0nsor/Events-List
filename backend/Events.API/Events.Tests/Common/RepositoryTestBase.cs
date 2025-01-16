using AutoMapper;
using Events.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;

namespace Events.Tests.Common
{
    public abstract class RepositoryTestBase
    {
        protected readonly DbContextOptions<EventsDbContext> ContextOptions;
        protected readonly Mock<IMapper> MapperMock;
        private readonly IOptions<AuthorizationOptions> authOptions;

        protected RepositoryTestBase()
        {
            ContextOptions = new DbContextOptionsBuilder<EventsDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            MapperMock = new Mock<IMapper>();

            var authOptionsMock = new Mock<IOptions<AuthorizationOptions>>();
            authOptionsMock
                .Setup(o => o.Value)
                .Returns(new AuthorizationOptions
                {
                });

            authOptions = authOptionsMock.Object;
        }

        protected EventsDbContext CreateContext()
        {
            var context = new EventsDbContext(ContextOptions, authOptions);
            context.Database.EnsureCreated();
            return context;
        }
    }
}
