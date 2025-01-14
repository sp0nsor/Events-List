using AutoMapper;
using Events.Application.DTOs;
using Events.Core.Models;

namespace Events.Application.Mappings
{
    public class ApplicationMappings : Profile
    {
        public ApplicationMappings()
        {
            CreateMap<Image, ImageDto>();
            CreateMap<Event, EventDto>();
            CreateMap<Participant, ParticipantDto>();
            CreateMap<PagedList<Event>, EventsPageDto>(); 
        }
    }
}
