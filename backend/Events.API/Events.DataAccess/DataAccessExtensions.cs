using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;


namespace Events.DataAccess
{
    public static class DataAccessExtensions
    {
        public static IServiceCollection AddDataAccess(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<EventsDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(nameof(EventsDbContext)));
            });

            return services;
        }
    }
}
