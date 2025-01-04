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
            CreateMap<ParticipantEntity, Participant>();
            CreateMap<RegistrationEntity, Registration>();
        }
    }
}
