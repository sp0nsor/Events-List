﻿using Events.Application.Interfaces.Services;
using Events.Application.Mappings;
using Events.Application.Services;
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

            return services;
        }

    }
}
