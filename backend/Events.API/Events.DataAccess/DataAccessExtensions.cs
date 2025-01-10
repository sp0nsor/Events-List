using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Events.DataAccess.Repositories;
using Events.DataAccess.Interfaces;
using Events.DataAccess.Mappings;


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

            services.AddAutoMapper(typeof(DataBaseMappings));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
