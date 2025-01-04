namespace Events.Core.Models
{
    public class Registration
    {
        private Registration(Guid id, Guid eventId, Guid participantId)
        {
            Id = id;
            EventId = eventId;
            ParticipantId = participantId;
            RegistrationDate = DateTime.Now;
        }

        public Guid Id { get; }
        
        public Guid EventId { get; }

        public Guid ParticipantId { get; }

        public DateTime RegistrationDate { get; }

        public static Registration Create (Guid id, Guid eventId, Guid participantId)
        {
            return new Registration(id, eventId, participantId);
        }
    }
}
