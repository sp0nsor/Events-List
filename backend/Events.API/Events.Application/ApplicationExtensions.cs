using Events.Application.Interfaces.Services;
using Events.Application.Interfaces.UseCases.Events;
using Events.Application.Interfaces.UseCases.Participants;
using Events.Application.Interfaces.UseCases.Registrations;
using Events.Application.Mappings;
using Events.Application.Services;
using Events.Application.UseCases.Events;
using Events.Application.UseCases.Participants;
using Events.Application.UseCases.Registrations;
using Microsoft.Extensions.DependencyInjection;

namespace Events.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationMappings));

            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IEventsService, EventsService>();
            services.AddScoped<IParticipantService, ParticipantService>();
            services.AddScoped<IRegistrationsService, RegistrationsService>();

            services.AddScoped<ICreateParticipantUseCase, CreateParticipantUseCase>();
            services.AddScoped<IGetParticipantsUseCase, GetParticipantsUseCase>();
            services.AddScoped<IGetParticipantByIdUseCase, GetParticipantByIdUseCase>();
            services.AddScoped<IDeleteParticipantUseCase, DeleteParticipantUseCase>();

            services.AddScoped<ICreateEventUseCase, CreateEventUseCase>();
            services.AddScoped<IGetEventsUseCase, GetEventsUseCase>();
            services.AddScoped<IGetEventParticipantsUseCase, GetEventParticipantsUseCase>();
            services.AddScoped<IGetEventByIdUseCase, GetEventByIdUseCase>();
            services.AddScoped<IUpdateEventUseCase, UpdateEventUseCase>();
            services.AddScoped<IDeleteEventUseCase, DeleteEventUseCase>();

            services.AddScoped<ICreateRegistrationUseCase, CreateRegistrationUseCase>();
            services.AddScoped<IDeleteRegistrationUseCase, DeleteRegistrationUseCase>();

            return services;
        }

    }
}
