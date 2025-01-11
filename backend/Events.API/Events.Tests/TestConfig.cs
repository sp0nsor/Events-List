using AutoMapper;
using Events.Application.Mappings;
using Events.DataAccess;
using Events.DataAccess.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Events.Tests
{
    public static class TestConfig
    {
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
            return new EventsDbContext(options);
        }
    }
}
