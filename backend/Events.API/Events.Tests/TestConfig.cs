using AutoMapper;
using Events.Application.Mappings;
using Events.DataAccess;
using Events.DataAccess.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Events.Tests
{
    public static class TestConfig
    {
        private static IOptions<AuthorizationOptions> _authOptions;

        public static void Initialize(IOptions<AuthorizationOptions> authOptions)
        {
            _authOptions = authOptions;
        }

        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationMappings>();
                cfg.AddProfile<DataBaseMappings>();
            });
            return config.CreateMapper();
        }

        public static EventsDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<EventsDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new EventsDbContext(options, _authOptions);
        }
    }
}
