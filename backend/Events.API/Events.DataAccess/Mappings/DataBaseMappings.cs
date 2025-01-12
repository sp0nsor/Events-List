using AutoMapper;
using Events.Core.Models;
using Events.DataAccess.Entities;

namespace Events.DataAccess.Mappings
{
    public class DataBaseMappings : Profile
    {
        public DataBaseMappings()
        {
            CreateMap<EventEntity, Event>();
            CreateMap<ImageEntity, Image>();
            CreateMap<UserEntity, User>();
            CreateMap<ParticipantEntity, Participant>();
            CreateMap<RegistrationEntity, Registration>();

            CreateMap<Image, ImageEntity>();
            CreateMap<Event, EventEntity>();
            CreateMap<Participant, ParticipantEntity>();
            CreateMap<Registration, RegistrationEntity>();
        }
    }
}
