using AutoMapper;
using Events.Application.Contracts.Events;
using Events.Application.Contracts.Images;
using Events.Application.Contracts.Participants;
using Events.Core.Models;

namespace Events.Application.Mappings
{
    public class ApplicationMappings : Profile
    {
        public ApplicationMappings()
        {
            CreateMap<Event, GetEventResponse>();
            CreateMap<Image, GetImageResponse>();
            CreateMap<Participant, GetParticipantResponse>();
        }
    }
}
