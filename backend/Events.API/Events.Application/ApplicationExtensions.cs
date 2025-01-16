using Events.Application.Comands.Events.CreateEvent;
using Events.Application.Comands.Participants.CreateParticipant;
using Events.Application.Comands.Registrations.CreateRegistration;
using Events.Application.Commands.Users.RegisterUser;
using Events.Application.Interfaces.Services;
using Events.Application.Mappings;
using Events.Application.Services;
using Events.Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Events.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationMappings));

            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IPermissionsService, PermissionsService>();

            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IEventsService, EventsService>();
            services.AddScoped<IParticipantsService, ParticipantsService>();
            services.AddScoped<IRegistrationsService, RegistrationsService>();

            services.AddScoped<IValidator<CreateEventCommand>, CreateEventValidator>();
            services.AddScoped<IValidator<CreateParticipantCommand>, CreateParticipantValidator>();
            services.AddScoped<IValidator<CreateRegistrationCommand>, CreateRegistrationValidator>();
            services.AddScoped<IValidator<RegisterUserCommand>, RegisterUserValidator>();

            return services;
        }

    }
}
