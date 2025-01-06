namespace Events.DataAccess.Entities
{
    public class RegistrationEntity
    {
        public Guid Id { get; set; }

        public Guid EventId { get; set; }

        public EventEntity? Event { get; set; }

        public Guid ParticipantId { get; set; }

        public ParticipantEntity? Participant { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
