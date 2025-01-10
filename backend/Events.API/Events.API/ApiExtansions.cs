using Events.API.Infrastructure;
using Events.API.Validators;
using Events.Application.Contracts.Events;
using Events.Application.Contracts.Participants;
using Events.Application.Contracts.Registrations;
using FluentValidation;

namespace Events.API
{
    public static class ApiExtansions
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddExceptionHandler<GlobalExceptionHandler>();

            services.AddScoped<IValidator<CreateEventRequest>, CreateEventValidator>();
            services.AddScoped<IValidator<CreateParticipantRequest>, CreateParticipantValidator>();
            services.AddScoped<IValidator<CreateRegistrationRequest>, CreateRegistrationValidator>();

            return services;
        }
    }
}
