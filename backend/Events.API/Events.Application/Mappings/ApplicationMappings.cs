﻿using AutoMapper;
using Events.Application.Contracts.Events;
using Events.Application.Contracts.Images;
using Events.Application.Contracts.Participants;
using Events.Application.DTOs;
using Events.Core.Models;

namespace Events.Application.Mappings
{
    public class ApplicationMappings : Profile
    {
        public ApplicationMappings()
        {
            CreateMap<Event, GetEventResponse>();
            CreateMap<Image, GetImageResponse>();
            CreateMap<PagedList<Event>, EventsPageResponse>();
            CreateMap<Participant, GetParticipantResponse>();



            CreateMap<Event, EventDto>();
            CreateMap<Image, ImageDto>();
            CreateMap<Participant, ParticipantDto>();
            CreateMap<PagedList<Event>, EventsPageDto>(); 
        }
    }
}
