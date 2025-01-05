using Events.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Events.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IEventsService, EventsService>();
            services.AddScoped<IParticipantService, ParticipantService>();
            services.AddScoped<IRegistrationsService, RegistrationsService>();

            return services;
        }
    }
}
