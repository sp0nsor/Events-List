using Events.API.Infrastructure;
using Events.API.Validators;
using Events.Application.Comands.Events.CreateEvent;
using Events.Application.Comands.Participants.CreateParticipant;
using Events.Application.Comands.Registrations.CreateRegistration;
using FluentValidation;

namespace Events.API
{
    public static class ApiExtansions
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddExceptionHandler<GlobalExceptionHandler>();

            services.AddScoped<IValidator<CreateEventCommand>, CreateEventValidator>();
            services.AddScoped<IValidator<CreateParticipantCommand>, CreateParticipantValidator>();
            services.AddScoped<IValidator<CreateRegistrationCommand>, CreateRegistrationValidator>();

            return services;
        }
    }
}
