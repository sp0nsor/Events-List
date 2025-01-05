using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Events.DataAccess.Repositories;


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

            services.AddScoped<IEventsRepository, EventsRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IParticipantsRepository, ParticipantsRepository>();
            services.AddScoped<IRegistrationsRepository, RegistrationsRepository>();

            return services;
        }
    }
}
